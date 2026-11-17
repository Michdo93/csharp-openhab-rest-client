// Generated from python-openhab-rest-client by tools/py2cs.py – do not edit.
#pragma warning disable CS1998, CS0168, CS0219, IDE0059
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using OpenHABRestClient.Internal;

namespace OpenHABRestClient
{
    /// <summary>
    /// openHAB REST API: ChannelTypes.
    /// </summary>
    public sealed class ChannelTypes
    {
        readonly OpenHABClient _client;

        /// <summary>Creates the ChannelTypes class for a connected client.</summary>
        public ChannelTypes(OpenHABClient client) => _client = client;

        /// <summary>
        /// Retrieves all available channel types.
        /// </summary>
        /// <param name="prefixes">Optional query parameter to filter channel types by prefix.</param>
        /// <param name="language">Optional headers 'Accept-Language' to specify the preferred language.</param>
        /// <returns>A list of channel types.</returns>
        public JsonNode? GetChannelTypes(string? prefixes = null, string? language = null)
            => R.Finish(() => getChannelTypes_S(_client, R.Arg(prefixes), R.Arg(language)));

        /// <summary>Asynchronous <see cref="GetChannelTypes"/>.</summary>
        public Task<JsonNode?> GetChannelTypesAsync(string? prefixes = null, string? language = null,
                                                    CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getChannelTypes_A(_client, cancellationToken, R.Arg(prefixes), R.Arg(language)));

        /// <summary>
        /// Retrieves the item types the given trigger channel type UID can be linked to.
        /// </summary>
        /// <param name="channelTypeUID">The unique UID of the channel type.</param>
        /// <param name="language">Optional headers 'Accept-Language' to specify the preferred language.</param>
        /// <returns>Details of the specific channel type.</returns>
        public JsonNode? GetChannelType(string channelTypeUID, string? language = null)
            => R.Finish(() => getChannelType_S(_client, R.Arg(channelTypeUID), R.Arg(language)));

        /// <summary>Asynchronous <see cref="GetChannelType"/>.</summary>
        public Task<JsonNode?> GetChannelTypeAsync(string channelTypeUID, string? language = null,
                                                   CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getChannelType_A(_client, cancellationToken, R.Arg(channelTypeUID), R.Arg(language)));

        /// <summary>
        /// Retrieves the item types that can be linked to the specified trigger channel type.
        /// </summary>
        /// <param name="channelTypeUID">The unique UID of the channel type.</param>
        /// <returns>A list of item types.</returns>
        public JsonNode? GetLinkableItemTypes(string channelTypeUID)
            => R.Finish(() => getLinkableItemTypes_S(_client, R.Arg(channelTypeUID)));

        /// <summary>Asynchronous <see cref="GetLinkableItemTypes"/>.</summary>
        public Task<JsonNode?> GetLinkableItemTypesAsync(string channelTypeUID,
                                                         CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getLinkableItemTypes_A(_client, cancellationToken, R.Arg(channelTypeUID)));

        static V getChannelTypes_S(OpenHABClient C, V v_prefixes, V v_language)
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
            if (R.Truthy(v_prefixes))
            {
                R.Set(v_params, R.S("prefixes"), v_prefixes);
            }
            try
            {
                v_response = R.Http(C, "get", R.S("/channel-types"), v_headers, V.None, v_params);
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

        static async Task<V> getChannelTypes_A(OpenHABClient C, CancellationToken ct, V v_prefixes,
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
            if (R.Truthy(v_prefixes))
            {
                R.Set(v_params, R.S("prefixes"), v_prefixes);
            }
            try
            {
                v_response = (await R.HttpAsync(C, "get", R.S("/channel-types"), v_headers, V.None, v_params, ct).ConfigureAwait(false));
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

        static V getChannelType_S(OpenHABClient C, V v_channelTypeUID, V v_language)
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
                v_response = R.Http(C, "get", R.Cat(R.S("/channel-types/"), v_channelTypeUID), v_headers, V.None, V.None);
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
                    return R.Dict(("error", R.S("Channel type with provided channelTypeUID does not exist.")));
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
                return R.Dict(("error", R.S("Channel type with provided channelTypeUID does not exist.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> getChannelType_A(OpenHABClient C, CancellationToken ct, V v_channelTypeUID,
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
                v_response = (await R.HttpAsync(C, "get", R.Cat(R.S("/channel-types/"), v_channelTypeUID), v_headers, V.None, V.None, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Channel type with provided channelTypeUID does not exist.")));
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
                return R.Dict(("error", R.S("Channel type with provided channelTypeUID does not exist.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V getLinkableItemTypes_S(OpenHABClient C, V v_channelTypeUID)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "get", R.Cat(R.S("/channel-types/"), v_channelTypeUID, R.S("/linkableItemTypes")), R.Dict(("Accept", R.S("application/json"))), V.None, V.None);
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
                if (R.Eq(v_status_code, R.I(204)))
                {
                    return R.Dict(("error", R.S("No content: channel type has no linkable items or is no trigger channel.")));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("Given channel type UID not found.")));
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
                return R.Dict(("error", R.S("Given channel type UID not found.")));
            }
            else if (R.Eq(v_status_code, R.I(204)))
            {
                return R.Dict(("error", R.S("No content: channel type has no linkable items or is no trigger channel.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> getLinkableItemTypes_A(OpenHABClient C, CancellationToken ct, V v_channelTypeUID)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "get", R.Cat(R.S("/channel-types/"), v_channelTypeUID, R.S("/linkableItemTypes")), R.Dict(("Accept", R.S("application/json"))), V.None, V.None, ct).ConfigureAwait(false));
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
                if (R.Eq(v_status_code, R.I(204)))
                {
                    return R.Dict(("error", R.S("No content: channel type has no linkable items or is no trigger channel.")));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("Given channel type UID not found.")));
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
                return R.Dict(("error", R.S("Given channel type UID not found.")));
            }
            else if (R.Eq(v_status_code, R.I(204)))
            {
                return R.Dict(("error", R.S("No content: channel type has no linkable items or is no trigger channel.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }
    }
}
