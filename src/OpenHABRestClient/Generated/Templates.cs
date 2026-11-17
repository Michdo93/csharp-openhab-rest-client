// Generated from python-openhab-rest-client by tools/py2cs.py – do not edit.
#pragma warning disable CS1998, CS0168, CS0219, IDE0059
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using OpenHABRestClient.Internal;

namespace OpenHABRestClient
{
    /// <summary>
    /// openHAB REST API: Templates.
    /// </summary>
    public sealed class Templates
    {
        readonly OpenHABClient _client;

        /// <summary>Creates the Templates class for a connected client.</summary>
        public Templates(OpenHABClient client) => _client = client;

        /// <summary>
        /// Get all available templates.
        /// </summary>
        /// <param name="language">(Optional) Language setting for the Accept-Language header.</param>
        /// <returns>A list of templates.</returns>
        public JsonNode? GetTemplates(string? language = null)
            => R.Finish(() => getTemplates_S(_client, R.Arg(language)));

        /// <summary>Asynchronous <see cref="GetTemplates"/>.</summary>
        public Task<JsonNode?> GetTemplatesAsync(string? language = null,
                                                 CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getTemplates_A(_client, cancellationToken, R.Arg(language)));

        /// <summary>
        /// Gets a template corresponding to the given UID.
        /// </summary>
        /// <param name="templateUID">The UID of the template.</param>
        /// <param name="language">(Optional) Language setting for the Accept-Language header.</param>
        /// <returns>A dictionary with the details of the template.</returns>
        public JsonNode? GetTemplate(string templateUID, string? language = null)
            => R.Finish(() => getTemplate_S(_client, R.Arg(templateUID), R.Arg(language)));

        /// <summary>Asynchronous <see cref="GetTemplate"/>.</summary>
        public Task<JsonNode?> GetTemplateAsync(string templateUID, string? language = null,
                                                CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getTemplate_A(_client, cancellationToken, R.Arg(templateUID), R.Arg(language)));

        static V getTemplates_S(OpenHABClient C, V v_language)
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
                v_response = R.Http(C, "get", R.S("/templates"), v_headers, V.None, V.None);
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

        static async Task<V> getTemplates_A(OpenHABClient C, CancellationToken ct, V v_language)
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
                v_response = (await R.HttpAsync(C, "get", R.S("/templates"), v_headers, V.None, V.None, ct).ConfigureAwait(false));
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

        static V getTemplate_S(OpenHABClient C, V v_templateUID, V v_language)
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
                v_response = R.Http(C, "get", R.Cat(R.S("/templates/"), v_templateUID), v_headers, V.None, V.None);
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
                    return R.Dict(("error", R.S("Template corresponding to the given UID was not found.")));
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
                return R.Dict(("error", R.S("Template corresponding to the given UID was not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> getTemplate_A(OpenHABClient C, CancellationToken ct, V v_templateUID,
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
                v_response = (await R.HttpAsync(C, "get", R.Cat(R.S("/templates/"), v_templateUID), v_headers, V.None, V.None, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Template corresponding to the given UID was not found.")));
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
                return R.Dict(("error", R.S("Template corresponding to the given UID was not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }
    }
}
