// Generated from python-openhab-rest-client by tools/py2cs.py – do not edit.
#pragma warning disable CS1998, CS0168, CS0219, IDE0059
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using OpenHABRestClient.Internal;

namespace OpenHABRestClient
{
    /// <summary>
    /// openHAB REST API: Links.
    /// </summary>
    public sealed class Links
    {
        readonly OpenHABClient _client;

        /// <summary>Creates the Links class for a connected client.</summary>
        public Links(OpenHABClient client) => _client = client;

        /// <summary>
        /// Gets all available links.
        /// </summary>
        /// <param name="channelUID">Optional; Filters by the Channel UID.</param>
        /// <param name="itemName">Optional; Filters by the Item Name.</param>
        /// <returns>A list of links containing details such as ItemName, ChannelUID, and configuration.</returns>
        public JsonNode? GetLinks(string? channelUID = null, string? itemName = null)
            => R.Finish(() => getLinks_S(_client, R.Arg(channelUID), R.Arg(itemName)));

        /// <summary>Asynchronous <see cref="GetLinks"/>.</summary>
        public Task<JsonNode?> GetLinksAsync(string? channelUID = null, string? itemName = null,
                                             CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getLinks_A(_client, cancellationToken, R.Arg(channelUID), R.Arg(itemName)));

        /// <summary>
        /// Retrieves an individual link.
        /// </summary>
        /// <param name="itemName">The name of the item.</param>
        /// <param name="channelUID">The UID of the channel.</param>
        /// <returns>The link with details of the item, channel UID, and configuration.</returns>
        public JsonNode? GetLink(string itemName, string channelUID)
            => R.Finish(() => getLink_S(_client, R.Arg(itemName), R.Arg(channelUID)));

        /// <summary>Asynchronous <see cref="GetLink"/>.</summary>
        public Task<JsonNode?> GetLinkAsync(string itemName, string channelUID,
                                            CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getLink_A(_client, cancellationToken, R.Arg(itemName), R.Arg(channelUID)));

        /// <summary>
        /// Links an item to a channel.
        /// </summary>
        /// <param name="itemName">The name of the item.</param>
        /// <param name="channelUID">The UID of the channel.</param>
        /// <param name="configuration">The configuration for the link.</param>
        /// <returns>The API response when the link is successfully created.</returns>
        public JsonNode? LinkItemToChannel(string itemName, string channelUID, object configuration)
            => R.Finish(() => linkItemToChannel_S(_client, R.Arg(itemName), R.Arg(channelUID), R.Arg(configuration)));

        /// <summary>Asynchronous <see cref="LinkItemToChannel"/>.</summary>
        public Task<JsonNode?> LinkItemToChannelAsync(string itemName, string channelUID,
                                                      object configuration,
                                                      CancellationToken cancellationToken = default)
            => R.FinishAsync(() => linkItemToChannel_A(_client, cancellationToken, R.Arg(itemName), R.Arg(channelUID), R.Arg(configuration)));

        /// <summary>
        /// Unlinks an item from a channel.
        /// </summary>
        /// <param name="itemName">The name of the item.</param>
        /// <param name="channelUID">The UID of the channel.</param>
        /// <returns>The API response when the link is successfully removed.</returns>
        public JsonNode? UnlinkItemFromChannel(string itemName, string channelUID)
            => R.Finish(() => unlinkItemFromChannel_S(_client, R.Arg(itemName), R.Arg(channelUID)));

        /// <summary>Asynchronous <see cref="UnlinkItemFromChannel"/>.</summary>
        public Task<JsonNode?> UnlinkItemFromChannelAsync(string itemName, string channelUID,
                                                          CancellationToken cancellationToken = default)
            => R.FinishAsync(() => unlinkItemFromChannel_A(_client, cancellationToken, R.Arg(itemName), R.Arg(channelUID)));

        /// <summary>
        /// Delete all links that refer to an item or thing.
        /// </summary>
        /// <param name="object">The name of the item or the UID of the thing.</param>
        /// <returns>The API response when all links are successfully deleted.</returns>
        public JsonNode? DeleteAllLinks(string @object)
            => R.Finish(() => deleteAllLinks_S(_client, R.Arg(@object)));

        /// <summary>Asynchronous <see cref="DeleteAllLinks"/>.</summary>
        public Task<JsonNode?> DeleteAllLinksAsync(string @object,
                                                   CancellationToken cancellationToken = default)
            => R.FinishAsync(() => deleteAllLinks_A(_client, cancellationToken, R.Arg(@object)));

        /// <summary>
        /// Get orphan links between items and broken/non-existent thing channels.
        /// </summary>
        /// <returns>A list of orphan links.</returns>
        public JsonNode? GetOrphanLinks()
            => R.Finish(() => getOrphanLinks_S(_client));

        /// <summary>Asynchronous <see cref="GetOrphanLinks"/>.</summary>
        public Task<JsonNode?> GetOrphanLinksAsync(CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getOrphanLinks_A(_client, cancellationToken));

        /// <summary>
        /// Remove unused/orphaned links.
        /// </summary>
        /// <returns>The API response when the links are successfully removed.</returns>
        public JsonNode? PurgeUnusedLinks()
            => R.Finish(() => purgeUnusedLinks_S(_client));

        /// <summary>Asynchronous <see cref="PurgeUnusedLinks"/>.</summary>
        public Task<JsonNode?> PurgeUnusedLinksAsync(CancellationToken cancellationToken = default)
            => R.FinishAsync(() => purgeUnusedLinks_A(_client, cancellationToken));

        static V getLinks_S(OpenHABClient C, V v_channelUID, V v_itemName)
        {
            V v_params = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_params = R.Dict();
            if (R.Truthy(v_channelUID))
            {
                R.Set(v_params, R.S("channelUID"), v_channelUID);
            }
            if (R.Truthy(v_itemName))
            {
                R.Set(v_params, R.S("itemName"), v_itemName);
            }
            try
            {
                v_response = R.Http(C, "get", R.S("/links"), R.Dict(("Accept", R.S("application/json"))), V.None, v_params);
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

        static async Task<V> getLinks_A(OpenHABClient C, CancellationToken ct, V v_channelUID, V v_itemName)
        {
            V v_params = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_params = R.Dict();
            if (R.Truthy(v_channelUID))
            {
                R.Set(v_params, R.S("channelUID"), v_channelUID);
            }
            if (R.Truthy(v_itemName))
            {
                R.Set(v_params, R.S("itemName"), v_itemName);
            }
            try
            {
                v_response = (await R.HttpAsync(C, "get", R.S("/links"), R.Dict(("Accept", R.S("application/json"))), V.None, v_params, ct).ConfigureAwait(false));
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

        static V getLink_S(OpenHABClient C, V v_itemName, V v_channelUID)
        {
            V v_channelPath = V.None;
            V v_itemPath = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_itemPath = R.Quote(v_itemName, "");
            v_channelPath = R.Quote(v_channelUID, "");
            try
            {
                v_response = R.Http(C, "get", R.Cat(R.S("/links/"), v_itemPath, R.S("/"), v_channelPath), R.Dict(("Accept", R.S("application/json"))), V.None, V.None);
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
                    return R.Dict(("error", R.S("Link not found.")));
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
                return R.Dict(("error", R.S("Link not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> getLink_A(OpenHABClient C, CancellationToken ct, V v_itemName, V v_channelUID)
        {
            V v_channelPath = V.None;
            V v_itemPath = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_itemPath = R.Quote(v_itemName, "");
            v_channelPath = R.Quote(v_channelUID, "");
            try
            {
                v_response = (await R.HttpAsync(C, "get", R.Cat(R.S("/links/"), v_itemPath, R.S("/"), v_channelPath), R.Dict(("Accept", R.S("application/json"))), V.None, V.None, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Link not found.")));
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
                return R.Dict(("error", R.S("Link not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V linkItemToChannel_S(OpenHABClient C, V v_itemName, V v_channelUID, V v_configuration)
        {
            V v_channelPath = V.None;
            V v_itemPath = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_itemPath = R.Quote(v_itemName, "");
            v_channelPath = R.Quote(v_channelUID, "");
            try
            {
                v_response = R.Http(C, "put", R.Cat(R.S("/links/"), v_itemPath, R.S("/"), v_channelPath), R.Dict(("Content-Type", R.S("application/json"))), R.Dumps(R.Dict(("itemName", v_itemName), ("channelUID", v_channelUID), ("configuration", v_configuration))), V.None);
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
                if (R.Eq(v_status_code, R.I(405)))
                {
                    return R.Dict(("error", R.S("Link is not editable.")));
                }
                else if (R.Eq(v_status_code, R.I(400)))
                {
                    return R.Dict(("error", R.S("Content does not match the path.")));
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
                return R.Dict(("error", R.S("Content does not match the path.")));
            }
            else if (R.Eq(v_status_code, R.I(405)))
            {
                return R.Dict(("error", R.S("Link is not editable.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> linkItemToChannel_A(OpenHABClient C, CancellationToken ct, V v_itemName,
                                                 V v_channelUID, V v_configuration)
        {
            V v_channelPath = V.None;
            V v_itemPath = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_itemPath = R.Quote(v_itemName, "");
            v_channelPath = R.Quote(v_channelUID, "");
            try
            {
                v_response = (await R.HttpAsync(C, "put", R.Cat(R.S("/links/"), v_itemPath, R.S("/"), v_channelPath), R.Dict(("Content-Type", R.S("application/json"))), R.Dumps(R.Dict(("itemName", v_itemName), ("channelUID", v_channelUID), ("configuration", v_configuration))), V.None, ct).ConfigureAwait(false));
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
                if (R.Eq(v_status_code, R.I(405)))
                {
                    return R.Dict(("error", R.S("Link is not editable.")));
                }
                else if (R.Eq(v_status_code, R.I(400)))
                {
                    return R.Dict(("error", R.S("Content does not match the path.")));
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
                return R.Dict(("error", R.S("Content does not match the path.")));
            }
            else if (R.Eq(v_status_code, R.I(405)))
            {
                return R.Dict(("error", R.S("Link is not editable.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V unlinkItemFromChannel_S(OpenHABClient C, V v_itemName, V v_channelUID)
        {
            V v_channelPath = V.None;
            V v_itemPath = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_itemPath = R.Quote(v_itemName, "");
            v_channelPath = R.Quote(v_channelUID, "");
            try
            {
                v_response = R.Http(C, "delete", R.Cat(R.S("/links/"), v_itemPath, R.S("/"), v_channelPath), R.Dict(("Content-Type", R.S("application/json"))), V.None, V.None);
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
                if (R.Eq(v_status_code, R.I(405)))
                {
                    return R.Dict(("error", R.S("Link not editable.")));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("Link not found.")));
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
                return R.Dict(("error", R.S("Link not found.")));
            }
            else if (R.Eq(v_status_code, R.I(405)))
            {
                return R.Dict(("error", R.S("Link not editable.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> unlinkItemFromChannel_A(OpenHABClient C, CancellationToken ct, V v_itemName,
                                                     V v_channelUID)
        {
            V v_channelPath = V.None;
            V v_itemPath = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_itemPath = R.Quote(v_itemName, "");
            v_channelPath = R.Quote(v_channelUID, "");
            try
            {
                v_response = (await R.HttpAsync(C, "delete", R.Cat(R.S("/links/"), v_itemPath, R.S("/"), v_channelPath), R.Dict(("Content-Type", R.S("application/json"))), V.None, V.None, ct).ConfigureAwait(false));
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
                if (R.Eq(v_status_code, R.I(405)))
                {
                    return R.Dict(("error", R.S("Link not editable.")));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("Link not found.")));
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
                return R.Dict(("error", R.S("Link not found.")));
            }
            else if (R.Eq(v_status_code, R.I(405)))
            {
                return R.Dict(("error", R.S("Link not editable.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V deleteAllLinks_S(OpenHABClient C, V v_object)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "delete", R.Cat(R.S("/links/"), v_object), R.Dict(("Accept", R.S("application/json"))), V.None, V.None);
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

        static async Task<V> deleteAllLinks_A(OpenHABClient C, CancellationToken ct, V v_object)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "delete", R.Cat(R.S("/links/"), v_object), R.Dict(("Accept", R.S("application/json"))), V.None, V.None, ct).ConfigureAwait(false));
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

        static V getOrphanLinks_S(OpenHABClient C)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "get", R.S("/links/orphans"), R.Dict(("Accept", R.S("application/json"))), V.None, V.None);
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

        static async Task<V> getOrphanLinks_A(OpenHABClient C, CancellationToken ct)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "get", R.S("/links/orphans"), R.Dict(("Accept", R.S("application/json"))), V.None, V.None, ct).ConfigureAwait(false));
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

        static V purgeUnusedLinks_S(OpenHABClient C)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "post", R.S("/links/purge"), V.None, V.None, V.None);
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

        static async Task<V> purgeUnusedLinks_A(OpenHABClient C, CancellationToken ct)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "post", R.S("/links/purge"), V.None, V.None, V.None, ct).ConfigureAwait(false));
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
