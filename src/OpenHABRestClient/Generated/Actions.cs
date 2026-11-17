// Generated from python-openhab-rest-client by tools/py2cs.py – do not edit.
#pragma warning disable CS1998, CS0168, CS0219, IDE0059
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using OpenHABRestClient.Internal;

namespace OpenHABRestClient
{
    /// <summary>
    /// openHAB REST API: Actions.
    /// </summary>
    public sealed class Actions
    {
        readonly OpenHABClient _client;

        /// <summary>Creates the Actions class for a connected client.</summary>
        public Actions(OpenHABClient client) => _client = client;

        /// <summary>
        /// Get all available actions for provided thing UID.
        /// </summary>
        /// <param name="thingUID">The UID of the thing for which actions are to be retrieved.</param>
        /// <param name="language">(Optional) Language setting for the Accept-Language headers.</param>
        /// <returns>A list of actions.</returns>
        public JsonNode? GetActions(string thingUID, string? language = null)
            => R.Finish(() => getActions_S(_client, R.Arg(thingUID), R.Arg(language)));

        /// <summary>Asynchronous <see cref="GetActions"/>.</summary>
        public Task<JsonNode?> GetActionsAsync(string thingUID, string? language = null,
                                               CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getActions_A(_client, cancellationToken, R.Arg(thingUID), R.Arg(language)));

        /// <summary>
        /// Executes a thing action.
        /// </summary>
        /// <param name="thingUID">The UID of the thing on which the action is to be executed.</param>
        /// <param name="actionUID">The UID of the action to be executed.</param>
        /// <param name="actionInputs">The inputs for the action as a dictionary.</param>
        /// <param name="language">(Optional) Language setting for the Accept-Language headers.</param>
        /// <returns>A response from the server.</returns>
        public JsonNode? ExecuteAction(string thingUID, string actionUID, object actionInputs,
                                       string? language = null)
            => R.Finish(() => executeAction_S(_client, R.Arg(thingUID), R.Arg(actionUID), R.Arg(actionInputs), R.Arg(language)));

        /// <summary>Asynchronous <see cref="ExecuteAction"/>.</summary>
        public Task<JsonNode?> ExecuteActionAsync(string thingUID, string actionUID, object actionInputs,
                                                  string? language = null,
                                                  CancellationToken cancellationToken = default)
            => R.FinishAsync(() => executeAction_A(_client, cancellationToken, R.Arg(thingUID), R.Arg(actionUID), R.Arg(actionInputs), R.Arg(language)));

        static V getActions_S(OpenHABClient C, V v_thingUID, V v_language)
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
                v_response = R.Http(C, "get", R.Cat(R.S("/actions/"), v_thingUID), v_headers, V.None, V.None);
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
                    return R.Dict(("error", R.S("No actions found.")));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.Cat(R.S("Thing not found: "), v_thingUID)));
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
            else if (R.Eq(v_status_code, R.I(204)))
            {
                return R.Dict(("error", R.S("No actions found.")));
            }
            else if (R.Eq(v_status_code, R.I(404)))
            {
                return R.Dict(("error", R.Cat(R.S("Thing not found: "), v_thingUID)));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> getActions_A(OpenHABClient C, CancellationToken ct, V v_thingUID, V v_language)
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
                v_response = (await R.HttpAsync(C, "get", R.Cat(R.S("/actions/"), v_thingUID), v_headers, V.None, V.None, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("No actions found.")));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.Cat(R.S("Thing not found: "), v_thingUID)));
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
            else if (R.Eq(v_status_code, R.I(204)))
            {
                return R.Dict(("error", R.S("No actions found.")));
            }
            else if (R.Eq(v_status_code, R.I(404)))
            {
                return R.Dict(("error", R.Cat(R.S("Thing not found: "), v_thingUID)));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V executeAction_S(OpenHABClient C, V v_thingUID, V v_actionUID, V v_actionInputs, V v_language)
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
                v_response = R.Http(C, "post", R.Cat(R.S("/actions/"), v_thingUID, R.S("/"), v_actionUID), v_headers, R.Dumps(v_actionInputs), V.None);
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
                    return R.Dict(("error", R.S("Action not found.")));
                }
                else if (R.Eq(v_status_code, R.I(500)))
                {
                    return R.Dict(("error", R.S("Creation of action handler or execution failed.")));
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
                return R.Dict(("error", R.S("Action not found.")));
            }
            else if (R.Eq(v_status_code, R.I(500)))
            {
                return R.Dict(("error", R.S("Creation of action handler or execution failed.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> executeAction_A(OpenHABClient C, CancellationToken ct, V v_thingUID,
                                             V v_actionUID, V v_actionInputs, V v_language)
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
                v_response = (await R.HttpAsync(C, "post", R.Cat(R.S("/actions/"), v_thingUID, R.S("/"), v_actionUID), v_headers, R.Dumps(v_actionInputs), V.None, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Action not found.")));
                }
                else if (R.Eq(v_status_code, R.I(500)))
                {
                    return R.Dict(("error", R.S("Creation of action handler or execution failed.")));
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
                return R.Dict(("error", R.S("Action not found.")));
            }
            else if (R.Eq(v_status_code, R.I(500)))
            {
                return R.Dict(("error", R.S("Creation of action handler or execution failed.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }
    }
}
