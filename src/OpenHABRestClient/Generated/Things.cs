// Generated from python-openhab-rest-client by tools/py2cs.py – do not edit.
#pragma warning disable CS1998, CS0168, CS0219, IDE0059
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using OpenHABRestClient.Internal;

namespace OpenHABRestClient
{
    /// <summary>
    /// openHAB REST API: Things.
    /// </summary>
    public sealed class Things
    {
        readonly OpenHABClient _client;

        /// <summary>Creates the Things class for a connected client.</summary>
        public Things(OpenHABClient client) => _client = client;

        /// <summary>
        /// Get all available things.
        /// </summary>
        /// <param name="summary">If True, returns only the summary fields.</param>
        /// <param name="staticDataOnly">If True, returns a cacheable list.</param>
        /// <param name="language">The preferred language for the response.</param>
        /// <returns>JSON response with the things.</returns>
        public JsonNode? GetThings(bool summary = false, bool staticDataOnly = false, string? language = null)
            => R.Finish(() => getThings_S(_client, R.Arg(summary), R.Arg(staticDataOnly), R.Arg(language)));

        /// <summary>Asynchronous <see cref="GetThings"/>.</summary>
        public Task<JsonNode?> GetThingsAsync(bool summary = false, bool staticDataOnly = false,
                                              string? language = null,
                                              CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getThings_A(_client, cancellationToken, R.Arg(summary), R.Arg(staticDataOnly), R.Arg(language)));

        /// <summary>
        /// Creates a new thing and adds it to the registry.
        /// </summary>
        /// <param name="thingData">The JSON object containing the thing data.</param>
        /// <param name="language">The preferred language for the response.</param>
        /// <returns>The API response.</returns>
        public JsonNode? CreateThing(object thingData, string? language = null)
            => R.Finish(() => createThing_S(_client, R.Arg(thingData), R.Arg(language)));

        /// <summary>Asynchronous <see cref="CreateThing"/>.</summary>
        public Task<JsonNode?> CreateThingAsync(object thingData, string? language = null,
                                                CancellationToken cancellationToken = default)
            => R.FinishAsync(() => createThing_A(_client, cancellationToken, R.Arg(thingData), R.Arg(language)));

        /// <summary>
        /// Gets a thing by UID.
        /// </summary>
        /// <param name="thingUID">The UID of the thing.</param>
        /// <param name="language">The preferred language for the response.</param>
        /// <returns>JSON response with the thing data.</returns>
        public JsonNode? GetThing(string thingUID, string? language = null)
            => R.Finish(() => getThing_S(_client, R.Arg(thingUID), R.Arg(language)));

        /// <summary>Asynchronous <see cref="GetThing"/>.</summary>
        public Task<JsonNode?> GetThingAsync(string thingUID, string? language = null,
                                             CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getThing_A(_client, cancellationToken, R.Arg(thingUID), R.Arg(language)));

        /// <summary>
        /// Updates a thing.
        /// </summary>
        /// <param name="thingUID">The UID of the thing.</param>
        /// <param name="thingData">The JSON object containing the updated thing data.</param>
        /// <param name="language">The preferred language for the response.</param>
        /// <returns>The API response.</returns>
        public JsonNode? UpdateThing(string thingUID, object thingData, string? language = null)
            => R.Finish(() => updateThing_S(_client, R.Arg(thingUID), R.Arg(thingData), R.Arg(language)));

        /// <summary>Asynchronous <see cref="UpdateThing"/>.</summary>
        public Task<JsonNode?> UpdateThingAsync(string thingUID, object thingData, string? language = null,
                                                CancellationToken cancellationToken = default)
            => R.FinishAsync(() => updateThing_A(_client, cancellationToken, R.Arg(thingUID), R.Arg(thingData), R.Arg(language)));

        /// <summary>
        /// Removes a thing from the registry. Set 'force' to __true__ if you want the thing to be removed immediately.
        /// </summary>
        /// <param name="thingUID">The UID of the thing.</param>
        /// <param name="force">If True, the thing will be immediately removed.</param>
        /// <param name="language">The preferred language for the response.</param>
        /// <returns>The API response.</returns>
        public JsonNode? DeleteThing(string thingUID, bool force = false, string? language = null)
            => R.Finish(() => deleteThing_S(_client, R.Arg(thingUID), R.Arg(force), R.Arg(language)));

        /// <summary>Asynchronous <see cref="DeleteThing"/>.</summary>
        public Task<JsonNode?> DeleteThingAsync(string thingUID, bool force = false, string? language = null,
                                                CancellationToken cancellationToken = default)
            => R.FinishAsync(() => deleteThing_A(_client, cancellationToken, R.Arg(thingUID), R.Arg(force), R.Arg(language)));

        /// <summary>
        /// Updates a thing's configuration.
        /// </summary>
        /// <param name="thingUID">The UID of the thing.</param>
        /// <param name="configurationData">The configuration data of the thing.</param>
        /// <param name="language">The preferred language for the response.</param>
        /// <returns>The API response.</returns>
        public JsonNode? UpdateThingConfiguration(string thingUID, object configurationData,
                                                  string? language = null)
            => R.Finish(() => updateThingConfiguration_S(_client, R.Arg(thingUID), R.Arg(configurationData), R.Arg(language)));

        /// <summary>Asynchronous <see cref="UpdateThingConfiguration"/>.</summary>
        public Task<JsonNode?> UpdateThingConfigurationAsync(string thingUID, object configurationData,
                                                             string? language = null,
                                                             CancellationToken cancellationToken = default)
            => R.FinishAsync(() => updateThingConfiguration_A(_client, cancellationToken, R.Arg(thingUID), R.Arg(configurationData), R.Arg(language)));

        /// <summary>
        /// Gets the thing's configuration status.
        /// </summary>
        /// <param name="thingUID">The UID of the thing.</param>
        /// <param name="language">The preferred language for the response.</param>
        /// <returns>JSON response with the thing's configuration status.</returns>
        public JsonNode? GetThingConfigStatus(string thingUID, string? language = null)
            => R.Finish(() => getThingConfigStatus_S(_client, R.Arg(thingUID), R.Arg(language)));

        /// <summary>Asynchronous <see cref="GetThingConfigStatus"/>.</summary>
        public Task<JsonNode?> GetThingConfigStatusAsync(string thingUID, string? language = null,
                                                         CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getThingConfigStatus_A(_client, cancellationToken, R.Arg(thingUID), R.Arg(language)));

        /// <summary>
        /// Sets the thing's enabled status.
        /// </summary>
        /// <param name="thingUID">The UID of the thing.</param>
        /// <param name="enabled">If True, the thing will be enabled.</param>
        /// <param name="language">The preferred language for the response.</param>
        /// <returns>The API response.</returns>
        public JsonNode? SetThingStatus(string thingUID, bool enabled, string? language = null)
            => R.Finish(() => setThingStatus_S(_client, R.Arg(thingUID), R.Arg(enabled), R.Arg(language)));

        /// <summary>Asynchronous <see cref="SetThingStatus"/>.</summary>
        public Task<JsonNode?> SetThingStatusAsync(string thingUID, bool enabled, string? language = null,
                                                   CancellationToken cancellationToken = default)
            => R.FinishAsync(() => setThingStatus_A(_client, cancellationToken, R.Arg(thingUID), R.Arg(enabled), R.Arg(language)));

        /// <summary>
        /// enableThing
        /// </summary>
        /// <param name="thingUID">(see the openHAB REST API documentation)</param>
        public JsonNode? EnableThing(string thingUID)
            => R.Finish(() => enableThing_S(_client, R.Arg(thingUID)));

        /// <summary>Asynchronous <see cref="EnableThing"/>.</summary>
        public Task<JsonNode?> EnableThingAsync(string thingUID,
                                                CancellationToken cancellationToken = default)
            => R.FinishAsync(() => enableThing_A(_client, cancellationToken, R.Arg(thingUID)));

        /// <summary>
        /// disableThing
        /// </summary>
        /// <param name="thingUID">(see the openHAB REST API documentation)</param>
        public JsonNode? DisableThing(string thingUID)
            => R.Finish(() => disableThing_S(_client, R.Arg(thingUID)));

        /// <summary>Asynchronous <see cref="DisableThing"/>.</summary>
        public Task<JsonNode?> DisableThingAsync(string thingUID,
                                                 CancellationToken cancellationToken = default)
            => R.FinishAsync(() => disableThing_A(_client, cancellationToken, R.Arg(thingUID)));

        /// <summary>
        /// Updates the firmware of a thing.
        /// </summary>
        /// <param name="thingUID">The UID of the thing.</param>
        /// <param name="firmwareVersion">The firmware version.</param>
        /// <param name="language">The preferred language for the response.</param>
        /// <returns>The API response.</returns>
        public JsonNode? UpdateThingFirmware(string thingUID, string firmwareVersion, string? language = null)
            => R.Finish(() => updateThingFirmware_S(_client, R.Arg(thingUID), R.Arg(firmwareVersion), R.Arg(language)));

        /// <summary>Asynchronous <see cref="UpdateThingFirmware"/>.</summary>
        public Task<JsonNode?> UpdateThingFirmwareAsync(string thingUID, string firmwareVersion,
                                                        string? language = null,
                                                        CancellationToken cancellationToken = default)
            => R.FinishAsync(() => updateThingFirmware_A(_client, cancellationToken, R.Arg(thingUID), R.Arg(firmwareVersion), R.Arg(language)));

        /// <summary>
        /// Gets the thing's firmware status.
        /// </summary>
        /// <param name="thingUID">The UID of the thing.</param>
        /// <param name="language">The preferred language for the response.</param>
        /// <returns>JSON response with the firmware status.</returns>
        public JsonNode? GetThingFirmwareStatus(string thingUID, string? language = null)
            => R.Finish(() => getThingFirmwareStatus_S(_client, R.Arg(thingUID), R.Arg(language)));

        /// <summary>Asynchronous <see cref="GetThingFirmwareStatus"/>.</summary>
        public Task<JsonNode?> GetThingFirmwareStatusAsync(string thingUID, string? language = null,
                                                           CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getThingFirmwareStatus_A(_client, cancellationToken, R.Arg(thingUID), R.Arg(language)));

        /// <summary>
        /// Gets all available firmwares for the provided thing UID.
        /// </summary>
        /// <param name="thingUID">The UID of the thing.</param>
        /// <param name="language">The preferred language for the response.</param>
        /// <returns>A list of available firmwares.</returns>
        public JsonNode? GetThingFirmwares(string thingUID, string? language = null)
            => R.Finish(() => getThingFirmwares_S(_client, R.Arg(thingUID), R.Arg(language)));

        /// <summary>Asynchronous <see cref="GetThingFirmwares"/>.</summary>
        public Task<JsonNode?> GetThingFirmwaresAsync(string thingUID, string? language = null,
                                                      CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getThingFirmwares_A(_client, cancellationToken, R.Arg(thingUID), R.Arg(language)));

        /// <summary>
        /// Gets the thing's status.
        /// </summary>
        /// <param name="thingUID">The UID of the thing.</param>
        /// <param name="language">The preferred language for the response.</param>
        /// <returns>JSON response with the thing's status.</returns>
        public JsonNode? GetThingStatus(string thingUID, string? language = null)
            => R.Finish(() => getThingStatus_S(_client, R.Arg(thingUID), R.Arg(language)));

        /// <summary>Asynchronous <see cref="GetThingStatus"/>.</summary>
        public Task<JsonNode?> GetThingStatusAsync(string thingUID, string? language = null,
                                                   CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getThingStatus_A(_client, cancellationToken, R.Arg(thingUID), R.Arg(language)));

        static V getThings_S(OpenHABClient C, V v_summary, V v_staticDataOnly, V v_language)
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
                v_response = R.Http(C, "get", R.S("/things"), v_headers, V.None, R.Dict(("summary", v_summary), ("staticDataOnly", v_staticDataOnly)));
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

        static async Task<V> getThings_A(OpenHABClient C, CancellationToken ct, V v_summary,
                                         V v_staticDataOnly, V v_language)
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
                v_response = (await R.HttpAsync(C, "get", R.S("/things"), v_headers, V.None, R.Dict(("summary", v_summary), ("staticDataOnly", v_staticDataOnly)), ct).ConfigureAwait(false));
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

        static V createThing_S(OpenHABClient C, V v_thingData, V v_language)
        {
            V v_headers = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_headers = R.Dict(("Content-Type", R.S("application/json")), ("Accept", R.S("*/*")));
            if (R.Truthy(v_language))
            {
                R.Set(v_headers, R.S("Accept-Language"), v_language);
            }
            try
            {
                v_response = R.Http(C, "post", R.S("/things"), v_headers, R.Dumps(v_thingData), V.None);
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
                if (R.Eq(v_status_code, R.I(409)))
                {
                    return R.Dict(("error", R.S("A thing with the same uid already exists.")));
                }
                else if (R.Eq(v_status_code, R.I(400)))
                {
                    return R.Dict(("error", R.S("A uid must be provided, if no binding can create a thing of this type.")));
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
                return R.Dict(("error", R.S("A uid must be provided, if no binding can create a thing of this type.")));
            }
            else if (R.Eq(v_status_code, R.I(409)))
            {
                return R.Dict(("error", R.S("A thing with the same uid already exists.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> createThing_A(OpenHABClient C, CancellationToken ct, V v_thingData, V v_language)
        {
            V v_headers = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_headers = R.Dict(("Content-Type", R.S("application/json")), ("Accept", R.S("*/*")));
            if (R.Truthy(v_language))
            {
                R.Set(v_headers, R.S("Accept-Language"), v_language);
            }
            try
            {
                v_response = (await R.HttpAsync(C, "post", R.S("/things"), v_headers, R.Dumps(v_thingData), V.None, ct).ConfigureAwait(false));
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
                if (R.Eq(v_status_code, R.I(409)))
                {
                    return R.Dict(("error", R.S("A thing with the same uid already exists.")));
                }
                else if (R.Eq(v_status_code, R.I(400)))
                {
                    return R.Dict(("error", R.S("A uid must be provided, if no binding can create a thing of this type.")));
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
                return R.Dict(("error", R.S("A uid must be provided, if no binding can create a thing of this type.")));
            }
            else if (R.Eq(v_status_code, R.I(409)))
            {
                return R.Dict(("error", R.S("A thing with the same uid already exists.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V getThing_S(OpenHABClient C, V v_thingUID, V v_language)
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
                v_response = R.Http(C, "get", R.Cat(R.S("/things/"), v_thingUID), v_headers, V.None, V.None);
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
                    return R.Dict(("error", R.S("Thing not found.")));
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
                return R.Dict(("error", R.S("THing not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> getThing_A(OpenHABClient C, CancellationToken ct, V v_thingUID, V v_language)
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
                v_response = (await R.HttpAsync(C, "get", R.Cat(R.S("/things/"), v_thingUID), v_headers, V.None, V.None, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Thing not found.")));
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
                return R.Dict(("error", R.S("THing not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V updateThing_S(OpenHABClient C, V v_thingUID, V v_thingData, V v_language)
        {
            V v_headers = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_headers = R.Dict(("Content-Type", R.S("application/json")), ("Accept", R.S("*/*")));
            if (R.Truthy(v_language))
            {
                R.Set(v_headers, R.S("Accept-Language"), v_language);
            }
            try
            {
                v_response = R.Http(C, "put", R.Cat(R.S("/things/"), v_thingUID), v_headers, R.Dumps(v_thingData), V.None);
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
                if (R.Eq(v_status_code, R.I(409)))
                {
                    return R.Dict(("error", R.S("Thing could not be updated as it is not editable.")));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("Thing not found.")));
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
                return R.Dict(("error", R.S("Thing not found.")));
            }
            else if (R.Eq(v_status_code, R.I(409)))
            {
                return R.Dict(("error", R.S("Thing could not be updated as it is not editable.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> updateThing_A(OpenHABClient C, CancellationToken ct, V v_thingUID, V v_thingData,
                                           V v_language)
        {
            V v_headers = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_headers = R.Dict(("Content-Type", R.S("application/json")), ("Accept", R.S("*/*")));
            if (R.Truthy(v_language))
            {
                R.Set(v_headers, R.S("Accept-Language"), v_language);
            }
            try
            {
                v_response = (await R.HttpAsync(C, "put", R.Cat(R.S("/things/"), v_thingUID), v_headers, R.Dumps(v_thingData), V.None, ct).ConfigureAwait(false));
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
                if (R.Eq(v_status_code, R.I(409)))
                {
                    return R.Dict(("error", R.S("Thing could not be updated as it is not editable.")));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("Thing not found.")));
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
                return R.Dict(("error", R.S("Thing not found.")));
            }
            else if (R.Eq(v_status_code, R.I(409)))
            {
                return R.Dict(("error", R.S("Thing could not be updated as it is not editable.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V deleteThing_S(OpenHABClient C, V v_thingUID, V v_force, V v_language)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "delete", R.Cat(R.S("/things/"), v_thingUID), (R.Truthy(v_language) ? R.Dict(("Accept-Language", v_language)) : R.Dict()), V.None, R.Dict(("force", v_force)));
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
                if (R.Eq(v_status_code, R.I(409)))
                {
                    return R.Dict(("error", R.S("Thing could not be deleted because it's not editable.")));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("Thing not found.")));
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
                return R.Dict(("message", R.S("OK, was deleted.")));
            }
            else if (R.Eq(v_status_code, R.I(202)))
            {
                return R.Dict(("message", R.S("ACCEPTED for asynchronous deletion.")));
            }
            else if (R.Eq(v_status_code, R.I(404)))
            {
                return R.Dict(("error", R.S("Thing not found.")));
            }
            else if (R.Eq(v_status_code, R.I(409)))
            {
                return R.Dict(("error", R.S("Thing could not be deleted because it's not editable.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> deleteThing_A(OpenHABClient C, CancellationToken ct, V v_thingUID, V v_force,
                                           V v_language)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "delete", R.Cat(R.S("/things/"), v_thingUID), (R.Truthy(v_language) ? R.Dict(("Accept-Language", v_language)) : R.Dict()), V.None, R.Dict(("force", v_force)), ct).ConfigureAwait(false));
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
                if (R.Eq(v_status_code, R.I(409)))
                {
                    return R.Dict(("error", R.S("Thing could not be deleted because it's not editable.")));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("Thing not found.")));
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
                return R.Dict(("message", R.S("OK, was deleted.")));
            }
            else if (R.Eq(v_status_code, R.I(202)))
            {
                return R.Dict(("message", R.S("ACCEPTED for asynchronous deletion.")));
            }
            else if (R.Eq(v_status_code, R.I(404)))
            {
                return R.Dict(("error", R.S("Thing not found.")));
            }
            else if (R.Eq(v_status_code, R.I(409)))
            {
                return R.Dict(("error", R.S("Thing could not be deleted because it's not editable.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V updateThingConfiguration_S(OpenHABClient C, V v_thingUID, V v_configurationData,
                                            V v_language)
        {
            V v_headers = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_headers = R.Dict(("Content-Type", R.S("application/json")), ("Accept", R.S("*/*")));
            if (R.Truthy(v_language))
            {
                R.Set(v_headers, R.S("Accept-Language"), v_language);
            }
            try
            {
                v_response = R.Http(C, "put", R.Cat(R.S("/things/"), v_thingUID, R.S("/config")), v_headers, R.Dumps(v_configurationData), V.None);
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
                    return R.Dict(("error", R.S("Configuration of the thing is not valid.")));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("Thing not found.")));
                }
                else if (R.Eq(v_status_code, R.I(409)))
                {
                    return R.Dict(("error", R.S("Thing could not be updated as it is not editable.")));
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
                return R.Dict(("error", R.S("Configuration of the thing is not valid.")));
            }
            else if (R.Eq(v_status_code, R.I(404)))
            {
                return R.Dict(("error", R.S("Thing not found.")));
            }
            else if (R.Eq(v_status_code, R.I(409)))
            {
                return R.Dict(("error", R.S("Thing could not be updated as it is not editable.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> updateThingConfiguration_A(OpenHABClient C, CancellationToken ct, V v_thingUID,
                                                        V v_configurationData, V v_language)
        {
            V v_headers = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_headers = R.Dict(("Content-Type", R.S("application/json")), ("Accept", R.S("*/*")));
            if (R.Truthy(v_language))
            {
                R.Set(v_headers, R.S("Accept-Language"), v_language);
            }
            try
            {
                v_response = (await R.HttpAsync(C, "put", R.Cat(R.S("/things/"), v_thingUID, R.S("/config")), v_headers, R.Dumps(v_configurationData), V.None, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Configuration of the thing is not valid.")));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("Thing not found.")));
                }
                else if (R.Eq(v_status_code, R.I(409)))
                {
                    return R.Dict(("error", R.S("Thing could not be updated as it is not editable.")));
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
                return R.Dict(("error", R.S("Configuration of the thing is not valid.")));
            }
            else if (R.Eq(v_status_code, R.I(404)))
            {
                return R.Dict(("error", R.S("Thing not found.")));
            }
            else if (R.Eq(v_status_code, R.I(409)))
            {
                return R.Dict(("error", R.S("Thing could not be updated as it is not editable.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V getThingConfigStatus_S(OpenHABClient C, V v_thingUID, V v_language)
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
                v_response = R.Http(C, "get", R.Cat(R.S("/things/"), v_thingUID, R.S("/config/status")), v_headers, V.None, V.None);
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
                    return R.Dict(("error", R.S("Thing not found.")));
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
                return R.Dict(("error", R.S("Thing not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> getThingConfigStatus_A(OpenHABClient C, CancellationToken ct, V v_thingUID,
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
                v_response = (await R.HttpAsync(C, "get", R.Cat(R.S("/things/"), v_thingUID, R.S("/config/status")), v_headers, V.None, V.None, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Thing not found.")));
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
                return R.Dict(("error", R.S("Thing not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V setThingStatus_S(OpenHABClient C, V v_thingUID, V v_enabled, V v_language)
        {
            V v_headers = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_headers = R.Dict(("Content-Type", R.S("text/plain")), ("Accept", R.S("*/*")));
            if (R.Truthy(v_language))
            {
                R.Set(v_headers, R.S("Accept-Language"), v_language);
            }
            try
            {
                v_response = R.Http(C, "put", R.Cat(R.S("/things/"), v_thingUID, R.S("/enable")), v_headers, (R.Truthy(v_enabled) ? R.S("true") : R.S("false")), V.None);
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
                    return R.Dict(("error", R.S("Thing not found.")));
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
                return R.Dict(("error", R.S("Thing not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> setThingStatus_A(OpenHABClient C, CancellationToken ct, V v_thingUID,
                                              V v_enabled, V v_language)
        {
            V v_headers = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_headers = R.Dict(("Content-Type", R.S("text/plain")), ("Accept", R.S("*/*")));
            if (R.Truthy(v_language))
            {
                R.Set(v_headers, R.S("Accept-Language"), v_language);
            }
            try
            {
                v_response = (await R.HttpAsync(C, "put", R.Cat(R.S("/things/"), v_thingUID, R.S("/enable")), v_headers, (R.Truthy(v_enabled) ? R.S("true") : R.S("false")), V.None, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Thing not found.")));
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
                return R.Dict(("error", R.S("Thing not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V enableThing_S(OpenHABClient C, V v_thingUID)
        {
            return setThingStatus_S(C, v_thingUID, R.B(true), V.None);
        }

        static async Task<V> enableThing_A(OpenHABClient C, CancellationToken ct, V v_thingUID)
        {
            return (await setThingStatus_A(C, ct, v_thingUID, R.B(true), V.None).ConfigureAwait(false));
        }

        static V disableThing_S(OpenHABClient C, V v_thingUID)
        {
            return setThingStatus_S(C, v_thingUID, R.B(false), V.None);
        }

        static async Task<V> disableThing_A(OpenHABClient C, CancellationToken ct, V v_thingUID)
        {
            return (await setThingStatus_A(C, ct, v_thingUID, R.B(false), V.None).ConfigureAwait(false));
        }

        static V updateThingFirmware_S(OpenHABClient C, V v_thingUID, V v_firmwareVersion, V v_language)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "put", R.Cat(R.S("/things/"), v_thingUID, R.S("/firmware/"), v_firmwareVersion), (R.Truthy(v_language) ? R.Dict(("Accept-Language", v_language)) : R.Dict()), V.None, V.None);
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
                    return R.Dict(("error", R.S("Firmware update preconditions not satisfied.")));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("Thing not found.")));
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
                return R.Dict(("error", R.S("Thing not found.")));
            }
            else if (R.Eq(v_status_code, R.I(400)))
            {
                return R.Dict(("error", R.S("Firmware update preconditions not satisfied.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> updateThingFirmware_A(OpenHABClient C, CancellationToken ct, V v_thingUID,
                                                   V v_firmwareVersion, V v_language)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "put", R.Cat(R.S("/things/"), v_thingUID, R.S("/firmware/"), v_firmwareVersion), (R.Truthy(v_language) ? R.Dict(("Accept-Language", v_language)) : R.Dict()), V.None, V.None, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Firmware update preconditions not satisfied.")));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("Thing not found.")));
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
                return R.Dict(("error", R.S("Thing not found.")));
            }
            else if (R.Eq(v_status_code, R.I(400)))
            {
                return R.Dict(("error", R.S("Firmware update preconditions not satisfied.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V getThingFirmwareStatus_S(OpenHABClient C, V v_thingUID, V v_language)
        {
            V v_headers = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_headers = R.Dict(("Accept", R.S("*/*")));
            if (R.Truthy(v_language))
            {
                R.Set(v_headers, R.S("Accept-Language"), v_language);
            }
            try
            {
                v_response = R.Http(C, "get", R.Cat(R.S("/things/"), v_thingUID, R.S("/firmware/status")), v_headers, V.None, V.None);
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
            else if (R.Eq(v_status_code, R.I(204)))
            {
                return R.Dict(("error", R.S("No firmware status provided by this Thing.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> getThingFirmwareStatus_A(OpenHABClient C, CancellationToken ct, V v_thingUID,
                                                      V v_language)
        {
            V v_headers = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_headers = R.Dict(("Accept", R.S("*/*")));
            if (R.Truthy(v_language))
            {
                R.Set(v_headers, R.S("Accept-Language"), v_language);
            }
            try
            {
                v_response = (await R.HttpAsync(C, "get", R.Cat(R.S("/things/"), v_thingUID, R.S("/firmware/status")), v_headers, V.None, V.None, ct).ConfigureAwait(false));
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
            else if (R.Eq(v_status_code, R.I(204)))
            {
                return R.Dict(("error", R.S("No firmware status provided by this Thing.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V getThingFirmwares_S(OpenHABClient C, V v_thingUID, V v_language)
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
                v_response = R.Http(C, "get", R.Cat(R.S("/things/"), v_thingUID, R.S("/firmwares")), v_headers, V.None, V.None);
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
            else if (R.Eq(v_status_code, R.I(204)))
            {
                return R.Dict(("error", R.S("No firmwares found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> getThingFirmwares_A(OpenHABClient C, CancellationToken ct, V v_thingUID,
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
                v_response = (await R.HttpAsync(C, "get", R.Cat(R.S("/things/"), v_thingUID, R.S("/firmwares")), v_headers, V.None, V.None, ct).ConfigureAwait(false));
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
            else if (R.Eq(v_status_code, R.I(204)))
            {
                return R.Dict(("error", R.S("No firmwares found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V getThingStatus_S(OpenHABClient C, V v_thingUID, V v_language)
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
                v_response = R.Http(C, "get", R.Cat(R.S("/things/"), v_thingUID, R.S("/status")), v_headers, V.None, V.None);
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
                    return R.Dict(("error", R.S("Thing not found.")));
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
                return R.Dict(("error", R.S("Thing not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> getThingStatus_A(OpenHABClient C, CancellationToken ct, V v_thingUID,
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
                v_response = (await R.HttpAsync(C, "get", R.Cat(R.S("/things/"), v_thingUID, R.S("/status")), v_headers, V.None, V.None, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Thing not found.")));
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
                return R.Dict(("error", R.S("Thing not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }
    }
}
