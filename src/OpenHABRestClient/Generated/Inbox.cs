// Generated from python-openhab-rest-client by tools/py2cs.py – do not edit.
#pragma warning disable CS1998, CS0168, CS0219, IDE0059
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using OpenHABRestClient.Internal;

namespace OpenHABRestClient
{
    /// <summary>
    /// openHAB REST API: Inbox.
    /// </summary>
    public sealed class Inbox
    {
        readonly OpenHABClient _client;

        /// <summary>Creates the Inbox class for a connected client.</summary>
        public Inbox(OpenHABClient client) => _client = client;

        /// <summary>
        /// Get all discovered things.
        /// </summary>
        /// <param name="includeIgnored">Whether ignored entries should also be included (default: True).</param>
        /// <returns>A list of discovered things with details such as UID, flag, label, and properties.</returns>
        public JsonNode? GetDiscoveredThings(bool includeIgnored = true)
            => R.Finish(() => getDiscoveredThings_S(_client, R.Arg(includeIgnored)));

        /// <summary>Asynchronous <see cref="GetDiscoveredThings"/>.</summary>
        public Task<JsonNode?> GetDiscoveredThingsAsync(bool includeIgnored = true,
                                                        CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getDiscoveredThings_A(_client, cancellationToken, R.Arg(includeIgnored)));

        /// <summary>
        /// Removes the discovery result from the inbox.
        /// </summary>
        /// <param name="thingUID">The UID of the discovered thing to be removed.</param>
        /// <returns>The API response to the delete request.</returns>
        public JsonNode? RemoveDiscoveryResult(string thingUID)
            => R.Finish(() => removeDiscoveryResult_S(_client, R.Arg(thingUID)));

        /// <summary>Asynchronous <see cref="RemoveDiscoveryResult"/>.</summary>
        public Task<JsonNode?> RemoveDiscoveryResultAsync(string thingUID,
                                                          CancellationToken cancellationToken = default)
            => R.FinishAsync(() => removeDiscoveryResult_A(_client, cancellationToken, R.Arg(thingUID)));

        /// <summary>
        /// Approves the discovery result by adding the thing to the registry.
        /// </summary>
        /// <param name="thingUID">The UID of the discovered thing.</param>
        /// <param name="thingLabel">The new name of the thing.</param>
        /// <param name="newThingID">Optional: The new thing ID.</param>
        /// <param name="language">Optional: Language preference for the response.</param>
        /// <returns>The API response to the approval request.</returns>
        public JsonNode? ApproveDiscoveryResult(string thingUID, string thingLabel, string? newThingID = null,
                                                string? language = null)
            => R.Finish(() => approveDiscoveryResult_S(_client, R.Arg(thingUID), R.Arg(thingLabel), R.Arg(newThingID), R.Arg(language)));

        /// <summary>Asynchronous <see cref="ApproveDiscoveryResult"/>.</summary>
        public Task<JsonNode?> ApproveDiscoveryResultAsync(string thingUID, string thingLabel,
                                                           string? newThingID = null, string? language = null,
                                                           CancellationToken cancellationToken = default)
            => R.FinishAsync(() => approveDiscoveryResult_A(_client, cancellationToken, R.Arg(thingUID), R.Arg(thingLabel), R.Arg(newThingID), R.Arg(language)));

        /// <summary>
        /// Flags a discovery result as ignored for further processing.
        /// </summary>
        /// <param name="thingUID">The UID of the discovered thing.</param>
        /// <returns>The API response to the ignore request.</returns>
        public JsonNode? IgnoreDiscoveryResult(string thingUID)
            => R.Finish(() => ignoreDiscoveryResult_S(_client, R.Arg(thingUID)));

        /// <summary>Asynchronous <see cref="IgnoreDiscoveryResult"/>.</summary>
        public Task<JsonNode?> IgnoreDiscoveryResultAsync(string thingUID,
                                                          CancellationToken cancellationToken = default)
            => R.FinishAsync(() => ignoreDiscoveryResult_A(_client, cancellationToken, R.Arg(thingUID)));

        /// <summary>
        /// Removes the ignore flag from a discovery result.
        /// </summary>
        /// <param name="thingUID">The UID of the discovered thing.</param>
        /// <returns>The API response to the unignore request.</returns>
        public JsonNode? UnignoreDiscoveryResult(string thingUID)
            => R.Finish(() => unignoreDiscoveryResult_S(_client, R.Arg(thingUID)));

        /// <summary>Asynchronous <see cref="UnignoreDiscoveryResult"/>.</summary>
        public Task<JsonNode?> UnignoreDiscoveryResultAsync(string thingUID,
                                                            CancellationToken cancellationToken = default)
            => R.FinishAsync(() => unignoreDiscoveryResult_A(_client, cancellationToken, R.Arg(thingUID)));

        static V getDiscoveredThings_S(OpenHABClient C, V v_includeIgnored)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "get", R.S("/inbox"), R.Dict(("Accept", R.S("application/json"))), V.None, R.Dict(("includeIgnored", R.Lower(R.Str(v_includeIgnored)))));
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

        static async Task<V> getDiscoveredThings_A(OpenHABClient C, CancellationToken ct, V v_includeIgnored)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "get", R.S("/inbox"), R.Dict(("Accept", R.S("application/json"))), V.None, R.Dict(("includeIgnored", R.Lower(R.Str(v_includeIgnored)))), ct).ConfigureAwait(false));
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

        static V removeDiscoveryResult_S(OpenHABClient C, V v_thingUID)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "delete", R.Cat(R.S("/inbox/"), v_thingUID), V.None, V.None, V.None);
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
                    return R.Dict(("error", R.S("Discovery result not found in the inbox.")));
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
                return R.Dict(("error", R.S("Discovery result not found in the inbox.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> removeDiscoveryResult_A(OpenHABClient C, CancellationToken ct, V v_thingUID)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "delete", R.Cat(R.S("/inbox/"), v_thingUID), V.None, V.None, V.None, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Discovery result not found in the inbox.")));
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
                return R.Dict(("error", R.S("Discovery result not found in the inbox.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V approveDiscoveryResult_S(OpenHABClient C, V v_thingUID, V v_thingLabel, V v_newThingID,
                                          V v_language)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "post", R.Cat(R.S("/inbox/"), v_thingUID, R.S("/approve")), (R.Truthy(v_language) ? R.Dict(("Accept-Language", v_language), ("Content-Type", R.S("text/plain"))) : R.Dict(("Content-Type", R.S("text/plain")))), v_thingLabel, (R.Truthy(v_newThingID) ? R.Dict(("newThingId", v_newThingID)) : R.Dict()));
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
                    return R.Dict(("error", R.S("Invalid new thing ID.")));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("Thing unable to be approved.")));
                }
                else if (R.Eq(v_status_code, R.I(409)))
                {
                    return R.Dict(("error", R.S("No binding found that supports this thing.")));
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
                return R.Dict(("error", R.S("Invalid new thing ID.")));
            }
            else if (R.Eq(v_status_code, R.I(404)))
            {
                return R.Dict(("error", R.S("Thing unable to be approved.")));
            }
            else if (R.Eq(v_status_code, R.I(409)))
            {
                return R.Dict(("error", R.S("No binding found that supports this thing.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> approveDiscoveryResult_A(OpenHABClient C, CancellationToken ct, V v_thingUID,
                                                      V v_thingLabel, V v_newThingID, V v_language)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "post", R.Cat(R.S("/inbox/"), v_thingUID, R.S("/approve")), (R.Truthy(v_language) ? R.Dict(("Accept-Language", v_language), ("Content-Type", R.S("text/plain"))) : R.Dict(("Content-Type", R.S("text/plain")))), v_thingLabel, (R.Truthy(v_newThingID) ? R.Dict(("newThingId", v_newThingID)) : R.Dict()), ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Invalid new thing ID.")));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("Thing unable to be approved.")));
                }
                else if (R.Eq(v_status_code, R.I(409)))
                {
                    return R.Dict(("error", R.S("No binding found that supports this thing.")));
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
                return R.Dict(("error", R.S("Invalid new thing ID.")));
            }
            else if (R.Eq(v_status_code, R.I(404)))
            {
                return R.Dict(("error", R.S("Thing unable to be approved.")));
            }
            else if (R.Eq(v_status_code, R.I(409)))
            {
                return R.Dict(("error", R.S("No binding found that supports this thing.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V ignoreDiscoveryResult_S(OpenHABClient C, V v_thingUID)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "post", R.Cat(R.S("/inbox/"), v_thingUID, R.S("/ignore")), V.None, V.None, V.None);
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

        static async Task<V> ignoreDiscoveryResult_A(OpenHABClient C, CancellationToken ct, V v_thingUID)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "post", R.Cat(R.S("/inbox/"), v_thingUID, R.S("/ignore")), V.None, V.None, V.None, ct).ConfigureAwait(false));
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

        static V unignoreDiscoveryResult_S(OpenHABClient C, V v_thingUID)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "post", R.Cat(R.S("/inbox/"), v_thingUID, R.S("/unignore")), V.None, V.None, V.None);
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

        static async Task<V> unignoreDiscoveryResult_A(OpenHABClient C, CancellationToken ct, V v_thingUID)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "post", R.Cat(R.S("/inbox/"), v_thingUID, R.S("/unignore")), V.None, V.None, V.None, ct).ConfigureAwait(false));
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
