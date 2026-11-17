// Generated from python-openhab-rest-client by tools/py2cs.py – do not edit.
#pragma warning disable CS1998, CS0168, CS0219, IDE0059
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using OpenHABRestClient.Internal;

namespace OpenHABRestClient
{
    /// <summary>
    /// openHAB REST API: Sitemaps.
    /// </summary>
    public sealed class Sitemaps
    {
        readonly OpenHABClient _client;

        /// <summary>Creates the Sitemaps class for a connected client.</summary>
        public Sitemaps(OpenHABClient client) => _client = client;

        /// <summary>
        /// Get all available sitemaps.
        /// </summary>
        /// <returns>A list of sitemaps (JSON).</returns>
        public JsonNode? GetSitemaps()
            => R.Finish(() => getSitemaps_S(_client));

        /// <summary>Asynchronous <see cref="GetSitemaps"/>.</summary>
        public Task<JsonNode?> GetSitemapsAsync(CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getSitemaps_A(_client, cancellationToken));

        /// <summary>
        /// Get sitemap by name.
        /// </summary>
        /// <param name="sitemapName">The name of the sitemap to retrieve.</param>
        /// <param name="type">Optional query parameter for type.</param>
        /// <param name="jsonCallback">Optional query parameter for JSON callback.</param>
        /// <param name="includeHidden">Whether hidden widgets should be included.</param>
        /// <param name="language">Optional language setting (as header).</param>
        /// <returns>The sitemap object (JSON).</returns>
        public JsonNode? GetSitemap(string sitemapName, string? type = null, string? jsonCallback = null,
                                    bool includeHidden = false, string? language = null)
            => R.Finish(() => getSitemap_S(_client, R.Arg(sitemapName), R.Arg(type), R.Arg(jsonCallback), R.Arg(includeHidden), R.Arg(language)));

        /// <summary>Asynchronous <see cref="GetSitemap"/>.</summary>
        public Task<JsonNode?> GetSitemapAsync(string sitemapName, string? type = null,
                                               string? jsonCallback = null, bool includeHidden = false,
                                               string? language = null,
                                               CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getSitemap_A(_client, cancellationToken, R.Arg(sitemapName), R.Arg(type), R.Arg(jsonCallback), R.Arg(includeHidden), R.Arg(language)));

        /// <summary>
        /// Polls the data for one page of a sitemap.
        /// </summary>
        /// <param name="sitemapName">The name of the sitemap.</param>
        /// <param name="pageID">The ID of the page.</param>
        /// <param name="subscriptionID">Optional query parameter for the subscription ID.</param>
        /// <param name="includeHidden">Whether hidden widgets should be included.</param>
        /// <param name="language">Optional language setting (as header).</param>
        /// <returns>The sitemap page (JSON).</returns>
        public JsonNode? GetSitemapPage(string sitemapName, string pageID, string? subscriptionID = null,
                                        bool includeHidden = false, string? language = null)
            => R.Finish(() => getSitemapPage_S(_client, R.Arg(sitemapName), R.Arg(pageID), R.Arg(subscriptionID), R.Arg(includeHidden), R.Arg(language)));

        /// <summary>Asynchronous <see cref="GetSitemapPage"/>.</summary>
        public Task<JsonNode?> GetSitemapPageAsync(string sitemapName, string pageID,
                                                   string? subscriptionID = null, bool includeHidden = false,
                                                   string? language = null,
                                                   CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getSitemapPage_A(_client, cancellationToken, R.Arg(sitemapName), R.Arg(pageID), R.Arg(subscriptionID), R.Arg(includeHidden), R.Arg(language)));

        /// <summary>
        /// Polls the data for a whole sitemap. Not recommended due to potentially high traffic.
        /// </summary>
        /// <param name="sitemapName">The name of the sitemap.</param>
        /// <param name="subscriptionID">Optional query parameter for the subscription ID.</param>
        /// <param name="includeHidden">Whether hidden widgets should be included.</param>
        /// <param name="language">Optional language setting (as header).</param>
        /// <returns>The complete sitemap (JSON).</returns>
        public JsonNode? GetFullSitemap(string sitemapName, string? subscriptionID = null,
                                        bool includeHidden = false, string? language = null)
            => R.Finish(() => getFullSitemap_S(_client, R.Arg(sitemapName), R.Arg(subscriptionID), R.Arg(includeHidden), R.Arg(language)));

        /// <summary>Asynchronous <see cref="GetFullSitemap"/>.</summary>
        public Task<JsonNode?> GetFullSitemapAsync(string sitemapName, string? subscriptionID = null,
                                                   bool includeHidden = false, string? language = null,
                                                   CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getFullSitemap_A(_client, cancellationToken, R.Arg(sitemapName), R.Arg(subscriptionID), R.Arg(includeHidden), R.Arg(language)));

        /// <summary>
        /// Opens the event stream (SSE) of a sitemap subscription for one page.
        /// </summary>
        /// <param name="subscriptionID">The ID of the subscription (see subscribeToSitemapEvents()).</param>
        /// <param name="sitemapName">The name of the sitemap.</param>
        /// <param name="pageID">The ID of the page (the sitemap name for the home page).</param>
        /// <returns>A SSE stream (requests.Response, read it with iterSSEEvents()) or {"error": ...}.</returns>
        public EventStream GetSitemapEvents(string subscriptionID, string? sitemapName = null,
                                            string? pageID = null)
            => R.FinishStream(() => getSitemapEvents_S(_client, R.Arg(subscriptionID), R.Arg(sitemapName), R.Arg(pageID)));

        /// <summary>Asynchronous <see cref="GetSitemapEvents"/>.</summary>
        public Task<EventStream> GetSitemapEventsAsync(string subscriptionID, string? sitemapName = null,
                                                       string? pageID = null,
                                                       CancellationToken cancellationToken = default)
            => R.FinishStreamAsync(() => getSitemapEvents_A(_client, cancellationToken, R.Arg(subscriptionID), R.Arg(sitemapName), R.Arg(pageID)));

        /// <summary>
        /// Opens the event stream (SSE) of a sitemap subscription for the whole sitemap.
        /// Not recommended due to potentially high traffic.
        /// </summary>
        /// <param name="subscriptionID">The ID of the subscription.</param>
        /// <param name="sitemapName">The name of the sitemap.</param>
        /// <returns>A SSE stream (requests.Response) or {"error": ...}.</returns>
        public EventStream GetFullSitemapEvents(string subscriptionID, string? sitemapName = null)
            => R.FinishStream(() => getFullSitemapEvents_S(_client, R.Arg(subscriptionID), R.Arg(sitemapName)));

        /// <summary>Asynchronous <see cref="GetFullSitemapEvents"/>.</summary>
        public Task<EventStream> GetFullSitemapEventsAsync(string subscriptionID, string? sitemapName = null,
                                                           CancellationToken cancellationToken = default)
            => R.FinishStreamAsync(() => getFullSitemapEvents_A(_client, cancellationToken, R.Arg(subscriptionID), R.Arg(sitemapName)));

        /// <summary>
        /// Creates a sitemap event subscription.
        /// </summary>
        /// <returns>The response to the subscription request (JSON).</returns>
        public JsonNode? SubscribeToSitemapEvents()
            => R.Finish(() => subscribeToSitemapEvents_S(_client));

        /// <summary>Asynchronous <see cref="SubscribeToSitemapEvents"/>.</summary>
        public Task<JsonNode?> SubscribeToSitemapEventsAsync(CancellationToken cancellationToken = default)
            => R.FinishAsync(() => subscribeToSitemapEvents_A(_client, cancellationToken));

        static EventStream openEventStream_S(OpenHABClient C, V v_path, V v_params, V v_errors)
        {
            V v_statusCode = V.None;
            try
            {
                return R.Sse(C, v_path, V.None, v_params);
            }
            catch (HttpError e_err)
            {
                v_statusCode = R.ExcStatus(e_err);
                if (R.Contains(v_errors, v_statusCode))
                {
                    return R.AsStream(R.Dict(("error", R.Get(v_errors, v_statusCode))));
                }
                return R.AsStream(R.Dict(("error", R.Cat(R.S("HTTP error "), v_statusCode, R.S(": "), R.ExcStr(e_err)))));
            }
            catch (RequestException e_err)
            {
                return R.AsStream(R.Dict(("error", R.Cat(R.S("Request error: "), R.ExcStr(e_err)))));
            }
        }

        static async Task<EventStream> openEventStream_A(OpenHABClient C, CancellationToken ct, V v_path,
                                                         V v_params, V v_errors)
        {
            V v_statusCode = V.None;
            try
            {
                return (await R.SseAsync(C, v_path, V.None, v_params, ct).ConfigureAwait(false));
            }
            catch (HttpError e_err)
            {
                v_statusCode = R.ExcStatus(e_err);
                if (R.Contains(v_errors, v_statusCode))
                {
                    return R.AsStream(R.Dict(("error", R.Get(v_errors, v_statusCode))));
                }
                return R.AsStream(R.Dict(("error", R.Cat(R.S("HTTP error "), v_statusCode, R.S(": "), R.ExcStr(e_err)))));
            }
            catch (RequestException e_err)
            {
                return R.AsStream(R.Dict(("error", R.Cat(R.S("Request error: "), R.ExcStr(e_err)))));
            }
        }

        static V getSitemaps_S(OpenHABClient C)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "get", R.S("/sitemaps"), R.Dict(("Accept", R.S("application/json"))), V.None, V.None);
                if (R.IsStatus(v_response))
                {
                    v_status_code = R.Get(v_response, R.S("status"));
                }
                else
                {
                    return v_response;
                }
            }
            catch (HttpError e_err)
            {
                v_status_code = R.ExcStatus(e_err);
                if (!R.Eq(v_status_code, R.I(200)))
                {
                    return R.Dict(("error", R.Cat(R.S("HTTP error "), v_status_code, R.S(": "), R.ExcStr(e_err))));
                }
            }
            catch (RequestException e_err)
            {
                return R.Dict(("error", R.Cat(R.S("Request error: "), R.ExcStr(e_err))));
            }
            if (R.Eq(v_status_code, R.I(200)))
            {
                return R.Dict(("message", R.S("OK")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> getSitemaps_A(OpenHABClient C, CancellationToken ct)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "get", R.S("/sitemaps"), R.Dict(("Accept", R.S("application/json"))), V.None, V.None, ct).ConfigureAwait(false));
                if (R.IsStatus(v_response))
                {
                    v_status_code = R.Get(v_response, R.S("status"));
                }
                else
                {
                    return v_response;
                }
            }
            catch (HttpError e_err)
            {
                v_status_code = R.ExcStatus(e_err);
                if (!R.Eq(v_status_code, R.I(200)))
                {
                    return R.Dict(("error", R.Cat(R.S("HTTP error "), v_status_code, R.S(": "), R.ExcStr(e_err))));
                }
            }
            catch (RequestException e_err)
            {
                return R.Dict(("error", R.Cat(R.S("Request error: "), R.ExcStr(e_err))));
            }
            if (R.Eq(v_status_code, R.I(200)))
            {
                return R.Dict(("message", R.S("OK")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V getSitemap_S(OpenHABClient C, V v_sitemapName, V v_type, V v_jsonCallback, V v_includeHidden,
                              V v_language)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            if (R.Truthy(v_includeHidden))
            {
                v_includeHidden = R.S("true");
            }
            else
            {
                v_includeHidden = R.S("false");
            }
            try
            {
                v_response = R.Http(C, "get", R.Cat(R.S("/sitemaps/"), v_sitemapName), (R.Truthy(v_language) ? R.Dict(("Accept-Language", v_language)) : R.Dict()), V.None, R.Dict(("type", v_type), ("jsoncallback", v_jsonCallback), ("includeHidden", v_includeHidden)));
                if (R.IsStatus(v_response))
                {
                    v_status_code = R.Get(v_response, R.S("status"));
                }
                else
                {
                    return v_response;
                }
            }
            catch (HttpError e_err)
            {
                v_status_code = R.ExcStatus(e_err);
                if (!R.Eq(v_status_code, R.I(200)))
                {
                    return R.Dict(("error", R.Cat(R.S("HTTP error "), v_status_code, R.S(": "), R.ExcStr(e_err))));
                }
            }
            catch (RequestException e_err)
            {
                return R.Dict(("error", R.Cat(R.S("Request error: "), R.ExcStr(e_err))));
            }
            if (R.Eq(v_status_code, R.I(200)))
            {
                return R.Dict(("message", R.S("OK")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> getSitemap_A(OpenHABClient C, CancellationToken ct, V v_sitemapName, V v_type,
                                          V v_jsonCallback, V v_includeHidden, V v_language)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            if (R.Truthy(v_includeHidden))
            {
                v_includeHidden = R.S("true");
            }
            else
            {
                v_includeHidden = R.S("false");
            }
            try
            {
                v_response = (await R.HttpAsync(C, "get", R.Cat(R.S("/sitemaps/"), v_sitemapName), (R.Truthy(v_language) ? R.Dict(("Accept-Language", v_language)) : R.Dict()), V.None, R.Dict(("type", v_type), ("jsoncallback", v_jsonCallback), ("includeHidden", v_includeHidden)), ct).ConfigureAwait(false));
                if (R.IsStatus(v_response))
                {
                    v_status_code = R.Get(v_response, R.S("status"));
                }
                else
                {
                    return v_response;
                }
            }
            catch (HttpError e_err)
            {
                v_status_code = R.ExcStatus(e_err);
                if (!R.Eq(v_status_code, R.I(200)))
                {
                    return R.Dict(("error", R.Cat(R.S("HTTP error "), v_status_code, R.S(": "), R.ExcStr(e_err))));
                }
            }
            catch (RequestException e_err)
            {
                return R.Dict(("error", R.Cat(R.S("Request error: "), R.ExcStr(e_err))));
            }
            if (R.Eq(v_status_code, R.I(200)))
            {
                return R.Dict(("message", R.S("OK")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V getSitemapPage_S(OpenHABClient C, V v_sitemapName, V v_pageID, V v_subscriptionID,
                                  V v_includeHidden, V v_language)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            if (R.Truthy(v_includeHidden))
            {
                v_includeHidden = R.S("true");
            }
            else
            {
                v_includeHidden = R.S("false");
            }
            try
            {
                v_response = R.Http(C, "get", R.Cat(R.S("/sitemaps/"), v_sitemapName, R.S("/"), v_pageID), (R.Truthy(v_language) ? R.Dict(("Accept-Language", v_language)) : R.Dict()), V.None, R.Dict(("subscriptionid", v_subscriptionID), ("includeHidden", v_includeHidden)));
                if (R.IsStatus(v_response))
                {
                    v_status_code = R.Get(v_response, R.S("status"));
                }
                else
                {
                    return v_response;
                }
            }
            catch (HttpError e_err)
            {
                v_status_code = R.ExcStatus(e_err);
                if (R.Eq(v_status_code, R.I(400)))
                {
                    return R.Dict(("error", R.S("Invalid subscription id has been provided.")));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("Sitemap with requested name does not exist or page does not exist, or page refers to a non-linkable widget.")));
                }
                else
                {
                    return R.Dict(("error", R.Cat(R.S("HTTP error "), v_status_code, R.S(": "), R.ExcStr(e_err))));
                }
            }
            catch (RequestException e_err)
            {
                return R.Dict(("error", R.Cat(R.S("Request error: "), R.ExcStr(e_err))));
            }
            if (R.Eq(v_status_code, R.I(200)))
            {
                return R.Dict(("message", R.S("OK")));
            }
            else if (R.Eq(v_status_code, R.I(404)))
            {
                return R.Dict(("error", R.S("Sitemap with requested name does not exist or page does not exist, or page refers to a non-linkable widget.")));
            }
            else if (R.Eq(v_status_code, R.I(400)))
            {
                return R.Dict(("error", R.S("Invalid subscription id has been provided.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> getSitemapPage_A(OpenHABClient C, CancellationToken ct, V v_sitemapName,
                                              V v_pageID, V v_subscriptionID, V v_includeHidden, V v_language)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            if (R.Truthy(v_includeHidden))
            {
                v_includeHidden = R.S("true");
            }
            else
            {
                v_includeHidden = R.S("false");
            }
            try
            {
                v_response = (await R.HttpAsync(C, "get", R.Cat(R.S("/sitemaps/"), v_sitemapName, R.S("/"), v_pageID), (R.Truthy(v_language) ? R.Dict(("Accept-Language", v_language)) : R.Dict()), V.None, R.Dict(("subscriptionid", v_subscriptionID), ("includeHidden", v_includeHidden)), ct).ConfigureAwait(false));
                if (R.IsStatus(v_response))
                {
                    v_status_code = R.Get(v_response, R.S("status"));
                }
                else
                {
                    return v_response;
                }
            }
            catch (HttpError e_err)
            {
                v_status_code = R.ExcStatus(e_err);
                if (R.Eq(v_status_code, R.I(400)))
                {
                    return R.Dict(("error", R.S("Invalid subscription id has been provided.")));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("Sitemap with requested name does not exist or page does not exist, or page refers to a non-linkable widget.")));
                }
                else
                {
                    return R.Dict(("error", R.Cat(R.S("HTTP error "), v_status_code, R.S(": "), R.ExcStr(e_err))));
                }
            }
            catch (RequestException e_err)
            {
                return R.Dict(("error", R.Cat(R.S("Request error: "), R.ExcStr(e_err))));
            }
            if (R.Eq(v_status_code, R.I(200)))
            {
                return R.Dict(("message", R.S("OK")));
            }
            else if (R.Eq(v_status_code, R.I(404)))
            {
                return R.Dict(("error", R.S("Sitemap with requested name does not exist or page does not exist, or page refers to a non-linkable widget.")));
            }
            else if (R.Eq(v_status_code, R.I(400)))
            {
                return R.Dict(("error", R.S("Invalid subscription id has been provided.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V getFullSitemap_S(OpenHABClient C, V v_sitemapName, V v_subscriptionID, V v_includeHidden,
                                  V v_language)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            if (R.Truthy(v_includeHidden))
            {
                v_includeHidden = R.S("true");
            }
            else
            {
                v_includeHidden = R.S("false");
            }
            try
            {
                v_response = R.Http(C, "get", R.Cat(R.S("/sitemaps/"), v_sitemapName, R.S("/*")), (R.Truthy(v_language) ? R.Dict(("Accept-Language", v_language)) : R.Dict()), V.None, R.Dict(("subscriptionid", v_subscriptionID), ("includeHidden", v_includeHidden)));
                if (R.IsStatus(v_response))
                {
                    v_status_code = R.Get(v_response, R.S("status"));
                }
                else
                {
                    return v_response;
                }
            }
            catch (HttpError e_err)
            {
                v_status_code = R.ExcStatus(e_err);
                if (R.Eq(v_status_code, R.I(400)))
                {
                    return R.Dict(("error", R.S("Invalid subscription id has been provided.")));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("Sitemap with requested name does not exist.")));
                }
                else
                {
                    return R.Dict(("error", R.Cat(R.S("HTTP error "), v_status_code, R.S(": "), R.ExcStr(e_err))));
                }
            }
            catch (RequestException e_err)
            {
                return R.Dict(("error", R.Cat(R.S("Request error: "), R.ExcStr(e_err))));
            }
            if (R.Eq(v_status_code, R.I(200)))
            {
                return R.Dict(("message", R.S("OK")));
            }
            else if (R.Eq(v_status_code, R.I(404)))
            {
                return R.Dict(("error", R.S("Sitemap with requested name does not exist.")));
            }
            else if (R.Eq(v_status_code, R.I(400)))
            {
                return R.Dict(("error", R.S("Invalid subscription id has been provided.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> getFullSitemap_A(OpenHABClient C, CancellationToken ct, V v_sitemapName,
                                              V v_subscriptionID, V v_includeHidden, V v_language)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            if (R.Truthy(v_includeHidden))
            {
                v_includeHidden = R.S("true");
            }
            else
            {
                v_includeHidden = R.S("false");
            }
            try
            {
                v_response = (await R.HttpAsync(C, "get", R.Cat(R.S("/sitemaps/"), v_sitemapName, R.S("/*")), (R.Truthy(v_language) ? R.Dict(("Accept-Language", v_language)) : R.Dict()), V.None, R.Dict(("subscriptionid", v_subscriptionID), ("includeHidden", v_includeHidden)), ct).ConfigureAwait(false));
                if (R.IsStatus(v_response))
                {
                    v_status_code = R.Get(v_response, R.S("status"));
                }
                else
                {
                    return v_response;
                }
            }
            catch (HttpError e_err)
            {
                v_status_code = R.ExcStatus(e_err);
                if (R.Eq(v_status_code, R.I(400)))
                {
                    return R.Dict(("error", R.S("Invalid subscription id has been provided.")));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("Sitemap with requested name does not exist.")));
                }
                else
                {
                    return R.Dict(("error", R.Cat(R.S("HTTP error "), v_status_code, R.S(": "), R.ExcStr(e_err))));
                }
            }
            catch (RequestException e_err)
            {
                return R.Dict(("error", R.Cat(R.S("Request error: "), R.ExcStr(e_err))));
            }
            if (R.Eq(v_status_code, R.I(200)))
            {
                return R.Dict(("message", R.S("OK")));
            }
            else if (R.Eq(v_status_code, R.I(404)))
            {
                return R.Dict(("error", R.S("Sitemap with requested name does not exist.")));
            }
            else if (R.Eq(v_status_code, R.I(400)))
            {
                return R.Dict(("error", R.S("Invalid subscription id has been provided.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static EventStream getSitemapEvents_S(OpenHABClient C, V v_subscriptionID, V v_sitemapName,
                                              V v_pageID)
        {
            return openEventStream_S(C, R.Cat(R.S("/rest/sitemaps/events/"), v_subscriptionID), R.Dict(("sitemap", v_sitemapName), ("pageid", v_pageID)), R.Dict(("400", R.S("Missing sitemap or page parameter, or page not linked successfully to the subscription.")), ("404", R.S("Subscription not found."))));
        }

        static async Task<EventStream> getSitemapEvents_A(OpenHABClient C, CancellationToken ct,
                                                          V v_subscriptionID, V v_sitemapName, V v_pageID)
        {
            return (await openEventStream_A(C, ct, R.Cat(R.S("/rest/sitemaps/events/"), v_subscriptionID), R.Dict(("sitemap", v_sitemapName), ("pageid", v_pageID)), R.Dict(("400", R.S("Missing sitemap or page parameter, or page not linked successfully to the subscription.")), ("404", R.S("Subscription not found.")))).ConfigureAwait(false));
        }

        static EventStream getFullSitemapEvents_S(OpenHABClient C, V v_subscriptionID, V v_sitemapName)
        {
            return openEventStream_S(C, R.Cat(R.S("/rest/sitemaps/events/"), v_subscriptionID, R.S("/*")), R.Dict(("sitemap", v_sitemapName)), R.Dict(("400", R.S("Missing sitemap parameter, or sitemap not linked successfully to the subscription.")), ("404", R.S("Subscription not found."))));
        }

        static async Task<EventStream> getFullSitemapEvents_A(OpenHABClient C, CancellationToken ct,
                                                              V v_subscriptionID, V v_sitemapName)
        {
            return (await openEventStream_A(C, ct, R.Cat(R.S("/rest/sitemaps/events/"), v_subscriptionID, R.S("/*")), R.Dict(("sitemap", v_sitemapName)), R.Dict(("400", R.S("Missing sitemap parameter, or sitemap not linked successfully to the subscription.")), ("404", R.S("Subscription not found.")))).ConfigureAwait(false));
        }

        static V subscribeToSitemapEvents_S(OpenHABClient C)
        {
            V v_headers = V.None;
            V v_location = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            V v_value = V.None;
            try
            {
                v_response = R.Http(C, "post", R.S("/sitemaps/events/subscribe"), V.None, V.None, V.None);
                v_location = V.None;
                if (R.IsDict(v_response))
                {
                    v_location = R.GetOr(v_response, R.S("location"));
                    if (!R.Truthy(v_location))
                    {
                        v_headers = (R.GetOr((R.GetOr(v_response, R.S("context")) is var t_1 ? (R.Truthy(t_1) ? t_1 : R.Dict()) : V.None), R.S("headers")) is var t_2 ? (R.Truthy(t_2) ? t_2 : R.Dict()) : V.None);
                        v_value = R.GetOr(v_headers, R.S("Location"));
                        v_location = (R.Truthy((R.Bool(R.IsList(v_value)) is var t_3 ? (R.Truthy(t_3) ? v_value : t_3) : V.None)) ? R.Get(v_value, R.I(0)) : v_value);
                    }
                }
                if (R.Truthy(v_location))
                {
                    return R.Dict(("message", R.S("Subscription created.")), ("location", v_location), ("subscriptionID", R.Get(R.Split(R.RStrip(v_location, R.S("/")), R.S("/")), R.I(-1))));
                }
                if (R.IsStatus(v_response))
                {
                    v_status_code = R.Get(v_response, R.S("status"));
                }
                else
                {
                    return v_response;
                }
            }
            catch (HttpError e_err)
            {
                v_status_code = R.ExcStatus(e_err);
                if (R.Eq(v_status_code, R.I(503)))
                {
                    return R.Dict(("error", R.S("Subscriptions limit reached.")));
                }
                else
                {
                    return R.Dict(("error", R.Cat(R.S("HTTP error "), v_status_code, R.S(": "), R.ExcStr(e_err))));
                }
            }
            catch (RequestException e_err)
            {
                return R.Dict(("error", R.Cat(R.S("Request error: "), R.ExcStr(e_err))));
            }
            if (R.Eq(v_status_code, R.I(201)))
            {
                return R.Dict(("message", R.S("Subscription created.")));
            }
            else if (R.Eq(v_status_code, R.I(503)))
            {
                return R.Dict(("error", R.S("Subscriptions limit reached.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> subscribeToSitemapEvents_A(OpenHABClient C, CancellationToken ct)
        {
            V v_headers = V.None;
            V v_location = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            V v_value = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "post", R.S("/sitemaps/events/subscribe"), V.None, V.None, V.None, ct).ConfigureAwait(false));
                v_location = V.None;
                if (R.IsDict(v_response))
                {
                    v_location = R.GetOr(v_response, R.S("location"));
                    if (!R.Truthy(v_location))
                    {
                        v_headers = (R.GetOr((R.GetOr(v_response, R.S("context")) is var t_1 ? (R.Truthy(t_1) ? t_1 : R.Dict()) : V.None), R.S("headers")) is var t_2 ? (R.Truthy(t_2) ? t_2 : R.Dict()) : V.None);
                        v_value = R.GetOr(v_headers, R.S("Location"));
                        v_location = (R.Truthy((R.Bool(R.IsList(v_value)) is var t_3 ? (R.Truthy(t_3) ? v_value : t_3) : V.None)) ? R.Get(v_value, R.I(0)) : v_value);
                    }
                }
                if (R.Truthy(v_location))
                {
                    return R.Dict(("message", R.S("Subscription created.")), ("location", v_location), ("subscriptionID", R.Get(R.Split(R.RStrip(v_location, R.S("/")), R.S("/")), R.I(-1))));
                }
                if (R.IsStatus(v_response))
                {
                    v_status_code = R.Get(v_response, R.S("status"));
                }
                else
                {
                    return v_response;
                }
            }
            catch (HttpError e_err)
            {
                v_status_code = R.ExcStatus(e_err);
                if (R.Eq(v_status_code, R.I(503)))
                {
                    return R.Dict(("error", R.S("Subscriptions limit reached.")));
                }
                else
                {
                    return R.Dict(("error", R.Cat(R.S("HTTP error "), v_status_code, R.S(": "), R.ExcStr(e_err))));
                }
            }
            catch (RequestException e_err)
            {
                return R.Dict(("error", R.Cat(R.S("Request error: "), R.ExcStr(e_err))));
            }
            if (R.Eq(v_status_code, R.I(201)))
            {
                return R.Dict(("message", R.S("Subscription created.")));
            }
            else if (R.Eq(v_status_code, R.I(503)))
            {
                return R.Dict(("error", R.S("Subscriptions limit reached.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }
    }
}
