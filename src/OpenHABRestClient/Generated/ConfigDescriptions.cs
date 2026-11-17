// Generated from python-openhab-rest-client by tools/py2cs.py – do not edit.
#pragma warning disable CS1998, CS0168, CS0219, IDE0059
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using OpenHABRestClient.Internal;

namespace OpenHABRestClient
{
    /// <summary>
    /// openHAB REST API: ConfigDescriptions.
    /// </summary>
    public sealed class ConfigDescriptions
    {
        readonly OpenHABClient _client;

        /// <summary>Creates the ConfigDescriptions class for a connected client.</summary>
        public ConfigDescriptions(OpenHABClient client) => _client = client;

        /// <summary>
        /// Retrieves all available config descriptions.
        /// </summary>
        /// <param name="scheme">Optional query parameter to filter results by a specific scheme.</param>
        /// <param name="language">Optional headers 'Accept-Language' to specify the preferred language.</param>
        /// <returns>A list of configuration descriptions.</returns>
        public JsonNode? GetConfigDescriptions(string? scheme = null, string? language = null)
            => R.Finish(() => getConfigDescriptions_S(_client, R.Arg(scheme), R.Arg(language)));

        /// <summary>Asynchronous <see cref="GetConfigDescriptions"/>.</summary>
        public Task<JsonNode?> GetConfigDescriptionsAsync(string? scheme = null, string? language = null,
                                                          CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getConfigDescriptions_A(_client, cancellationToken, R.Arg(scheme), R.Arg(language)));

        /// <summary>
        /// Retrieves a config description by URI.
        /// </summary>
        /// <param name="uri">The URI of the requested configuration description.</param>
        /// <param name="language">Optional headers 'Accept-Language' to specify the preferred language.</param>
        /// <returns>Details of the specific configuration description.</returns>
        public JsonNode? GetConfigDescription(string uri, string? language = null)
            => R.Finish(() => getConfigDescription_S(_client, R.Arg(uri), R.Arg(language)));

        /// <summary>Asynchronous <see cref="GetConfigDescription"/>.</summary>
        public Task<JsonNode?> GetConfigDescriptionAsync(string uri, string? language = null,
                                                         CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getConfigDescription_A(_client, cancellationToken, R.Arg(uri), R.Arg(language)));

        static V getConfigDescriptions_S(OpenHABClient C, V v_scheme, V v_language)
        {
            V v_headers = V.None;
            V v_params = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_headers = R.Dict(("Accept", R.S("application/json")));
            if (R.Truthy(v_language))
            {
                R.Set(v_headers, R.S("Accept-Language"), v_language);
            }
            v_params = R.Dict();
            if (R.Truthy(v_scheme))
            {
                R.Set(v_params, R.S("scheme"), v_scheme);
            }
            try
            {
                v_response = R.Http(C, "get", R.S("/config-descriptions"), v_headers, V.None, v_params);
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

        static async Task<V> getConfigDescriptions_A(OpenHABClient C, CancellationToken ct, V v_scheme,
                                                     V v_language)
        {
            V v_headers = V.None;
            V v_params = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_headers = R.Dict(("Accept", R.S("application/json")));
            if (R.Truthy(v_language))
            {
                R.Set(v_headers, R.S("Accept-Language"), v_language);
            }
            v_params = R.Dict();
            if (R.Truthy(v_scheme))
            {
                R.Set(v_params, R.S("scheme"), v_scheme);
            }
            try
            {
                v_response = (await R.HttpAsync(C, "get", R.S("/config-descriptions"), v_headers, V.None, v_params, ct).ConfigureAwait(false));
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

        static V getConfigDescription_S(OpenHABClient C, V v_uri, V v_language)
        {
            V v_headers = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_headers = R.Dict(("Accept", R.S("application/json")));
            if (R.Truthy(v_language))
            {
                R.Set(v_headers, R.S("Accept-Language"), v_language);
            }
            try
            {
                v_response = R.Http(C, "get", R.Cat(R.S("/config-descriptions/"), v_uri), v_headers, V.None, V.None);
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
                    return R.Dict(("error", R.S("Invalid URI syntax.")));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("Not found.")));
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
                return R.Dict(("error", R.S("Not found.")));
            }
            else if (R.Eq(v_status_code, R.I(400)))
            {
                return R.Dict(("error", R.S("Invalid URI syntax.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> getConfigDescription_A(OpenHABClient C, CancellationToken ct, V v_uri,
                                                    V v_language)
        {
            V v_headers = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_headers = R.Dict(("Accept", R.S("application/json")));
            if (R.Truthy(v_language))
            {
                R.Set(v_headers, R.S("Accept-Language"), v_language);
            }
            try
            {
                v_response = (await R.HttpAsync(C, "get", R.Cat(R.S("/config-descriptions/"), v_uri), v_headers, V.None, V.None, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Invalid URI syntax.")));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("Not found.")));
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
                return R.Dict(("error", R.S("Not found.")));
            }
            else if (R.Eq(v_status_code, R.I(400)))
            {
                return R.Dict(("error", R.S("Invalid URI syntax.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }
    }
}
