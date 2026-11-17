// Generated from python-openhab-rest-client by tools/py2cs.py – do not edit.
#pragma warning disable CS1998, CS0168, CS0219, IDE0059
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using OpenHABRestClient.Internal;

namespace OpenHABRestClient
{
    /// <summary>
    /// openHAB REST API: Services.
    /// </summary>
    public sealed class Services
    {
        readonly OpenHABClient _client;

        /// <summary>Creates the Services class for a connected client.</summary>
        public Services(OpenHABClient client) => _client = client;

        /// <summary>
        /// Get all configurable services.
        /// </summary>
        /// <param name="language">Optional language setting (as header).</param>
        /// <returns>A list of services (JSON).</returns>
        public JsonNode? GetServices(string? language = null)
            => R.Finish(() => getServices_S(_client, R.Arg(language)));

        /// <summary>Asynchronous <see cref="GetServices"/>.</summary>
        public Task<JsonNode?> GetServicesAsync(string? language = null,
                                                CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getServices_A(_client, cancellationToken, R.Arg(language)));

        /// <summary>
        /// Get configurable service for the given service ID.
        /// </summary>
        /// <param name="serviceID">The ID of the service to retrieve.</param>
        /// <param name="language">Optional language setting (as header).</param>
        /// <returns>The service object (JSON).</returns>
        public JsonNode? GetService(string serviceID, string? language = null)
            => R.Finish(() => getService_S(_client, R.Arg(serviceID), R.Arg(language)));

        /// <summary>Asynchronous <see cref="GetService"/>.</summary>
        public Task<JsonNode?> GetServiceAsync(string serviceID, string? language = null,
                                               CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getService_A(_client, cancellationToken, R.Arg(serviceID), R.Arg(language)));

        /// <summary>
        /// Get service configuration for the given service ID.
        /// </summary>
        /// <param name="serviceID">The ID of the service.</param>
        /// <returns>The configuration of the service (JSON).</returns>
        public JsonNode? GetServiceConfig(string serviceID)
            => R.Finish(() => getServiceConfig_S(_client, R.Arg(serviceID)));

        /// <summary>Asynchronous <see cref="GetServiceConfig"/>.</summary>
        public Task<JsonNode?> GetServiceConfigAsync(string serviceID,
                                                     CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getServiceConfig_A(_client, cancellationToken, R.Arg(serviceID)));

        /// <summary>
        /// Updates a service configuration for the given service ID and returns the old configuration.
        /// </summary>
        /// <param name="serviceID">The ID of the service.</param>
        /// <param name="configData">The new configuration data (as a dictionary).</param>
        /// <param name="language">(see the openHAB REST API documentation)</param>
        /// <returns>The old configuration of the service (JSON).</returns>
        public JsonNode? UpdateServiceConfig(string serviceID, object configData, string? language = null)
            => R.Finish(() => updateServiceConfig_S(_client, R.Arg(serviceID), R.Arg(configData), R.Arg(language)));

        /// <summary>Asynchronous <see cref="UpdateServiceConfig"/>.</summary>
        public Task<JsonNode?> UpdateServiceConfigAsync(string serviceID, object configData,
                                                        string? language = null,
                                                        CancellationToken cancellationToken = default)
            => R.FinishAsync(() => updateServiceConfig_A(_client, cancellationToken, R.Arg(serviceID), R.Arg(configData), R.Arg(language)));

        /// <summary>
        /// Deletes a service configuration for the given service ID and returns the old configuration.
        /// </summary>
        /// <param name="serviceID">The ID of the service.</param>
        /// <returns>The old configuration of the service (JSON).</returns>
        public JsonNode? DeleteServiceConfig(string serviceID)
            => R.Finish(() => deleteServiceConfig_S(_client, R.Arg(serviceID)));

        /// <summary>Asynchronous <see cref="DeleteServiceConfig"/>.</summary>
        public Task<JsonNode?> DeleteServiceConfigAsync(string serviceID,
                                                        CancellationToken cancellationToken = default)
            => R.FinishAsync(() => deleteServiceConfig_A(_client, cancellationToken, R.Arg(serviceID)));

        /// <summary>
        /// Get existing multiple context service configurations for the given factory PID.
        /// </summary>
        /// <param name="serviceID">The ID of the service.</param>
        /// <param name="language">Optional language setting (as header).</param>
        /// <returns>A list of contexts (JSON).</returns>
        public JsonNode? GetServiceContexts(string serviceID, string? language = null)
            => R.Finish(() => getServiceContexts_S(_client, R.Arg(serviceID), R.Arg(language)));

        /// <summary>Asynchronous <see cref="GetServiceContexts"/>.</summary>
        public Task<JsonNode?> GetServiceContextsAsync(string serviceID, string? language = null,
                                                       CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getServiceContexts_A(_client, cancellationToken, R.Arg(serviceID), R.Arg(language)));

        static V getServices_S(OpenHABClient C, V v_language)
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
                v_response = R.Http(C, "get", R.S("/services"), v_headers, V.None, V.None);
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

        static async Task<V> getServices_A(OpenHABClient C, CancellationToken ct, V v_language)
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
                v_response = (await R.HttpAsync(C, "get", R.S("/services"), v_headers, V.None, V.None, ct).ConfigureAwait(false));
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

        static V getService_S(OpenHABClient C, V v_serviceID, V v_language)
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
                v_response = R.Http(C, "get", R.Cat(R.S("/services/"), v_serviceID), v_headers, V.None, V.None);
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
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> getService_A(OpenHABClient C, CancellationToken ct, V v_serviceID, V v_language)
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
                v_response = (await R.HttpAsync(C, "get", R.Cat(R.S("/services/"), v_serviceID), v_headers, V.None, V.None, ct).ConfigureAwait(false));
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
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V getServiceConfig_S(OpenHABClient C, V v_serviceID)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "get", R.Cat(R.S("/services/"), v_serviceID, R.S("/config")), R.Dict(("Accept", R.S("application/json"))), V.None, V.None);
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
                if (R.Eq(v_status_code, R.I(500)))
                {
                    return R.Dict(("error", R.S("Configuration can not be read due to internal error.")));
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
            else if (R.Eq(v_status_code, R.I(500)))
            {
                return R.Dict(("error", R.S("Configuration can not be read due to internal error.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> getServiceConfig_A(OpenHABClient C, CancellationToken ct, V v_serviceID)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "get", R.Cat(R.S("/services/"), v_serviceID, R.S("/config")), R.Dict(("Accept", R.S("application/json"))), V.None, V.None, ct).ConfigureAwait(false));
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
                if (R.Eq(v_status_code, R.I(500)))
                {
                    return R.Dict(("error", R.S("Configuration can not be read due to internal error.")));
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
            else if (R.Eq(v_status_code, R.I(500)))
            {
                return R.Dict(("error", R.S("Configuration can not be read due to internal error.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V updateServiceConfig_S(OpenHABClient C, V v_serviceID, V v_configData, V v_language)
        {
            V v_headers = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_headers = R.Dict(("Content-Type", R.S("application/json")), ("Accept", R.S("application/json")));
            if (R.Truthy(v_language))
            {
                R.Set(v_headers, R.S("Accept-Language"), v_language);
            }
            try
            {
                v_response = R.Http(C, "put", R.Cat(R.S("/services/"), v_serviceID, R.S("/config")), v_headers, R.Dumps(v_configData), V.None);
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
                if (R.Eq(v_status_code, R.I(500)))
                {
                    return R.Dict(("error", R.S("Configuration can not be updated due to internal error.")));
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
            else if (R.Eq(v_status_code, R.I(204)))
            {
                return R.Dict(("message", R.S("OK, no old configuration.")));
            }
            else if (R.Eq(v_status_code, R.I(500)))
            {
                return R.Dict(("error", R.S("Configuration can not be updated due to internal error.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> updateServiceConfig_A(OpenHABClient C, CancellationToken ct, V v_serviceID,
                                                   V v_configData, V v_language)
        {
            V v_headers = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_headers = R.Dict(("Content-Type", R.S("application/json")), ("Accept", R.S("application/json")));
            if (R.Truthy(v_language))
            {
                R.Set(v_headers, R.S("Accept-Language"), v_language);
            }
            try
            {
                v_response = (await R.HttpAsync(C, "put", R.Cat(R.S("/services/"), v_serviceID, R.S("/config")), v_headers, R.Dumps(v_configData), V.None, ct).ConfigureAwait(false));
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
                if (R.Eq(v_status_code, R.I(500)))
                {
                    return R.Dict(("error", R.S("Configuration can not be updated due to internal error.")));
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
            else if (R.Eq(v_status_code, R.I(204)))
            {
                return R.Dict(("message", R.S("OK, no old configuration.")));
            }
            else if (R.Eq(v_status_code, R.I(500)))
            {
                return R.Dict(("error", R.S("Configuration can not be updated due to internal error.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V deleteServiceConfig_S(OpenHABClient C, V v_serviceID)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "delete", R.Cat(R.S("/services/"), v_serviceID, R.S("/config")), R.Dict(("Accept", R.S("application/json"))), V.None, V.None);
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
                if (R.Eq(v_status_code, R.I(500)))
                {
                    return R.Dict(("error", R.S("Configuration can not be updated due to internal error.")));
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
            else if (R.Eq(v_status_code, R.I(204)))
            {
                return R.Dict(("message", R.S("OK, no old configuration.")));
            }
            else if (R.Eq(v_status_code, R.I(500)))
            {
                return R.Dict(("error", R.S("Configuration can not be updated due to internal error.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> deleteServiceConfig_A(OpenHABClient C, CancellationToken ct, V v_serviceID)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "delete", R.Cat(R.S("/services/"), v_serviceID, R.S("/config")), R.Dict(("Accept", R.S("application/json"))), V.None, V.None, ct).ConfigureAwait(false));
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
                if (R.Eq(v_status_code, R.I(500)))
                {
                    return R.Dict(("error", R.S("Configuration can not be updated due to internal error.")));
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
            else if (R.Eq(v_status_code, R.I(204)))
            {
                return R.Dict(("message", R.S("OK, no old configuration.")));
            }
            else if (R.Eq(v_status_code, R.I(500)))
            {
                return R.Dict(("error", R.S("Configuration can not be updated due to internal error.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V getServiceContexts_S(OpenHABClient C, V v_serviceID, V v_language)
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
                v_response = R.Http(C, "get", R.Cat(R.S("/services/"), v_serviceID, R.S("/contexts")), v_headers, V.None, V.None);
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

        static async Task<V> getServiceContexts_A(OpenHABClient C, CancellationToken ct, V v_serviceID,
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
                v_response = (await R.HttpAsync(C, "get", R.Cat(R.S("/services/"), v_serviceID, R.S("/contexts")), v_headers, V.None, V.None, ct).ConfigureAwait(false));
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
