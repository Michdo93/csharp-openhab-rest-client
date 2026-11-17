// Generated from python-openhab-rest-client by tools/py2cs.py – do not edit.
#pragma warning disable CS1998, CS0168, CS0219, IDE0059
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using OpenHABRestClient.Internal;

namespace OpenHABRestClient
{
    /// <summary>
    /// openHAB REST API: Auth.
    /// </summary>
    public sealed class Auth
    {
        readonly OpenHABClient _client;

        /// <summary>Creates the Auth class for a connected client.</summary>
        public Auth(OpenHABClient client) => _client = client;

        /// <summary>
        /// Retrieve the API tokens associated with the authenticated user.
        /// </summary>
        /// <returns>JSON response from the server.</returns>
        public JsonNode? GetAPITokens()
            => R.Finish(() => getAPITokens_S(_client));

        /// <summary>Asynchronous <see cref="GetAPITokens"/>.</summary>
        public Task<JsonNode?> GetAPITokensAsync(CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getAPITokens_A(_client, cancellationToken));

        /// <summary>
        /// Revoke a specific API token associated with the authenticated user.
        /// </summary>
        /// <param name="tokenName">Name of the API token to be revoked.</param>
        /// <returns>JSON response from the server.</returns>
        public JsonNode? RevokeAPIToken(string tokenName)
            => R.Finish(() => revokeAPIToken_S(_client, R.Arg(tokenName)));

        /// <summary>Asynchronous <see cref="RevokeAPIToken"/>.</summary>
        public Task<JsonNode?> RevokeAPITokenAsync(string tokenName,
                                                   CancellationToken cancellationToken = default)
            => R.FinishAsync(() => revokeAPIToken_A(_client, cancellationToken, R.Arg(tokenName)));

        /// <summary>
        /// Terminate the session associated with a refresh token.
        /// </summary>
        /// <param name="refreshToken">The refresh token used to delete the session.</param>
        /// <param name="sessionID">(see the openHAB REST API documentation)</param>
        /// <returns>JSON response from the server.</returns>
        public JsonNode? Logout(string refreshToken, string sessionID)
            => R.Finish(() => logout_S(_client, R.Arg(refreshToken), R.Arg(sessionID)));

        /// <summary>Asynchronous <see cref="Logout"/>.</summary>
        public Task<JsonNode?> LogoutAsync(string refreshToken, string sessionID,
                                           CancellationToken cancellationToken = default)
            => R.FinishAsync(() => logout_A(_client, cancellationToken, R.Arg(refreshToken), R.Arg(sessionID)));

        /// <summary>
        /// Retrieve the sessions associated with the authenticated user.
        /// </summary>
        /// <returns>JSON response from the server.</returns>
        public JsonNode? GetSessions()
            => R.Finish(() => getSessions_S(_client));

        /// <summary>Asynchronous <see cref="GetSessions"/>.</summary>
        public Task<JsonNode?> GetSessionsAsync(CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getSessions_A(_client, cancellationToken));

        /// <summary>
        /// Obtain access and refresh tokens.
        /// </summary>
        /// <param name="useCookie">(Optional) Whether to use cookies for the session.</param>
        /// <param name="grantType">(Optional) The type of grant being requested.</param>
        /// <param name="code">(Optional) Authorization code for authentication.</param>
        /// <param name="redirectURI">(Optional) Redirect URI for OAuth authentication.</param>
        /// <param name="clientID">(Optional) Client ID for authentication.</param>
        /// <param name="refreshToken">(Optional) Refresh token for token renewal.</param>
        /// <param name="codeVerifier">(Optional) Code verifier for PKCE authentication.</param>
        /// <returns>JSON response from the server.</returns>
        public JsonNode? GetToken(bool useCookie = false, string? grantType = null, string? code = null,
                                  string? redirectURI = null, string? clientID = null,
                                  string? refreshToken = null, string? codeVerifier = null)
            => R.Finish(() => getToken_S(_client, R.Arg(useCookie), R.Arg(grantType), R.Arg(code), R.Arg(redirectURI), R.Arg(clientID), R.Arg(refreshToken), R.Arg(codeVerifier)));

        /// <summary>Asynchronous <see cref="GetToken"/>.</summary>
        public Task<JsonNode?> GetTokenAsync(bool useCookie = false, string? grantType = null,
                                             string? code = null, string? redirectURI = null,
                                             string? clientID = null, string? refreshToken = null,
                                             string? codeVerifier = null,
                                             CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getToken_A(_client, cancellationToken, R.Arg(useCookie), R.Arg(grantType), R.Arg(code), R.Arg(redirectURI), R.Arg(clientID), R.Arg(refreshToken), R.Arg(codeVerifier)));

        static V getAPITokens_S(OpenHABClient C)
        {
            V v_headers = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_headers = R.Dict(("Accept", R.S("application/json")));
            try
            {
                v_response = R.Http(C, "get", R.S("/auth/apitokens"), v_headers, V.None, V.None);
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
                if (R.Eq(v_status_code, R.I(401)))
                {
                    return R.Dict(("error", R.S("User is not authenticated.")));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("User not found.")));
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
                return R.Dict(("error", R.S("User not found.")));
            }
            else if (R.Eq(v_status_code, R.I(401)))
            {
                return R.Dict(("error", R.S("User is not authenticated.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> getAPITokens_A(OpenHABClient C, CancellationToken ct)
        {
            V v_headers = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_headers = R.Dict(("Accept", R.S("application/json")));
            try
            {
                v_response = (await R.HttpAsync(C, "get", R.S("/auth/apitokens"), v_headers, V.None, V.None, ct).ConfigureAwait(false));
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
                if (R.Eq(v_status_code, R.I(401)))
                {
                    return R.Dict(("error", R.S("User is not authenticated.")));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("User not found.")));
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
                return R.Dict(("error", R.S("User not found.")));
            }
            else if (R.Eq(v_status_code, R.I(401)))
            {
                return R.Dict(("error", R.S("User is not authenticated.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V revokeAPIToken_S(OpenHABClient C, V v_tokenName)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "delete", R.Cat(R.S("/auth/apitokens/"), v_tokenName), V.None, V.None, V.None);
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
                if (R.Eq(v_status_code, R.I(401)))
                {
                    return R.Dict(("error", R.S("User is not authenticated.")));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("User not found.")));
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
                return R.Dict(("error", R.S("User not found.")));
            }
            else if (R.Eq(v_status_code, R.I(401)))
            {
                return R.Dict(("error", R.S("User is not authenticated.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> revokeAPIToken_A(OpenHABClient C, CancellationToken ct, V v_tokenName)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "delete", R.Cat(R.S("/auth/apitokens/"), v_tokenName), V.None, V.None, V.None, ct).ConfigureAwait(false));
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
                if (R.Eq(v_status_code, R.I(401)))
                {
                    return R.Dict(("error", R.S("User is not authenticated.")));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("User not found.")));
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
                return R.Dict(("error", R.S("User not found.")));
            }
            else if (R.Eq(v_status_code, R.I(401)))
            {
                return R.Dict(("error", R.S("User is not authenticated.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V logout_S(OpenHABClient C, V v_refreshToken, V v_sessionID)
        {
            V v_data = V.None;
            V v_headers = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_headers = R.Dict(("Content-Type", R.S("application/x-www-form-urlencoded")));
            v_data = R.Dict(("refresh_token", v_refreshToken), ("id", v_sessionID));
            try
            {
                v_response = R.Http(C, "post", R.S("/auth/logout"), v_headers, v_data, V.None);
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
                if (R.Eq(v_status_code, R.I(401)))
                {
                    return R.Dict(("error", R.S("User is not authenticated.")));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("User not found.")));
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
                return R.Dict(("error", R.S("User not found.")));
            }
            else if (R.Eq(v_status_code, R.I(401)))
            {
                return R.Dict(("error", R.S("User is not authenticated.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> logout_A(OpenHABClient C, CancellationToken ct, V v_refreshToken, V v_sessionID)
        {
            V v_data = V.None;
            V v_headers = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_headers = R.Dict(("Content-Type", R.S("application/x-www-form-urlencoded")));
            v_data = R.Dict(("refresh_token", v_refreshToken), ("id", v_sessionID));
            try
            {
                v_response = (await R.HttpAsync(C, "post", R.S("/auth/logout"), v_headers, v_data, V.None, ct).ConfigureAwait(false));
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
                if (R.Eq(v_status_code, R.I(401)))
                {
                    return R.Dict(("error", R.S("User is not authenticated.")));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("User not found.")));
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
                return R.Dict(("error", R.S("User not found.")));
            }
            else if (R.Eq(v_status_code, R.I(401)))
            {
                return R.Dict(("error", R.S("User is not authenticated.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V getSessions_S(OpenHABClient C)
        {
            V v_headers = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_headers = R.Dict(("Accept", R.S("application/json")));
            try
            {
                v_response = R.Http(C, "get", R.S("/auth/sessions"), v_headers, V.None, V.None);
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
                if (R.Eq(v_status_code, R.I(401)))
                {
                    return R.Dict(("error", R.S("User is not authenticated.")));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("User not found.")));
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
                return R.Dict(("error", R.S("User not found.")));
            }
            else if (R.Eq(v_status_code, R.I(401)))
            {
                return R.Dict(("error", R.S("User is not authenticated.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> getSessions_A(OpenHABClient C, CancellationToken ct)
        {
            V v_headers = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_headers = R.Dict(("Accept", R.S("application/json")));
            try
            {
                v_response = (await R.HttpAsync(C, "get", R.S("/auth/sessions"), v_headers, V.None, V.None, ct).ConfigureAwait(false));
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
                if (R.Eq(v_status_code, R.I(401)))
                {
                    return R.Dict(("error", R.S("User is not authenticated.")));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("User not found.")));
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
                return R.Dict(("error", R.S("User not found.")));
            }
            else if (R.Eq(v_status_code, R.I(401)))
            {
                return R.Dict(("error", R.S("User is not authenticated.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V getToken_S(OpenHABClient C, V v_useCookie, V v_grantType, V v_code, V v_redirectURI,
                            V v_clientID, V v_refreshToken, V v_codeVerifier)
        {
            V v_body = V.None;
            V v_encodedBody = V.None;
            V v_headers = V.None;
            V v_params = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_headers = R.Dict(("Content-Type", R.S("application/x-www-form-urlencoded")), ("Accept", R.S("application/json")));
            v_params = R.Dict(("useCookie", R.Lower(R.Str(v_useCookie))));
            v_body = R.Dict(("grant_type", v_grantType), ("code", v_code), ("redirect_uri", v_redirectURI), ("client_id", v_clientID), ("refresh_token", v_refreshToken), ("code_verifier", v_codeVerifier));
            v_body = R.WithoutNone(v_body);
            v_encodedBody = R.UrlEncode(v_body);
            try
            {
                v_response = R.Http(C, "post", R.S("/auth/token"), v_headers, v_encodedBody, v_params);
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
                    return R.Dict(("error", R.S("Invalid request parameters.")));
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
                return v_response;
            }
            else if (R.Eq(v_status_code, R.I(400)))
            {
                return R.Dict(("error", R.S("Invalid request parameters.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> getToken_A(OpenHABClient C, CancellationToken ct, V v_useCookie, V v_grantType,
                                        V v_code, V v_redirectURI, V v_clientID, V v_refreshToken,
                                        V v_codeVerifier)
        {
            V v_body = V.None;
            V v_encodedBody = V.None;
            V v_headers = V.None;
            V v_params = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_headers = R.Dict(("Content-Type", R.S("application/x-www-form-urlencoded")), ("Accept", R.S("application/json")));
            v_params = R.Dict(("useCookie", R.Lower(R.Str(v_useCookie))));
            v_body = R.Dict(("grant_type", v_grantType), ("code", v_code), ("redirect_uri", v_redirectURI), ("client_id", v_clientID), ("refresh_token", v_refreshToken), ("code_verifier", v_codeVerifier));
            v_body = R.WithoutNone(v_body);
            v_encodedBody = R.UrlEncode(v_body);
            try
            {
                v_response = (await R.HttpAsync(C, "post", R.S("/auth/token"), v_headers, v_encodedBody, v_params, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Invalid request parameters.")));
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
                return v_response;
            }
            else if (R.Eq(v_status_code, R.I(400)))
            {
                return R.Dict(("error", R.S("Invalid request parameters.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }
    }
}
