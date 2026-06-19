using System.Collections.Generic;
using System.Threading.Tasks;
using static OpenHABRestClient.OpenHABClient;

namespace OpenHABRestClient
{
    /// <summary>openHAB Rules REST API.</summary>
    public class Rules
    {
        private readonly OpenHABClient _c;
        public Rules(OpenHABClient client) => _c = client;

        public string GetRules(string? prefix=null,string? tags=null,bool summary=false,bool staticDataOnly=false)
            => _c.Get("/rules",H("Accept","application/json"),Q("prefix",prefix,"tags",tags,"summary",summary.ToString().ToLower(),"staticDataOnly",staticDataOnly.ToString().ToLower()));
        public Task<string> GetRulesAsync(string?prefix=null,string?tags=null,bool summary=false,bool staticDataOnly=false)
            => _c.GetAsync("/rules",H("Accept","application/json"),Q("prefix",prefix,"tags",tags,"summary",summary.ToString().ToLower(),"staticDataOnly",staticDataOnly.ToString().ToLower()));

        public string CreateRule(string json)        => _c.Post("/rules",H("Content-Type","application/json"),json);
        public Task<string> CreateRuleAsync(string json) => _c.PostAsync("/rules",H("Content-Type","application/json"),json);

        public string GetRule(string uid)            => _c.Get($"/rules/{uid}");
        public Task<string> GetRuleAsync(string uid) => _c.GetAsync($"/rules/{uid}");

        public string UpdateRule(string uid,string json)        => _c.Put($"/rules/{uid}",H("Content-Type","application/json"),json);
        public Task<string> UpdateRuleAsync(string uid,string json) => _c.PutAsync($"/rules/{uid}",H("Content-Type","application/json"),json);

        public string DeleteRule(string uid)        => _c.Delete($"/rules/{uid}");
        public Task<string> DeleteRuleAsync(string uid) => _c.DeleteAsync($"/rules/{uid}");

        public string GetModule(string uid,string cat,string mid)        => _c.Get($"/rules/{uid}/{cat}/{mid}");
        public Task<string> GetModuleAsync(string uid,string cat,string mid) => _c.GetAsync($"/rules/{uid}/{cat}/{mid}");

        public string GetModuleConfig(string uid,string cat,string mid)        => _c.Get($"/rules/{uid}/{cat}/{mid}/config");
        public Task<string> GetModuleConfigAsync(string uid,string cat,string mid) => _c.GetAsync($"/rules/{uid}/{cat}/{mid}/config");

        public string GetModuleConfigParam(string uid,string cat,string mid,string param)        => _c.Get($"/rules/{uid}/{cat}/{mid}/config/{param}");
        public Task<string> GetModuleConfigParamAsync(string uid,string cat,string mid,string param) => _c.GetAsync($"/rules/{uid}/{cat}/{mid}/config/{param}");

        public string SetModuleConfigParam(string uid,string cat,string mid,string param,string val)
            => _c.Put($"/rules/{uid}/{cat}/{mid}/config/{param}",H("Content-Type","text/plain"),val);
        public Task<string> SetModuleConfigParamAsync(string uid,string cat,string mid,string param,string val)
            => _c.PutAsync($"/rules/{uid}/{cat}/{mid}/config/{param}",H("Content-Type","text/plain"),val);

        public string GetActions(string uid)           => _c.Get($"/rules/{uid}/actions");
        public Task<string> GetActionsAsync(string uid)=> _c.GetAsync($"/rules/{uid}/actions");
        public string GetConditions(string uid)        => _c.Get($"/rules/{uid}/conditions");
        public Task<string> GetConditionsAsync(string uid)=> _c.GetAsync($"/rules/{uid}/conditions");
        public string GetTriggers(string uid)          => _c.Get($"/rules/{uid}/triggers");
        public Task<string> GetTriggersAsync(string uid)=> _c.GetAsync($"/rules/{uid}/triggers");
        public string GetConfiguration(string uid)     => _c.Get($"/rules/{uid}/config");
        public Task<string> GetConfigurationAsync(string uid)=> _c.GetAsync($"/rules/{uid}/config");

        public string UpdateConfiguration(string uid,string json)
            => _c.Put($"/rules/{uid}/config",H("Content-Type","application/json"),json);
        public Task<string> UpdateConfigurationAsync(string uid,string json)
            => _c.PutAsync($"/rules/{uid}/config",H("Content-Type","application/json"),json);

        public string SetRuleState(string uid,bool enable)
            => _c.Post($"/rules/{uid}/enable",H("Content-Type","text/plain"),enable.ToString().ToLower());
        public Task<string> SetRuleStateAsync(string uid,bool enable)
            => _c.PostAsync($"/rules/{uid}/enable",H("Content-Type","text/plain"),enable.ToString().ToLower());

        public string Enable(string uid)  => SetRuleState(uid, true);
        public string Disable(string uid) => SetRuleState(uid, false);
        public Task<string> EnableAsync(string uid)  => SetRuleStateAsync(uid, true);
        public Task<string> DisableAsync(string uid) => SetRuleStateAsync(uid, false);

        public string RunNow(string uid, string? contextJson = null)
        {
            var h = contextJson != null ? H("Content-Type","application/json") : null;
            return _c.Post($"/rules/{uid}/runnow", h, contextJson);
        }
        public Task<string> RunNowAsync(string uid, string? contextJson = null)
        {
            var h = contextJson != null ? H("Content-Type","application/json") : null;
            return _c.PostAsync($"/rules/{uid}/runnow", h, contextJson);
        }

        public string SimulateSchedule(string from, string until)
            => _c.Get("/rules/schedule/simulations",null,Q("from",from,"until",until));
        public Task<string> SimulateScheduleAsync(string from,string until)
            => _c.GetAsync("/rules/schedule/simulations",null,Q("from",from,"until",until));
    }
}
