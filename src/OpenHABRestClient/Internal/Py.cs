// Runtime for the REST classes that tools/py2cs.py generates from
// python-openhab-rest-client. Python values become V (a JSON value that also knows
// whether it is a StatusResponse); requests throw HttpError/RequestException like
// requests does, and the generated code catches them where Python does.
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;

namespace OpenHABRestClient.Internal
{
    /// <summary>A Python value: JSON (null = None) plus the StatusResponse marker.</summary>
    internal readonly struct V
    {
        public readonly JsonNode? J;
        public readonly bool Status;
        public V(JsonNode? j, bool status = false) { J = j; Status = status; }
        public static readonly V None = new V(null);
    }

    /// <summary>Requests' RequestException – status 0 if there was no HTTP answer.</summary>
    internal class RequestException : Exception
    {
        public int StatusCode { get; }
        public RequestException(string message, int status = 0) : base(message) { StatusCode = status; }
    }

    /// <summary>Requests' HTTPError (status &gt;= 400).</summary>
    internal sealed class HttpError : RequestException
    {
        public HttpError(string message, int status) : base(message, status) { }
    }

    internal static class R
    {
        // ── values ───────────────────────────────────────────────────────────
        public static JsonNode? Clone(JsonNode? n) => n?.DeepClone();

        public static V S(string s) => new V(JsonValue.Create(s));
        public static V B(bool b) => new V(JsonValue.Create(b));
        public static V I(long i) => new V(JsonValue.Create(i));
        public static V D(double d) => new V(JsonValue.Create(d));
        public static V Bool(bool b) => B(b);

        public static V Arg(string? s) => s == null ? V.None : S(s);
        public static V Arg(bool b) => B(b);
        public static V Arg(bool? b) => b.HasValue ? B(b.Value) : V.None;
        public static V Arg(int i) => I(i);
        public static V Arg(int? i) => i.HasValue ? I(i.Value) : V.None;
        public static V Arg(double d) => D(d);
        public static V Arg(double? d) => d.HasValue ? D(d.Value) : V.None;
        public static V Arg(object? o) => new V(ToNode(o));
        public static V ArgOr(object? o, V dflt) => o == null ? dflt : new V(ToNode(o));

        /// <summary>Converts a user value (JsonNode, string, number, collection, object) to JSON.</summary>
        public static JsonNode? ToNode(object? o)
        {
            switch (o)
            {
                case null: return null;
                case JsonNode n: return n.DeepClone();
                case JsonElement e: return JsonNode.Parse(e.GetRawText());
                case string s: return JsonValue.Create(s);
                case bool b: return JsonValue.Create(b);
                case int i: return JsonValue.Create(i);
                case long l: return JsonValue.Create(l);
                case double d: return JsonValue.Create(d);
                case float f: return JsonValue.Create((double)f);
                case decimal m: return JsonValue.Create(m);
                default: return JsonSerializer.SerializeToNode(o, o.GetType());
            }
        }

        public static double Dbl(JsonNode? n) => n == null ? 0 :
            double.Parse(n.ToJsonString(), NumberStyles.Float, CultureInfo.InvariantCulture);

        static bool TryNum(JsonNode? n, out double d)
        {
            d = 0;
            if (n is JsonValue v)
            {
                var k = v.GetValueKind();
                if (k == JsonValueKind.Number) { d = Dbl(v); return true; }
                if (k == JsonValueKind.True) { d = 1; return true; }
                if (k == JsonValueKind.False) { d = 0; return true; }
            }
            return false;
        }

        static JsonValueKind Kind(JsonNode? n) => n == null ? JsonValueKind.Null : n.GetValueKind();

        public static bool IsNone(V v) => v.J == null || Kind(v.J) == JsonValueKind.Null;

        public static bool Truthy(V v)
        {
            var j = v.J;
            switch (Kind(j))
            {
                case JsonValueKind.Null: case JsonValueKind.Undefined: return false;
                case JsonValueKind.True: return true;
                case JsonValueKind.False: return false;
                case JsonValueKind.Number: return Dbl(j) != 0;
                case JsonValueKind.String: return j!.GetValue<string>().Length > 0;
                case JsonValueKind.Array: return j!.AsArray().Count > 0 || v.Status;
                case JsonValueKind.Object: return j!.AsObject().Count > 0 || v.Status;
            }
            return true;
        }

        public static bool Eq(V a, V b)
        {
            if (IsNone(a) || IsNone(b)) return IsNone(a) && IsNone(b);
            if (TryNum(a.J, out var x) && TryNum(b.J, out var y)) return x == y;
            return JsonNode.DeepEquals(a.J, b.J);
        }

        public static int Cmp(V a, V b)
        {
            TryNum(a.J, out var x);
            TryNum(b.J, out var y);
            return x < y ? -1 : x > y ? 1 : 0;
        }

        static string? KeyText(JsonNode? k)
        {
            switch (Kind(k))
            {
                case JsonValueKind.String: return k!.GetValue<string>();
                case JsonValueKind.Number:
                    var d = Dbl(k);
                    return d == Math.Floor(d) ? ((long)d).ToString(CultureInfo.InvariantCulture) : null;
            }
            return null;
        }

        static string Text(V v) => Kind(v.J) == JsonValueKind.String ? v.J!.GetValue<string>() : "";

        public static bool Contains(V c, V x)
        {
            switch (Kind(c.J))
            {
                case JsonValueKind.Object:
                    var k = KeyText(x.J);
                    return k != null && c.J!.AsObject().ContainsKey(k);
                case JsonValueKind.Array:
                    foreach (var e in c.J!.AsArray())
                        if (Eq(new V(e), x)) return true;
                    return false;
                case JsonValueKind.String:
                    return Kind(x.J) == JsonValueKind.String &&
                           c.J!.GetValue<string>().Contains(x.J!.GetValue<string>());
            }
            return false;
        }

        // ── strings ──────────────────────────────────────────────────────────
        /// <summary>Python str() (top level) / repr() (nested) of a value.</summary>
        public static string PyStr(JsonNode? v, bool top = true)
        {
            switch (Kind(v))
            {
                case JsonValueKind.Null: case JsonValueKind.Undefined: return "None";
                case JsonValueKind.True: return "True";
                case JsonValueKind.False: return "False";
                case JsonValueKind.Number: return v!.ToJsonString();
                case JsonValueKind.String:
                    var s = v!.GetValue<string>();
                    return top ? s : "'" + s + "'";
                case JsonValueKind.Array:
                    return "[" + string.Join(", ", v!.AsArray().Select(e => PyStr(e, false))) + "]";
                default:
                    return "{" + string.Join(", ", v!.AsObject().Select(p => "'" + p.Key + "': " + PyStr(p.Value, false))) + "}";
            }
        }

        public static V Str(V v) => S(PyStr(v.J));
        public static V Cat(params V[] parts) => S(string.Concat(parts.Select(p => PyStr(p.J))));
        public static V Lower(V s) => S((Kind(s.J) == JsonValueKind.String ? s.J!.GetValue<string>() : PyStr(s.J)).ToLowerInvariant());
        public static V Strip(V s) => S(Text(s).Trim(' ', '\t', '\r', '\n'));
        public static V RStrip(V s, V chars) => S(Text(s).TrimEnd(Text(chars).ToCharArray()));

        public static V Split(V s, V sep)
        {
            var a = new JsonArray();
            var d = Text(sep);
            foreach (var p in d.Length == 0 ? new[] { Text(s) } : Text(s).Split(new[] { d }, StringSplitOptions.None))
                a.Add(JsonValue.Create(p));
            return new V(a);
        }

        public static V Join(V sep, V items)
        {
            if (Kind(items.J) != JsonValueKind.Array) return S("");
            return S(string.Join(Text(sep), items.J!.AsArray().Select(e => PyStr(e))));
        }

        public static V Len(V v)
        {
            switch (Kind(v.J))
            {
                case JsonValueKind.String: return I(v.J!.GetValue<string>().Length);
                case JsonValueKind.Array: return I(v.J!.AsArray().Count);
                case JsonValueKind.Object: return I(v.J!.AsObject().Count);
            }
            return I(0);
        }

        public static bool IsDict(V v) => Kind(v.J) == JsonValueKind.Object && !v.Status;
        public static bool IsList(V v) => Kind(v.J) == JsonValueKind.Array;
        public static bool IsStr(V v) => Kind(v.J) == JsonValueKind.String;
        public static bool IsBool(V v) => Kind(v.J) == JsonValueKind.True || Kind(v.J) == JsonValueKind.False;
        public static bool IsStatus(V v) => v.Status;

        // ── containers ───────────────────────────────────────────────────────
        public static V Dict() => new V(new JsonObject());

        public static V Dict(params (string Key, V Value)[] items)
        {
            var o = new JsonObject();
            foreach (var (k, v) in items) o[k] = Clone(v.J);
            return new V(o);
        }

        public static V List() => new V(new JsonArray());

        public static V List(params V[] items)
        {
            var a = new JsonArray();
            foreach (var v in items) a.Add(Clone(v.J));
            return new V(a);
        }

        public static V Copy(V m) => IsNone(m) ? Dict() : new V(Clone(m.J));

        public static V WithoutNone(V m)
        {
            var o = new JsonObject();
            if (Kind(m.J) == JsonValueKind.Object)
                foreach (var p in m.J!.AsObject())
                    if (p.Value != null && Kind(p.Value) != JsonValueKind.Null) o[p.Key] = Clone(p.Value);
            return new V(o);
        }

        public static V Get(V obj, V key)
        {
            if (Kind(obj.J) == JsonValueKind.Object)
            {
                var k = KeyText(key.J);
                if (k != null && obj.J!.AsObject().TryGetPropertyValue(k, out var x)) return new V(x);
            }
            else if (Kind(obj.J) == JsonValueKind.Array && Kind(key.J) == JsonValueKind.Number)
            {
                var a = obj.J!.AsArray();
                var i = (int)Dbl(key.J);
                if (i < 0) i += a.Count;
                if (i >= 0 && i < a.Count) return new V(a[i]);
            }
            return V.None;
        }

        public static V GetOr(V obj, V key) => GetOr(obj, key, V.None);

        public static V GetOr(V obj, V key, V dflt)
        {
            var k = KeyText(key.J);
            if (Kind(obj.J) == JsonValueKind.Object && k != null && obj.J!.AsObject().ContainsKey(k))
                return Get(obj, key);
            return dflt;
        }

        public static void Set(V obj, V key, V value)
        {
            if (Kind(obj.J) != JsonValueKind.Object) return;
            var k = KeyText(key.J);
            if (k != null) obj.J!.AsObject()[k] = Clone(value.J);
        }

        // ── encoding ─────────────────────────────────────────────────────────
        public static string Quote(string s, string safe)
        {
            var sb = new StringBuilder();
            foreach (var b in Encoding.UTF8.GetBytes(s))
            {
                char ch = (char)b;
                if ((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z') || (ch >= '0' && ch <= '9') ||
                    "_.-~".IndexOf(ch) >= 0 || (b < 128 && b != 0 && safe.IndexOf(ch) >= 0))
                    sb.Append(ch);
                else
                    sb.Append('%').Append(b.ToString("X2"));
            }
            return sb.ToString();
        }

        public static V Quote(V s, string safe) =>
            S(Quote(Kind(s.J) == JsonValueKind.String ? s.J!.GetValue<string>() : PyStr(s.J), safe));

        public static V UrlEncode(V p) => S(HttpCore.QueryString(p.J));

        public static V Dumps(V v) => S(v.J == null ? "null" : v.J.ToJsonString());

        // ── HTTP and streams ─────────────────────────────────────────────────
        public static V Http(OpenHABClient c, string verb, V path, V headers, V data, V prm)
        {
            var r = Internal.HttpCore.Request(c, verb, Text(path), headers.J, data.J, prm.J, CancellationToken.None, false)
                            .GetAwaiter().GetResult();
            return new V(r.Value, r.IsStatus);
        }

        public static async Task<V> HttpAsync(OpenHABClient c, string verb, V path, V headers, V data, V prm,
                                              CancellationToken ct)
        {
            var r = await Internal.HttpCore.Request(c, verb, Text(path), headers.J, data.J, prm.J, ct, true)
                                       .ConfigureAwait(false);
            return new V(r.Value, r.IsStatus);
        }

        public static EventStream Sse(OpenHABClient c, V path, V headers, V prm) =>
            SseAsync(c, path, headers, prm, CancellationToken.None).GetAwaiter().GetResult();

        public static async Task<EventStream> SseAsync(OpenHABClient c, V path, V headers, V prm, CancellationToken ct)
        {
            var s = await EventStream.OpenAsync(c, Text(path), headers.J, prm.J, ct).ConfigureAwait(false);
            if (s.IsError)
            {
                if (s.ErrorStatus != 0) throw new HttpError(s.Error!, s.ErrorStatus);
                throw new RequestException(s.Error!);
            }
            return s;
        }

        public static EventStream OpenStream(OpenHABClient c, V topics, V path, V headers, V errors) =>
            OpenStreamAsync(c, topics, path, headers, errors, CancellationToken.None).GetAwaiter().GetResult();

        public static async Task<EventStream> OpenStreamAsync(OpenHABClient c, V topics, V path, V headers,
                                                              V errors, CancellationToken ct)
        {
            JsonNode? prm = null;
            if (Truthy(topics)) prm = new JsonObject { ["topics"] = Clone(topics.J) };
            var p = IsStr(path) ? Text(path) : "/rest/events";
            var s = await EventStream.OpenAsync(c, p, headers.J, prm, ct).ConfigureAwait(false);
            if (!s.IsError) return s;
            var status = s.ErrorStatus;
            var key = status.ToString(CultureInfo.InvariantCulture);
            string msg;
            if (status != 0 && Kind(errors.J) == JsonValueKind.Object &&
                errors.J!.AsObject().TryGetPropertyValue(key, out var m) && Kind(m) == JsonValueKind.String)
                msg = m!.GetValue<string>();
            else if (status != 0)
                msg = "HTTP error " + key + ": " + s.Error;
            else
                msg = "Request error: " + s.Error;
            s.Dispose();
            return EventStream.Failed(msg, status);
        }

        public static EventStream AsStream(V v)
        {
            var e = OpenHABResults.ErrorMessage(v.J);
            return EventStream.Failed(e.Length == 0 ? "no event stream" : e, 0);
        }

        public static Task<EventStream> AsStreamAsync(V v) => Task.FromResult(AsStream(v));

        public static V ExcStatus(RequestException e) => I(e.StatusCode);
        public static V ExcStr(RequestException e) => S(e.Message);

        // ── public results ───────────────────────────────────────────────────
        public static JsonObject ErrorObject(RequestException e) =>
            e is HttpError
                ? new JsonObject { ["error"] = "HTTP error " + e.StatusCode.ToString(CultureInfo.InvariantCulture) + ": " + e.Message }
                : new JsonObject { ["error"] = "Request error: " + e.Message };

        public static JsonNode? Finish(Func<V> f)
        {
            try { return f().J; }
            catch (RequestException e) { return ErrorObject(e); }
        }

        public static async Task<JsonNode?> FinishAsync(Func<Task<V>> f)
        {
            try { return (await f().ConfigureAwait(false)).J; }
            catch (RequestException e) { return ErrorObject(e); }
        }

        public static EventStream FinishStream(Func<EventStream> f)
        {
            try { return f(); }
            catch (RequestException e) { return EventStream.Failed(ErrorObject(e)["error"]!.GetValue<string>(), e.StatusCode); }
        }

        public static async Task<EventStream> FinishStreamAsync(Func<Task<EventStream>> f)
        {
            try { return await f().ConfigureAwait(false); }
            catch (RequestException e) { return EventStream.Failed(ErrorObject(e)["error"]!.GetValue<string>(), e.StatusCode); }
        }
    }
}
