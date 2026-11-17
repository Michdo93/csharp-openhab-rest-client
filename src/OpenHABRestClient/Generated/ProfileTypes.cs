// Generated from python-openhab-rest-client by tools/py2cs.py – do not edit.
#pragma warning disable CS1998, CS0168, CS0219, IDE0059
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using OpenHABRestClient.Internal;

namespace OpenHABRestClient
{
    /// <summary>
    /// openHAB REST API: ProfileTypes.
    /// </summary>
    public sealed class ProfileTypes
    {
        readonly OpenHABClient _client;

        /// <summary>Creates the ProfileTypes class for a connected client.</summary>
        public ProfileTypes(OpenHABClient client) => _client = client;

        /// <summary>
        /// Gets all available profile types.
        /// </summary>
        /// <param name="channelTypeUID">Optional filter for the channel type.</param>
        /// <param name="itemType">Optional filter for the item type.</param>
        /// <param name="language">(Optional) Language setting for the Accept-Language header.</param>
        /// <returns>A list of profile types.</returns>
        public JsonNode? GetProfileTypes(string? channelTypeUID = null, string? itemType = null,
                                         string? language = null)
            => R.Finish(() => getProfileTypes_S(_client, R.Arg(channelTypeUID), R.Arg(itemType), R.Arg(language)));

        /// <summary>Asynchronous <see cref="GetProfileTypes"/>.</summary>
        public Task<JsonNode?> GetProfileTypesAsync(string? channelTypeUID = null, string? itemType = null,
                                                    string? language = null,
                                                    CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getProfileTypes_A(_client, cancellationToken, R.Arg(channelTypeUID), R.Arg(itemType), R.Arg(language)));

        static V getProfileTypes_S(OpenHABClient C, V v_channelTypeUID, V v_itemType, V v_language)
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
            if (R.Truthy(v_channelTypeUID))
            {
                R.Set(v_params, R.S("channelTypeUID"), v_channelTypeUID);
            }
            if (R.Truthy(v_itemType))
            {
                R.Set(v_params, R.S("itemType"), v_itemType);
            }
            try
            {
                v_response = R.Http(C, "get", R.S("/profile-types"), v_headers, V.None, v_params);
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

        static async Task<V> getProfileTypes_A(OpenHABClient C, CancellationToken ct, V v_channelTypeUID,
                                               V v_itemType, V v_language)
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
            if (R.Truthy(v_channelTypeUID))
            {
                R.Set(v_params, R.S("channelTypeUID"), v_channelTypeUID);
            }
            if (R.Truthy(v_itemType))
            {
                R.Set(v_params, R.S("itemType"), v_itemType);
            }
            try
            {
                v_response = (await R.HttpAsync(C, "get", R.S("/profile-types"), v_headers, V.None, v_params, ct).ConfigureAwait(false));
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
