// Generated from python-openhab-rest-client by tools/py2cs.py – do not edit.
#pragma warning disable CS1998, CS0168, CS0219, IDE0059
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using OpenHABRestClient.Internal;

namespace OpenHABRestClient
{
    /// <summary>
    /// openHAB REST API: Items.
    /// </summary>
    public sealed class Items
    {
        readonly OpenHABClient _client;

        /// <summary>Creates the Items class for a connected client.</summary>
        public Items(OpenHABClient client) => _client = client;

        /// <summary>
        /// Get all available items.
        /// </summary>
        /// <param name="type">Optional; Item type filter.</param>
        /// <param name="tags">Optional; Item tag filter.</param>
        /// <param name="metadata">Optional; Metadata selector (default: .*).</param>
        /// <param name="recursive">Optional; Whether to fetch group members recursively (default: False).</param>
        /// <param name="fields">Optional; Limit to specific fields (comma-separated).</param>
        /// <param name="staticDataOnly">Optional; Only returns cached data (default: False).</param>
        /// <param name="language">Optional; Language filter for headers "Accept-Language".</param>
        /// <param name="parents">Optional; Include the parent groups of each item (openHAB 4.1+).</param>
        /// <returns>A list containing the item data as returned by the API.</returns>
        public JsonNode? GetItems(string? type = null, string? tags = null, string metadata = ".*",
                                  bool recursive = false, string? fields = null, bool staticDataOnly = false,
                                  string? language = null, bool? parents = null)
            => R.Finish(() => getItems_S(_client, R.Arg(type), R.Arg(tags), R.Arg(metadata), R.Arg(recursive), R.Arg(fields), R.Arg(staticDataOnly), R.Arg(language), R.Arg(parents)));

        /// <summary>Asynchronous <see cref="GetItems"/>.</summary>
        public Task<JsonNode?> GetItemsAsync(string? type = null, string? tags = null, string metadata = ".*",
                                             bool recursive = false, string? fields = null,
                                             bool staticDataOnly = false, string? language = null,
                                             bool? parents = null,
                                             CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getItems_A(_client, cancellationToken, R.Arg(type), R.Arg(tags), R.Arg(metadata), R.Arg(recursive), R.Arg(fields), R.Arg(staticDataOnly), R.Arg(language), R.Arg(parents)));

        /// <summary>
        /// Adds a list of items to the registry or updates the existing items.
        /// </summary>
        /// <param name="items">A list of item data (Dictionary).</param>
        /// <returns>A response object or confirmation that the items were successfully added or updated.</returns>
        public JsonNode? AddOrUpdateItems(object items)
            => R.Finish(() => addOrUpdateItems_S(_client, R.Arg(items)));

        /// <summary>Asynchronous <see cref="AddOrUpdateItems"/>.</summary>
        public Task<JsonNode?> AddOrUpdateItemsAsync(object items,
                                                     CancellationToken cancellationToken = default)
            => R.FinishAsync(() => addOrUpdateItems_A(_client, cancellationToken, R.Arg(items)));

        /// <summary>
        /// Gets a single item.
        /// </summary>
        /// <param name="itemName">The name of the item.</param>
        /// <param name="metadata">Optional; Metadata selector (default: .*).</param>
        /// <param name="recursive">Optional; Whether to fetch group members recursively (default: True).</param>
        /// <param name="language">Optional; Language filter for headers "Accept-Language".</param>
        /// <param name="parents">(see the openHAB REST API documentation)</param>
        /// <returns>A dictionary containing the requested item data.</returns>
        public JsonNode? GetItem(string itemName, string metadata = ".*", bool recursive = true,
                                 string? language = null, bool? parents = null)
            => R.Finish(() => getItem_S(_client, R.Arg(itemName), R.Arg(metadata), R.Arg(recursive), R.Arg(language), R.Arg(parents)));

        /// <summary>Asynchronous <see cref="GetItem"/>.</summary>
        public Task<JsonNode?> GetItemAsync(string itemName, string metadata = ".*", bool recursive = true,
                                            string? language = null, bool? parents = null,
                                            CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getItem_A(_client, cancellationToken, R.Arg(itemName), R.Arg(metadata), R.Arg(recursive), R.Arg(language), R.Arg(parents)));

        /// <summary>
        /// Adds a new item to the registry or updates the existing item.
        /// </summary>
        /// <param name="itemName">The name of the item.</param>
        /// <param name="itemData">The data of the item (Dictionary).</param>
        /// <param name="language">Optional; Language filter for headers "Accept-Language".</param>
        /// <returns>A response object or confirmation that the item was successfully added or updated.</returns>
        public JsonNode? AddOrUpdateItem(string itemName, object itemData, string? language = null)
            => R.Finish(() => addOrUpdateItem_S(_client, R.Arg(itemName), R.Arg(itemData), R.Arg(language)));

        /// <summary>Asynchronous <see cref="AddOrUpdateItem"/>.</summary>
        public Task<JsonNode?> AddOrUpdateItemAsync(string itemName, object itemData, string? language = null,
                                                    CancellationToken cancellationToken = default)
            => R.FinishAsync(() => addOrUpdateItem_A(_client, cancellationToken, R.Arg(itemName), R.Arg(itemData), R.Arg(language)));

        /// <summary>
        /// Sends a command to an item.
        /// </summary>
        /// <param name="itemName">The name of the item.</param>
        /// <param name="command">The command to be sent (e.g., ON, OFF).</param>
        /// <param name="source">Optional; Source of the command, shown in the event (openHAB 4.1+).</param>
        /// <returns>A response object or confirmation that the command was successfully sent.</returns>
        public JsonNode? SendCommand(string itemName, string command, string? source = null)
            => R.Finish(() => sendCommand_S(_client, R.Arg(itemName), R.Arg(command), R.Arg(source)));

        /// <summary>Asynchronous <see cref="SendCommand"/>.</summary>
        public Task<JsonNode?> SendCommandAsync(string itemName, string command, string? source = null,
                                                CancellationToken cancellationToken = default)
            => R.FinishAsync(() => sendCommand_A(_client, cancellationToken, R.Arg(itemName), R.Arg(command), R.Arg(source)));

        /// <summary>
        /// Updates the state of an item.
        /// </summary>
        /// <param name="itemName">The name of the item.</param>
        /// <param name="state">The state to be signaled for the item.</param>
        /// <param name="source">(see the openHAB REST API documentation)</param>
        /// <returns>A response object or confirmation that the state was successfully updated.</returns>
        public JsonNode? PostUpdate(string itemName, string state, string? source = null)
            => R.Finish(() => postUpdate_S(_client, R.Arg(itemName), R.Arg(state), R.Arg(source)));

        /// <summary>Asynchronous <see cref="PostUpdate"/>.</summary>
        public Task<JsonNode?> PostUpdateAsync(string itemName, string state, string? source = null,
                                               CancellationToken cancellationToken = default)
            => R.FinishAsync(() => postUpdate_A(_client, cancellationToken, R.Arg(itemName), R.Arg(state), R.Arg(source)));

        /// <summary>
        /// Removes an item from the registry.
        /// </summary>
        /// <param name="itemName">The name of the item.</param>
        /// <returns>A response object or confirmation that the item was successfully deleted.</returns>
        public JsonNode? DeleteItem(string itemName)
            => R.Finish(() => deleteItem_S(_client, R.Arg(itemName)));

        /// <summary>Asynchronous <see cref="DeleteItem"/>.</summary>
        public Task<JsonNode?> DeleteItemAsync(string itemName, CancellationToken cancellationToken = default)
            => R.FinishAsync(() => deleteItem_A(_client, cancellationToken, R.Arg(itemName)));

        /// <summary>
        /// Adds a new member to a group item.
        /// </summary>
        /// <param name="itemName">The name of the group item.</param>
        /// <param name="memberItemName">The name of the member item.</param>
        /// <returns>A response object or confirmation that the group member was successfully added.</returns>
        public JsonNode? AddGroupMember(string itemName, string memberItemName)
            => R.Finish(() => addGroupMember_S(_client, R.Arg(itemName), R.Arg(memberItemName)));

        /// <summary>Asynchronous <see cref="AddGroupMember"/>.</summary>
        public Task<JsonNode?> AddGroupMemberAsync(string itemName, string memberItemName,
                                                   CancellationToken cancellationToken = default)
            => R.FinishAsync(() => addGroupMember_A(_client, cancellationToken, R.Arg(itemName), R.Arg(memberItemName)));

        /// <summary>
        /// Removes an existing member from a group item.
        /// </summary>
        /// <param name="itemName">The name of the group item.</param>
        /// <param name="memberItemName">The name of the member item.</param>
        /// <returns>A response object or confirmation that the group member was successfully removed.</returns>
        public JsonNode? RemoveGroupMember(string itemName, string memberItemName)
            => R.Finish(() => removeGroupMember_S(_client, R.Arg(itemName), R.Arg(memberItemName)));

        /// <summary>Asynchronous <see cref="RemoveGroupMember"/>.</summary>
        public Task<JsonNode?> RemoveGroupMemberAsync(string itemName, string memberItemName,
                                                      CancellationToken cancellationToken = default)
            => R.FinishAsync(() => removeGroupMember_A(_client, cancellationToken, R.Arg(itemName), R.Arg(memberItemName)));

        /// <summary>
        /// Adds metadata to an item.
        /// </summary>
        /// <param name="itemName">The name of the item.</param>
        /// <param name="namespace">The namespace of the metadata.</param>
        /// <param name="metadata">A dictionary containing the metadata.</param>
        /// <returns>A response object or confirmation that the metadata was successfully added.</returns>
        public JsonNode? AddMetadata(string itemName, string @namespace, object metadata)
            => R.Finish(() => addMetadata_S(_client, R.Arg(itemName), R.Arg(@namespace), R.Arg(metadata)));

        /// <summary>Asynchronous <see cref="AddMetadata"/>.</summary>
        public Task<JsonNode?> AddMetadataAsync(string itemName, string @namespace, object metadata,
                                                CancellationToken cancellationToken = default)
            => R.FinishAsync(() => addMetadata_A(_client, cancellationToken, R.Arg(itemName), R.Arg(@namespace), R.Arg(metadata)));

        /// <summary>
        /// Removes metadata from an item.
        /// </summary>
        /// <param name="itemName">The name of the item.</param>
        /// <param name="namespace">The namespace of the metadata.</param>
        /// <returns>A response object or confirmation that the metadata was successfully removed.</returns>
        public JsonNode? RemoveMetadata(string itemName, string @namespace)
            => R.Finish(() => removeMetadata_S(_client, R.Arg(itemName), R.Arg(@namespace)));

        /// <summary>Asynchronous <see cref="RemoveMetadata"/>.</summary>
        public Task<JsonNode?> RemoveMetadataAsync(string itemName, string @namespace,
                                                   CancellationToken cancellationToken = default)
            => R.FinishAsync(() => removeMetadata_A(_client, cancellationToken, R.Arg(itemName), R.Arg(@namespace)));

        /// <summary>
        /// Gets the namespaces of an item.
        /// </summary>
        /// <param name="itemName">The name of the item.</param>
        /// <param name="language">Optional; Language filter for headers "Accept-Language".</param>
        /// <returns>A list of namespaces associated with the item.</returns>
        public JsonNode? GetMetadataNamespaces(string itemName, string? language = null)
            => R.Finish(() => getMetadataNamespaces_S(_client, R.Arg(itemName), R.Arg(language)));

        /// <summary>Asynchronous <see cref="GetMetadataNamespaces"/>.</summary>
        public Task<JsonNode?> GetMetadataNamespacesAsync(string itemName, string? language = null,
                                                          CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getMetadataNamespaces_A(_client, cancellationToken, R.Arg(itemName), R.Arg(language)));

        /// <summary>
        /// Gets the item that defines the requested semantics of an item.
        /// </summary>
        /// <param name="itemName">The name of the item.</param>
        /// <param name="semanticClass">The requested semantic class.</param>
        /// <param name="language">Optional; Language filter for headers "Accept-Language".</param>
        /// <returns>A dictionary containing the semantic item data.</returns>
        public JsonNode? GetSemanticItem(string itemName, string semanticClass, string? language = null)
            => R.Finish(() => getSemanticItem_S(_client, R.Arg(itemName), R.Arg(semanticClass), R.Arg(language)));

        /// <summary>Asynchronous <see cref="GetSemanticItem"/>.</summary>
        public Task<JsonNode?> GetSemanticItemAsync(string itemName, string semanticClass,
                                                    string? language = null,
                                                    CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getSemanticItem_A(_client, cancellationToken, R.Arg(itemName), R.Arg(semanticClass), R.Arg(language)));

        /// <summary>
        /// Gets the state of an item.
        /// </summary>
        /// <param name="itemName">The name of the item.</param>
        /// <returns>A dictionary containing the current state of the item.</returns>
        public JsonNode? GetItemState(string itemName)
            => R.Finish(() => getItemState_S(_client, R.Arg(itemName)));

        /// <summary>Asynchronous <see cref="GetItemState"/>.</summary>
        public Task<JsonNode?> GetItemStateAsync(string itemName,
                                                 CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getItemState_A(_client, cancellationToken, R.Arg(itemName)));

        /// <summary>
        /// Updates the state of an item.
        /// </summary>
        /// <param name="itemName">The name of the item.</param>
        /// <param name="state">The new state of the item.</param>
        /// <param name="language">Optional; Language filter for headers "Accept-Language".</param>
        /// <param name="source">(see the openHAB REST API documentation)</param>
        /// <returns>A response object or confirmation that the state was successfully updated.</returns>
        public JsonNode? UpdateItemState(string itemName, string state, string? language = null,
                                         string? source = null)
            => R.Finish(() => updateItemState_S(_client, R.Arg(itemName), R.Arg(state), R.Arg(language), R.Arg(source)));

        /// <summary>Asynchronous <see cref="UpdateItemState"/>.</summary>
        public Task<JsonNode?> UpdateItemStateAsync(string itemName, string state, string? language = null,
                                                    string? source = null,
                                                    CancellationToken cancellationToken = default)
            => R.FinishAsync(() => updateItemState_A(_client, cancellationToken, R.Arg(itemName), R.Arg(state), R.Arg(language), R.Arg(source)));

        /// <summary>
        /// Adds a tag to an item.
        /// </summary>
        /// <param name="itemName">The name of the item.</param>
        /// <param name="tag">The tag to be added.</param>
        /// <returns>A response object or confirmation that the tag was successfully added.</returns>
        public JsonNode? AddTag(string itemName, string tag)
            => R.Finish(() => addTag_S(_client, R.Arg(itemName), R.Arg(tag)));

        /// <summary>Asynchronous <see cref="AddTag"/>.</summary>
        public Task<JsonNode?> AddTagAsync(string itemName, string tag,
                                           CancellationToken cancellationToken = default)
            => R.FinishAsync(() => addTag_A(_client, cancellationToken, R.Arg(itemName), R.Arg(tag)));

        /// <summary>
        /// Removes a tag from an item.
        /// </summary>
        /// <param name="itemName">The name of the item.</param>
        /// <param name="tag">The tag to be removed.</param>
        /// <returns>A response object or confirmation that the tag was successfully removed.</returns>
        public JsonNode? RemoveTag(string itemName, string tag)
            => R.Finish(() => removeTag_S(_client, R.Arg(itemName), R.Arg(tag)));

        /// <summary>Asynchronous <see cref="RemoveTag"/>.</summary>
        public Task<JsonNode?> RemoveTagAsync(string itemName, string tag,
                                              CancellationToken cancellationToken = default)
            => R.FinishAsync(() => removeTag_A(_client, cancellationToken, R.Arg(itemName), R.Arg(tag)));

        /// <summary>
        /// Remove unused/orphaned metadata.
        /// </summary>
        /// <returns>A response object or confirmation that orphaned metadata was successfully purged.</returns>
        public JsonNode? PurgeOrphanedMetadata()
            => R.Finish(() => purgeOrphanedMetadata_S(_client));

        /// <summary>Asynchronous <see cref="PurgeOrphanedMetadata"/>.</summary>
        public Task<JsonNode?> PurgeOrphanedMetadataAsync(CancellationToken cancellationToken = default)
            => R.FinishAsync(() => purgeOrphanedMetadata_A(_client, cancellationToken));

        static V getItems_S(OpenHABClient C, V v_type, V v_tags, V v_metadata, V v_recursive, V v_fields,
                            V v_staticDataOnly, V v_language, V v_parents)
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
            v_params = R.Dict(("type", v_type), ("tags", v_tags), ("metadata", v_metadata), ("recursive", R.Lower(R.Str(v_recursive))), ("fields", v_fields), ("staticDataOnly", R.Lower(R.Str(v_staticDataOnly))), ("parents", v_parents));
            v_params = R.WithoutNone(v_params);
            try
            {
                v_response = R.Http(C, "get", R.S("/items"), v_headers, V.None, v_params);
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

        static async Task<V> getItems_A(OpenHABClient C, CancellationToken ct, V v_type, V v_tags,
                                        V v_metadata, V v_recursive, V v_fields, V v_staticDataOnly,
                                        V v_language, V v_parents)
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
            v_params = R.Dict(("type", v_type), ("tags", v_tags), ("metadata", v_metadata), ("recursive", R.Lower(R.Str(v_recursive))), ("fields", v_fields), ("staticDataOnly", R.Lower(R.Str(v_staticDataOnly))), ("parents", v_parents));
            v_params = R.WithoutNone(v_params);
            try
            {
                v_response = (await R.HttpAsync(C, "get", R.S("/items"), v_headers, V.None, v_params, ct).ConfigureAwait(false));
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

        static V addOrUpdateItems_S(OpenHABClient C, V v_items)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "put", R.S("/items"), R.Dict(("Content-Type", R.S("application/json")), ("Accept", R.S("*/*"))), R.Dumps(v_items), V.None);
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
                    return R.Dict(("error", R.S("Payload is invalid.")));
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
                return R.Dict(("error", R.S("Payload is invalid.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> addOrUpdateItems_A(OpenHABClient C, CancellationToken ct, V v_items)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "put", R.S("/items"), R.Dict(("Content-Type", R.S("application/json")), ("Accept", R.S("*/*"))), R.Dumps(v_items), V.None, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Payload is invalid.")));
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
                return R.Dict(("error", R.S("Payload is invalid.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V getItem_S(OpenHABClient C, V v_itemName, V v_metadata, V v_recursive, V v_language,
                           V v_parents)
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
            v_params = R.Dict(("metadata", v_metadata), ("recursive", R.Lower(R.Str(v_recursive))), ("parents", v_parents));
            try
            {
                v_response = R.Http(C, "get", R.Cat(R.S("/items/"), v_itemName), v_headers, V.None, v_params);
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
                    return R.Dict(("error", R.S("Item not found.")));
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
                return R.Dict(("error", R.S("Item not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> getItem_A(OpenHABClient C, CancellationToken ct, V v_itemName, V v_metadata,
                                       V v_recursive, V v_language, V v_parents)
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
            v_params = R.Dict(("metadata", v_metadata), ("recursive", R.Lower(R.Str(v_recursive))), ("parents", v_parents));
            try
            {
                v_response = (await R.HttpAsync(C, "get", R.Cat(R.S("/items/"), v_itemName), v_headers, V.None, v_params, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Item not found.")));
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
                return R.Dict(("error", R.S("Item not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V addOrUpdateItem_S(OpenHABClient C, V v_itemName, V v_itemData, V v_language)
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
                v_response = R.Http(C, "put", R.Cat(R.S("/items/"), v_itemName), v_headers, R.Dumps(v_itemData), V.None);
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
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("Item not found or name in path invalid.")));
                }
                else if (R.Eq(v_status_code, R.I(405)))
                {
                    return R.Dict(("error", R.S("Item not editable.")));
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
            if (R.Eq(v_status_code, R.I(201)))
            {
                return R.Dict(("message", R.S("Item created.")));
            }
            else if (R.Eq(v_status_code, R.I(400)))
            {
                return R.Dict(("error", R.S("Payload invalid.")));
            }
            else if (R.Eq(v_status_code, R.I(404)))
            {
                return R.Dict(("error", R.S("Item not found or name in path invalid.")));
            }
            else if (R.Eq(v_status_code, R.I(405)))
            {
                return R.Dict(("error", R.S("Item not editable.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> addOrUpdateItem_A(OpenHABClient C, CancellationToken ct, V v_itemName,
                                               V v_itemData, V v_language)
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
                v_response = (await R.HttpAsync(C, "put", R.Cat(R.S("/items/"), v_itemName), v_headers, R.Dumps(v_itemData), V.None, ct).ConfigureAwait(false));
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
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("Item not found or name in path invalid.")));
                }
                else if (R.Eq(v_status_code, R.I(405)))
                {
                    return R.Dict(("error", R.S("Item not editable.")));
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
            if (R.Eq(v_status_code, R.I(201)))
            {
                return R.Dict(("message", R.S("Item created.")));
            }
            else if (R.Eq(v_status_code, R.I(400)))
            {
                return R.Dict(("error", R.S("Payload invalid.")));
            }
            else if (R.Eq(v_status_code, R.I(404)))
            {
                return R.Dict(("error", R.S("Item not found or name in path invalid.")));
            }
            else if (R.Eq(v_status_code, R.I(405)))
            {
                return R.Dict(("error", R.S("Item not editable.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V sendCommand_S(OpenHABClient C, V v_itemName, V v_command, V v_source)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "post", R.Cat(R.S("/items/"), v_itemName), R.Dict(("Content-Type", R.S("text/plain"))), R.Str(v_command), R.Dict(("source", v_source)));
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
                    return R.Dict(("error", R.S("Invalid command for this item.")));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("Item not found.")));
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
                return R.Dict(("error", R.S("Item not found.")));
            }
            else if (R.Eq(v_status_code, R.I(400)))
            {
                return R.Dict(("error", R.S("Invalid command for this item.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> sendCommand_A(OpenHABClient C, CancellationToken ct, V v_itemName, V v_command,
                                           V v_source)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "post", R.Cat(R.S("/items/"), v_itemName), R.Dict(("Content-Type", R.S("text/plain"))), R.Str(v_command), R.Dict(("source", v_source)), ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Invalid command for this item.")));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("Item not found.")));
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
                return R.Dict(("error", R.S("Item not found.")));
            }
            else if (R.Eq(v_status_code, R.I(400)))
            {
                return R.Dict(("error", R.S("Invalid command for this item.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V postUpdate_S(OpenHABClient C, V v_itemName, V v_state, V v_source)
        {
            return updateItemState_S(C, v_itemName, v_state, V.None, v_source);
        }

        static async Task<V> postUpdate_A(OpenHABClient C, CancellationToken ct, V v_itemName, V v_state,
                                          V v_source)
        {
            return (await updateItemState_A(C, ct, v_itemName, v_state, V.None, v_source).ConfigureAwait(false));
        }

        static V deleteItem_S(OpenHABClient C, V v_itemName)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "delete", R.Cat(R.S("/items/"), v_itemName), V.None, V.None, V.None);
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
                    return R.Dict(("error", R.S("Item not found or item is not editable.")));
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
                return R.Dict(("error", R.S("Item not found or item is not editable.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> deleteItem_A(OpenHABClient C, CancellationToken ct, V v_itemName)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "delete", R.Cat(R.S("/items/"), v_itemName), V.None, V.None, V.None, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Item not found or item is not editable.")));
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
                return R.Dict(("error", R.S("Item not found or item is not editable.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V addGroupMember_S(OpenHABClient C, V v_itemName, V v_memberItemName)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "put", R.Cat(R.S("/items/"), v_itemName, R.S("/members/"), v_memberItemName), V.None, V.None, V.None);
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
                    return R.Dict(("error", R.S("Member item is not editable.")));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("Item or member item not found or item is not of type group item.")));
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
                return R.Dict(("error", R.S("Item or member item not found or item is not of type group item.")));
            }
            else if (R.Eq(v_status_code, R.I(405)))
            {
                return R.Dict(("error", R.S("Member item is not editable.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> addGroupMember_A(OpenHABClient C, CancellationToken ct, V v_itemName,
                                              V v_memberItemName)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "put", R.Cat(R.S("/items/"), v_itemName, R.S("/members/"), v_memberItemName), V.None, V.None, V.None, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Member item is not editable.")));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("Item or member item not found or item is not of type group item.")));
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
                return R.Dict(("error", R.S("Item or member item not found or item is not of type group item.")));
            }
            else if (R.Eq(v_status_code, R.I(405)))
            {
                return R.Dict(("error", R.S("Member item is not editable.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V removeGroupMember_S(OpenHABClient C, V v_itemName, V v_memberItemName)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "delete", R.Cat(R.S("/items/"), v_itemName, R.S("/members/"), v_memberItemName), V.None, V.None, V.None);
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
                    return R.Dict(("error", R.S("Member item is not editable.")));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("Item or member item not found or item is not of type group item.")));
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
                return R.Dict(("error", R.S("Item or member item not found or item is not of type group item.")));
            }
            else if (R.Eq(v_status_code, R.I(405)))
            {
                return R.Dict(("error", R.S("Member item is not editable.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> removeGroupMember_A(OpenHABClient C, CancellationToken ct, V v_itemName,
                                                 V v_memberItemName)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "delete", R.Cat(R.S("/items/"), v_itemName, R.S("/members/"), v_memberItemName), V.None, V.None, V.None, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Member item is not editable.")));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("Item or member item not found or item is not of type group item.")));
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
                return R.Dict(("error", R.S("Item or member item not found or item is not of type group item.")));
            }
            else if (R.Eq(v_status_code, R.I(405)))
            {
                return R.Dict(("error", R.S("Member item is not editable.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V addMetadata_S(OpenHABClient C, V v_itemName, V v_namespace, V v_metadata)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "put", R.Cat(R.S("/items/"), v_itemName, R.S("/metadata/"), v_namespace), R.Dict(("Content-Type", R.S("application/json"))), R.Dumps(v_metadata), V.None);
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
                    return R.Dict(("error", R.S("Metadata value empty.")));
                }
                else if (R.Eq(v_status_code, R.I(405)))
                {
                    return R.Dict(("error", R.S("Metadata not editable.")));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("Item not found.")));
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
                return R.Dict(("message", R.S("Created.")));
            }
            else if (R.Eq(v_status_code, R.I(400)))
            {
                return R.Dict(("error", R.S("Metadata value empty.")));
            }
            else if (R.Eq(v_status_code, R.I(404)))
            {
                return R.Dict(("error", R.S("Item not found.")));
            }
            else if (R.Eq(v_status_code, R.I(405)))
            {
                return R.Dict(("error", R.S("Metadata not editable.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> addMetadata_A(OpenHABClient C, CancellationToken ct, V v_itemName, V v_namespace,
                                           V v_metadata)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "put", R.Cat(R.S("/items/"), v_itemName, R.S("/metadata/"), v_namespace), R.Dict(("Content-Type", R.S("application/json"))), R.Dumps(v_metadata), V.None, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Metadata value empty.")));
                }
                else if (R.Eq(v_status_code, R.I(405)))
                {
                    return R.Dict(("error", R.S("Metadata not editable.")));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("Item not found.")));
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
                return R.Dict(("message", R.S("Created.")));
            }
            else if (R.Eq(v_status_code, R.I(400)))
            {
                return R.Dict(("error", R.S("Metadata value empty.")));
            }
            else if (R.Eq(v_status_code, R.I(404)))
            {
                return R.Dict(("error", R.S("Item not found.")));
            }
            else if (R.Eq(v_status_code, R.I(405)))
            {
                return R.Dict(("error", R.S("Metadata not editable.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V removeMetadata_S(OpenHABClient C, V v_itemName, V v_namespace)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "delete", R.Cat(R.S("/items/"), v_itemName, R.S("/metadata/"), v_namespace), V.None, V.None, V.None);
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
                    return R.Dict(("error", R.S("Meta data not editable.")));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("Item not found.")));
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
                return R.Dict(("error", R.S("Item not found.")));
            }
            else if (R.Eq(v_status_code, R.I(405)))
            {
                return R.Dict(("error", R.S("Meta data not editable.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> removeMetadata_A(OpenHABClient C, CancellationToken ct, V v_itemName,
                                              V v_namespace)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "delete", R.Cat(R.S("/items/"), v_itemName, R.S("/metadata/"), v_namespace), V.None, V.None, V.None, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Meta data not editable.")));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("Item not found.")));
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
                return R.Dict(("error", R.S("Item not found.")));
            }
            else if (R.Eq(v_status_code, R.I(405)))
            {
                return R.Dict(("error", R.S("Meta data not editable.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V getMetadataNamespaces_S(OpenHABClient C, V v_itemName, V v_language)
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
                v_response = R.Http(C, "get", R.Cat(R.S("/items/"), v_itemName, R.S("/metadata/namespaces")), v_headers, V.None, V.None);
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
                    return R.Dict(("error", R.S("Item not found.")));
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
                return R.Dict(("error", R.S("Item not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> getMetadataNamespaces_A(OpenHABClient C, CancellationToken ct, V v_itemName,
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
                v_response = (await R.HttpAsync(C, "get", R.Cat(R.S("/items/"), v_itemName, R.S("/metadata/namespaces")), v_headers, V.None, V.None, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Item not found.")));
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
                return R.Dict(("error", R.S("Item not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V getSemanticItem_S(OpenHABClient C, V v_itemName, V v_semanticClass, V v_language)
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
                v_response = R.Http(C, "get", R.Cat(R.S("/items/"), v_itemName, R.S("/semantic/"), v_semanticClass), v_headers, V.None, V.None);
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
                    return R.Dict(("error", R.S("Item not found.")));
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
                return R.Dict(("error", R.S("Item not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> getSemanticItem_A(OpenHABClient C, CancellationToken ct, V v_itemName,
                                               V v_semanticClass, V v_language)
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
                v_response = (await R.HttpAsync(C, "get", R.Cat(R.S("/items/"), v_itemName, R.S("/semantic/"), v_semanticClass), v_headers, V.None, V.None, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Item not found.")));
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
                return R.Dict(("error", R.S("Item not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V getItemState_S(OpenHABClient C, V v_itemName)
        {
            V v_headers = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_headers = R.Dict(("Accept", R.S("text/plain")));
            try
            {
                v_response = R.Http(C, "get", R.Cat(R.S("/items/"), v_itemName, R.S("/state")), v_headers, V.None, V.None);
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
                    return R.Dict(("error", R.S("Item not found.")));
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
                return R.Dict(("error", R.S("Item not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> getItemState_A(OpenHABClient C, CancellationToken ct, V v_itemName)
        {
            V v_headers = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_headers = R.Dict(("Accept", R.S("text/plain")));
            try
            {
                v_response = (await R.HttpAsync(C, "get", R.Cat(R.S("/items/"), v_itemName, R.S("/state")), v_headers, V.None, V.None, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Item not found.")));
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
                return R.Dict(("error", R.S("Item not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V updateItemState_S(OpenHABClient C, V v_itemName, V v_state, V v_language, V v_source)
        {
            V v_headers = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_headers = R.Dict(("Content-Type", R.S("text/plain")));
            if (R.Truthy(v_language))
            {
                R.Set(v_headers, R.S("Accept-Language"), v_language);
            }
            try
            {
                v_response = R.Http(C, "put", R.Cat(R.S("/items/"), v_itemName, R.S("/state")), v_headers, R.Str(v_state), R.Dict(("source", v_source)));
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
                    return R.Dict(("error", R.S("Invalid state for this item.")));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("Item not found.")));
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
            if (R.Eq(v_status_code, R.I(202)))
            {
                return R.Dict(("message", R.S("Accepted.")));
            }
            else if (R.Eq(v_status_code, R.I(404)))
            {
                return R.Dict(("error", R.S("Item not found.")));
            }
            else if (R.Eq(v_status_code, R.I(400)))
            {
                return R.Dict(("error", R.S("Invalid state for this item.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> updateItemState_A(OpenHABClient C, CancellationToken ct, V v_itemName, V v_state,
                                               V v_language, V v_source)
        {
            V v_headers = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_headers = R.Dict(("Content-Type", R.S("text/plain")));
            if (R.Truthy(v_language))
            {
                R.Set(v_headers, R.S("Accept-Language"), v_language);
            }
            try
            {
                v_response = (await R.HttpAsync(C, "put", R.Cat(R.S("/items/"), v_itemName, R.S("/state")), v_headers, R.Str(v_state), R.Dict(("source", v_source)), ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Invalid state for this item.")));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("Item not found.")));
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
            if (R.Eq(v_status_code, R.I(202)))
            {
                return R.Dict(("message", R.S("Accepted.")));
            }
            else if (R.Eq(v_status_code, R.I(404)))
            {
                return R.Dict(("error", R.S("Item not found.")));
            }
            else if (R.Eq(v_status_code, R.I(400)))
            {
                return R.Dict(("error", R.S("Invalid state for this item.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V addTag_S(OpenHABClient C, V v_itemName, V v_tag)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "put", R.Cat(R.S("/items/"), v_itemName, R.S("/tags/"), v_tag), V.None, V.None, V.None);
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
                    return R.Dict(("error", R.S("Item not editable.")));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("Item not found.")));
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
                return R.Dict(("error", R.S("Item not found.")));
            }
            else if (R.Eq(v_status_code, R.I(405)))
            {
                return R.Dict(("error", R.S("Item not editable.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> addTag_A(OpenHABClient C, CancellationToken ct, V v_itemName, V v_tag)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "put", R.Cat(R.S("/items/"), v_itemName, R.S("/tags/"), v_tag), V.None, V.None, V.None, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Item not editable.")));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("Item not found.")));
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
                return R.Dict(("error", R.S("Item not found.")));
            }
            else if (R.Eq(v_status_code, R.I(405)))
            {
                return R.Dict(("error", R.S("Item not editable.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V removeTag_S(OpenHABClient C, V v_itemName, V v_tag)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "delete", R.Cat(R.S("/items/"), v_itemName, R.S("/tags/"), v_tag), V.None, V.None, V.None);
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
                    return R.Dict(("error", R.S("Item not editable.")));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("Item not found.")));
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
                return R.Dict(("error", R.S("Item not found.")));
            }
            else if (R.Eq(v_status_code, R.I(405)))
            {
                return R.Dict(("error", R.S("Item not editable.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> removeTag_A(OpenHABClient C, CancellationToken ct, V v_itemName, V v_tag)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "delete", R.Cat(R.S("/items/"), v_itemName, R.S("/tags/"), v_tag), V.None, V.None, V.None, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Item not editable.")));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("Item not found.")));
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
                return R.Dict(("error", R.S("Item not found.")));
            }
            else if (R.Eq(v_status_code, R.I(405)))
            {
                return R.Dict(("error", R.S("Item not editable.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V purgeOrphanedMetadata_S(OpenHABClient C)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "post", R.S("/items/metadata/purge"), V.None, V.None, V.None);
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

        static async Task<V> purgeOrphanedMetadata_A(OpenHABClient C, CancellationToken ct)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "post", R.S("/items/metadata/purge"), V.None, V.None, V.None, ct).ConfigureAwait(false));
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
