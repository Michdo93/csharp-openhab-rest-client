// Generated from python-openhab-rest-client by tools/py2cs.py – do not edit.
#pragma warning disable CS1998, CS0168, CS0219, IDE0059
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using OpenHABRestClient.Internal;

namespace OpenHABRestClient
{
    /// <summary>
    /// openHAB REST API: Rules.
    /// </summary>
    public sealed class Rules
    {
        readonly OpenHABClient _client;

        /// <summary>Creates the Rules class for a connected client.</summary>
        public Rules(OpenHABClient client) => _client = client;

        /// <summary>
        /// Get available rules, optionally filtered by tags and/or prefix.
        /// </summary>
        /// <param name="prefix">Optional prefix to filter the results.</param>
        /// <param name="tags">Optional tag array to filter the results.</param>
        /// <param name="summary">If true, only summary fields will be returned.</param>
        /// <param name="staticDataOnly">If true, only static data will be returned.</param>
        /// <returns>A list of rules (JSON objects).</returns>
        public JsonNode? GetRules(string? prefix = null, string? tags = null, bool summary = false,
                                  bool staticDataOnly = false)
            => R.Finish(() => getRules_S(_client, R.Arg(prefix), R.Arg(tags), R.Arg(summary), R.Arg(staticDataOnly)));

        /// <summary>Asynchronous <see cref="GetRules"/>.</summary>
        public Task<JsonNode?> GetRulesAsync(string? prefix = null, string? tags = null, bool summary = false,
                                             bool staticDataOnly = false,
                                             CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getRules_A(_client, cancellationToken, R.Arg(prefix), R.Arg(tags), R.Arg(summary), R.Arg(staticDataOnly)));

        /// <summary>
        /// Creates a rule.
        /// </summary>
        /// <param name="ruleData">The rule data to be created (as a dictionary).</param>
        /// <returns>The created rule (JSON).</returns>
        public JsonNode? CreateRule(object ruleData)
            => R.Finish(() => createRule_S(_client, R.Arg(ruleData)));

        /// <summary>Asynchronous <see cref="CreateRule"/>.</summary>
        public Task<JsonNode?> CreateRuleAsync(object ruleData, CancellationToken cancellationToken = default)
            => R.FinishAsync(() => createRule_A(_client, cancellationToken, R.Arg(ruleData)));

        /// <summary>
        /// Gets the rule corresponding to the given UID.
        /// </summary>
        /// <param name="ruleUID">The UID of the rule to retrieve.</param>
        /// <returns>The rule object (JSON).</returns>
        public JsonNode? GetRule(string ruleUID)
            => R.Finish(() => getRule_S(_client, R.Arg(ruleUID)));

        /// <summary>Asynchronous <see cref="GetRule"/>.</summary>
        public Task<JsonNode?> GetRuleAsync(string ruleUID, CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getRule_A(_client, cancellationToken, R.Arg(ruleUID)));

        /// <summary>
        /// Updates an existing rule corresponding to the given UID.
        /// </summary>
        /// <param name="ruleUID">The UID of the rule to update.</param>
        /// <param name="ruleData">The new rule data (as a dictionary).</param>
        /// <returns>The updated rule (JSON).</returns>
        public JsonNode? UpdateRule(string ruleUID, object ruleData)
            => R.Finish(() => updateRule_S(_client, R.Arg(ruleUID), R.Arg(ruleData)));

        /// <summary>Asynchronous <see cref="UpdateRule"/>.</summary>
        public Task<JsonNode?> UpdateRuleAsync(string ruleUID, object ruleData,
                                               CancellationToken cancellationToken = default)
            => R.FinishAsync(() => updateRule_A(_client, cancellationToken, R.Arg(ruleUID), R.Arg(ruleData)));

        /// <summary>
        /// Removes an existing rule corresponding to the given UID.
        /// </summary>
        /// <param name="ruleUID">The UID of the rule to delete.</param>
        /// <returns>The API response (status code).</returns>
        public JsonNode? DeleteRule(string ruleUID)
            => R.Finish(() => deleteRule_S(_client, R.Arg(ruleUID)));

        /// <summary>Asynchronous <see cref="DeleteRule"/>.</summary>
        public Task<JsonNode?> DeleteRuleAsync(string ruleUID, CancellationToken cancellationToken = default)
            => R.FinishAsync(() => deleteRule_A(_client, cancellationToken, R.Arg(ruleUID)));

        /// <summary>
        /// Gets the rule's module corresponding to the given category and ID.
        /// </summary>
        /// <param name="ruleUID">The UID of the rule.</param>
        /// <param name="moduleCategory">The category of the module.</param>
        /// <param name="moduleID">The ID of the module.</param>
        /// <returns>The module (JSON).</returns>
        public JsonNode? GetModule(string ruleUID, string moduleCategory, string moduleID)
            => R.Finish(() => getModule_S(_client, R.Arg(ruleUID), R.Arg(moduleCategory), R.Arg(moduleID)));

        /// <summary>Asynchronous <see cref="GetModule"/>.</summary>
        public Task<JsonNode?> GetModuleAsync(string ruleUID, string moduleCategory, string moduleID,
                                              CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getModule_A(_client, cancellationToken, R.Arg(ruleUID), R.Arg(moduleCategory), R.Arg(moduleID)));

        /// <summary>
        /// Gets the module's configuration.
        /// </summary>
        /// <param name="ruleUID">The UID of the rule.</param>
        /// <param name="moduleCategory">The category of the module.</param>
        /// <param name="moduleID">The ID of the module.</param>
        /// <returns>The module configuration (JSON).</returns>
        public JsonNode? GetModuleConfig(string ruleUID, string moduleCategory, string moduleID)
            => R.Finish(() => getModuleConfig_S(_client, R.Arg(ruleUID), R.Arg(moduleCategory), R.Arg(moduleID)));

        /// <summary>Asynchronous <see cref="GetModuleConfig"/>.</summary>
        public Task<JsonNode?> GetModuleConfigAsync(string ruleUID, string moduleCategory, string moduleID,
                                                    CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getModuleConfig_A(_client, cancellationToken, R.Arg(ruleUID), R.Arg(moduleCategory), R.Arg(moduleID)));

        /// <summary>
        /// Gets the module's configuration parameter.
        /// </summary>
        /// <param name="ruleUID">The UID of the rule.</param>
        /// <param name="moduleCategory">The category of the module.</param>
        /// <param name="moduleID">The ID of the module.</param>
        /// <param name="param">The name of the configuration parameter.</param>
        /// <returns>The configuration parameter value (JSON).</returns>
        public JsonNode? GetModuleConfigParam(string ruleUID, string moduleCategory, string moduleID,
                                              string param)
            => R.Finish(() => getModuleConfigParam_S(_client, R.Arg(ruleUID), R.Arg(moduleCategory), R.Arg(moduleID), R.Arg(param)));

        /// <summary>Asynchronous <see cref="GetModuleConfigParam"/>.</summary>
        public Task<JsonNode?> GetModuleConfigParamAsync(string ruleUID, string moduleCategory,
                                                         string moduleID, string param,
                                                         CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getModuleConfigParam_A(_client, cancellationToken, R.Arg(ruleUID), R.Arg(moduleCategory), R.Arg(moduleID), R.Arg(param)));

        /// <summary>
        /// Sets the module's configuration parameter value.
        /// </summary>
        /// <param name="ruleUID">The UID of the rule.</param>
        /// <param name="moduleCategory">The category of the module.</param>
        /// <param name="moduleID">The ID of the module.</param>
        /// <param name="param">The name of the configuration parameter.</param>
        /// <param name="value">The value to set for the configuration parameter.</param>
        /// <returns>The API response (status code).</returns>
        public JsonNode? SetModuleConfigParam(string ruleUID, string moduleCategory, string moduleID,
                                              string param, string value)
            => R.Finish(() => setModuleConfigParam_S(_client, R.Arg(ruleUID), R.Arg(moduleCategory), R.Arg(moduleID), R.Arg(param), R.Arg(value)));

        /// <summary>Asynchronous <see cref="SetModuleConfigParam"/>.</summary>
        public Task<JsonNode?> SetModuleConfigParamAsync(string ruleUID, string moduleCategory,
                                                         string moduleID, string param, string value,
                                                         CancellationToken cancellationToken = default)
            => R.FinishAsync(() => setModuleConfigParam_A(_client, cancellationToken, R.Arg(ruleUID), R.Arg(moduleCategory), R.Arg(moduleID), R.Arg(param), R.Arg(value)));

        /// <summary>
        /// Gets the rule actions.
        /// </summary>
        /// <param name="ruleUID">The UID of the rule.</param>
        /// <returns>A list of actions (JSON).</returns>
        public JsonNode? GetActions(string ruleUID)
            => R.Finish(() => getActions_S(_client, R.Arg(ruleUID)));

        /// <summary>Asynchronous <see cref="GetActions"/>.</summary>
        public Task<JsonNode?> GetActionsAsync(string ruleUID, CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getActions_A(_client, cancellationToken, R.Arg(ruleUID)));

        /// <summary>
        /// Gets the rule conditions.
        /// </summary>
        /// <param name="ruleUID">The UID of the rule.</param>
        /// <returns>A list of conditions (JSON).</returns>
        public JsonNode? GetConditions(string ruleUID)
            => R.Finish(() => getConditions_S(_client, R.Arg(ruleUID)));

        /// <summary>Asynchronous <see cref="GetConditions"/>.</summary>
        public Task<JsonNode?> GetConditionsAsync(string ruleUID,
                                                  CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getConditions_A(_client, cancellationToken, R.Arg(ruleUID)));

        /// <summary>
        /// Gets the rule configuration values.
        /// </summary>
        /// <param name="ruleUID">The UID of the rule.</param>
        /// <returns>The configuration of the rule (JSON).</returns>
        public JsonNode? GetConfiguration(string ruleUID)
            => R.Finish(() => getConfiguration_S(_client, R.Arg(ruleUID)));

        /// <summary>Asynchronous <see cref="GetConfiguration"/>.</summary>
        public Task<JsonNode?> GetConfigurationAsync(string ruleUID,
                                                     CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getConfiguration_A(_client, cancellationToken, R.Arg(ruleUID)));

        /// <summary>
        /// Sets the rule configuration values.
        /// </summary>
        /// <param name="ruleUID">The UID of the rule.</param>
        /// <param name="configData">The new configuration data (as a dictionary).</param>
        /// <returns>The updated configuration (JSON).</returns>
        public JsonNode? UpdateConfiguration(string ruleUID, object configData)
            => R.Finish(() => updateConfiguration_S(_client, R.Arg(ruleUID), R.Arg(configData)));

        /// <summary>Asynchronous <see cref="UpdateConfiguration"/>.</summary>
        public Task<JsonNode?> UpdateConfigurationAsync(string ruleUID, object configData,
                                                        CancellationToken cancellationToken = default)
            => R.FinishAsync(() => updateConfiguration_A(_client, cancellationToken, R.Arg(ruleUID), R.Arg(configData)));

        /// <summary>
        /// Sets the rule configuration values. Activates or deactivates the rule.
        /// </summary>
        /// <param name="ruleUID">The UID of the rule.</param>
        /// <param name="enable">If true, the rule will be activated. If false, the rule will be deactivated.</param>
        /// <returns>The API response (status code).</returns>
        public JsonNode? SetRuleState(string ruleUID, bool enable)
            => R.Finish(() => setRuleState_S(_client, R.Arg(ruleUID), R.Arg(enable)));

        /// <summary>Asynchronous <see cref="SetRuleState"/>.</summary>
        public Task<JsonNode?> SetRuleStateAsync(string ruleUID, bool enable,
                                                 CancellationToken cancellationToken = default)
            => R.FinishAsync(() => setRuleState_A(_client, cancellationToken, R.Arg(ruleUID), R.Arg(enable)));

        /// <summary>
        /// enable
        /// </summary>
        /// <param name="ruleUID">(see the openHAB REST API documentation)</param>
        public JsonNode? Enable(string ruleUID)
            => R.Finish(() => enable_S(_client, R.Arg(ruleUID)));

        /// <summary>Asynchronous <see cref="Enable"/>.</summary>
        public Task<JsonNode?> EnableAsync(string ruleUID, CancellationToken cancellationToken = default)
            => R.FinishAsync(() => enable_A(_client, cancellationToken, R.Arg(ruleUID)));

        /// <summary>
        /// disable
        /// </summary>
        /// <param name="ruleUID">(see the openHAB REST API documentation)</param>
        public JsonNode? Disable(string ruleUID)
            => R.Finish(() => disable_S(_client, R.Arg(ruleUID)));

        /// <summary>Asynchronous <see cref="Disable"/>.</summary>
        public Task<JsonNode?> DisableAsync(string ruleUID, CancellationToken cancellationToken = default)
            => R.FinishAsync(() => disable_A(_client, cancellationToken, R.Arg(ruleUID)));

        /// <summary>
        /// Executes the rule's actions immediately.
        /// </summary>
        /// <param name="ruleUID">The UID of the rule.</param>
        /// <param name="contextData">Optional context data for executing the rule.</param>
        /// <returns>The API response (status code).</returns>
        public JsonNode? RunNow(string ruleUID, object? contextData = null)
            => R.Finish(() => runNow_S(_client, R.Arg(ruleUID), R.Arg(contextData)));

        /// <summary>Asynchronous <see cref="RunNow"/>.</summary>
        public Task<JsonNode?> RunNowAsync(string ruleUID, object? contextData = null,
                                           CancellationToken cancellationToken = default)
            => R.FinishAsync(() => runNow_A(_client, cancellationToken, R.Arg(ruleUID), R.Arg(contextData)));

        /// <summary>
        /// Gets the rule triggers.
        /// </summary>
        /// <param name="ruleUID">The UID of the rule.</param>
        /// <returns>A list of triggers (JSON).</returns>
        public JsonNode? GetTriggers(string ruleUID)
            => R.Finish(() => getTriggers_S(_client, R.Arg(ruleUID)));

        /// <summary>Asynchronous <see cref="GetTriggers"/>.</summary>
        public Task<JsonNode?> GetTriggersAsync(string ruleUID, CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getTriggers_A(_client, cancellationToken, R.Arg(ruleUID)));

        /// <summary>
        /// Simulates the executions of rules filtered by tag 'Schedule' within the given times.
        /// </summary>
        /// <param name="fromTime">Simulates the executions of rules filtered by tag 'Schedule' within the given times.</param>
        /// <param name="untilTime">Simulates the executions of rules filtered by tag 'Schedule' within the given times.</param>
        /// <returns>The simulation results (JSON).</returns>
        public JsonNode? SimulateSchedule(string fromTime, string untilTime)
            => R.Finish(() => simulateSchedule_S(_client, R.Arg(fromTime), R.Arg(untilTime)));

        /// <summary>Asynchronous <see cref="SimulateSchedule"/>.</summary>
        public Task<JsonNode?> SimulateScheduleAsync(string fromTime, string untilTime,
                                                     CancellationToken cancellationToken = default)
            => R.FinishAsync(() => simulateSchedule_A(_client, cancellationToken, R.Arg(fromTime), R.Arg(untilTime)));

        static V getRules_S(OpenHABClient C, V v_prefix, V v_tags, V v_summary, V v_staticDataOnly)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "get", R.S("/rules"), R.Dict(("Accept", R.S("application/json"))), V.None, R.Dict(("prefix", v_prefix), ("tags", v_tags), ("summary", v_summary), ("staticDataOnly", v_staticDataOnly)));
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

        static async Task<V> getRules_A(OpenHABClient C, CancellationToken ct, V v_prefix, V v_tags,
                                        V v_summary, V v_staticDataOnly)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "get", R.S("/rules"), R.Dict(("Accept", R.S("application/json"))), V.None, R.Dict(("prefix", v_prefix), ("tags", v_tags), ("summary", v_summary), ("staticDataOnly", v_staticDataOnly)), ct).ConfigureAwait(false));
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

        static V createRule_S(OpenHABClient C, V v_ruleData)
        {
            V v_location = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "post", R.S("/rules"), R.Dict(("Content-Type", R.S("application/json"))), R.Dumps(v_ruleData), V.None);
                if (R.IsStatus(v_response))
                {
                    v_status_code = R.Get(v_response, R.S("status"));
                    v_location = R.GetOr(v_response, R.S("location"));
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
                    return R.Dict(("error", R.S("Creation refused: Missing required parameter.")));
                }
                else if (R.Eq(v_status_code, R.I(409)))
                {
                    return R.Dict(("error", R.S("Creation refused: Rule with the same UID already exists.")));
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
                return R.Dict(("message", R.S("Rule successfully created.")), ("location", (R.Truthy(v_location) ? v_location : R.S("No Location headers provided."))));
            }
            else if (R.Eq(v_status_code, R.I(400)))
            {
                return R.Dict(("error", R.S("Creation refused: Missing required parameter.")));
            }
            else if (R.Eq(v_status_code, R.I(409)))
            {
                return R.Dict(("error", R.S("Creation refused: Rule with the same UID already exists.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> createRule_A(OpenHABClient C, CancellationToken ct, V v_ruleData)
        {
            V v_location = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "post", R.S("/rules"), R.Dict(("Content-Type", R.S("application/json"))), R.Dumps(v_ruleData), V.None, ct).ConfigureAwait(false));
                if (R.IsStatus(v_response))
                {
                    v_status_code = R.Get(v_response, R.S("status"));
                    v_location = R.GetOr(v_response, R.S("location"));
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
                    return R.Dict(("error", R.S("Creation refused: Missing required parameter.")));
                }
                else if (R.Eq(v_status_code, R.I(409)))
                {
                    return R.Dict(("error", R.S("Creation refused: Rule with the same UID already exists.")));
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
                return R.Dict(("message", R.S("Rule successfully created.")), ("location", (R.Truthy(v_location) ? v_location : R.S("No Location headers provided."))));
            }
            else if (R.Eq(v_status_code, R.I(400)))
            {
                return R.Dict(("error", R.S("Creation refused: Missing required parameter.")));
            }
            else if (R.Eq(v_status_code, R.I(409)))
            {
                return R.Dict(("error", R.S("Creation refused: Rule with the same UID already exists.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V getRule_S(OpenHABClient C, V v_ruleUID)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "get", R.Cat(R.S("/rules/"), v_ruleUID), R.Dict(("Accept", R.S("application/json"))), V.None, V.None);
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
                    return R.Dict(("error", R.S("Rule not found.")));
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
                return R.Dict(("error", R.S("Rule not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> getRule_A(OpenHABClient C, CancellationToken ct, V v_ruleUID)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "get", R.Cat(R.S("/rules/"), v_ruleUID), R.Dict(("Accept", R.S("application/json"))), V.None, V.None, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Rule not found.")));
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
                return R.Dict(("error", R.S("Rule not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V updateRule_S(OpenHABClient C, V v_ruleUID, V v_ruleData)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "put", R.Cat(R.S("/rules/"), v_ruleUID), R.Dict(("Content-Type", R.S("application/json"))), R.Dumps(v_ruleData), V.None);
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
                    return R.Dict(("error", R.S("Rule corresponding to the given UID was not found.")));
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
                return R.Dict(("error", R.S("Rule corresponding to the given UID was not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> updateRule_A(OpenHABClient C, CancellationToken ct, V v_ruleUID, V v_ruleData)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "put", R.Cat(R.S("/rules/"), v_ruleUID), R.Dict(("Content-Type", R.S("application/json"))), R.Dumps(v_ruleData), V.None, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Rule corresponding to the given UID was not found.")));
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
                return R.Dict(("error", R.S("Rule corresponding to the given UID was not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V deleteRule_S(OpenHABClient C, V v_ruleUID)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "delete", R.Cat(R.S("/rules/"), v_ruleUID), V.None, V.None, V.None);
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
                    return R.Dict(("error", R.S("Rule corresponding to the given UID was not found.")));
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
                return R.Dict(("error", R.S("Rule corresponding to the given UID was not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> deleteRule_A(OpenHABClient C, CancellationToken ct, V v_ruleUID)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "delete", R.Cat(R.S("/rules/"), v_ruleUID), V.None, V.None, V.None, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Rule corresponding to the given UID was not found.")));
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
                return R.Dict(("error", R.S("Rule corresponding to the given UID was not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V getModule_S(OpenHABClient C, V v_ruleUID, V v_moduleCategory, V v_moduleID)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "get", R.Cat(R.S("/rules/"), v_ruleUID, R.S("/"), v_moduleCategory, R.S("/"), v_moduleID), R.Dict(("Accept", R.S("application/json"))), V.None, V.None);
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
                    return R.Dict(("error", R.S("Rule corresponding to the given UID was not found or does not have a module with such Category and ID.")));
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
                return R.Dict(("error", R.S("Rule corresponding to the given UID was not found or does not have a module with such Category and ID.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> getModule_A(OpenHABClient C, CancellationToken ct, V v_ruleUID,
                                         V v_moduleCategory, V v_moduleID)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "get", R.Cat(R.S("/rules/"), v_ruleUID, R.S("/"), v_moduleCategory, R.S("/"), v_moduleID), R.Dict(("Accept", R.S("application/json"))), V.None, V.None, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Rule corresponding to the given UID was not found or does not have a module with such Category and ID.")));
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
                return R.Dict(("error", R.S("Rule corresponding to the given UID was not found or does not have a module with such Category and ID.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V getModuleConfig_S(OpenHABClient C, V v_ruleUID, V v_moduleCategory, V v_moduleID)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "get", R.Cat(R.S("/rules/"), v_ruleUID, R.S("/"), v_moduleCategory, R.S("/"), v_moduleID, R.S("/config")), R.Dict(("Accept", R.S("application/json"))), V.None, V.None);
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
                    return R.Dict(("error", R.S("Rule corresponding to the given UID was not found or does not have a module with such Category and ID.")));
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
                return R.Dict(("error", R.S("Rule corresponding to the given UID was not found or does not have a module with such Category and ID.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> getModuleConfig_A(OpenHABClient C, CancellationToken ct, V v_ruleUID,
                                               V v_moduleCategory, V v_moduleID)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "get", R.Cat(R.S("/rules/"), v_ruleUID, R.S("/"), v_moduleCategory, R.S("/"), v_moduleID, R.S("/config")), R.Dict(("Accept", R.S("application/json"))), V.None, V.None, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Rule corresponding to the given UID was not found or does not have a module with such Category and ID.")));
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
                return R.Dict(("error", R.S("Rule corresponding to the given UID was not found or does not have a module with such Category and ID.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V getModuleConfigParam_S(OpenHABClient C, V v_ruleUID, V v_moduleCategory, V v_moduleID,
                                        V v_param)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "get", R.Cat(R.S("/rules/"), v_ruleUID, R.S("/"), v_moduleCategory, R.S("/"), v_moduleID, R.S("/config/"), v_param), R.Dict(("Accept", R.S("text/plain"))), V.None, V.None);
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
                    return R.Dict(("error", R.S("Rule corresponding to the given UID was not found or does not have a module with such Category and ID.")));
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
                return R.Dict(("error", R.S("Rule corresponding to the given UID was not found or does not have a module with such Category and ID.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> getModuleConfigParam_A(OpenHABClient C, CancellationToken ct, V v_ruleUID,
                                                    V v_moduleCategory, V v_moduleID, V v_param)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "get", R.Cat(R.S("/rules/"), v_ruleUID, R.S("/"), v_moduleCategory, R.S("/"), v_moduleID, R.S("/config/"), v_param), R.Dict(("Accept", R.S("text/plain"))), V.None, V.None, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Rule corresponding to the given UID was not found or does not have a module with such Category and ID.")));
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
                return R.Dict(("error", R.S("Rule corresponding to the given UID was not found or does not have a module with such Category and ID.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V setModuleConfigParam_S(OpenHABClient C, V v_ruleUID, V v_moduleCategory, V v_moduleID,
                                        V v_param, V v_value)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "put", R.Cat(R.S("/rules/"), v_ruleUID, R.S("/"), v_moduleCategory, R.S("/"), v_moduleID, R.S("/config/"), v_param), R.Dict(("Content-Type", R.S("text/plain"))), R.Str(v_value), V.None);
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
                    return R.Dict(("error", R.S("Rule corresponding to the given UID was not found or does not have a module with such Category and ID.")));
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
                return R.Dict(("error", R.S("Rule corresponding to the given UID was not found or does not have a module with such Category and ID.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> setModuleConfigParam_A(OpenHABClient C, CancellationToken ct, V v_ruleUID,
                                                    V v_moduleCategory, V v_moduleID, V v_param, V v_value)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "put", R.Cat(R.S("/rules/"), v_ruleUID, R.S("/"), v_moduleCategory, R.S("/"), v_moduleID, R.S("/config/"), v_param), R.Dict(("Content-Type", R.S("text/plain"))), R.Str(v_value), V.None, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Rule corresponding to the given UID was not found or does not have a module with such Category and ID.")));
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
                return R.Dict(("error", R.S("Rule corresponding to the given UID was not found or does not have a module with such Category and ID.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V getActions_S(OpenHABClient C, V v_ruleUID)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "get", R.Cat(R.S("/rules/"), v_ruleUID, R.S("/actions")), R.Dict(("Accept", R.S("application/json"))), V.None, V.None);
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
                    return R.Dict(("error", R.S("Rule corresponding to the given UID was not found.")));
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
                return R.Dict(("error", R.S("Rule corresponding to the given UID was not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> getActions_A(OpenHABClient C, CancellationToken ct, V v_ruleUID)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "get", R.Cat(R.S("/rules/"), v_ruleUID, R.S("/actions")), R.Dict(("Accept", R.S("application/json"))), V.None, V.None, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Rule corresponding to the given UID was not found.")));
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
                return R.Dict(("error", R.S("Rule corresponding to the given UID was not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V getConditions_S(OpenHABClient C, V v_ruleUID)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "get", R.Cat(R.S("/rules/"), v_ruleUID, R.S("/conditions")), R.Dict(("Accept", R.S("application/json"))), V.None, V.None);
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
                    return R.Dict(("error", R.S("Rule corresponding to the given UID was not found.")));
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
                return R.Dict(("error", R.S("Rule corresponding to the given UID was not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> getConditions_A(OpenHABClient C, CancellationToken ct, V v_ruleUID)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "get", R.Cat(R.S("/rules/"), v_ruleUID, R.S("/conditions")), R.Dict(("Accept", R.S("application/json"))), V.None, V.None, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Rule corresponding to the given UID was not found.")));
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
                return R.Dict(("error", R.S("Rule corresponding to the given UID was not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V getConfiguration_S(OpenHABClient C, V v_ruleUID)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "get", R.Cat(R.S("/rules/"), v_ruleUID, R.S("/config")), R.Dict(("Accept", R.S("application/json"))), V.None, V.None);
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
                    return R.Dict(("error", R.S("Rule corresponding to the given UID was not found.")));
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
                return R.Dict(("error", R.S("Rule corresponding to the given UID was not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> getConfiguration_A(OpenHABClient C, CancellationToken ct, V v_ruleUID)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "get", R.Cat(R.S("/rules/"), v_ruleUID, R.S("/config")), R.Dict(("Accept", R.S("application/json"))), V.None, V.None, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Rule corresponding to the given UID was not found.")));
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
                return R.Dict(("error", R.S("Rule corresponding to the given UID was not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V updateConfiguration_S(OpenHABClient C, V v_ruleUID, V v_configData)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "put", R.Cat(R.S("/rules/"), v_ruleUID, R.S("/config")), R.Dict(("Content-Type", R.S("application/json"))), R.Dumps(v_configData), V.None);
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
                    return R.Dict(("error", R.S("Rule corresponding to the given UID was not found.")));
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
                return R.Dict(("error", R.S("Rule corresponding to the given UID was not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> updateConfiguration_A(OpenHABClient C, CancellationToken ct, V v_ruleUID,
                                                   V v_configData)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "put", R.Cat(R.S("/rules/"), v_ruleUID, R.S("/config")), R.Dict(("Content-Type", R.S("application/json"))), R.Dumps(v_configData), V.None, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Rule corresponding to the given UID was not found.")));
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
                return R.Dict(("error", R.S("Rule corresponding to the given UID was not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V setRuleState_S(OpenHABClient C, V v_ruleUID, V v_enable)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "post", R.Cat(R.S("/rules/"), v_ruleUID, R.S("/enable")), R.Dict(("Content-Type", R.S("text/plain"))), (R.Truthy(v_enable) ? R.S("true") : R.S("false")), V.None);
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
                    return R.Dict(("error", R.S("Rule corresponding to the given UID was not found.")));
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
                return R.Dict(("error", R.S("Rule corresponding to the given UID was not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> setRuleState_A(OpenHABClient C, CancellationToken ct, V v_ruleUID, V v_enable)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "post", R.Cat(R.S("/rules/"), v_ruleUID, R.S("/enable")), R.Dict(("Content-Type", R.S("text/plain"))), (R.Truthy(v_enable) ? R.S("true") : R.S("false")), V.None, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Rule corresponding to the given UID was not found.")));
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
                return R.Dict(("error", R.S("Rule corresponding to the given UID was not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V enable_S(OpenHABClient C, V v_ruleUID)
        {
            return setRuleState_S(C, v_ruleUID, R.B(true));
        }

        static async Task<V> enable_A(OpenHABClient C, CancellationToken ct, V v_ruleUID)
        {
            return (await setRuleState_A(C, ct, v_ruleUID, R.B(true)).ConfigureAwait(false));
        }

        static V disable_S(OpenHABClient C, V v_ruleUID)
        {
            return setRuleState_S(C, v_ruleUID, R.B(false));
        }

        static async Task<V> disable_A(OpenHABClient C, CancellationToken ct, V v_ruleUID)
        {
            return (await setRuleState_A(C, ct, v_ruleUID, R.B(false)).ConfigureAwait(false));
        }

        static V runNow_S(OpenHABClient C, V v_ruleUID, V v_contextData)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "post", R.Cat(R.S("/rules/"), v_ruleUID, R.S("/runnow")), R.Dict(("Content-Type", R.S("application/json")), ("Accept", R.S("application/json"))), R.Dumps((v_contextData is var t_1 ? (R.Truthy(t_1) ? t_1 : R.Dict()) : V.None)), V.None);
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
                    return R.Dict(("error", R.S("Rule corresponding to the given UID was not found.")));
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
                return R.Dict(("error", R.S("Rule corresponding to the given UID was not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> runNow_A(OpenHABClient C, CancellationToken ct, V v_ruleUID, V v_contextData)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "post", R.Cat(R.S("/rules/"), v_ruleUID, R.S("/runnow")), R.Dict(("Content-Type", R.S("application/json")), ("Accept", R.S("application/json"))), R.Dumps((v_contextData is var t_1 ? (R.Truthy(t_1) ? t_1 : R.Dict()) : V.None)), V.None, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Rule corresponding to the given UID was not found.")));
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
                return R.Dict(("error", R.S("Rule corresponding to the given UID was not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V getTriggers_S(OpenHABClient C, V v_ruleUID)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "get", R.Cat(R.S("/rules/"), v_ruleUID, R.S("/triggers")), R.Dict(("Accept", R.S("application/json"))), V.None, V.None);
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
                    return R.Dict(("error", R.S("Rule corresponding to the given UID was not found.")));
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
                return R.Dict(("error", R.S("Rule corresponding to the given UID was not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> getTriggers_A(OpenHABClient C, CancellationToken ct, V v_ruleUID)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "get", R.Cat(R.S("/rules/"), v_ruleUID, R.S("/triggers")), R.Dict(("Accept", R.S("application/json"))), V.None, V.None, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Rule corresponding to the given UID was not found.")));
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
                return R.Dict(("error", R.S("Rule corresponding to the given UID was not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V simulateSchedule_S(OpenHABClient C, V v_fromTime, V v_untilTime)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "get", R.S("/rules/schedule/simulations"), R.Dict(("Accept", R.S("application/json"))), V.None, R.Dict(("from", v_fromTime), ("until", v_untilTime)));
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
                    return R.Dict(("error", R.S("The max. simulation duration of 180 days is exceeded.")));
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
                return R.Dict(("error", R.S("The max. simulation duration of 180 days is exceeded.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> simulateSchedule_A(OpenHABClient C, CancellationToken ct, V v_fromTime,
                                                V v_untilTime)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "get", R.S("/rules/schedule/simulations"), R.Dict(("Accept", R.S("application/json"))), V.None, R.Dict(("from", v_fromTime), ("until", v_untilTime)), ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("The max. simulation duration of 180 days is exceeded.")));
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
                return R.Dict(("error", R.S("The max. simulation duration of 180 days is exceeded.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }
    }
}
