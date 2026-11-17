// Generated from python-openhab-rest-client by tools/py2cs.py – do not edit.
#pragma warning disable CS1998, CS0168, CS0219, IDE0059
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using OpenHABRestClient.Internal;

namespace OpenHABRestClient
{
    /// <summary>
    /// openHAB REST API: UI.
    /// </summary>
    public sealed class UI
    {
        readonly OpenHABClient _client;

        /// <summary>Creates the UI class for a connected client.</summary>
        public UI(OpenHABClient client) => _client = client;

        /// <summary>
        /// Get all registered UI components in the specified namespace.
        /// </summary>
        /// <param name="namespace">The namespace for which UI components should be retrieved.</param>
        /// <param name="summary">If True, only summary fields will be returned.</param>
        /// <returns>A list of UI components (JSON).</returns>
        public JsonNode? GetUIComponents(string @namespace, bool summary = false)
            => R.Finish(() => getUIComponents_S(_client, R.Arg(@namespace), R.Arg(summary)));

        /// <summary>Asynchronous <see cref="GetUIComponents"/>.</summary>
        public Task<JsonNode?> GetUIComponentsAsync(string @namespace, bool summary = false,
                                                    CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getUIComponents_A(_client, cancellationToken, R.Arg(@namespace), R.Arg(summary)));

        /// <summary>
        /// Add a UI component in the specified namespace.
        /// </summary>
        /// <param name="namespace">The namespace where the UI component should be added.</param>
        /// <param name="componentData">The data of the UI component (JSON) to be added.</param>
        /// <returns>The response to the request (JSON).</returns>
        public JsonNode? AddUIComponent(string @namespace, object componentData)
            => R.Finish(() => addUIComponent_S(_client, R.Arg(@namespace), R.Arg(componentData)));

        /// <summary>Asynchronous <see cref="AddUIComponent"/>.</summary>
        public Task<JsonNode?> AddUIComponentAsync(string @namespace, object componentData,
                                                   CancellationToken cancellationToken = default)
            => R.FinishAsync(() => addUIComponent_A(_client, cancellationToken, R.Arg(@namespace), R.Arg(componentData)));

        /// <summary>
        /// Get a specific UI component in the specified namespace.
        /// </summary>
        /// <param name="namespace">The namespace where the UI component is located.</param>
        /// <param name="componentUID">The UID of the UI component to retrieve.</param>
        /// <returns>The UI component (JSON).</returns>
        public JsonNode? GetUIComponent(string @namespace, string componentUID)
            => R.Finish(() => getUIComponent_S(_client, R.Arg(@namespace), R.Arg(componentUID)));

        /// <summary>Asynchronous <see cref="GetUIComponent"/>.</summary>
        public Task<JsonNode?> GetUIComponentAsync(string @namespace, string componentUID,
                                                   CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getUIComponent_A(_client, cancellationToken, R.Arg(@namespace), R.Arg(componentUID)));

        /// <summary>
        /// Update a specific UI component in the specified namespace.
        /// </summary>
        /// <param name="namespace">The namespace where the UI component should be updated.</param>
        /// <param name="componentUID">The UID of the UI component to update.</param>
        /// <param name="componentData">The new data for the UI component (JSON).</param>
        /// <returns>The response to the request (JSON).</returns>
        public JsonNode? UpdateUIComponent(string @namespace, string componentUID, object componentData)
            => R.Finish(() => updateUIComponent_S(_client, R.Arg(@namespace), R.Arg(componentUID), R.Arg(componentData)));

        /// <summary>Asynchronous <see cref="UpdateUIComponent"/>.</summary>
        public Task<JsonNode?> UpdateUIComponentAsync(string @namespace, string componentUID,
                                                      object componentData,
                                                      CancellationToken cancellationToken = default)
            => R.FinishAsync(() => updateUIComponent_A(_client, cancellationToken, R.Arg(@namespace), R.Arg(componentUID), R.Arg(componentData)));

        /// <summary>
        /// Remove a specific UI component in the specified namespace.
        /// </summary>
        /// <param name="namespace">The namespace where the UI component should be removed.</param>
        /// <param name="componentUID">The UID of the UI component to delete.</param>
        /// <returns>The response to the request (JSON).</returns>
        public JsonNode? DeleteUIComponent(string @namespace, string componentUID)
            => R.Finish(() => deleteUIComponent_S(_client, R.Arg(@namespace), R.Arg(componentUID)));

        /// <summary>Asynchronous <see cref="DeleteUIComponent"/>.</summary>
        public Task<JsonNode?> DeleteUIComponentAsync(string @namespace, string componentUID,
                                                      CancellationToken cancellationToken = default)
            => R.FinishAsync(() => deleteUIComponent_A(_client, cancellationToken, R.Arg(@namespace), R.Arg(componentUID)));

        /// <summary>
        /// Get all registered UI tiles.
        /// </summary>
        /// <returns>A list of UI tiles (JSON).</returns>
        public JsonNode? GetUITiles()
            => R.Finish(() => getUITiles_S(_client));

        /// <summary>Asynchronous <see cref="GetUITiles"/>.</summary>
        public Task<JsonNode?> GetUITilesAsync(CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getUITiles_A(_client, cancellationToken));

        static V getUIComponents_S(OpenHABClient C, V v_namespace, V v_summary)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "get", R.Cat(R.S("/ui/components/"), v_namespace), R.Dict(("Accept", R.S("application/json"))), V.None, (R.Truthy(v_summary) ? R.Dict(("summary", v_summary)) : R.Dict()));
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

        static async Task<V> getUIComponents_A(OpenHABClient C, CancellationToken ct, V v_namespace,
                                               V v_summary)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "get", R.Cat(R.S("/ui/components/"), v_namespace), R.Dict(("Accept", R.S("application/json"))), V.None, (R.Truthy(v_summary) ? R.Dict(("summary", v_summary)) : R.Dict()), ct).ConfigureAwait(false));
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

        static V addUIComponent_S(OpenHABClient C, V v_namespace, V v_componentData)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "post", R.Cat(R.S("/ui/components/"), v_namespace), R.Dict(("Content-Type", R.S("application/json")), ("Accept", R.S("application/json"))), R.Dumps(v_componentData), V.None);
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

        static async Task<V> addUIComponent_A(OpenHABClient C, CancellationToken ct, V v_namespace,
                                              V v_componentData)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "post", R.Cat(R.S("/ui/components/"), v_namespace), R.Dict(("Content-Type", R.S("application/json")), ("Accept", R.S("application/json"))), R.Dumps(v_componentData), V.None, ct).ConfigureAwait(false));
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

        static V getUIComponent_S(OpenHABClient C, V v_namespace, V v_componentUID)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "get", R.Cat(R.S("/ui/components/"), v_namespace, R.S("/"), v_componentUID), R.Dict(("Accept", R.S("application/json"))), V.None, V.None);
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
                    return R.Dict(("error", R.S("Component not found.")));
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
                return R.Dict(("error", R.S("Component not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> getUIComponent_A(OpenHABClient C, CancellationToken ct, V v_namespace,
                                              V v_componentUID)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "get", R.Cat(R.S("/ui/components/"), v_namespace, R.S("/"), v_componentUID), R.Dict(("Accept", R.S("application/json"))), V.None, V.None, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Component not found.")));
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
                return R.Dict(("error", R.S("Component not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V updateUIComponent_S(OpenHABClient C, V v_namespace, V v_componentUID, V v_componentData)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "put", R.Cat(R.S("/ui/components/"), v_namespace, R.S("/"), v_componentUID), R.Dict(("Content-Type", R.S("application/json")), ("Accept", R.S("application/json"))), R.Dumps(v_componentData), V.None);
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
                    return R.Dict(("error", R.S("Component not found.")));
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
                return R.Dict(("error", R.S("Component not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> updateUIComponent_A(OpenHABClient C, CancellationToken ct, V v_namespace,
                                                 V v_componentUID, V v_componentData)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "put", R.Cat(R.S("/ui/components/"), v_namespace, R.S("/"), v_componentUID), R.Dict(("Content-Type", R.S("application/json")), ("Accept", R.S("application/json"))), R.Dumps(v_componentData), V.None, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Component not found.")));
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
                return R.Dict(("error", R.S("Component not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V deleteUIComponent_S(OpenHABClient C, V v_namespace, V v_componentUID)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "delete", R.Cat(R.S("/ui/components/"), v_namespace, R.S("/"), v_componentUID), V.None, V.None, V.None);
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
                    return R.Dict(("error", R.S("Component not found.")));
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
                return R.Dict(("error", R.S("Component not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> deleteUIComponent_A(OpenHABClient C, CancellationToken ct, V v_namespace,
                                                 V v_componentUID)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "delete", R.Cat(R.S("/ui/components/"), v_namespace, R.S("/"), v_componentUID), V.None, V.None, V.None, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Component not found.")));
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
                return R.Dict(("error", R.S("Component not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V getUITiles_S(OpenHABClient C)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "get", R.S("/ui/tiles"), R.Dict(("Accept", R.S("application/json"))), V.None, V.None);
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

        static async Task<V> getUITiles_A(OpenHABClient C, CancellationToken ct)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "get", R.S("/ui/tiles"), R.Dict(("Accept", R.S("application/json"))), V.None, V.None, ct).ConfigureAwait(false));
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
