// Generated from python-openhab-rest-client by tools/py2cs.py – do not edit.
#pragma warning disable CS1998, CS0168, CS0219, IDE0059
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using OpenHABRestClient.Internal;

namespace OpenHABRestClient
{
    /// <summary>
    /// openHAB REST API: Discovery.
    /// </summary>
    public sealed class Discovery
    {
        readonly OpenHABClient _client;

        /// <summary>Creates the Discovery class for a connected client.</summary>
        public Discovery(OpenHABClient client) => _client = client;

        /// <summary>
        /// Gets all bindings that support discovery.
        /// </summary>
        /// <returns>Eine Liste der Bindings als Strings.</returns>
        public JsonNode? GetDiscoveryBindings()
            => R.Finish(() => getDiscoveryBindings_S(_client));

        /// <summary>Asynchronous <see cref="GetDiscoveryBindings"/>.</summary>
        public Task<JsonNode?> GetDiscoveryBindingsAsync(CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getDiscoveryBindings_A(_client, cancellationToken));

        /// <summary>
        /// Gets information about the discovery services for a binding.
        /// </summary>
        /// <param name="bindingID">The ID of the binding to get discovery information for.</param>
        /// <param name="language">Optional language parameter for the response (Accept-Language header).</param>
        /// <returns>Information about the discovery service for the specified binding.</returns>
        public JsonNode? GetBindingInfo(string bindingID, string? language = null)
            => R.Finish(() => getBindingInfo_S(_client, R.Arg(bindingID), R.Arg(language)));

        /// <summary>Asynchronous <see cref="GetBindingInfo"/>.</summary>
        public Task<JsonNode?> GetBindingInfoAsync(string bindingID, string? language = null,
                                                   CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getBindingInfo_A(_client, cancellationToken, R.Arg(bindingID), R.Arg(language)));

        /// <summary>
        /// Starts asynchronous discovery process for a binding and returns the timeout in seconds of the discovery operation.
        /// </summary>
        /// <param name="bindingID">The ID of the binding for which the discovery is to be started.</param>
        /// <param name="input">An input parameter to start the discovery.</param>
        /// <returns>Timeout duration of the discovery operation in seconds.</returns>
        public JsonNode? StartBindingScan(string bindingID, string? input = null)
            => R.Finish(() => startBindingScan_S(_client, R.Arg(bindingID), R.Arg(input)));

        /// <summary>Asynchronous <see cref="StartBindingScan"/>.</summary>
        public Task<JsonNode?> StartBindingScanAsync(string bindingID, string? input = null,
                                                     CancellationToken cancellationToken = default)
            => R.FinishAsync(() => startBindingScan_A(_client, cancellationToken, R.Arg(bindingID), R.Arg(input)));

        static V getDiscoveryBindings_S(OpenHABClient C)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "get", R.S("/discovery"), R.Dict(("Accept", R.S("application/json"))), V.None, V.None);
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

        static async Task<V> getDiscoveryBindings_A(OpenHABClient C, CancellationToken ct)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "get", R.S("/discovery"), R.Dict(("Accept", R.S("application/json"))), V.None, V.None, ct).ConfigureAwait(false));
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

        static V getBindingInfo_S(OpenHABClient C, V v_bindingID, V v_language)
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
                v_response = R.Http(C, "get", R.Cat(R.S("/discovery/bindings/"), v_bindingID, R.S("/info")), v_headers, V.None, V.None);
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
                if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("Discovery service not found.")));
                }
                else if (!R.Eq(v_status_code, R.I(200)))
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
                return v_response;
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> getBindingInfo_A(OpenHABClient C, CancellationToken ct, V v_bindingID,
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
                v_response = (await R.HttpAsync(C, "get", R.Cat(R.S("/discovery/bindings/"), v_bindingID, R.S("/info")), v_headers, V.None, V.None, ct).ConfigureAwait(false));
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
                if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("Discovery service not found.")));
                }
                else if (!R.Eq(v_status_code, R.I(200)))
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
                return v_response;
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V startBindingScan_S(OpenHABClient C, V v_bindingID, V v_input)
        {
            V v_params = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_params = R.Dict(("input", v_input));
            try
            {
                v_response = R.Http(C, "post", R.Cat(R.S("/discovery/bindings/"), v_bindingID, R.S("/scan")), R.Dict(("Accept", R.S("text/plain"))), V.None, v_params);
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

        static async Task<V> startBindingScan_A(OpenHABClient C, CancellationToken ct, V v_bindingID,
                                                V v_input)
        {
            V v_params = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_params = R.Dict(("input", v_input));
            try
            {
                v_response = (await R.HttpAsync(C, "post", R.Cat(R.S("/discovery/bindings/"), v_bindingID, R.S("/scan")), R.Dict(("Accept", R.S("text/plain"))), V.None, v_params, ct).ConfigureAwait(false));
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
    }
}
