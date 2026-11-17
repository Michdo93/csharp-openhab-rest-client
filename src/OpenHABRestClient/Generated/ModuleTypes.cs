// Generated from python-openhab-rest-client by tools/py2cs.py – do not edit.
#pragma warning disable CS1998, CS0168, CS0219, IDE0059
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using OpenHABRestClient.Internal;

namespace OpenHABRestClient
{
    /// <summary>
    /// openHAB REST API: ModuleTypes.
    /// </summary>
    public sealed class ModuleTypes
    {
        readonly OpenHABClient _client;

        /// <summary>Creates the ModuleTypes class for a connected client.</summary>
        public ModuleTypes(OpenHABClient client) => _client = client;

        /// <summary>
        /// Get all available module types.
        /// </summary>
        /// <param name="tags">Optional filter for tags.</param>
        /// <param name="typeFilter">Optional filter for the type (action, condition, trigger).</param>
        /// <param name="language">(Optional) Language setting for the Accept-Language header.</param>
        /// <returns>A list of module types.</returns>
        public JsonNode? GetModuleTypes(string? tags = null, string? typeFilter = null,
                                        string? language = null)
            => R.Finish(() => getModuleTypes_S(_client, R.Arg(tags), R.Arg(typeFilter), R.Arg(language)));

        /// <summary>Asynchronous <see cref="GetModuleTypes"/>.</summary>
        public Task<JsonNode?> GetModuleTypesAsync(string? tags = null, string? typeFilter = null,
                                                   string? language = null,
                                                   CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getModuleTypes_A(_client, cancellationToken, R.Arg(tags), R.Arg(typeFilter), R.Arg(language)));

        /// <summary>
        /// Gets a module type corresponding to the given UID.
        /// </summary>
        /// <param name="moduleTypeUID">The UID of the module type.</param>
        /// <param name="language">(Optional) Language setting for the Accept-Language header.</param>
        /// <returns>A dictionary with the module type information.</returns>
        public JsonNode? GetModuleType(string moduleTypeUID, string? language = null)
            => R.Finish(() => getModuleType_S(_client, R.Arg(moduleTypeUID), R.Arg(language)));

        /// <summary>Asynchronous <see cref="GetModuleType"/>.</summary>
        public Task<JsonNode?> GetModuleTypeAsync(string moduleTypeUID, string? language = null,
                                                  CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getModuleType_A(_client, cancellationToken, R.Arg(moduleTypeUID), R.Arg(language)));

        static V getModuleTypes_S(OpenHABClient C, V v_tags, V v_typeFilter, V v_language)
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
            if (R.Truthy(v_tags))
            {
                R.Set(v_params, R.S("tags"), v_tags);
            }
            if (R.Truthy(v_typeFilter))
            {
                R.Set(v_params, R.S("type"), v_typeFilter);
            }
            try
            {
                v_response = R.Http(C, "get", R.S("/module-types"), v_headers, V.None, v_params);
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

        static async Task<V> getModuleTypes_A(OpenHABClient C, CancellationToken ct, V v_tags, V v_typeFilter,
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
            if (R.Truthy(v_tags))
            {
                R.Set(v_params, R.S("tags"), v_tags);
            }
            if (R.Truthy(v_typeFilter))
            {
                R.Set(v_params, R.S("type"), v_typeFilter);
            }
            try
            {
                v_response = (await R.HttpAsync(C, "get", R.S("/module-types"), v_headers, V.None, v_params, ct).ConfigureAwait(false));
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

        static V getModuleType_S(OpenHABClient C, V v_moduleTypeUID, V v_language)
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
                v_response = R.Http(C, "get", R.Cat(R.S("/module-types/"), v_moduleTypeUID), v_headers, V.None, V.None);
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
                    return R.Dict(("error", R.S("Module Type corresponding to the given UID was not found.")));
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
                return R.Dict(("error", R.S("Module Type corresponding to the given UID was not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> getModuleType_A(OpenHABClient C, CancellationToken ct, V v_moduleTypeUID,
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
                v_response = (await R.HttpAsync(C, "get", R.Cat(R.S("/module-types/"), v_moduleTypeUID), v_headers, V.None, V.None, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Module Type corresponding to the given UID was not found.")));
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
                return R.Dict(("error", R.S("Module Type corresponding to the given UID was not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }
    }
}
