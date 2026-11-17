// HTTP requests – the C# counterpart of python-openhab-rest-client/openhab/Client.py.
using System;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;

namespace OpenHABRestClient.Internal
{
    internal readonly struct Reply
    {
        public readonly JsonNode? Value;
        public readonly bool IsStatus;
        public Reply(JsonNode? v, bool s) { Value = v; IsStatus = s; }
    }

    internal static class HttpCore
    {
        public static string BuildUrl(string baseUrl, string resourcePath)
        {
            if (resourcePath.StartsWith("http://", StringComparison.Ordinal) ||
                resourcePath.StartsWith("https://", StringComparison.Ordinal))
                return resourcePath;
            var p = resourcePath;
            if (p.Length == 0 || p[0] != '/') p = "/" + p;
            if (!(p == "/rest" || p.StartsWith("/rest/", StringComparison.Ordinal) ||
                  p.StartsWith("/rest?", StringComparison.Ordinal)))
                p = "/rest" + p;
            // "#" is valid inside openHAB UIDs but would start a URL fragment
            var q = p.IndexOf('?');
            var path = q < 0 ? p : p.Substring(0, q);
            var rest = q < 0 ? "" : p.Substring(q);
            return baseUrl + path.Replace("#", "%23") + rest;
        }

        static void AddParam(StringBuilder b, string key, JsonNode? v)
        {
            if (v == null) return;
            string text;
            switch (v.GetValueKind())
            {
                case JsonValueKind.True: text = "true"; break;
                case JsonValueKind.False: text = "false"; break;
                case JsonValueKind.Number: text = v.ToJsonString(); break;
                case JsonValueKind.String: text = v.GetValue<string>(); break;
                default: return;
            }
            if (b.Length > 0) b.Append('&');
            b.Append(R.Quote(key, "")).Append('=').Append(R.Quote(text, ""));
        }

        /// <summary>"a=b&amp;c=d" from a params object (None dropped, booleans lower case, lists repeated).</summary>
        public static string QueryString(JsonNode? prm)
        {
            var b = new StringBuilder();
            if (prm is JsonObject o)
                foreach (var kv in o)
                {
                    if (kv.Value is JsonArray a)
                        foreach (var e in a) AddParam(b, kv.Key, e);
                    else
                        AddParam(b, kv.Key, kv.Value);
                }
            return b.ToString();
        }

        public static string WithQuery(string url, JsonNode? prm)
        {
            var q = QueryString(prm);
            if (q.Length == 0) return url;
            return url + (url.IndexOf('?') >= 0 ? "&" : "?") + q;
        }

        public static string HttpErrorText(int status, string? reason, string url, string body)
        {
            var message = "";
            try
            {
                var j = JsonNode.Parse(body);
                if (j is JsonObject o && o.TryGetPropertyValue("error", out var e))
                {
                    if (e is JsonObject eo)
                        message = eo.TryGetPropertyValue("message", out var m) && m is JsonValue mv &&
                                  mv.GetValueKind() == JsonValueKind.String ? mv.GetValue<string>() : "";
                    else if (e != null)
                        message = R.PyStr(e);
                }
            }
            catch (JsonException)
            {
                var t = body.Trim();
                message = (t.Length > 200 ? t.Substring(0, 200) : t).Trim();
            }
            var text = status.ToString(CultureInfo.InvariantCulture) +
                       (status < 500 ? " Client Error: " : " Server Error: ") + reason + " for url: " + url;
            if (message.Length > 0) text += " (" + message + ")";
            return text;
        }

        internal static void AddHeaders(HttpRequestMessage req, JsonNode? headers, out string? contentType)
        {
            contentType = null;
            if (headers is not JsonObject h) return;
            foreach (var kv in h)
            {
                if (kv.Value is not JsonValue v || v.GetValueKind() != JsonValueKind.String) continue;
                var value = v.GetValue<string>();
                if (string.Equals(kv.Key, "Content-Type", StringComparison.OrdinalIgnoreCase))
                    contentType = value;
                else
                    req.Headers.TryAddWithoutValidation(kv.Key, value);
            }
        }

        static string ReadBody(HttpResponseMessage resp, bool async, CancellationToken ct)
        {
            var bytes = resp.Content.ReadAsByteArrayAsync().GetAwaiter().GetResult();
            return Encoding.UTF8.GetString(bytes);
        }

        public static async Task<Reply> Request(OpenHABClient c, string verb, string path, JsonNode? headers,
                                                JsonNode? data, JsonNode? prm, CancellationToken ct, bool async)
        {
            var url = WithQuery(BuildUrl(c.Url, path.Length == 0 ? "/" : path), prm);
            var method = verb switch
            {
                "get" => HttpMethod.Get,
                "post" => HttpMethod.Post,
                "put" => HttpMethod.Put,
                _ => HttpMethod.Delete,
            };
            using var req = new HttpRequestMessage(method, url);
            AddHeaders(req, headers, out var contentType);

            // body: strings as they are, everything else as JSON
            string? body = null;
            var bodyIsJson = false;
            if (data != null && data.GetValueKind() != JsonValueKind.Null)
            {
                if (data.GetValueKind() == JsonValueKind.String)
                {
                    body = data.GetValue<string>();
                    var t = body.TrimStart(' ', '\t', '\r', '\n');
                    bodyIsJson = t.Length > 0 && (t[0] == '{' || t[0] == '[');
                }
                else
                {
                    body = data.ToJsonString();
                    bodyIsJson = true;
                }
            }
            if (!string.IsNullOrEmpty(body))
            {
                var content = new ByteArrayContent(Encoding.UTF8.GetBytes(body));
                content.Headers.TryAddWithoutValidation("Content-Type",
                    contentType ?? (bodyIsJson ? "application/json" : "text/plain"));
                req.Content = content;
            }
            else if (contentType != null && method != HttpMethod.Get)
            {
                var content = new ByteArrayContent(Array.Empty<byte>());
                content.Headers.TryAddWithoutValidation("Content-Type", contentType);
                req.Content = content;
            }

            HttpResponseMessage resp;
            string text;
            try
            {
                if (async)
                {
                    resp = await c.HttpClient.SendAsync(req, HttpCompletionOption.ResponseContentRead, ct)
                                             .ConfigureAwait(false);
                    var bytes = await resp.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
                    text = Encoding.UTF8.GetString(bytes);
                }
                else
                {
#if NET5_0_OR_GREATER
                    resp = c.HttpClient.Send(req, HttpCompletionOption.ResponseContentRead, ct);
                    using var s = resp.Content.ReadAsStream(ct);
                    using var ms = new System.IO.MemoryStream();
                    s.CopyTo(ms);
                    text = Encoding.UTF8.GetString(ms.ToArray());
#else
                    resp = c.HttpClient.SendAsync(req, HttpCompletionOption.ResponseContentRead, ct)
                                       .ConfigureAwait(false).GetAwaiter().GetResult();
                    text = ReadBody(resp, false, ct);
#endif
                }
            }
            catch (OperationCanceledException) when (!ct.IsCancellationRequested)
            {
                throw new RequestException("Read timed out. (read timeout=" +
                    c.Timeout.TotalSeconds.ToString(CultureInfo.InvariantCulture) + ")");
            }
            catch (HttpRequestException e)
            {
                throw new RequestException(Describe(e));
            }

            using (resp)
            {
                var status = (int)resp.StatusCode;
                var effective = resp.RequestMessage?.RequestUri?.ToString() ?? url;
                if (status >= 400)
                    throw new HttpError(HttpErrorText(status, resp.ReasonPhrase, effective, text), status);
                if (text.Trim().Length == 0)
                {
                    var o = new JsonObject { ["status"] = status };
                    var loc = resp.Headers.Location;
                    if (loc != null) o["location"] = loc.OriginalString;
                    return new Reply(o, true);
                }
                var ct2 = resp.Content.Headers.ContentType?.MediaType ?? "";
                if (ct2.Contains("json"))
                {
                    try { return new Reply(JsonNode.Parse(text), false); }
                    catch (JsonException) { }
                }
                return new Reply(JsonValue.Create(text), false);
            }
        }

        public static string Describe(Exception e)
        {
            var msg = e.Message;
            for (var inner = e.InnerException; inner != null; inner = inner.InnerException)
                if (!string.IsNullOrEmpty(inner.Message) && !msg.Contains(inner.Message))
                    msg += " (" + inner.Message + ")";
            return msg;
        }
    }
}
