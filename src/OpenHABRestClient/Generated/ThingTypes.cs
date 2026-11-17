// Generated from python-openhab-rest-client by tools/py2cs.py – do not edit.
#pragma warning disable CS1998, CS0168, CS0219, IDE0059
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using OpenHABRestClient.Internal;

namespace OpenHABRestClient
{
    /// <summary>
    /// openHAB REST API: ThingTypes.
    /// </summary>
    public sealed class ThingTypes
    {
        readonly OpenHABClient _client;

        /// <summary>Creates the ThingTypes class for a connected client.</summary>
        public ThingTypes(OpenHABClient client) => _client = client;

        /// <summary>
        /// Gets all available thing types without config description, channels, and properties.
        /// </summary>
        /// <param name="bindingID">(Optional) Filter by binding ID.</param>
        /// <param name="language">(Optional) Language setting for the Accept-Language header.</param>
        /// <returns>A list of thing types.</returns>
        public JsonNode? GetThingTypes(string? bindingID = null, string? language = null)
            => R.Finish(() => getThingTypes_S(_client, R.Arg(bindingID), R.Arg(language)));

        /// <summary>Asynchronous <see cref="GetThingTypes"/>.</summary>
        public Task<JsonNode?> GetThingTypesAsync(string? bindingID = null, string? language = null,
                                                  CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getThingTypes_A(_client, cancellationToken, R.Arg(bindingID), R.Arg(language)));

        /// <summary>
        /// Gets a thing type by UID.
        /// </summary>
        /// <param name="thingTypeUID">The UID of the thing type.</param>
        /// <param name="language">(Optional) Language setting for the Accept-Language header.</param>
        /// <returns>A dictionary with the details of the thing type or an empty response with status 204.</returns>
        public JsonNode? GetThingType(string thingTypeUID, string? language = null)
            => R.Finish(() => getThingType_S(_client, R.Arg(thingTypeUID), R.Arg(language)));

        /// <summary>Asynchronous <see cref="GetThingType"/>.</summary>
        public Task<JsonNode?> GetThingTypeAsync(string thingTypeUID, string? language = null,
                                                 CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getThingType_A(_client, cancellationToken, R.Arg(thingTypeUID), R.Arg(language)));

        static V getThingTypes_S(OpenHABClient C, V v_bindingID, V v_language)
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
                v_response = R.Http(C, "get", R.S("/thing-types"), v_headers, V.None, (R.Truthy(v_bindingID) ? R.Dict(("bindingId", v_bindingID)) : R.Dict()));
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

        static async Task<V> getThingTypes_A(OpenHABClient C, CancellationToken ct, V v_bindingID,
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
                v_response = (await R.HttpAsync(C, "get", R.S("/thing-types"), v_headers, V.None, (R.Truthy(v_bindingID) ? R.Dict(("bindingId", v_bindingID)) : R.Dict()), ct).ConfigureAwait(false));
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

        static V getThingType_S(OpenHABClient C, V v_thingTypeUID, V v_language)
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
                v_response = R.Http(C, "get", R.Cat(R.S("/thing-types/"), v_thingTypeUID), v_headers, V.None, V.None);
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
                    return R.Dict(("error", R.S("No Content.")));
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
                return R.Dict(("error", R.S("No Content.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> getThingType_A(OpenHABClient C, CancellationToken ct, V v_thingTypeUID,
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
                v_response = (await R.HttpAsync(C, "get", R.Cat(R.S("/thing-types/"), v_thingTypeUID), v_headers, V.None, V.None, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("No Content.")));
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
                return R.Dict(("error", R.S("No Content.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }
    }
}
