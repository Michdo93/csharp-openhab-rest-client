using System.Collections.Generic;
using System.Threading.Tasks;
using static OpenHABRestClient.OpenHABClient;

namespace OpenHABRestClient
{
    /// <summary>openHAB Items REST API.</summary>
    public class Items
    {
        private readonly OpenHABClient _client;

        /// <param name="client">Connected <see cref="OpenHABClient"/> instance.</param>
        public Items(OpenHABClient client) => _client = client;

        // ── getItems ──────────────────────────────────────────────────────────

        public string GetItems(string? type = null, string? tags = null,
            string metadata = ".*", bool recursive = false,
            string? fields = null, bool staticDataOnly = false, string? language = null)
        {
            var h = new Dictionary<string, string> { ["Accept"] = "application/json" };
            if (language != null) h["Accept-Language"] = language;
            return _client.Get("/items", h, Q("type", type, "tags", tags,
                "metadata", metadata, "recursive", recursive.ToString().ToLower(),
                "fields", fields, "staticDataOnly", staticDataOnly.ToString().ToLower()));
        }

        public Task<string> GetItemsAsync(string? type = null, string? tags = null,
            string metadata = ".*", bool recursive = false,
            string? fields = null, bool staticDataOnly = false, string? language = null)
        {
            var h = new Dictionary<string, string> { ["Accept"] = "application/json" };
            if (language != null) h["Accept-Language"] = language;
            return _client.GetAsync("/items", h, Q("type", type, "tags", tags,
                "metadata", metadata, "recursive", recursive.ToString().ToLower(),
                "fields", fields, "staticDataOnly", staticDataOnly.ToString().ToLower()));
        }

        // ── addOrUpdateItems ──────────────────────────────────────────────────

        public string AddOrUpdateItems(string itemsJson)
            => _client.Put("/items", H("Content-Type", "application/json", "Accept", "*/*"), itemsJson);

        public Task<string> AddOrUpdateItemsAsync(string itemsJson)
            => _client.PutAsync("/items", H("Content-Type", "application/json", "Accept", "*/*"), itemsJson);

        // ── getItem ───────────────────────────────────────────────────────────

        public string GetItem(string itemName, string metadata = ".*",
            bool recursive = true, string? language = null)
        {
            var h = new Dictionary<string, string> { ["Accept"] = "application/json" };
            if (language != null) h["Accept-Language"] = language;
            return _client.Get($"/items/{itemName}", h,
                Q("metadata", metadata, "recursive", recursive.ToString().ToLower()));
        }

        public Task<string> GetItemAsync(string itemName, string metadata = ".*",
            bool recursive = true, string? language = null)
        {
            var h = new Dictionary<string, string> { ["Accept"] = "application/json" };
            if (language != null) h["Accept-Language"] = language;
            return _client.GetAsync($"/items/{itemName}", h,
                Q("metadata", metadata, "recursive", recursive.ToString().ToLower()));
        }

        // ── addOrUpdateItem ───────────────────────────────────────────────────

        public string AddOrUpdateItem(string itemName, string itemDataJson, string? language = null)
        {
            var h = new Dictionary<string, string>
                { ["Content-Type"] = "application/json", ["Accept"] = "*/*" };
            if (language != null) h["Accept-Language"] = language;
            return _client.Put($"/items/{itemName}", h, itemDataJson);
        }

        public Task<string> AddOrUpdateItemAsync(string itemName, string itemDataJson, string? language = null)
        {
            var h = new Dictionary<string, string>
                { ["Content-Type"] = "application/json", ["Accept"] = "*/*" };
            if (language != null) h["Accept-Language"] = language;
            return _client.PutAsync($"/items/{itemName}", h, itemDataJson);
        }

        // ── sendCommand ───────────────────────────────────────────────────────

        public string SendCommand(string itemName, string command)
            => _client.Post($"/items/{itemName}", H("Content-Type", "text/plain"), command);

        public Task<string> SendCommandAsync(string itemName, string command)
            => _client.PostAsync($"/items/{itemName}", H("Content-Type", "text/plain"), command);

        // ── postUpdate ────────────────────────────────────────────────────────

        public string PostUpdate(string itemName, string state)
            => UpdateItemState(itemName, state);

        public Task<string> PostUpdateAsync(string itemName, string state)
            => UpdateItemStateAsync(itemName, state);

        // ── deleteItem ────────────────────────────────────────────────────────

        public string DeleteItem(string itemName)
            => _client.Delete($"/items/{itemName}");

        public Task<string> DeleteItemAsync(string itemName)
            => _client.DeleteAsync($"/items/{itemName}");

        // ── group members ─────────────────────────────────────────────────────

        public string AddGroupMember(string itemName, string memberItemName)
            => _client.Put($"/items/{itemName}/members/{memberItemName}");

        public Task<string> AddGroupMemberAsync(string itemName, string memberItemName)
            => _client.PutAsync($"/items/{itemName}/members/{memberItemName}");

        public string RemoveGroupMember(string itemName, string memberItemName)
            => _client.Delete($"/items/{itemName}/members/{memberItemName}");

        public Task<string> RemoveGroupMemberAsync(string itemName, string memberItemName)
            => _client.DeleteAsync($"/items/{itemName}/members/{memberItemName}");

        // ── metadata ─────────────────────────────────────────────────────────

        public string AddMetadata(string itemName, string ns, string metadataJson)
            => _client.Put($"/items/{itemName}/metadata/{ns}",
                H("Content-Type", "application/json"), metadataJson);

        public Task<string> AddMetadataAsync(string itemName, string ns, string metadataJson)
            => _client.PutAsync($"/items/{itemName}/metadata/{ns}",
                H("Content-Type", "application/json"), metadataJson);

        public string RemoveMetadata(string itemName, string ns)
            => _client.Delete($"/items/{itemName}/metadata/{ns}");

        public Task<string> RemoveMetadataAsync(string itemName, string ns)
            => _client.DeleteAsync($"/items/{itemName}/metadata/{ns}");

        public string GetMetadataNamespaces(string itemName, string? language = null)
        {
            var h = new Dictionary<string, string> { ["Accept"] = "application/json" };
            if (language != null) h["Accept-Language"] = language;
            return _client.Get($"/items/{itemName}/metadata/namespaces", h);
        }

        public Task<string> GetMetadataNamespacesAsync(string itemName, string? language = null)
        {
            var h = new Dictionary<string, string> { ["Accept"] = "application/json" };
            if (language != null) h["Accept-Language"] = language;
            return _client.GetAsync($"/items/{itemName}/metadata/namespaces", h);
        }

        // ── semantic ─────────────────────────────────────────────────────────

        public string GetSemanticItem(string itemName, string semanticClass, string? language = null)
        {
            var h = new Dictionary<string, string> { ["Accept"] = "application/json" };
            if (language != null) h["Accept-Language"] = language;
            return _client.Get($"/items/{itemName}/semantic/{semanticClass}", h);
        }

        public Task<string> GetSemanticItemAsync(string itemName, string semanticClass, string? language = null)
        {
            var h = new Dictionary<string, string> { ["Accept"] = "application/json" };
            if (language != null) h["Accept-Language"] = language;
            return _client.GetAsync($"/items/{itemName}/semantic/{semanticClass}", h);
        }

        // ── state ─────────────────────────────────────────────────────────────

        public string GetItemState(string itemName)
            => _client.Get($"/items/{itemName}/state", H("Accept", "text/plain"));

        public Task<string> GetItemStateAsync(string itemName)
            => _client.GetAsync($"/items/{itemName}/state", H("Accept", "text/plain"));

        public string UpdateItemState(string itemName, string state, string? language = null)
        {
            var h = new Dictionary<string, string> { ["Content-Type"] = "text/plain" };
            if (language != null) h["Accept-Language"] = language;
            return _client.Put($"/items/{itemName}/state", h, state);
        }

        public Task<string> UpdateItemStateAsync(string itemName, string state, string? language = null)
        {
            var h = new Dictionary<string, string> { ["Content-Type"] = "text/plain" };
            if (language != null) h["Accept-Language"] = language;
            return _client.PutAsync($"/items/{itemName}/state", h, state);
        }

        // ── tags ──────────────────────────────────────────────────────────────

        public string AddTag(string itemName, string tag)
            => _client.Put($"/items/{itemName}/tags/{tag}");

        public Task<string> AddTagAsync(string itemName, string tag)
            => _client.PutAsync($"/items/{itemName}/tags/{tag}");

        public string RemoveTag(string itemName, string tag)
            => _client.Delete($"/items/{itemName}/tags/{tag}");

        public Task<string> RemoveTagAsync(string itemName, string tag)
            => _client.DeleteAsync($"/items/{itemName}/tags/{tag}");

        // ── misc ──────────────────────────────────────────────────────────────

        public string PurgeOrphanedMetadata()
            => _client.Post("/items/metadata/purge");

        public Task<string> PurgeOrphanedMetadataAsync()
            => _client.PostAsync("/items/metadata/purge");
    }
}
