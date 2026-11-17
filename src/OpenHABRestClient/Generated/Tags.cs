// Generated from python-openhab-rest-client by tools/py2cs.py – do not edit.
#pragma warning disable CS1998, CS0168, CS0219, IDE0059
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using OpenHABRestClient.Internal;

namespace OpenHABRestClient
{
    /// <summary>
    /// openHAB REST API: Tags.
    /// </summary>
    public sealed class Tags
    {
        readonly OpenHABClient _client;

        /// <summary>Creates the Tags class for a connected client.</summary>
        public Tags(OpenHABClient client) => _client = client;

        /// <summary>
        /// Get all available semantic tags.
        /// </summary>
        /// <param name="language">Optional headers for language setting.</param>
        /// <returns>A list of semantic tags (JSON).</returns>
        public JsonNode? GetTags(string? language = null)
            => R.Finish(() => getTags_S(_client, R.Arg(language)));

        /// <summary>Asynchronous <see cref="GetTags"/>.</summary>
        public Task<JsonNode?> GetTagsAsync(string? language = null,
                                            CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getTags_A(_client, cancellationToken, R.Arg(language)));

        /// <summary>
        /// Creates a new semantic tag and adds it to the registry.
        /// </summary>
        /// <param name="tagData">The data object for the tag to be created.</param>
        /// <param name="language">Optional headers for language setting.</param>
        /// <returns>The response to the tag creation request (JSON).</returns>
        public JsonNode? CreateTag(object tagData, string? language = null)
            => R.Finish(() => createTag_S(_client, R.Arg(tagData), R.Arg(language)));

        /// <summary>Asynchronous <see cref="CreateTag"/>.</summary>
        public Task<JsonNode?> CreateTagAsync(object tagData, string? language = null,
                                              CancellationToken cancellationToken = default)
            => R.FinishAsync(() => createTag_A(_client, cancellationToken, R.Arg(tagData), R.Arg(language)));

        /// <summary>
        /// Gets a semantic tag and its sub-tags.
        /// </summary>
        /// <param name="tagID">The ID of the tag to retrieve.</param>
        /// <param name="language">Optional headers for language setting.</param>
        /// <returns>The tag object and its sub-tags (JSON).</returns>
        public JsonNode? GetTag(string tagID, string? language = null)
            => R.Finish(() => getTag_S(_client, R.Arg(tagID), R.Arg(language)));

        /// <summary>Asynchronous <see cref="GetTag"/>.</summary>
        public Task<JsonNode?> GetTagAsync(string tagID, string? language = null,
                                           CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getTag_A(_client, cancellationToken, R.Arg(tagID), R.Arg(language)));

        /// <summary>
        /// Updates a semantic tag.
        /// </summary>
        /// <param name="tagID">The ID of the tag to be updated.</param>
        /// <param name="tagData">The new tag data.</param>
        /// <param name="language">Optional headers for language setting.</param>
        /// <returns>The response to the tag update request (JSON).</returns>
        public JsonNode? UpdateTag(string tagID, object tagData, string? language = null)
            => R.Finish(() => updateTag_S(_client, R.Arg(tagID), R.Arg(tagData), R.Arg(language)));

        /// <summary>Asynchronous <see cref="UpdateTag"/>.</summary>
        public Task<JsonNode?> UpdateTagAsync(string tagID, object tagData, string? language = null,
                                              CancellationToken cancellationToken = default)
            => R.FinishAsync(() => updateTag_A(_client, cancellationToken, R.Arg(tagID), R.Arg(tagData), R.Arg(language)));

        /// <summary>
        /// Removes a semantic tag and its sub-tags from the registry.
        /// </summary>
        /// <param name="tagID">The ID of the tag to be removed.</param>
        /// <param name="language">Optional headers for language setting.</param>
        /// <returns>The response to the tag deletion request (JSON).</returns>
        public JsonNode? DeleteTag(string tagID, string? language = null)
            => R.Finish(() => deleteTag_S(_client, R.Arg(tagID), R.Arg(language)));

        /// <summary>Asynchronous <see cref="DeleteTag"/>.</summary>
        public Task<JsonNode?> DeleteTagAsync(string tagID, string? language = null,
                                              CancellationToken cancellationToken = default)
            => R.FinishAsync(() => deleteTag_A(_client, cancellationToken, R.Arg(tagID), R.Arg(language)));

        static V getTags_S(OpenHABClient C, V v_language)
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
                v_response = R.Http(C, "get", R.S("/tags"), v_headers, V.None, V.None);
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

        static async Task<V> getTags_A(OpenHABClient C, CancellationToken ct, V v_language)
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
                v_response = (await R.HttpAsync(C, "get", R.S("/tags"), v_headers, V.None, V.None, ct).ConfigureAwait(false));
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

        static V createTag_S(OpenHABClient C, V v_tagData, V v_language)
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
                v_response = R.Http(C, "post", R.S("/tags"), v_headers, R.Dumps(v_tagData), V.None);
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
                    return R.Dict(("error", R.S("The tag identifier is invalid or the tag label is missing.")));
                }
                else if (R.Eq(v_status_code, R.I(409)))
                {
                    return R.Dict(("error", R.S("A tag with the same identifier already exists.")));
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
                return R.Dict(("message", R.S("Created")));
            }
            else if (R.Eq(v_status_code, R.I(400)))
            {
                return R.Dict(("error", R.S("The tag identifier is invalid or the tag label is missing.")));
            }
            else if (R.Eq(v_status_code, R.I(409)))
            {
                return R.Dict(("error", R.S("A tag with the same identifier already exists.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> createTag_A(OpenHABClient C, CancellationToken ct, V v_tagData, V v_language)
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
                v_response = (await R.HttpAsync(C, "post", R.S("/tags"), v_headers, R.Dumps(v_tagData), V.None, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("The tag identifier is invalid or the tag label is missing.")));
                }
                else if (R.Eq(v_status_code, R.I(409)))
                {
                    return R.Dict(("error", R.S("A tag with the same identifier already exists.")));
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
                return R.Dict(("message", R.S("Created")));
            }
            else if (R.Eq(v_status_code, R.I(400)))
            {
                return R.Dict(("error", R.S("The tag identifier is invalid or the tag label is missing.")));
            }
            else if (R.Eq(v_status_code, R.I(409)))
            {
                return R.Dict(("error", R.S("A tag with the same identifier already exists.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V getTag_S(OpenHABClient C, V v_tagID, V v_language)
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
                v_response = R.Http(C, "get", R.Cat(R.S("/tags/"), v_tagID), v_headers, V.None, V.None);
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
                    return R.Dict(("error", R.S("Semantic tag not found.")));
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
                return R.Dict(("error", R.S("Semantic tag not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> getTag_A(OpenHABClient C, CancellationToken ct, V v_tagID, V v_language)
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
                v_response = (await R.HttpAsync(C, "get", R.Cat(R.S("/tags/"), v_tagID), v_headers, V.None, V.None, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Semantic tag not found.")));
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
                return R.Dict(("error", R.S("Semantic tag not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V updateTag_S(OpenHABClient C, V v_tagID, V v_tagData, V v_language)
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
                v_response = R.Http(C, "put", R.Cat(R.S("/tags/"), v_tagID), v_headers, R.Dumps(v_tagData), V.None);
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
                    return R.Dict(("error", R.S("Semantic tag not editable.")));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("Semantic tag not found.")));
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
                return R.Dict(("error", R.S("Semantic tag not found.")));
            }
            else if (R.Eq(v_status_code, R.I(405)))
            {
                return R.Dict(("error", R.S("Semantic tag not editable.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> updateTag_A(OpenHABClient C, CancellationToken ct, V v_tagID, V v_tagData,
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
                v_response = (await R.HttpAsync(C, "put", R.Cat(R.S("/tags/"), v_tagID), v_headers, R.Dumps(v_tagData), V.None, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Semantic tag not editable.")));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("Semantic tag not found.")));
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
                return R.Dict(("error", R.S("Semantic tag not found.")));
            }
            else if (R.Eq(v_status_code, R.I(405)))
            {
                return R.Dict(("error", R.S("Semantic tag not editable.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V deleteTag_S(OpenHABClient C, V v_tagID, V v_language)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "delete", R.Cat(R.S("/tags/"), v_tagID), (R.Truthy(v_language) ? R.Dict(("Accept-Language", v_language)) : R.Dict()), V.None, V.None);
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
                    return R.Dict(("error", R.S("Semantic tag not removable.")));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("Semantic tag not found.")));
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
            else if (R.Eq(v_status_code, R.I(404)))
            {
                return R.Dict(("error", R.S("Semantic tag not found.")));
            }
            else if (R.Eq(v_status_code, R.I(405)))
            {
                return R.Dict(("error", R.S("Semantic tag not removable.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> deleteTag_A(OpenHABClient C, CancellationToken ct, V v_tagID, V v_language)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "delete", R.Cat(R.S("/tags/"), v_tagID), (R.Truthy(v_language) ? R.Dict(("Accept-Language", v_language)) : R.Dict()), V.None, V.None, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Semantic tag not removable.")));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("Semantic tag not found.")));
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
            else if (R.Eq(v_status_code, R.I(404)))
            {
                return R.Dict(("error", R.S("Semantic tag not found.")));
            }
            else if (R.Eq(v_status_code, R.I(405)))
            {
                return R.Dict(("error", R.S("Semantic tag not removable.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }
    }
}
