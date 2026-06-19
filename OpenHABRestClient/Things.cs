using System.Collections.Generic;
using System.Threading.Tasks;
using static OpenHABRestClient.OpenHABClient;

namespace OpenHABRestClient
{
    /// <summary>openHAB Things REST API.</summary>
    public class Things
    {
        private readonly OpenHABClient _c;
        public Things(OpenHABClient client) => _c = client;

        public string GetThings(bool summary = false, bool staticDataOnly = false, string? language = null)
        { var h = new Dictionary<string,string>{["Accept"]="application/json"}; if(language!=null)h["Accept-Language"]=language; return _c.Get("/things",h,Q("summary",summary.ToString().ToLower(),"staticDataOnly",staticDataOnly.ToString().ToLower())); }
        public Task<string> GetThingsAsync(bool summary=false,bool staticDataOnly=false,string?language=null)
        { var h=new Dictionary<string,string>{["Accept"]="application/json"};if(language!=null)h["Accept-Language"]=language;return _c.GetAsync("/things",h,Q("summary",summary.ToString().ToLower(),"staticDataOnly",staticDataOnly.ToString().ToLower())); }

        public string CreateThing(string json, string? language = null)
        { var h=new Dictionary<string,string>{["Content-Type"]="application/json",["Accept"]="application/json"};if(language!=null)h["Accept-Language"]=language;return _c.Post("/things",h,json); }
        public Task<string> CreateThingAsync(string json,string?language=null)
        { var h=new Dictionary<string,string>{["Content-Type"]="application/json",["Accept"]="application/json"};if(language!=null)h["Accept-Language"]=language;return _c.PostAsync("/things",h,json); }

        public string GetThing(string uid, string? language = null)
        { var h=new Dictionary<string,string>{["Accept"]="application/json"};if(language!=null)h["Accept-Language"]=language;return _c.Get($"/things/{uid}",h); }
        public Task<string> GetThingAsync(string uid,string?language=null)
        { var h=new Dictionary<string,string>{["Accept"]="application/json"};if(language!=null)h["Accept-Language"]=language;return _c.GetAsync($"/things/{uid}",h); }

        public string UpdateThing(string uid, string json, string? language = null)
        { var h=new Dictionary<string,string>{["Content-Type"]="application/json",["Accept"]="application/json"};if(language!=null)h["Accept-Language"]=language;return _c.Put($"/things/{uid}",h,json); }
        public Task<string> UpdateThingAsync(string uid,string json,string?language=null)
        { var h=new Dictionary<string,string>{["Content-Type"]="application/json",["Accept"]="application/json"};if(language!=null)h["Accept-Language"]=language;return _c.PutAsync($"/things/{uid}",h,json); }

        public string DeleteThing(string uid, bool force = false, string? language = null)
        { var h=new Dictionary<string,string>();if(language!=null)h["Accept-Language"]=language;return _c.Delete($"/things/{uid}",h,null,Q("force",force.ToString().ToLower())); }
        public Task<string> DeleteThingAsync(string uid,bool force=false,string?language=null)
        { var h=new Dictionary<string,string>();if(language!=null)h["Accept-Language"]=language;return _c.DeleteAsync($"/things/{uid}",h,null,Q("force",force.ToString().ToLower())); }

        public string UpdateThingConfiguration(string uid, string json, string? language = null)
        { var h=new Dictionary<string,string>{["Content-Type"]="application/json",["Accept"]="application/json"};if(language!=null)h["Accept-Language"]=language;return _c.Put($"/things/{uid}/config",h,json); }
        public Task<string> UpdateThingConfigurationAsync(string uid,string json,string?language=null)
        { var h=new Dictionary<string,string>{["Content-Type"]="application/json",["Accept"]="application/json"};if(language!=null)h["Accept-Language"]=language;return _c.PutAsync($"/things/{uid}/config",h,json); }

        public string GetThingConfigStatus(string uid, string? language = null)
        { var h=new Dictionary<string,string>{["Accept"]="application/json"};if(language!=null)h["Accept-Language"]=language;return _c.Get($"/things/{uid}/config/status",h); }
        public Task<string> GetThingConfigStatusAsync(string uid,string?language=null)
        { var h=new Dictionary<string,string>{["Accept"]="application/json"};if(language!=null)h["Accept-Language"]=language;return _c.GetAsync($"/things/{uid}/config/status",h); }

        public string SetThingStatus(string uid, bool enabled, string? language = null)
        { var h=new Dictionary<string,string>{["Content-Type"]="text/plain"};if(language!=null)h["Accept-Language"]=language;return _c.Put($"/things/{uid}/enable",h,enabled.ToString().ToLower()); }
        public Task<string> SetThingStatusAsync(string uid,bool enabled,string?language=null)
        { var h=new Dictionary<string,string>{["Content-Type"]="text/plain"};if(language!=null)h["Accept-Language"]=language;return _c.PutAsync($"/things/{uid}/enable",h,enabled.ToString().ToLower()); }

        public string EnableThing(string uid)  => SetThingStatus(uid, true);
        public string DisableThing(string uid) => SetThingStatus(uid, false);
        public Task<string> EnableThingAsync(string uid)  => SetThingStatusAsync(uid, true);
        public Task<string> DisableThingAsync(string uid) => SetThingStatusAsync(uid, false);

        public string UpdateThingFirmware(string uid, string version, string? language = null)
        { var h=new Dictionary<string,string>{["Content-Type"]="application/json"};if(language!=null)h["Accept-Language"]=language;return _c.Put($"/things/{uid}/firmware/{version}",h); }
        public Task<string> UpdateThingFirmwareAsync(string uid,string version,string?language=null)
        { var h=new Dictionary<string,string>{["Content-Type"]="application/json"};if(language!=null)h["Accept-Language"]=language;return _c.PutAsync($"/things/{uid}/firmware/{version}",h); }

        public string GetThingFirmwareStatus(string uid, string? language = null)
        { var h=new Dictionary<string,string>{["Accept"]="application/json"};if(language!=null)h["Accept-Language"]=language;return _c.Get($"/things/{uid}/firmware/status",h); }
        public Task<string> GetThingFirmwareStatusAsync(string uid,string?language=null)
        { var h=new Dictionary<string,string>{["Accept"]="application/json"};if(language!=null)h["Accept-Language"]=language;return _c.GetAsync($"/things/{uid}/firmware/status",h); }

        public string GetThingFirmwares(string uid, string? language = null)
        { var h=new Dictionary<string,string>{["Accept"]="application/json"};if(language!=null)h["Accept-Language"]=language;return _c.Get($"/things/{uid}/firmwares",h); }
        public Task<string> GetThingFirmwaresAsync(string uid,string?language=null)
        { var h=new Dictionary<string,string>{["Accept"]="application/json"};if(language!=null)h["Accept-Language"]=language;return _c.GetAsync($"/things/{uid}/firmwares",h); }

        public string GetThingStatus(string uid, string? language = null)
        { var h=new Dictionary<string,string>{["Accept"]="application/json"};if(language!=null)h["Accept-Language"]=language;return _c.Get($"/things/{uid}/status",h); }
        public Task<string> GetThingStatusAsync(string uid,string?language=null)
        { var h=new Dictionary<string,string>{["Accept"]="application/json"};if(language!=null)h["Accept-Language"]=language;return _c.GetAsync($"/things/{uid}/status",h); }
    }
}
