using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenHABRestClient
{
    /// <summary>
    /// Core HTTP client for the openHAB REST API.
    ///
    /// Supports Basic Authentication and Bearer Token Authentication.
    /// The interface mirrors python-openhab-rest-client exactly.
    ///
    /// <code>
    /// // Basic Auth
    /// var client = new OpenHABClient("http://127.0.0.1:8080", "openhab", "habopen");
    ///
    /// // Token Auth
    /// var client = new OpenHABClient("http://127.0.0.1:8080", token: "oh.openhab.xxx");
    ///
    /// // Async
    /// var client = new AsyncOpenHABClient("http://127.0.0.1:8080", "openhab", "habopen");
    /// await client.LoginAsync();
    /// </code>
    /// </summary>
    public class OpenHABClient : IDisposable
    {
        private readonly HttpClient _http;

        /// <summary>Base URL of the openHAB server.</summary>
        public string BaseUrl { get; }

        /// <summary>Username used for Basic Authentication.</summary>
        public string? Username { get; }

        /// <summary>True if the server URL is myopenhab.org.</summary>
        public bool IsCloud { get; private set; }

        /// <summary>True after a successful connectivity check.</summary>
        public bool IsLoggedIn { get; private set; }

        // ── Constructors ────────────────────────────────────────────────────

        /// <summary>
        /// Creates an OpenHABClient with optional Basic Auth or Token Auth.
        /// Immediately performs a connectivity check (<see cref="Login"/>).
        /// </summary>
        public OpenHABClient(string url, string? username = null,
                             string? password = null, string? token = null)
        {
            BaseUrl  = url.TrimEnd('/');
            Username = username;

            var handler = new HttpClientHandler
            {
                // Accept self-signed certs (common in local openHAB)
                ServerCertificateCustomValidationCallback = (_, _, _, _) => true
            };

            _http = new HttpClient(handler)
            {
                Timeout = TimeSpan.FromSeconds(10)
            };

            if (!string.IsNullOrEmpty(token))
            {
                _http.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
            }
            else if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                var encoded = Convert.ToBase64String(
                    Encoding.UTF8.GetBytes($"{username}:{password}"));
                _http.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Basic", encoded);
            }

            Login();
        }

        // ── Login ────────────────────────────────────────────────────────────

        /// <summary>Verifies connectivity. Sets <see cref="IsLoggedIn"/> on success.</summary>
        public void Login()
        {
            IsCloud = BaseUrl.Contains("myopenhab.org");
            if (IsCloud)
            {
                // myopenhab.org does not accept Basic Auth on /rest directly.
                // Validation happens on first real API call.
                IsLoggedIn = true;
                return;
            }
            try
            {
                var resp = _http.GetAsync(BaseUrl + "/rest").GetAwaiter().GetResult();
                IsLoggedIn = resp.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"openHAB login error: {ex.Message}");
            }
        }

        // ── Internal HTTP engine ─────────────────────────────────────────────

        internal string NormalisePath(string path)
        {
            if (!path.StartsWith("/"))    path = "/" + path;
            if (!path.StartsWith("/rest")) path = "/rest" + path;
            return path;
        }

        internal string BuildUrl(string path, Dictionary<string, string?>? query)
        {
            var url = BaseUrl + NormalisePath(path);
            if (query == null || query.Count == 0) return url;

            var sb = new StringBuilder(url).Append('?');
            bool first = true;
            foreach (var kv in query)
            {
                if (kv.Value == null) continue;
                if (!first) sb.Append('&');
                sb.Append(Uri.EscapeDataString(kv.Key));
                sb.Append('=');
                sb.Append(Uri.EscapeDataString(kv.Value));
                first = false;
            }
            return sb.ToString();
        }

        internal async Task<string> ExecuteRequestAsync(
            HttpMethod method, string path,
            Dictionary<string, string>? headers = null,
            string? body = null,
            Dictionary<string, string?>? query = null)
        {
            var url = BuildUrl(path, query);
            var req = new HttpRequestMessage(method, url);

            if (headers != null)
                foreach (var h in headers)
                    req.Headers.TryAddWithoutValidation(h.Key, h.Value);

            if (body != null)
            {
                var ct = headers != null && headers.TryGetValue("Content-Type", out var c)
                    ? c : "application/json";
                req.Content = new StringContent(body, Encoding.UTF8, ct);
            }

            HttpResponseMessage resp;
            try { resp = await _http.SendAsync(req); }
            catch (Exception ex) { throw new OpenHABException($"Request failed: {ex.Message}", ex); }

            // Location header → return status JSON
            if (resp.Headers.Location != null)
                return $"{{\"status\":{(int)resp.StatusCode},\"location\":\"{resp.Headers.Location}\"}}";

            if (!resp.IsSuccessStatusCode)
            {
                var err = await resp.Content.ReadAsStringAsync();
                throw new OpenHABException($"HTTP {(int)resp.StatusCode}: {err}", (int)resp.StatusCode);
            }

            var text = await resp.Content.ReadAsStringAsync();
            return string.IsNullOrWhiteSpace(text)
                ? $"{{\"status\":{(int)resp.StatusCode}}}"
                : text;
        }

        // Sync wrappers
        internal string ExecuteRequest(HttpMethod method, string path,
            Dictionary<string, string>? headers = null, string? body = null,
            Dictionary<string, string?>? query = null)
            => ExecuteRequestAsync(method, path, headers, body, query).GetAwaiter().GetResult();

        // ── SSE ──────────────────────────────────────────────────────────────

        /// <summary>Opens a Server-Sent Events stream.</summary>
        public SSEConnection ExecuteSSE(string url) => new SSEConnection(_http, url);

        // ── Public HTTP helpers ──────────────────────────────────────────────

        /// <summary>GET request. Returns raw JSON or text string.</summary>
        public string Get(string path,
            Dictionary<string, string>? headers = null,
            Dictionary<string, string?>? query = null)
            => ExecuteRequest(HttpMethod.Get, path, headers, null, query);

        /// <summary>POST request.</summary>
        public string Post(string path,
            Dictionary<string, string>? headers = null,
            string? body = null,
            Dictionary<string, string?>? query = null)
            => ExecuteRequest(HttpMethod.Post, path, headers, body, query);

        /// <summary>PUT request.</summary>
        public string Put(string path,
            Dictionary<string, string>? headers = null,
            string? body = null,
            Dictionary<string, string?>? query = null)
            => ExecuteRequest(HttpMethod.Put, path, headers, body, query);

        /// <summary>DELETE request.</summary>
        public string Delete(string path,
            Dictionary<string, string>? headers = null,
            string? body = null,
            Dictionary<string, string?>? query = null)
            => ExecuteRequest(HttpMethod.Delete, path, headers, body, query);

        // ── Async public API ─────────────────────────────────────────────────

        /// <summary>Async GET.</summary>
        public Task<string> GetAsync(string path,
            Dictionary<string, string>? headers = null,
            Dictionary<string, string?>? query = null)
            => ExecuteRequestAsync(HttpMethod.Get, path, headers, null, query);

        /// <summary>Async POST.</summary>
        public Task<string> PostAsync(string path,
            Dictionary<string, string>? headers = null,
            string? body = null,
            Dictionary<string, string?>? query = null)
            => ExecuteRequestAsync(HttpMethod.Post, path, headers, body, query);

        /// <summary>Async PUT.</summary>
        public Task<string> PutAsync(string path,
            Dictionary<string, string>? headers = null,
            string? body = null,
            Dictionary<string, string?>? query = null)
            => ExecuteRequestAsync(HttpMethod.Put, path, headers, body, query);

        /// <summary>Async DELETE.</summary>
        public Task<string> DeleteAsync(string path,
            Dictionary<string, string>? headers = null,
            string? body = null,
            Dictionary<string, string?>? query = null)
            => ExecuteRequestAsync(HttpMethod.Delete, path, headers, body, query);

        // ── Static builder helpers ───────────────────────────────────────────

        /// <summary>Builds a header dictionary from key-value pairs.</summary>
        public static Dictionary<string, string> H(params string[] kv)
        {
            var d = new Dictionary<string, string>();
            for (int i = 0; i + 1 < kv.Length; i += 2) d[kv[i]] = kv[i + 1];
            return d;
        }

        /// <summary>Builds a query-params dictionary, skipping null values.</summary>
        public static Dictionary<string, string?> Q(params string?[] kv)
        {
            var d = new Dictionary<string, string?>();
            for (int i = 0; i + 1 < kv.Length; i += 2)
                if (kv[i + 1] != null) d[kv[i]!] = kv[i + 1];
            return d;
        }

        /// <inheritdoc/>
        public void Dispose() => _http.Dispose();
    }

    /// <summary>
    /// Async variant of <see cref="OpenHABClient"/>.
    /// All API classes accept both <see cref="OpenHABClient"/> and
    /// <see cref="AsyncOpenHABClient"/> — they share the same base.
    /// </summary>
    public class AsyncOpenHABClient : OpenHABClient
    {
        /// <inheritdoc/>
        public AsyncOpenHABClient(string url, string? username = null,
                                  string? password = null, string? token = null)
            : base(url, username, password, token) { }

        /// <summary>Async connectivity check.</summary>
        public async Task LoginAsync()
        {
            // Re-uses the sync login for simplicity; override for true async init
            await Task.Run(Login);
        }
    }
}
