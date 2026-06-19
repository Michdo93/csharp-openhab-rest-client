using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace OpenHABRestClient
{
    /// <summary>
    /// Represents an active Server-Sent Events (SSE) stream from openHAB.
    ///
    /// <para>Use in a <c>await foreach</c> loop (C# 8+):</para>
    /// <code>
    /// await using var sse = itemEvents.ItemStateChangedEvent("testSwitch");
    /// await foreach (var data in sse.ReadAllAsync())
    /// {
    ///     Console.WriteLine(data);   // raw JSON after "data: "
    /// }
    /// </code>
    ///
    /// <para>Or synchronously:</para>
    /// <code>
    /// using var sse = itemEvents.ItemStateChangedEvent("testSwitch");
    /// foreach (var data in sse.ReadAll())
    ///     Console.WriteLine(data);
    /// </code>
    /// </summary>
    public sealed class SSEConnection : IDisposable, IAsyncDisposable
    {
        private readonly HttpClient _http;
        private readonly string     _url;
        private CancellationTokenSource? _cts;

        internal SSEConnection(HttpClient http, string url)
        {
            _http = http;
            _url  = url;
        }

        /// <summary>
        /// Reads SSE events synchronously. Each yielded string is the raw
        /// payload after <c>data: </c>. Blocks until cancelled or stream ends.
        /// </summary>
        public IEnumerable<string> ReadAll(CancellationToken ct = default)
        {
            _cts = CancellationTokenSource.CreateLinkedTokenSource(ct);
            var req = new HttpRequestMessage(HttpMethod.Get, _url);
            req.Headers.TryAddWithoutValidation("Accept", "text/event-stream");
            req.Headers.TryAddWithoutValidation("Cache-Control", "no-cache");

            var resp = _http.SendAsync(req, HttpCompletionOption.ResponseHeadersRead, _cts.Token)
                            .GetAwaiter().GetResult();
            resp.EnsureSuccessStatusCode();

            using var stream = resp.Content.ReadAsStreamAsync().GetAwaiter().GetResult();
            using var reader = new StreamReader(stream);

            while (!_cts.Token.IsCancellationRequested && !reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (line != null && line.StartsWith("data: "))
                    yield return line.Substring(6).Trim();
            }
        }

        /// <summary>
        /// Reads SSE events asynchronously. Use with <c>await foreach</c>.
        /// </summary>
        public async IAsyncEnumerable<string> ReadAllAsync(
            [EnumeratorCancellation] CancellationToken ct = default)
        {
            _cts = CancellationTokenSource.CreateLinkedTokenSource(ct);
            var req = new HttpRequestMessage(HttpMethod.Get, _url);
            req.Headers.TryAddWithoutValidation("Accept", "text/event-stream");
            req.Headers.TryAddWithoutValidation("Cache-Control", "no-cache");

            var resp = await _http.SendAsync(req,
                HttpCompletionOption.ResponseHeadersRead, _cts.Token);
            resp.EnsureSuccessStatusCode();

            using var stream = await resp.Content.ReadAsStreamAsync();
            using var reader = new StreamReader(stream);

            while (!_cts.IsCancellationRequested && !reader.EndOfStream)
            {
                var line = await reader.ReadLineAsync();
                if (line != null && line.StartsWith("data: "))
                    yield return line.Substring(6).Trim();
            }
        }

        /// <summary>Stops the SSE stream.</summary>
        public void Cancel() => _cts?.Cancel();

        /// <inheritdoc/>
        public void Dispose() => _cts?.Cancel();

        /// <inheritdoc/>
        public ValueTask DisposeAsync()
        {
            _cts?.Cancel();
            return default;
        }
    }
}
