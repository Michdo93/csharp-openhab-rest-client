// Generated from python-openhab-rest-client by tools/py2cs.py – do not edit.
#pragma warning disable CS1998, CS0168, CS0219, IDE0059
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using OpenHABRestClient.Internal;

namespace OpenHABRestClient
{
    /// <summary>
    /// openHAB REST API: Addons.
    /// </summary>
    public sealed class Addons
    {
        readonly OpenHABClient _client;

        /// <summary>Creates the Addons class for a connected client.</summary>
        public Addons(OpenHABClient client) => _client = client;

        /// <summary>
        /// Retrieves a list of all available add-ons.
        /// </summary>
        /// <param name="serviceID">Optional service ID to filter the results.</param>
        /// <param name="language">Optional language preference for the response.</param>
        /// <returns>A dictionary containing the add-ons data.</returns>
        public JsonNode? GetAddons(string? serviceID = null, string? language = null)
            => R.Finish(() => getAddons_S(_client, R.Arg(serviceID), R.Arg(language)));

        /// <summary>Asynchronous <see cref="GetAddons"/>.</summary>
        public Task<JsonNode?> GetAddonsAsync(string? serviceID = null, string? language = null,
                                              CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getAddons_A(_client, cancellationToken, R.Arg(serviceID), R.Arg(language)));

        /// <summary>
        /// Retrieves details of a specific add-on by its ID.
        /// </summary>
        /// <param name="addonID">The unique identifier of the add-on.</param>
        /// <param name="serviceID">Optional service ID to filter the results.</param>
        /// <param name="language">Optional language preference for the response.</param>
        /// <returns>A dictionary containing details of the specified add-on.</returns>
        public JsonNode? GetAddon(string addonID, string? serviceID = null, string? language = null)
            => R.Finish(() => getAddon_S(_client, R.Arg(addonID), R.Arg(serviceID), R.Arg(language)));

        /// <summary>Asynchronous <see cref="GetAddon"/>.</summary>
        public Task<JsonNode?> GetAddonAsync(string addonID, string? serviceID = null,
                                             string? language = null,
                                             CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getAddon_A(_client, cancellationToken, R.Arg(addonID), R.Arg(serviceID), R.Arg(language)));

        /// <summary>
        /// Retrieves the configuration of a specific add-on.
        /// </summary>
        /// <param name="addonID">The unique identifier of the add-on.</param>
        /// <param name="serviceID">Optional service ID to filter the results.</param>
        /// <returns>A dictionary containing the configuration of the specified add-on.</returns>
        public JsonNode? GetAddonConfig(string addonID, string? serviceID = null)
            => R.Finish(() => getAddonConfig_S(_client, R.Arg(addonID), R.Arg(serviceID)));

        /// <summary>Asynchronous <see cref="GetAddonConfig"/>.</summary>
        public Task<JsonNode?> GetAddonConfigAsync(string addonID, string? serviceID = null,
                                                   CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getAddonConfig_A(_client, cancellationToken, R.Arg(addonID), R.Arg(serviceID)));

        /// <summary>
        /// Updates the configuration of a specific add-on and returns the updated configuration.
        /// </summary>
        /// <param name="addonID">The unique identifier of the add-on.</param>
        /// <param name="configData">A dictionary containing the new configuration settings.</param>
        /// <param name="serviceID">Optional service ID to specify the target service.</param>
        /// <returns>A dictionary containing the updated configuration.</returns>
        public JsonNode? UpdateAddonConfig(string addonID, object configData, string? serviceID = null)
            => R.Finish(() => updateAddonConfig_S(_client, R.Arg(addonID), R.Arg(configData), R.Arg(serviceID)));

        /// <summary>Asynchronous <see cref="UpdateAddonConfig"/>.</summary>
        public Task<JsonNode?> UpdateAddonConfigAsync(string addonID, object configData,
                                                      string? serviceID = null,
                                                      CancellationToken cancellationToken = default)
            => R.FinishAsync(() => updateAddonConfig_A(_client, cancellationToken, R.Arg(addonID), R.Arg(configData), R.Arg(serviceID)));

        /// <summary>
        /// Installs an add-on by its ID.
        /// </summary>
        /// <param name="addonID">The unique identifier of the add-on.</param>
        /// <param name="serviceID">Optional service ID to specify the target service.</param>
        /// <returns>A dictionary containing the installation status.</returns>
        public JsonNode? InstallAddon(string addonID, string? serviceID = null)
            => R.Finish(() => installAddon_S(_client, R.Arg(addonID), R.Arg(serviceID)));

        /// <summary>Asynchronous <see cref="InstallAddon"/>.</summary>
        public Task<JsonNode?> InstallAddonAsync(string addonID, string? serviceID = null,
                                                 CancellationToken cancellationToken = default)
            => R.FinishAsync(() => installAddon_A(_client, cancellationToken, R.Arg(addonID), R.Arg(serviceID)));

        /// <summary>
        /// Uninstalls an add-on by its ID.
        /// </summary>
        /// <param name="addonID">The unique identifier of the add-on.</param>
        /// <param name="serviceID">Optional service ID to specify the target service.</param>
        /// <returns>A dictionary containing the uninstallation status.</returns>
        public JsonNode? UninstallAddon(string addonID, string? serviceID = null)
            => R.Finish(() => uninstallAddon_S(_client, R.Arg(addonID), R.Arg(serviceID)));

        /// <summary>Asynchronous <see cref="UninstallAddon"/>.</summary>
        public Task<JsonNode?> UninstallAddonAsync(string addonID, string? serviceID = null,
                                                   CancellationToken cancellationToken = default)
            => R.FinishAsync(() => uninstallAddon_A(_client, cancellationToken, R.Arg(addonID), R.Arg(serviceID)));

        /// <summary>
        /// Retrieves a list of all available add-on services.
        /// </summary>
        /// <param name="language">Optional language preference for the response.</param>
        /// <returns>A dictionary containing the available add-on services.</returns>
        public JsonNode? GetAddonServices(string? language = null)
            => R.Finish(() => getAddonServices_S(_client, R.Arg(language)));

        /// <summary>Asynchronous <see cref="GetAddonServices"/>.</summary>
        public Task<JsonNode?> GetAddonServicesAsync(string? language = null,
                                                     CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getAddonServices_A(_client, cancellationToken, R.Arg(language)));

        /// <summary>
        /// Retrieves a list of suggested add-ons for installation.
        /// </summary>
        /// <param name="language">Optional language preference for the response.</param>
        /// <returns>A dictionary containing suggested add-ons.</returns>
        public JsonNode? GetAddonSuggestions(string? language = null)
            => R.Finish(() => getAddonSuggestions_S(_client, R.Arg(language)));

        /// <summary>Asynchronous <see cref="GetAddonSuggestions"/>.</summary>
        public Task<JsonNode?> GetAddonSuggestionsAsync(string? language = null,
                                                        CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getAddonSuggestions_A(_client, cancellationToken, R.Arg(language)));

        /// <summary>
        /// Retrieves a list of all available add-on types.
        /// </summary>
        /// <param name="serviceID">(see the openHAB REST API documentation)</param>
        /// <param name="language">Optional language preference for the response.</param>
        /// <returns>A dictionary containing available add-on types.</returns>
        public JsonNode? GetAddonTypes(string? serviceID = null, string? language = null)
            => R.Finish(() => getAddonTypes_S(_client, R.Arg(serviceID), R.Arg(language)));

        /// <summary>Asynchronous <see cref="GetAddonTypes"/>.</summary>
        public Task<JsonNode?> GetAddonTypesAsync(string? serviceID = null, string? language = null,
                                                  CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getAddonTypes_A(_client, cancellationToken, R.Arg(serviceID), R.Arg(language)));

        /// <summary>
        /// Installs an add-on from a given URL.
        /// </summary>
        /// <param name="url">The URL of the add-on to install.</param>
        /// <returns>A dictionary containing the installation status.</returns>
        public JsonNode? InstallAddonFromUrl(string url)
            => R.Finish(() => installAddonFromUrl_S(_client, R.Arg(url)));

        /// <summary>Asynchronous <see cref="InstallAddonFromUrl"/>.</summary>
        public Task<JsonNode?> InstallAddonFromUrlAsync(string url,
                                                        CancellationToken cancellationToken = default)
            => R.FinishAsync(() => installAddonFromUrl_A(_client, cancellationToken, R.Arg(url)));

        static V getAddons_S(OpenHABClient C, V v_serviceID, V v_language)
        {
            V v_headers = V.None;
            V v_params = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_params = (R.Truthy(v_serviceID) ? R.Dict(("serviceId", v_serviceID)) : R.Dict());
            v_headers = R.Dict(("Accept", R.S("application/json")));
            if (R.Truthy(v_language))
            {
                R.Set(v_headers, R.S("Accept-Language"), v_language);
            }
            try
            {
                v_response = R.Http(C, "get", R.S("/addons"), v_headers, V.None, v_params);
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
                    return R.Dict(("error", R.S("Service not found.")));
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
                return R.Dict(("error", R.S("Service not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> getAddons_A(OpenHABClient C, CancellationToken ct, V v_serviceID, V v_language)
        {
            V v_headers = V.None;
            V v_params = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_params = (R.Truthy(v_serviceID) ? R.Dict(("serviceId", v_serviceID)) : R.Dict());
            v_headers = R.Dict(("Accept", R.S("application/json")));
            if (R.Truthy(v_language))
            {
                R.Set(v_headers, R.S("Accept-Language"), v_language);
            }
            try
            {
                v_response = (await R.HttpAsync(C, "get", R.S("/addons"), v_headers, V.None, v_params, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Service not found.")));
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
                return R.Dict(("error", R.S("Service not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V getAddon_S(OpenHABClient C, V v_addonID, V v_serviceID, V v_language)
        {
            V v_headers = V.None;
            V v_params = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_params = (R.Truthy(v_serviceID) ? R.Dict(("serviceId", v_serviceID)) : R.Dict());
            v_headers = R.Dict(("Accept", R.S("application/json")));
            if (R.Truthy(v_language))
            {
                R.Set(v_headers, R.S("Accept-Language"), v_language);
            }
            try
            {
                v_response = R.Http(C, "get", R.Cat(R.S("/addons/"), v_addonID), v_headers, V.None, v_params);
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

        static async Task<V> getAddon_A(OpenHABClient C, CancellationToken ct, V v_addonID, V v_serviceID,
                                        V v_language)
        {
            V v_headers = V.None;
            V v_params = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_params = (R.Truthy(v_serviceID) ? R.Dict(("serviceId", v_serviceID)) : R.Dict());
            v_headers = R.Dict(("Accept", R.S("application/json")));
            if (R.Truthy(v_language))
            {
                R.Set(v_headers, R.S("Accept-Language"), v_language);
            }
            try
            {
                v_response = (await R.HttpAsync(C, "get", R.Cat(R.S("/addons/"), v_addonID), v_headers, V.None, v_params, ct).ConfigureAwait(false));
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

        static V getAddonConfig_S(OpenHABClient C, V v_addonID, V v_serviceID)
        {
            V v_params = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_params = (R.Truthy(v_serviceID) ? R.Dict(("serviceId", v_serviceID)) : R.Dict());
            try
            {
                v_response = R.Http(C, "get", R.Cat(R.S("/addons/"), v_addonID, R.S("/config")), R.Dict(("Accept", R.S("application/json"))), V.None, v_params);
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
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("Add-on does not exist.")));
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
                return R.Dict(("error", R.S("Add-on does not exist.")));
            }
            else if (R.Eq(v_status_code, R.I(500)))
            {
                return R.Dict(("error", R.S("Configuration can not be read due to internal error.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> getAddonConfig_A(OpenHABClient C, CancellationToken ct, V v_addonID,
                                              V v_serviceID)
        {
            V v_params = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_params = (R.Truthy(v_serviceID) ? R.Dict(("serviceId", v_serviceID)) : R.Dict());
            try
            {
                v_response = (await R.HttpAsync(C, "get", R.Cat(R.S("/addons/"), v_addonID, R.S("/config")), R.Dict(("Accept", R.S("application/json"))), V.None, v_params, ct).ConfigureAwait(false));
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
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("Add-on does not exist.")));
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
                return R.Dict(("error", R.S("Add-on does not exist.")));
            }
            else if (R.Eq(v_status_code, R.I(500)))
            {
                return R.Dict(("error", R.S("Configuration can not be read due to internal error.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V updateAddonConfig_S(OpenHABClient C, V v_addonID, V v_configData, V v_serviceID)
        {
            V v_data = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_data = R.Copy(v_configData);
            try
            {
                v_response = R.Http(C, "put", R.Cat(R.S("/addons/"), v_addonID, R.S("/config")), R.Dict(("Content-Type", R.S("application/json")), ("Accept", R.S("application/json"))), R.Dumps(v_data), R.Dict(("serviceId", v_serviceID)));
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
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("Add-on does not exist.")));
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
                return R.Dict(("error", R.S("Add-on does not exist.")));
            }
            else if (R.Eq(v_status_code, R.I(500)))
            {
                return R.Dict(("error", R.S("Configuration can not be updated due to internal error.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> updateAddonConfig_A(OpenHABClient C, CancellationToken ct, V v_addonID,
                                                 V v_configData, V v_serviceID)
        {
            V v_data = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_data = R.Copy(v_configData);
            try
            {
                v_response = (await R.HttpAsync(C, "put", R.Cat(R.S("/addons/"), v_addonID, R.S("/config")), R.Dict(("Content-Type", R.S("application/json")), ("Accept", R.S("application/json"))), R.Dumps(v_data), R.Dict(("serviceId", v_serviceID)), ct).ConfigureAwait(false));
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
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("Add-on does not exist.")));
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
                return R.Dict(("error", R.S("Add-on does not exist.")));
            }
            else if (R.Eq(v_status_code, R.I(500)))
            {
                return R.Dict(("error", R.S("Configuration can not be updated due to internal error.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V installAddon_S(OpenHABClient C, V v_addonID, V v_serviceID)
        {
            V v_data = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_data = (R.Truthy(v_serviceID) ? R.Dict(("serviceId", v_serviceID)) : R.Dict());
            try
            {
                v_response = R.Http(C, "post", R.Cat(R.S("/addons/"), v_addonID, R.S("/install")), V.None, V.None, v_data);
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

        static async Task<V> installAddon_A(OpenHABClient C, CancellationToken ct, V v_addonID, V v_serviceID)
        {
            V v_data = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_data = (R.Truthy(v_serviceID) ? R.Dict(("serviceId", v_serviceID)) : R.Dict());
            try
            {
                v_response = (await R.HttpAsync(C, "post", R.Cat(R.S("/addons/"), v_addonID, R.S("/install")), V.None, V.None, v_data, ct).ConfigureAwait(false));
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

        static V uninstallAddon_S(OpenHABClient C, V v_addonID, V v_serviceID)
        {
            V v_data = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_data = (R.Truthy(v_serviceID) ? R.Dict(("serviceId", v_serviceID)) : R.Dict());
            try
            {
                v_response = R.Http(C, "post", R.Cat(R.S("/addons/"), v_addonID, R.S("/uninstall")), V.None, V.None, v_data);
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

        static async Task<V> uninstallAddon_A(OpenHABClient C, CancellationToken ct, V v_addonID,
                                              V v_serviceID)
        {
            V v_data = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_data = (R.Truthy(v_serviceID) ? R.Dict(("serviceId", v_serviceID)) : R.Dict());
            try
            {
                v_response = (await R.HttpAsync(C, "post", R.Cat(R.S("/addons/"), v_addonID, R.S("/uninstall")), V.None, V.None, v_data, ct).ConfigureAwait(false));
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

        static V getAddonServices_S(OpenHABClient C, V v_language)
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
                v_response = R.Http(C, "get", R.S("/addons/services"), v_headers, V.None, V.None);
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

        static async Task<V> getAddonServices_A(OpenHABClient C, CancellationToken ct, V v_language)
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
                v_response = (await R.HttpAsync(C, "get", R.S("/addons/services"), v_headers, V.None, V.None, ct).ConfigureAwait(false));
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

        static V getAddonSuggestions_S(OpenHABClient C, V v_language)
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
                v_response = R.Http(C, "get", R.S("/addons/suggestions"), v_headers, V.None, V.None);
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

        static async Task<V> getAddonSuggestions_A(OpenHABClient C, CancellationToken ct, V v_language)
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
                v_response = (await R.HttpAsync(C, "get", R.S("/addons/suggestions"), v_headers, V.None, V.None, ct).ConfigureAwait(false));
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

        static V getAddonTypes_S(OpenHABClient C, V v_serviceID, V v_language)
        {
            V v_headers = V.None;
            V v_params = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_params = (R.Truthy(v_serviceID) ? R.Dict(("serviceId", v_serviceID)) : R.Dict());
            v_headers = R.Dict(("Accept", R.S("application/json")));
            if (R.Truthy(v_language))
            {
                R.Set(v_headers, R.S("Accept-Language"), v_language);
            }
            try
            {
                v_response = R.Http(C, "get", R.S("/addons/types"), v_headers, V.None, v_params);
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
                    return R.Dict(("error", R.S("Service not found.")));
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
                return R.Dict(("error", R.S("Service not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> getAddonTypes_A(OpenHABClient C, CancellationToken ct, V v_serviceID,
                                             V v_language)
        {
            V v_headers = V.None;
            V v_params = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_params = (R.Truthy(v_serviceID) ? R.Dict(("serviceId", v_serviceID)) : R.Dict());
            v_headers = R.Dict(("Accept", R.S("application/json")));
            if (R.Truthy(v_language))
            {
                R.Set(v_headers, R.S("Accept-Language"), v_language);
            }
            try
            {
                v_response = (await R.HttpAsync(C, "get", R.S("/addons/types"), v_headers, V.None, v_params, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Service not found.")));
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
                return R.Dict(("error", R.S("Service not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V installAddonFromUrl_S(OpenHABClient C, V v_url)
        {
            V v_encoded_url = V.None;
            V v_endpoint = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_encoded_url = R.Quote(v_url, "");
            v_endpoint = R.Cat(R.S("/addons/url/"), v_encoded_url, R.S("/install"));
            try
            {
                v_response = R.Http(C, "post", v_endpoint, V.None, V.None, V.None);
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
                    return R.Dict(("error", R.S("The given URL is malformed or not valid.")));
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
            else if (R.Eq(v_status_code, R.I(400)))
            {
                return R.Dict(("error", R.S("The given URL is malformed or not valid.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> installAddonFromUrl_A(OpenHABClient C, CancellationToken ct, V v_url)
        {
            V v_encoded_url = V.None;
            V v_endpoint = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_encoded_url = R.Quote(v_url, "");
            v_endpoint = R.Cat(R.S("/addons/url/"), v_encoded_url, R.S("/install"));
            try
            {
                v_response = (await R.HttpAsync(C, "post", v_endpoint, V.None, V.None, V.None, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("The given URL is malformed or not valid.")));
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
            else if (R.Eq(v_status_code, R.I(400)))
            {
                return R.Dict(("error", R.S("The given URL is malformed or not valid.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }
    }
}
