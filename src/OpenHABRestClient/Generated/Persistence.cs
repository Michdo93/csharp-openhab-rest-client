// Generated from python-openhab-rest-client by tools/py2cs.py – do not edit.
#pragma warning disable CS1998, CS0168, CS0219, IDE0059
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using OpenHABRestClient.Internal;

namespace OpenHABRestClient
{
    /// <summary>
    /// openHAB REST API: Persistence.
    /// </summary>
    public sealed class Persistence
    {
        readonly OpenHABClient _client;

        /// <summary>Creates the Persistence class for a connected client.</summary>
        public Persistence(OpenHABClient client) => _client = client;

        /// <summary>
        /// Gets a list of persistence services.
        /// </summary>
        /// <param name="language">(see the openHAB REST API documentation)</param>
        /// <returns>A list of persistence services with IDs, labels, and types.</returns>
        public JsonNode? GetServices(string? language = null)
            => R.Finish(() => getServices_S(_client, R.Arg(language)));

        /// <summary>Asynchronous <see cref="GetServices"/>.</summary>
        public Task<JsonNode?> GetServicesAsync(string? language = null,
                                                CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getServices_A(_client, cancellationToken, R.Arg(language)));

        /// <summary>
        /// Gets a persistence service configuration.
        /// </summary>
        /// <param name="serviceID">The ID of the persistence service.</param>
        /// <returns>The configuration of the service.</returns>
        public JsonNode? GetServiceConfiguration(string serviceID)
            => R.Finish(() => getServiceConfiguration_S(_client, R.Arg(serviceID)));

        /// <summary>Asynchronous <see cref="GetServiceConfiguration"/>.</summary>
        public Task<JsonNode?> GetServiceConfigurationAsync(string serviceID,
                                                            CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getServiceConfiguration_A(_client, cancellationToken, R.Arg(serviceID)));

        /// <summary>
        /// Sets a persistence service configuration.
        /// </summary>
        /// <param name="serviceID">The ID of the persistence service.</param>
        /// <param name="config">The configuration data.</param>
        /// <returns>The response from the API after modification.</returns>
        public JsonNode? SetServiceConfiguration(string serviceID, object config)
            => R.Finish(() => setServiceConfiguration_S(_client, R.Arg(serviceID), R.Arg(config)));

        /// <summary>Asynchronous <see cref="SetServiceConfiguration"/>.</summary>
        public Task<JsonNode?> SetServiceConfigurationAsync(string serviceID, object config,
                                                            CancellationToken cancellationToken = default)
            => R.FinishAsync(() => setServiceConfiguration_A(_client, cancellationToken, R.Arg(serviceID), R.Arg(config)));

        /// <summary>
        /// Deletes a persistence service configuration.
        /// </summary>
        /// <param name="serviceID">The ID of the persistence service.</param>
        /// <returns>The response from the API after deleting the configuration.</returns>
        public JsonNode? DeleteServiceConfiguration(string serviceID)
            => R.Finish(() => deleteServiceConfiguration_S(_client, R.Arg(serviceID)));

        /// <summary>Asynchronous <see cref="DeleteServiceConfiguration"/>.</summary>
        public Task<JsonNode?> DeleteServiceConfigurationAsync(string serviceID,
                                                               CancellationToken cancellationToken = default)
            => R.FinishAsync(() => deleteServiceConfiguration_A(_client, cancellationToken, R.Arg(serviceID)));

        /// <summary>
        /// Gets a list of items available via a specific persistence service.
        /// </summary>
        /// <param name="serviceID">Optional; The ID of the persistence service (default service if omitted).</param>
        /// <param name="itemName">Optional; Only return information for this item.</param>
        /// <returns>A list of items with their last and earliest timestamps.</returns>
        public JsonNode? GetItemsFromService(string? serviceID = null, string? itemName = null)
            => R.Finish(() => getItemsFromService_S(_client, R.Arg(serviceID), R.Arg(itemName)));

        /// <summary>Asynchronous <see cref="GetItemsFromService"/>.</summary>
        public Task<JsonNode?> GetItemsFromServiceAsync(string? serviceID = null, string? itemName = null,
                                                        CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getItemsFromService_A(_client, cancellationToken, R.Arg(serviceID), R.Arg(itemName)));

        /// <summary>
        /// Gets item persistence data from the persistence service.
        /// </summary>
        /// <param name="itemName">The name of the item.</param>
        /// <param name="serviceID">Optional; The ID of the persistence service. If omitted, the default service is used.</param>
        /// <param name="startTime">Optional; Start time (ISO 8601, e.g. "2026-10-30T00:00:00.000Z"). Defaults to 1 day before `endTime`.</param>
        /// <param name="endTime">Optional; End time (ISO 8601). Defaults to the current time.</param>
        /// <param name="page">Optional; Page number, starting at 0. Paging is only active if `pageLength` is set as well.</param>
        /// <param name="pageLength">Optional; Number of data points per page. Without it, all data points are returned.</param>
        /// <param name="boundary">Optional; Also return the values just before and after the time range (default: False).</param>
        /// <param name="itemState">Optional; Add the current item state at the end of the series (default: False).</param>
        /// <param name="displayState">Optional; Add a formatted display state to every data point (openHAB 5.0+).</param>
        /// <param name="language">Optional; Value for the "Accept-Language" header.</param>
        /// <returns>The retrieved data points of the item.</returns>
        public JsonNode? GetItemPersistenceData(string itemName, string? serviceID = null,
                                                string? startTime = null, string? endTime = null,
                                                int? page = null, int? pageLength = null,
                                                bool boundary = false, bool itemState = false,
                                                bool? displayState = null, string? language = null)
            => R.Finish(() => getItemPersistenceData_S(_client, R.Arg(itemName), R.Arg(serviceID), R.Arg(startTime), R.Arg(endTime), R.Arg(page), R.Arg(pageLength), R.Arg(boundary), R.Arg(itemState), R.Arg(displayState), R.Arg(language)));

        /// <summary>Asynchronous <see cref="GetItemPersistenceData"/>.</summary>
        public Task<JsonNode?> GetItemPersistenceDataAsync(string itemName, string? serviceID = null,
                                                           string? startTime = null, string? endTime = null,
                                                           int? page = null, int? pageLength = null,
                                                           bool boundary = false, bool itemState = false,
                                                           bool? displayState = null, string? language = null,
                                                           CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getItemPersistenceData_A(_client, cancellationToken, R.Arg(itemName), R.Arg(serviceID), R.Arg(startTime), R.Arg(endTime), R.Arg(page), R.Arg(pageLength), R.Arg(boundary), R.Arg(itemState), R.Arg(displayState), R.Arg(language)));

        /// <summary>
        /// Stores item persistence data into the persistence service.
        /// </summary>
        /// <param name="itemName">The name of the item.</param>
        /// <param name="time">The time of the storage.</param>
        /// <param name="state">The state of the item to be stored.</param>
        /// <param name="serviceID">The ID of the persistence service.</param>
        /// <returns>The response from the API after storing the data.</returns>
        public JsonNode? StoreItemData(string itemName, string time, string state, string? serviceID = null)
            => R.Finish(() => storeItemData_S(_client, R.Arg(itemName), R.Arg(time), R.Arg(state), R.Arg(serviceID)));

        /// <summary>Asynchronous <see cref="StoreItemData"/>.</summary>
        public Task<JsonNode?> StoreItemDataAsync(string itemName, string time, string state,
                                                  string? serviceID = null,
                                                  CancellationToken cancellationToken = default)
            => R.FinishAsync(() => storeItemData_A(_client, cancellationToken, R.Arg(itemName), R.Arg(time), R.Arg(state), R.Arg(serviceID)));

        /// <summary>
        /// Deletes item persistence data from a specific persistence service in a given time range.
        /// </summary>
        /// <param name="itemName">The name of the item.</param>
        /// <param name="startTime">The start time of the data to be deleted.</param>
        /// <param name="endTime">The end time of the data to be deleted.</param>
        /// <param name="serviceID">The ID of the persistence service.</param>
        /// <returns>The response from the API after deleting the data.</returns>
        public JsonNode? DeleteItemData(string itemName, string startTime, string endTime, string serviceID)
            => R.Finish(() => deleteItemData_S(_client, R.Arg(itemName), R.Arg(startTime), R.Arg(endTime), R.Arg(serviceID)));

        /// <summary>Asynchronous <see cref="DeleteItemData"/>.</summary>
        public Task<JsonNode?> DeleteItemDataAsync(string itemName, string startTime, string endTime,
                                                   string serviceID,
                                                   CancellationToken cancellationToken = default)
            => R.FinishAsync(() => deleteItemData_A(_client, cancellationToken, R.Arg(itemName), R.Arg(startTime), R.Arg(endTime), R.Arg(serviceID)));

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
                v_response = R.Http(C, "get", R.S("/persistence"), v_headers, V.None, V.None);
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
                v_response = (await R.HttpAsync(C, "get", R.S("/persistence"), v_headers, V.None, V.None, ct).ConfigureAwait(false));
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

        static V getServiceConfiguration_S(OpenHABClient C, V v_serviceID)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "get", R.Cat(R.S("/persistence/"), v_serviceID), R.Dict(("Accept", R.S("application/json"))), V.None, V.None);
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
                    return R.Dict(("error", R.S("Service configuration not found.")));
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
                return R.Dict(("error", R.S("Service configuration not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> getServiceConfiguration_A(OpenHABClient C, CancellationToken ct, V v_serviceID)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "get", R.Cat(R.S("/persistence/"), v_serviceID), R.Dict(("Accept", R.S("application/json"))), V.None, V.None, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Service configuration not found.")));
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
                return R.Dict(("error", R.S("Service configuration not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V setServiceConfiguration_S(OpenHABClient C, V v_serviceID, V v_config)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                R.Set(v_config, R.S("serviceId"), v_serviceID);
                v_response = R.Http(C, "put", R.Cat(R.S("/persistence/"), v_serviceID), R.Dict(("Content-Type", R.S("application/json")), ("Accept", R.S("application/json"))), R.Dumps(v_config), V.None);
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
                    return R.Dict(("error", R.S("Payload invalid.")));
                }
                else if (R.Eq(v_status_code, R.I(405)))
                {
                    return R.Dict(("error", R.S("PersistenceServiceConfiguration not editable.")));
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
            else if (R.Eq(v_status_code, R.I(201)))
            {
                return R.Dict(("message", R.S("PersistenceServiceConfiguration created.")));
            }
            else if (R.Eq(v_status_code, R.I(400)))
            {
                return R.Dict(("error", R.S("Payload invalid.")));
            }
            else if (R.Eq(v_status_code, R.I(405)))
            {
                return R.Dict(("error", R.S("PersistenceServiceConfiguration not editable.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> setServiceConfiguration_A(OpenHABClient C, CancellationToken ct, V v_serviceID,
                                                       V v_config)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                R.Set(v_config, R.S("serviceId"), v_serviceID);
                v_response = (await R.HttpAsync(C, "put", R.Cat(R.S("/persistence/"), v_serviceID), R.Dict(("Content-Type", R.S("application/json")), ("Accept", R.S("application/json"))), R.Dumps(v_config), V.None, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Payload invalid.")));
                }
                else if (R.Eq(v_status_code, R.I(405)))
                {
                    return R.Dict(("error", R.S("PersistenceServiceConfiguration not editable.")));
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
            else if (R.Eq(v_status_code, R.I(201)))
            {
                return R.Dict(("message", R.S("PersistenceServiceConfiguration created.")));
            }
            else if (R.Eq(v_status_code, R.I(400)))
            {
                return R.Dict(("error", R.S("Payload invalid.")));
            }
            else if (R.Eq(v_status_code, R.I(405)))
            {
                return R.Dict(("error", R.S("PersistenceServiceConfiguration not editable.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V deleteServiceConfiguration_S(OpenHABClient C, V v_serviceID)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "delete", R.Cat(R.S("/persistence/"), v_serviceID), V.None, V.None, V.None);
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
                    return R.Dict(("error", R.S("Payload invalid.")));
                }
                else if (R.Eq(v_status_code, R.I(405)))
                {
                    return R.Dict(("error", R.S("PersistenceServiceConfiguration not editable.")));
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
                return R.Dict(("error", R.S("Payload invalid.")));
            }
            else if (R.Eq(v_status_code, R.I(405)))
            {
                return R.Dict(("error", R.S("PersistenceServiceConfiguration not editable.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> deleteServiceConfiguration_A(OpenHABClient C, CancellationToken ct,
                                                          V v_serviceID)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "delete", R.Cat(R.S("/persistence/"), v_serviceID), V.None, V.None, V.None, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Payload invalid.")));
                }
                else if (R.Eq(v_status_code, R.I(405)))
                {
                    return R.Dict(("error", R.S("PersistenceServiceConfiguration not editable.")));
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
                return R.Dict(("error", R.S("Payload invalid.")));
            }
            else if (R.Eq(v_status_code, R.I(405)))
            {
                return R.Dict(("error", R.S("PersistenceServiceConfiguration not editable.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V getItemsFromService_S(OpenHABClient C, V v_serviceID, V v_itemName)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "get", R.S("/persistence/items"), R.Dict(("Accept", R.S("application/json"))), V.None, R.Dict(("serviceId", v_serviceID), ("itemName", v_itemName)));
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
                    return R.Dict(("error", R.S("Unknown persistence service.")));
                }
                if (R.Eq(v_status_code, R.I(405)))
                {
                    return R.Dict(("error", R.S("The persistence service does not provide item information.")));
                }
                return R.Dict(("error", R.Cat(R.S("HTTP error "), v_status_code, R.S(": "), R.ExcStr(e_err))));
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

        static async Task<V> getItemsFromService_A(OpenHABClient C, CancellationToken ct, V v_serviceID,
                                                   V v_itemName)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "get", R.S("/persistence/items"), R.Dict(("Accept", R.S("application/json"))), V.None, R.Dict(("serviceId", v_serviceID), ("itemName", v_itemName)), ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Unknown persistence service.")));
                }
                if (R.Eq(v_status_code, R.I(405)))
                {
                    return R.Dict(("error", R.S("The persistence service does not provide item information.")));
                }
                return R.Dict(("error", R.Cat(R.S("HTTP error "), v_status_code, R.S(": "), R.ExcStr(e_err))));
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

        static V getItemPersistenceData_S(OpenHABClient C, V v_itemName, V v_serviceID, V v_startTime,
                                          V v_endTime, V v_page, V v_pageLength, V v_boundary, V v_itemState,
                                          V v_displayState, V v_language)
        {
            V v_headers = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            if (R.Truthy((R.Bool(!R.IsNone(v_pageLength)) is var t_1 ? (R.Truthy(t_1) ? R.Bool(R.IsNone(v_page)) : t_1) : V.None)))
            {
                v_page = R.I(0);
            }
            v_headers = R.Dict(("Accept", R.S("application/json")));
            if (R.Truthy(v_language))
            {
                R.Set(v_headers, R.S("Accept-Language"), v_language);
            }
            try
            {
                v_response = R.Http(C, "get", R.Cat(R.S("/persistence/items/"), v_itemName), v_headers, V.None, R.Dict(("serviceId", v_serviceID), ("starttime", v_startTime), ("endtime", v_endTime), ("page", v_page), ("pagelength", v_pageLength), ("boundary", v_boundary), ("itemState", v_itemState), ("displayState", v_displayState)));
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
                    return R.Dict(("error", R.S("Unknown Item or persistence service.")));
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
                return R.Dict(("error", R.S("Unknown Item or persistence service.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> getItemPersistenceData_A(OpenHABClient C, CancellationToken ct, V v_itemName,
                                                      V v_serviceID, V v_startTime, V v_endTime, V v_page,
                                                      V v_pageLength, V v_boundary, V v_itemState,
                                                      V v_displayState, V v_language)
        {
            V v_headers = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            if (R.Truthy((R.Bool(!R.IsNone(v_pageLength)) is var t_1 ? (R.Truthy(t_1) ? R.Bool(R.IsNone(v_page)) : t_1) : V.None)))
            {
                v_page = R.I(0);
            }
            v_headers = R.Dict(("Accept", R.S("application/json")));
            if (R.Truthy(v_language))
            {
                R.Set(v_headers, R.S("Accept-Language"), v_language);
            }
            try
            {
                v_response = (await R.HttpAsync(C, "get", R.Cat(R.S("/persistence/items/"), v_itemName), v_headers, V.None, R.Dict(("serviceId", v_serviceID), ("starttime", v_startTime), ("endtime", v_endTime), ("page", v_page), ("pagelength", v_pageLength), ("boundary", v_boundary), ("itemState", v_itemState), ("displayState", v_displayState)), ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Unknown Item or persistence service.")));
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
                return R.Dict(("error", R.S("Unknown Item or persistence service.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V storeItemData_S(OpenHABClient C, V v_itemName, V v_time, V v_state, V v_serviceID)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "put", R.Cat(R.S("/persistence/items/"), v_itemName), V.None, V.None, R.Dict(("serviceId", v_serviceID), ("time", v_time), ("state", v_state)));
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
                    return R.Dict(("error", R.S("Unknown Item or persistence service.")));
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
                return R.Dict(("error", R.S("Unknown Item or persistence service.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> storeItemData_A(OpenHABClient C, CancellationToken ct, V v_itemName, V v_time,
                                             V v_state, V v_serviceID)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "put", R.Cat(R.S("/persistence/items/"), v_itemName), V.None, V.None, R.Dict(("serviceId", v_serviceID), ("time", v_time), ("state", v_state)), ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Unknown Item or persistence service.")));
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
                return R.Dict(("error", R.S("Unknown Item or persistence service.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V deleteItemData_S(OpenHABClient C, V v_itemName, V v_startTime, V v_endTime, V v_serviceID)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "delete", R.Cat(R.S("/persistence/items/"), v_itemName), R.Dict(("Accept", R.S("application/json"))), V.None, R.Dict(("serviceId", v_serviceID), ("starttime", v_startTime), ("endtime", v_endTime)));
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
                    return R.Dict(("error", R.Cat(R.S("Invalid filter parameters or service not modifiable: "), R.ExcStr(e_err))));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("Unknown persistence service.")));
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
                return R.Dict(("error", R.S("Unknown persistence service.")));
            }
            else if (R.Eq(v_status_code, R.I(400)))
            {
                return R.Dict(("error", R.S("Invalid filter parameters.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> deleteItemData_A(OpenHABClient C, CancellationToken ct, V v_itemName,
                                              V v_startTime, V v_endTime, V v_serviceID)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "delete", R.Cat(R.S("/persistence/items/"), v_itemName), R.Dict(("Accept", R.S("application/json"))), V.None, R.Dict(("serviceId", v_serviceID), ("starttime", v_startTime), ("endtime", v_endTime)), ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.Cat(R.S("Invalid filter parameters or service not modifiable: "), R.ExcStr(e_err))));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("Unknown persistence service.")));
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
                return R.Dict(("error", R.S("Unknown persistence service.")));
            }
            else if (R.Eq(v_status_code, R.I(400)))
            {
                return R.Dict(("error", R.S("Invalid filter parameters.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }
    }
}
