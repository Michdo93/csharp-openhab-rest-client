using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using OpenHABRestClient.Internal;

namespace OpenHABRestClient
{
    /// <summary>
    /// A Server-Sent-Events stream of openHAB – returned by the methods of <see cref="Events"/>,
    /// <see cref="ItemEvents"/>, <see cref="ThingEvents"/>, … and by <see cref="Sitemaps"/>.
    /// <code>
    /// using var stream = new ItemEvents(client).ItemStateChangedEvent("Wohnzimmer_Licht");
    /// await foreach (var e in stream.EventsAsync(cancellationToken: ct))
    ///     Console.WriteLine(e.Str("payload.value"));
    ///
    /// JsonNode? e = stream.NextEvent(TimeSpan.FromSeconds(10));   // null: nothing within 10 s
    /// </code>
    /// The events have the payload already decoded (Python: iterSSEEvents/parseSSEData).
    /// Errors are not thrown: a stream that could not be opened has <see cref="IsError"/> set.
    /// The stream is read by one consumer at a time; <see cref="Interrupt"/> and
    /// <see cref="Dispose"/> may be called from any thread.
    /// </summary>
    public sealed class EventStream : IDisposable, IAsyncDisposable, IEnumerable<JsonNode>, IAsyncEnumerable<JsonNode>
    {
        HttpResponseMessage? _response;
        Stream? _stream;
        readonly CancellationTokenSource _cts = new CancellationTokenSource();
        byte[] _in = new byte[8192];
        int _len, _pos;
        readonly byte[] _chunk = new byte[16384];
        Task<int>? _pending;
        bool _ended;
        volatile bool _interrupted;
        volatile bool _disposed;

        /// <summary>True if the stream could not be opened or broke off with an error.</summary>
        public bool IsError { get; private set; }
        /// <summary>Error message, or null.</summary>
        public string? Error { get; private set; }
        /// <summary>HTTP status of the error (0 without HTTP answer).</summary>
        public int ErrorStatus { get; private set; }
        /// <summary>The URL of the stream.</summary>
        public string Url { get; private set; } = "";

        EventStream() { }

        /// <summary>A stream that only carries an error message.</summary>
        public static EventStream Failed(string message, int status = 0)
        {
            var s = new EventStream();
            s.Fail(string.IsNullOrEmpty(message) ? "error" : message, status);
            return s;
        }

        void Fail(string msg, int status)
        {
            if (!IsError) Error = msg;
            IsError = true;
            ErrorStatus = status;
            _ended = true;
        }

        internal static async Task<EventStream> OpenAsync(OpenHABClient c, string path, JsonNode? headers,
                                                          JsonNode? prm, CancellationToken ct)
        {
            var s = new EventStream { Url = HttpCore.WithQuery(HttpCore.BuildUrl(c.Url, path), prm) };
            var req = new HttpRequestMessage(HttpMethod.Get, s.Url);
            req.Headers.TryAddWithoutValidation("Accept", "text/event-stream");
            // identity: a compressed stream would be flushed late, events would arrive delayed
            req.Headers.TryAddWithoutValidation("Accept-Encoding", "identity");
            req.Headers.TryAddWithoutValidation("Cache-Control", "no-cache");
            if (headers is JsonObject h)
                foreach (var kv in h)
                    if (kv.Value is JsonValue v && v.GetValueKind() == JsonValueKind.String)
                    {
                        req.Headers.Remove(kv.Key);
                        req.Headers.TryAddWithoutValidation(kv.Key, v.GetValue<string>());
                    }
            try
            {
                using var linked = CancellationTokenSource.CreateLinkedTokenSource(ct, s._cts.Token);
                s._response = await c.StreamClient.SendAsync(req, HttpCompletionOption.ResponseHeadersRead, linked.Token)
                                                  .ConfigureAwait(false);
                var status = (int)s._response.StatusCode;
                if (status >= 400)
                {
                    // read the error body (at most "timeout"), then report it like _raiseForStatus
                    string body;
                    using (var t = new CancellationTokenSource(c.Timeout))
                    {
                        try
                        {
#if NET5_0_OR_GREATER
                            body = await s._response.Content.ReadAsStringAsync(t.Token).ConfigureAwait(false);
#else
                            body = await s._response.Content.ReadAsStringAsync().ConfigureAwait(false);
#endif
                        }
                        catch (Exception) { body = ""; }
                    }
                    var url = s._response.RequestMessage?.RequestUri?.ToString() ?? s.Url;
                    s.Fail(HttpCore.HttpErrorText(status, s._response.ReasonPhrase, url, body), status);
                    s.Release();
                    return s;
                }
#if NET5_0_OR_GREATER
                s._stream = await s._response.Content.ReadAsStreamAsync(ct).ConfigureAwait(false);
#else
                s._stream = await s._response.Content.ReadAsStreamAsync().ConfigureAwait(false);
#endif
            }
            catch (OperationCanceledException) when (ct.IsCancellationRequested)
            {
                s.Release();
                throw;
            }
            catch (Exception e) when (e is HttpRequestException || e is OperationCanceledException || e is IOException)
            {
                s.Fail(HttpCore.Describe(e), 0);
                s.Release();
            }
            return s;
        }

        // ── lines ────────────────────────────────────────────────────────────

        bool TakeLine(out string? line)
        {
            for (var i = _pos; i < _len; i++)
            {
                if (_in[i] != (byte)'\n') continue;
                var end = i > _pos && _in[i - 1] == (byte)'\r' ? i - 1 : i;
                line = Encoding.UTF8.GetString(_in, _pos, end - _pos);
                _pos = i + 1;
                return true;
            }
            line = null;
            return false;
        }

        bool TakeRest(out string? line)
        {
            line = null;
            if (_pos >= _len) return false;
            line = Encoding.UTF8.GetString(_in, _pos, _len - _pos).TrimEnd('\r');
            _pos = _len;
            return true;
        }

        void Append(int n)
        {
            if (_pos > 0 && _pos == _len) { _pos = _len = 0; }
            if (_len + n > _in.Length)
            {
                if (_pos > 0)
                {
                    Buffer.BlockCopy(_in, _pos, _in, 0, _len - _pos);
                    _len -= _pos;
                    _pos = 0;
                }
                if (_len + n > _in.Length) Array.Resize(ref _in, Math.Max(_in.Length * 2, _len + n));
            }
            Buffer.BlockCopy(_chunk, 0, _in, _len, n);
            _len += n;
        }

        // Finishes a completed read; false if the stream has ended.
        bool Complete(Task<int> t)
        {
            _pending = null;
            if (t.Status == TaskStatus.RanToCompletion && t.Result > 0)
            {
                Append(t.Result);
                return true;
            }
            if (t.IsFaulted && !_interrupted && !_disposed)
                Fail("Stream error: " + HttpCore.Describe(t.Exception!.GetBaseException()), 0);
            _ended = true;
            return false;
        }

        Task<int>? StartRead()
        {
            if (_stream == null || _ended || _interrupted) return null;
            try
            {
                return _pending ??= _stream.ReadAsync(_chunk, 0, _chunk.Length, _cts.Token);
            }
            catch (Exception e) when (e is ObjectDisposedException || e is IOException)
            {
                _ended = true;
                return null;
            }
        }

        static long Deadline(TimeSpan? timeout) =>
            timeout == null || timeout.Value < TimeSpan.Zero ? -1
                : Clock.Now() + (long)timeout.Value.TotalMilliseconds;

        static int Left(long deadline)
        {
            if (deadline < 0) return -1;
            var l = deadline - Clock.Now();
            return l <= 0 ? 0 : (int)Math.Min(l, int.MaxValue);
        }

        /// <summary>
        /// Next line of the stream (without line break). Null if nothing arrived within
        /// <paramref name="timeout"/> (null = wait without limit), or if the stream has ended.
        /// </summary>
        public string? NextLine(TimeSpan? timeout = null)
        {
            var deadline = Deadline(timeout);
            for (;;)
            {
                if (TakeLine(out var line)) return line;
                if (_interrupted || _disposed) return null;
                var t = StartRead();
                if (t == null) return TakeRest(out line) ? line : null;
                try { if (!t.Wait(Left(deadline))) return null; }
                catch (AggregateException) { }
                if (!Complete(t)) return TakeRest(out line) ? line : null;
            }
        }

        /// <summary>Asynchronous <see cref="NextLine"/>.</summary>
        public async Task<string?> NextLineAsync(TimeSpan? timeout = null, CancellationToken cancellationToken = default)
        {
            var deadline = Deadline(timeout);
            for (;;)
            {
                if (TakeLine(out var line)) return line;
                if (_interrupted || _disposed) return null;
                cancellationToken.ThrowIfCancellationRequested();
                var t = StartRead();
                if (t == null) return TakeRest(out line) ? line : null;
                var left = Left(deadline);
                if (!t.IsCompleted)
                {
                    using var stop = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
                    var delay = Task.Delay(left, stop.Token);
                    var done = await Task.WhenAny(t, delay).ConfigureAwait(false);
                    stop.Cancel();
                    if (done != t)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        return null;
                    }
                }
                try { await t.ConfigureAwait(false); } catch (Exception) { }
                if (!Complete(t)) return TakeRest(out line) ? line : null;
            }
        }

        // ── events ───────────────────────────────────────────────────────────

        /// <summary>
        /// Decodes one <c>data:</c> line (Python: parseSSEData): the event with decoded payload,
        /// the raw object for control messages such as <c>{"type": "ALIVE"}</c>, or null for
        /// all other lines.
        /// </summary>
        public static JsonNode? ParseData(string line)
        {
            if (line == null || !line.StartsWith("data:", StringComparison.Ordinal)) return null;
            JsonNode? ev;
            try { ev = JsonNode.Parse(line.Substring(5).Trim()); }
            catch (JsonException) { return null; }
            if (ev is JsonObject o && o.TryGetPropertyValue("payload", out var p) && p is JsonValue pv &&
                pv.GetValueKind() == JsonValueKind.String)
            {
                try { o["payload"] = JsonNode.Parse(pv.GetValue<string>()); }
                catch (JsonException) { }
            }
            return ev;
        }

        static bool Wanted(JsonNode ev, bool includeAlive) =>
            includeAlive || (ev is JsonObject o && o.ContainsKey("topic"));

        /// <summary>
        /// Next event (an object with <c>topic</c>, <c>payload</c>, <c>type</c>). Null if none
        /// arrived within <paramref name="timeout"/> (null = no limit) or the stream has ended.
        /// </summary>
        public JsonNode? NextEvent(TimeSpan? timeout = null, bool includeAlive = false)
        {
            var deadline = Deadline(timeout);
            for (;;)
            {
                var left = Left(deadline);
                var line = NextLine(left < 0 ? (TimeSpan?)null : TimeSpan.FromMilliseconds(left));
                if (line == null) return null;
                var ev = ParseData(line);
                if (ev != null && Wanted(ev, includeAlive)) return ev;
            }
        }

        /// <summary>Asynchronous <see cref="NextEvent"/>.</summary>
        public async Task<JsonNode?> NextEventAsync(TimeSpan? timeout = null, bool includeAlive = false,
                                                    CancellationToken cancellationToken = default)
        {
            var deadline = Deadline(timeout);
            for (;;)
            {
                var left = Left(deadline);
                var line = await NextLineAsync(left < 0 ? (TimeSpan?)null : TimeSpan.FromMilliseconds(left),
                                               cancellationToken).ConfigureAwait(false);
                if (line == null) return null;
                var ev = ParseData(line);
                if (ev != null && Wanted(ev, includeAlive)) return ev;
            }
        }

        /// <summary>All events until the stream ends or is interrupted (Python: iterSSEEvents).</summary>
        public IEnumerable<JsonNode> Events(bool includeAlive = false)
        {
            for (JsonNode? e; (e = NextEvent(null, includeAlive)) != null;)
                yield return e;
        }

        /// <summary>All lines until the stream ends (Python: iterSSELines).</summary>
        public IEnumerable<string> Lines()
        {
            for (string? l; (l = NextLine()) != null;)
                yield return l;
        }

        /// <summary>
        /// All events for <c>await foreach</c> (Python: aiterSSEEvents). Ends with the stream,
        /// with <see cref="Interrupt"/> or when <paramref name="cancellationToken"/> is cancelled
        /// (then an OperationCanceledException is thrown).
        /// </summary>
        public async IAsyncEnumerable<JsonNode> EventsAsync(bool includeAlive = false,
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            for (;;)
            {
                var e = await NextEventAsync(null, includeAlive, cancellationToken).ConfigureAwait(false);
                if (e == null) yield break;
                yield return e;
            }
        }

        /// <summary>All lines for <c>await foreach</c>.</summary>
        public async IAsyncEnumerable<string> LinesAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            for (;;)
            {
                var l = await NextLineAsync(null, cancellationToken).ConfigureAwait(false);
                if (l == null) yield break;
                yield return l;
            }
        }

        IEnumerator<JsonNode> IEnumerable<JsonNode>.GetEnumerator() => Events().GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => Events().GetEnumerator();
        IAsyncEnumerator<JsonNode> IAsyncEnumerable<JsonNode>.GetAsyncEnumerator(CancellationToken cancellationToken) =>
            EventsAsync(false, cancellationToken).GetAsyncEnumerator(cancellationToken);

        // ── state ────────────────────────────────────────────────────────────

        /// <summary>True while events can still arrive.</summary>
        public bool IsOpen => !IsError && !_interrupted && !_disposed && (!_ended || _pos < _len);

        /// <summary><c>{"error": …}</c> like the other methods, or null if there is no error.</summary>
        public JsonObject? ErrorResult => IsError ? new JsonObject { ["error"] = Error } : null;

        /// <summary>Ends a waiting <see cref="NextEvent"/> at once (from another thread, a timer, Ctrl+C).</summary>
        public void Interrupt()
        {
            _interrupted = true;
            try { _cts.Cancel(); } catch (ObjectDisposedException) { }
        }

        void Release()
        {
            try { _stream?.Dispose(); } catch (Exception) { }
            try { _response?.Dispose(); } catch (Exception) { }
            _stream = null;
            _response = null;
        }

        /// <summary>Closes the stream (Python: response.close()).</summary>
        public void Close() => Dispose();

        /// <summary>Closes the stream.</summary>
        public void Dispose()
        {
            if (_disposed) return;
            _disposed = true;
            Interrupt();
            Release();
        }

        /// <summary>Closes the stream.</summary>
        public ValueTask DisposeAsync()
        {
            Dispose();
            return default;
        }
    }

    internal static class Clock
    {
#if NET5_0_OR_GREATER
        public static long Now() => System.Environment.TickCount64;
#else
        static readonly System.Diagnostics.Stopwatch Watch = System.Diagnostics.Stopwatch.StartNew();
        public static long Now() => Watch.ElapsedMilliseconds;
#endif
    }
}
