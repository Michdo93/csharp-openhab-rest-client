// Generated from python-openhab-rest-client by tools/py2cs.py – do not edit.
#pragma warning disable CS1998, CS0168, CS0219, IDE0059
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using OpenHABRestClient.Internal;

namespace OpenHABRestClient
{
    /// <summary>
    /// openHAB REST API: Logging.
    /// </summary>
    public sealed class Logging
    {
        readonly OpenHABClient _client;

        /// <summary>Creates the Logging class for a connected client.</summary>
        public Logging(OpenHABClient client) => _client = client;

        /// <summary>
        /// Get all loggers.
        /// </summary>
        /// <returns>A list of loggers with names and levels.</returns>
        public JsonNode? GetLoggers()
            => R.Finish(() => getLoggers_S(_client));

        /// <summary>Asynchronous <see cref="GetLoggers"/>.</summary>
        public Task<JsonNode?> GetLoggersAsync(CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getLoggers_A(_client, cancellationToken));

        /// <summary>
        /// Get a single logger.
        /// </summary>
        /// <param name="loggerName">The name of the logger.</param>
        /// <returns>The logger with the specified name and level.</returns>
        public JsonNode? GetLogger(string loggerName)
            => R.Finish(() => getLogger_S(_client, R.Arg(loggerName)));

        /// <summary>Asynchronous <see cref="GetLogger"/>.</summary>
        public Task<JsonNode?> GetLoggerAsync(string loggerName,
                                              CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getLogger_A(_client, cancellationToken, R.Arg(loggerName)));

        /// <summary>
        /// Modify or add a logger.
        /// </summary>
        /// <param name="loggerName">The name of the logger.</param>
        /// <param name="level">The level of the logger.</param>
        /// <returns>The API response after modification or addition.</returns>
        public JsonNode? ModifyOrAddLogger(string loggerName, string level)
            => R.Finish(() => modifyOrAddLogger_S(_client, R.Arg(loggerName), R.Arg(level)));

        /// <summary>Asynchronous <see cref="ModifyOrAddLogger"/>.</summary>
        public Task<JsonNode?> ModifyOrAddLoggerAsync(string loggerName, string level,
                                                      CancellationToken cancellationToken = default)
            => R.FinishAsync(() => modifyOrAddLogger_A(_client, cancellationToken, R.Arg(loggerName), R.Arg(level)));

        /// <summary>
        /// Remove a single logger.
        /// </summary>
        /// <param name="loggerName">The name of the logger.</param>
        /// <returns>The API response after removing the logger.</returns>
        public JsonNode? RemoveLogger(string loggerName)
            => R.Finish(() => removeLogger_S(_client, R.Arg(loggerName)));

        /// <summary>Asynchronous <see cref="RemoveLogger"/>.</summary>
        public Task<JsonNode?> RemoveLoggerAsync(string loggerName,
                                                 CancellationToken cancellationToken = default)
            => R.FinishAsync(() => removeLogger_A(_client, cancellationToken, R.Arg(loggerName)));

        static V getLoggers_S(OpenHABClient C)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "get", R.S("/logging"), R.Dict(("Accept", R.S("application/json"))), V.None, V.None);
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

        static async Task<V> getLoggers_A(OpenHABClient C, CancellationToken ct)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "get", R.S("/logging"), R.Dict(("Accept", R.S("application/json"))), V.None, V.None, ct).ConfigureAwait(false));
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

        static V getLogger_S(OpenHABClient C, V v_loggerName)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "get", R.Cat(R.S("/logging/"), v_loggerName), R.Dict(("Accept", R.S("application/json"))), V.None, V.None);
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

        static async Task<V> getLogger_A(OpenHABClient C, CancellationToken ct, V v_loggerName)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "get", R.Cat(R.S("/logging/"), v_loggerName), R.Dict(("Accept", R.S("application/json"))), V.None, V.None, ct).ConfigureAwait(false));
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

        static V modifyOrAddLogger_S(OpenHABClient C, V v_loggerName, V v_level)
        {
            V v_data = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_data = R.Dict(("loggerName", v_loggerName), ("level", v_level));
            try
            {
                v_response = R.Http(C, "put", R.Cat(R.S("/logging/"), v_loggerName), R.Dict(("Content-Type", R.S("application/json"))), R.Dumps(v_data), V.None);
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

        static async Task<V> modifyOrAddLogger_A(OpenHABClient C, CancellationToken ct, V v_loggerName,
                                                 V v_level)
        {
            V v_data = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_data = R.Dict(("loggerName", v_loggerName), ("level", v_level));
            try
            {
                v_response = (await R.HttpAsync(C, "put", R.Cat(R.S("/logging/"), v_loggerName), R.Dict(("Content-Type", R.S("application/json"))), R.Dumps(v_data), V.None, ct).ConfigureAwait(false));
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

        static V removeLogger_S(OpenHABClient C, V v_loggerName)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "delete", R.Cat(R.S("/logging/"), v_loggerName), V.None, V.None, V.None);
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

        static async Task<V> removeLogger_A(OpenHABClient C, CancellationToken ct, V v_loggerName)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "delete", R.Cat(R.S("/logging/"), v_loggerName), V.None, V.None, V.None, ct).ConfigureAwait(false));
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
