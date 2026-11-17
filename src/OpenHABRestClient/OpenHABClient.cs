using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using OpenHABRestClient.Internal;

namespace OpenHABRestClient
{
    /// <summary>
    /// Connection to an openHAB server – the C# counterpart of <c>openhab.OpenHABClient</c>.
    /// <code>
    /// using var client = new OpenHABClient("http://127.0.0.1:8080", token: token);
    /// var items = new Items(client);
    /// JsonNode? r = items.SendCommand("Wohnzimmer_Licht", "ON");
    /// if (r.IsError()) Console.WriteLine(r.ErrorMessage());
    /// </code>
    /// A client may be used from several threads at the same time.
    /// </summary>
    public sealed class OpenHABClient : IDisposable
    {
        /// <summary>Timeout of normal requests in seconds (Python: DEFAULT_TIMEOUT).</summary>
        public const double DEFAULT_TIMEOUT = 10;
        /// <summary>Time limit for opening an event stream in seconds (Python: SSE_CONNECT_TIMEOUT).</summary>
        public const double SSE_CONNECT_TIMEOUT = 10;
        /// <summary>Version of the library.</summary>
        public const string VERSION = "2.0.1";

        readonly HttpMessageHandler _handler;
        readonly bool _ownsHandler;

        internal HttpClient HttpClient { get; }
        internal HttpClient StreamClient { get; }
        internal bool OwnHandler => _ownsHandler;

        /// <summary>Base URL without trailing slash.</summary>
        public string Url { get; }
        /// <summary>User name for Basic Authentication (myopenHAB), or null.</summary>
        public string? Username { get; }
        /// <summary>Timeout of normal requests.</summary>
        public TimeSpan Timeout { get; }
        /// <summary>True if the URL is myopenhab.org.</summary>
        public bool IsCloud { get; private set; }
        /// <summary>True if openHAB answered the connection check of the constructor or of <see cref="Login"/>.</summary>
        public bool IsLoggedIn { get; private set; }
        /// <summary>Why the last connection check failed (empty if it succeeded).</summary>
        public string LastError { get; private set; } = "";

        /// <summary>
        /// Connects to openHAB. With <paramref name="token"/> the API token is sent as Bearer token;
        /// otherwise <paramref name="username"/> and <paramref name="password"/> are used for Basic
        /// Authentication (myopenHAB). The constructor checks the connection (<see cref="IsLoggedIn"/>)
        /// but never throws.
        /// </summary>
        /// <param name="url">e.g. "http://127.0.0.1:8080" or "https://myopenhab.org"</param>
        /// <param name="username">user name for Basic Authentication</param>
        /// <param name="password">password for Basic Authentication</param>
        /// <param name="token">API token (Main UI: profile → API tokens)</param>
        /// <param name="timeout">timeout of normal requests in seconds (default 10)</param>
        /// <param name="verify">verify the TLS certificate (false only for self-signed certificates)</param>
        /// <param name="handler">own HttpMessageHandler (tests, proxies); it is not disposed</param>
        public OpenHABClient(string url, string? username = null, string? password = null, string? token = null,
                             double timeout = DEFAULT_TIMEOUT, bool verify = true, HttpMessageHandler? handler = null)
        {
            Url = url.TrimEnd('/');
            Username = username;
            Timeout = TimeSpan.FromSeconds(timeout > 0 ? timeout : DEFAULT_TIMEOUT);
            _ownsHandler = handler == null;
            _handler = handler ?? CreateHandler(verify);
            HttpClient = new HttpClient(_handler, false) { Timeout = Timeout };
            StreamClient = new HttpClient(_handler, false) { Timeout = System.Threading.Timeout.InfiniteTimeSpan };
            foreach (var h in new[] { HttpClient, StreamClient })
            {
                h.DefaultRequestHeaders.UserAgent.ParseAdd("csharp-openhab-rest-client/" + VERSION);
                if (!string.IsNullOrEmpty(token))
                    h.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                else if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                    h.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                        Convert.ToBase64String(Encoding.UTF8.GetBytes(username + ":" + password)));
            }
            Login();
        }

        static HttpMessageHandler CreateHandler(bool verify)
        {
#if NET5_0_OR_GREATER
            var h = new SocketsHttpHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                ConnectTimeout = TimeSpan.FromSeconds(SSE_CONNECT_TIMEOUT),
                PooledConnectionLifetime = TimeSpan.FromMinutes(5),
            };
            if (!verify)
                h.SslOptions.RemoteCertificateValidationCallback = (_, _, _, _) => true;
            return h;
#else
            var h = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
            };
            if (!verify)
                h.ServerCertificateCustomValidationCallback = (_, _, _, _) => true;
            return h;
#endif
        }

        /// <summary>Checks again whether openHAB is reachable and accepts the credentials.</summary>
        public bool Login() => LoginAsync().GetAwaiter().GetResult();

        /// <summary>Asynchronous <see cref="Login"/>.</summary>
        public async Task<bool> LoginAsync(CancellationToken cancellationToken = default)
        {
            IsCloud = Url == "https://myopenhab.org" || Url == "https://home.myopenhab.org";
            IsLoggedIn = false;
            LastError = "";
            var url = Url + "/rest/";
            try
            {
                using var resp = await HttpClient.GetAsync(url, cancellationToken).ConfigureAwait(false);
                var status = (int)resp.StatusCode;
                if (status >= 400)
                    LastError = "HTTP error occurred: " + status + " for url: " + url;
                else
                    IsLoggedIn = true;
            }
            catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested)
            {
                LastError = "Timeout occurred: " + url;
            }
            catch (HttpRequestException e)
            {
                LastError = "Connection error occurred: " + HttpCore.Describe(e);
            }
            return IsLoggedIn;
        }

        // ── low-level requests (Python: client.get/post/put/delete) ──────────

        /// <summary>GET request; JSON, text, <c>{"status": …}</c> for empty answers or <c>{"error": …}</c>.</summary>
        public JsonNode? Get(string endpoint, object? headers = null, object? @params = null) =>
            LowLevel("get", endpoint, headers, null, @params);
        /// <summary>POST request – see <see cref="Get"/>.</summary>
        public JsonNode? Post(string endpoint, object? headers = null, object? data = null, object? @params = null) =>
            LowLevel("post", endpoint, headers, data, @params);
        /// <summary>PUT request – see <see cref="Get"/>.</summary>
        public JsonNode? Put(string endpoint, object? headers = null, object? data = null, object? @params = null) =>
            LowLevel("put", endpoint, headers, data, @params);
        /// <summary>DELETE request – see <see cref="Get"/>.</summary>
        public JsonNode? Delete(string endpoint, object? headers = null, object? data = null, object? @params = null) =>
            LowLevel("delete", endpoint, headers, data, @params);

        /// <summary>Asynchronous <see cref="Get"/>.</summary>
        public Task<JsonNode?> GetAsync(string endpoint, object? headers = null, object? @params = null,
                                        CancellationToken cancellationToken = default) =>
            LowLevelAsync("get", endpoint, headers, null, @params, cancellationToken);
        /// <summary>Asynchronous <see cref="Post"/>.</summary>
        public Task<JsonNode?> PostAsync(string endpoint, object? headers = null, object? data = null,
                                         object? @params = null, CancellationToken cancellationToken = default) =>
            LowLevelAsync("post", endpoint, headers, data, @params, cancellationToken);
        /// <summary>Asynchronous <see cref="Put"/>.</summary>
        public Task<JsonNode?> PutAsync(string endpoint, object? headers = null, object? data = null,
                                        object? @params = null, CancellationToken cancellationToken = default) =>
            LowLevelAsync("put", endpoint, headers, data, @params, cancellationToken);
        /// <summary>Asynchronous <see cref="Delete"/>.</summary>
        public Task<JsonNode?> DeleteAsync(string endpoint, object? headers = null, object? data = null,
                                           object? @params = null, CancellationToken cancellationToken = default) =>
            LowLevelAsync("delete", endpoint, headers, data, @params, cancellationToken);

        JsonNode? LowLevel(string verb, string endpoint, object? headers, object? data, object? prm) =>
            R.Finish(() => R.Http(this, verb, R.S(endpoint), R.Arg(headers), R.Arg(data), R.Arg(prm)));

        Task<JsonNode?> LowLevelAsync(string verb, string endpoint, object? headers, object? data, object? prm,
                                      CancellationToken ct) =>
            R.FinishAsync(() => R.HttpAsync(this, verb, R.S(endpoint), R.Arg(headers), R.Arg(data), R.Arg(prm), ct));

        /// <summary>
        /// Opens a Server-Sent-Events stream (Python: client.executeSSE). HTTP errors are reported by
        /// the stream (<see cref="EventStream.IsError"/>), nothing is thrown.
        /// </summary>
        public EventStream ExecuteSSE(string url, object? headers = null, object? @params = null) =>
            EventStream.OpenAsync(this, url, R.ToNode(headers), R.ToNode(@params), CancellationToken.None)
                       .GetAwaiter().GetResult();

        /// <summary>Asynchronous <see cref="ExecuteSSE"/>.</summary>
        public Task<EventStream> ExecuteSSEAsync(string url, object? headers = null, object? @params = null,
                                                 CancellationToken cancellationToken = default) =>
            EventStream.OpenAsync(this, url, R.ToNode(headers), R.ToNode(@params), cancellationToken);

        /// <summary>Closes the connections.</summary>
        public void Dispose()
        {
            HttpClient.Dispose();
            StreamClient.Dispose();
            if (_ownsHandler) _handler.Dispose();
        }
    }
}
