using System.Collections.Generic;
using System.Threading.Tasks;
using static OpenHABRestClient.OpenHABClient;

namespace OpenHABRestClient
{
    // ═══════════════════════════════════════════════════════════════════════════
    // Actions
    // ═══════════════════════════════════════════════════════════════════════════

    /// <summary>openHAB Actions REST API.</summary>
    public class Actions
    {
        private readonly OpenHABClient _c;
        public Actions(OpenHABClient client) => _c = client;

        public string GetActions(string thingUID, string? language = null)
        { var h=new Dictionary<string,string>{["Accept"]="application/json"};if(language!=null)h["Accept-Language"]=language;return _c.Get($"/actions/{thingUID}",h); }
        public Task<string> GetActionsAsync(string thingUID, string? language = null)
        { var h=new Dictionary<string,string>{["Accept"]="application/json"};if(language!=null)h["Accept-Language"]=language;return _c.GetAsync($"/actions/{thingUID}",h); }

        public string ExecuteAction(string thingUID, string actionUID, string inputsJson, string? language = null)
        { var h=new Dictionary<string,string>{["Content-Type"]="application/json",["Accept"]="application/json"};if(language!=null)h["Accept-Language"]=language;return _c.Post($"/actions/{thingUID}/{actionUID}",h,inputsJson); }
        public Task<string> ExecuteActionAsync(string thingUID, string actionUID, string inputsJson, string? language = null)
        { var h=new Dictionary<string,string>{["Content-Type"]="application/json",["Accept"]="application/json"};if(language!=null)h["Accept-Language"]=language;return _c.PostAsync($"/actions/{thingUID}/{actionUID}",h,inputsJson); }
    }

    // ═══════════════════════════════════════════════════════════════════════════
    // Addons
    // ═══════════════════════════════════════════════════════════════════════════

    /// <summary>openHAB Addons REST API.</summary>
    public class Addons
    {
        private readonly OpenHABClient _c;
        public Addons(OpenHABClient client) => _c = client;

        public string GetAddons(string? serviceID = null, string? language = null)
        { var h=new Dictionary<string,string>{["Accept"]="application/json"};if(language!=null)h["Accept-Language"]=language;return _c.Get("/addons",h,serviceID!=null?Q("serviceId",serviceID):null); }
        public Task<string> GetAddonsAsync(string?serviceID=null,string?language=null)
        { var h=new Dictionary<string,string>{["Accept"]="application/json"};if(language!=null)h["Accept-Language"]=language;return _c.GetAsync("/addons",h,serviceID!=null?Q("serviceId",serviceID):null); }

        public string GetAddon(string id, string? serviceID = null, string? language = null)
        { var h=new Dictionary<string,string>{["Accept"]="application/json"};if(language!=null)h["Accept-Language"]=language;return _c.Get($"/addons/{id}",h,serviceID!=null?Q("serviceId",serviceID):null); }
        public Task<string> GetAddonAsync(string id,string?serviceID=null,string?language=null)
        { var h=new Dictionary<string,string>{["Accept"]="application/json"};if(language!=null)h["Accept-Language"]=language;return _c.GetAsync($"/addons/{id}",h,serviceID!=null?Q("serviceId",serviceID):null); }

        public string GetAddonConfig(string id, string? serviceID = null)
            => _c.Get($"/addons/{id}/config",null,serviceID!=null?Q("serviceId",serviceID):null);
        public Task<string> GetAddonConfigAsync(string id,string?serviceID=null)
            => _c.GetAsync($"/addons/{id}/config",null,serviceID!=null?Q("serviceId",serviceID):null);

        public string UpdateAddonConfig(string id,string json,string?serviceID=null)
            => _c.Put($"/addons/{id}/config",H("Content-Type","application/json"),json,serviceID!=null?Q("serviceId",serviceID):null);
        public Task<string> UpdateAddonConfigAsync(string id,string json,string?serviceID=null)
            => _c.PutAsync($"/addons/{id}/config",H("Content-Type","application/json"),json,serviceID!=null?Q("serviceId",serviceID):null);

        public string InstallAddon(string id,string?serviceID=null)
            => _c.Post($"/addons/{id}/install",null,null,serviceID!=null?Q("serviceId",serviceID):null);
        public Task<string> InstallAddonAsync(string id,string?serviceID=null)
            => _c.PostAsync($"/addons/{id}/install",null,null,serviceID!=null?Q("serviceId",serviceID):null);

        public string UninstallAddon(string id,string?serviceID=null)
            => _c.Post($"/addons/{id}/uninstall",null,null,serviceID!=null?Q("serviceId",serviceID):null);
        public Task<string> UninstallAddonAsync(string id,string?serviceID=null)
            => _c.PostAsync($"/addons/{id}/uninstall",null,null,serviceID!=null?Q("serviceId",serviceID):null);

        public string GetAddonServices(string?language=null)
        { var h=new Dictionary<string,string>{["Accept"]="application/json"};if(language!=null)h["Accept-Language"]=language;return _c.Get("/addons/services",h); }
        public Task<string> GetAddonServicesAsync(string?language=null)
        { var h=new Dictionary<string,string>{["Accept"]="application/json"};if(language!=null)h["Accept-Language"]=language;return _c.GetAsync("/addons/services",h); }

        public string GetAddonSuggestions(string?language=null)
        { var h=new Dictionary<string,string>{["Accept"]="application/json"};if(language!=null)h["Accept-Language"]=language;return _c.Get("/addons/suggestions",h); }
        public Task<string> GetAddonSuggestionsAsync(string?language=null)
        { var h=new Dictionary<string,string>{["Accept"]="application/json"};if(language!=null)h["Accept-Language"]=language;return _c.GetAsync("/addons/suggestions",h); }

        public string GetAddonTypes(string?serviceID=null,string?language=null)
        { var h=new Dictionary<string,string>{["Accept"]="application/json"};if(language!=null)h["Accept-Language"]=language;return _c.Get("/addons/types",h,serviceID!=null?Q("serviceId",serviceID):null); }
        public Task<string> GetAddonTypesAsync(string?serviceID=null,string?language=null)
        { var h=new Dictionary<string,string>{["Accept"]="application/json"};if(language!=null)h["Accept-Language"]=language;return _c.GetAsync("/addons/types",h,serviceID!=null?Q("serviceId",serviceID):null); }

        public string InstallAddonFromUrl(string url)
            => _c.Post("/addons/url",H("Content-Type","text/plain"),url);
        public Task<string> InstallAddonFromUrlAsync(string url)
            => _c.PostAsync("/addons/url",H("Content-Type","text/plain"),url);
    }

    // ═══════════════════════════════════════════════════════════════════════════
    // Audio
    // ═══════════════════════════════════════════════════════════════════════════

    /// <summary>openHAB Audio REST API.</summary>
    public class Audio
    {
        private readonly OpenHABClient _c;
        public Audio(OpenHABClient client) => _c = client;
        private static Dictionary<string,string> AccJson(string? lang) { var h=new Dictionary<string,string>{["Accept"]="application/json"};if(lang!=null)h["Accept-Language"]=lang;return h; }

        public string GetDefaultSink(string?language=null)   => _c.Get("/audio/defaultsink",AccJson(language));
        public Task<string> GetDefaultSinkAsync(string?l=null)=> _c.GetAsync("/audio/defaultsink",AccJson(l));
        public string GetDefaultSource(string?language=null) => _c.Get("/audio/defaultsource",AccJson(language));
        public Task<string> GetDefaultSourceAsync(string?l=null)=>_c.GetAsync("/audio/defaultsource",AccJson(l));
        public string GetSinks(string?language=null)         => _c.Get("/audio/sinks",AccJson(language));
        public Task<string> GetSinksAsync(string?l=null)    => _c.GetAsync("/audio/sinks",AccJson(l));
        public string GetSources(string?language=null)       => _c.Get("/audio/sources",AccJson(language));
        public Task<string> GetSourcesAsync(string?l=null)  => _c.GetAsync("/audio/sources",AccJson(l));
    }

    // ═══════════════════════════════════════════════════════════════════════════
    // Auth
    // ═══════════════════════════════════════════════════════════════════════════

    /// <summary>openHAB Auth REST API.</summary>
    public class Auth
    {
        private readonly OpenHABClient _c;
        public Auth(OpenHABClient client) => _c = client;

        public string GetAPITokens() => _c.Get("/auth/apitokens");
        public Task<string> GetAPITokensAsync() => _c.GetAsync("/auth/apitokens");
        public string RevokeAPIToken(string name) => _c.Delete($"/auth/apitokens/{name}");
        public Task<string> RevokeAPITokenAsync(string name) => _c.DeleteAsync($"/auth/apitokens/{name}");
        public string Logout(string refreshToken,string sessionID)
            => _c.Delete("/auth/logout",null,null,Q("refreshToken",refreshToken,"sessionId",sessionID));
        public Task<string> LogoutAsync(string refreshToken,string sessionID)
            => _c.DeleteAsync("/auth/logout",null,null,Q("refreshToken",refreshToken,"sessionId",sessionID));
        public string GetSessions() => _c.Get("/auth/sessions");
        public Task<string> GetSessionsAsync() => _c.GetAsync("/auth/sessions");
        public string GetToken(string? grantType=null,string? code=null,string? redirectUri=null,
            string? clientId=null,string? refreshToken=null,string? codeVerifier=null)
        {
            var parts=new System.Collections.Generic.List<string>();
            if(grantType!=null)parts.Add($"grant_type={grantType}");
            if(code!=null)parts.Add($"code={code}");
            if(redirectUri!=null)parts.Add($"redirect_uri={redirectUri}");
            if(clientId!=null)parts.Add($"client_id={clientId}");
            if(refreshToken!=null)parts.Add($"refresh_token={refreshToken}");
            if(codeVerifier!=null)parts.Add($"code_verifier={codeVerifier}");
            return _c.Post("/auth/token",H("Content-Type","application/x-www-form-urlencoded"),string.Join("&",parts));
        }
        public Task<string> GetTokenAsync(string?grantType=null,string?code=null,string?redirectUri=null,
            string?clientId=null,string?refreshToken=null,string?codeVerifier=null)
        {
            var parts=new System.Collections.Generic.List<string>();
            if(grantType!=null)parts.Add($"grant_type={grantType}");if(code!=null)parts.Add($"code={code}");
            if(redirectUri!=null)parts.Add($"redirect_uri={redirectUri}");if(clientId!=null)parts.Add($"client_id={clientId}");
            if(refreshToken!=null)parts.Add($"refresh_token={refreshToken}");if(codeVerifier!=null)parts.Add($"code_verifier={codeVerifier}");
            return _c.PostAsync("/auth/token",H("Content-Type","application/x-www-form-urlencoded"),string.Join("&",parts));
        }
    }

    // ═══════════════════════════════════════════════════════════════════════════
    // ChannelTypes
    // ═══════════════════════════════════════════════════════════════════════════

    /// <summary>openHAB ChannelTypes REST API.</summary>
    public class ChannelTypes
    {
        private readonly OpenHABClient _c;
        public ChannelTypes(OpenHABClient client) => _c = client;
        public string GetChannelTypes(string?prefixes=null,string?language=null){var h=new Dictionary<string,string>{["Accept"]="application/json"};if(language!=null)h["Accept-Language"]=language;return _c.Get("/channel-types",h,prefixes!=null?Q("prefixes",prefixes):null);}
        public Task<string> GetChannelTypesAsync(string?p=null,string?l=null){var h=new Dictionary<string,string>{["Accept"]="application/json"};if(l!=null)h["Accept-Language"]=l;return _c.GetAsync("/channel-types",h,p!=null?Q("prefixes",p):null);}
        public string GetChannelType(string uid,string?language=null){var h=new Dictionary<string,string>{["Accept"]="application/json"};if(language!=null)h["Accept-Language"]=language;return _c.Get($"/channel-types/{uid}",h);}
        public Task<string> GetChannelTypeAsync(string uid,string?l=null){var h=new Dictionary<string,string>{["Accept"]="application/json"};if(l!=null)h["Accept-Language"]=l;return _c.GetAsync($"/channel-types/{uid}",h);}
        public string GetLinkableItemTypes(string uid) => _c.Get($"/channel-types/{uid}/linkableItemTypes");
        public Task<string> GetLinkableItemTypesAsync(string uid) => _c.GetAsync($"/channel-types/{uid}/linkableItemTypes");
    }

    // ═══════════════════════════════════════════════════════════════════════════
    // ConfigDescriptions
    // ═══════════════════════════════════════════════════════════════════════════

    /// <summary>openHAB ConfigDescriptions REST API.</summary>
    public class ConfigDescriptions
    {
        private readonly OpenHABClient _c;
        public ConfigDescriptions(OpenHABClient client) => _c = client;
        public string GetConfigDescriptions(string?scheme=null,string?language=null){var h=new Dictionary<string,string>{["Accept"]="application/json"};if(language!=null)h["Accept-Language"]=language;return _c.Get("/config-descriptions",h,scheme!=null?Q("scheme",scheme):null);}
        public Task<string> GetConfigDescriptionsAsync(string?s=null,string?l=null){var h=new Dictionary<string,string>{["Accept"]="application/json"};if(l!=null)h["Accept-Language"]=l;return _c.GetAsync("/config-descriptions",h,s!=null?Q("scheme",s):null);}
        public string GetConfigDescription(string uri,string?language=null){var h=new Dictionary<string,string>{["Accept"]="application/json"};if(language!=null)h["Accept-Language"]=language;return _c.Get($"/config-descriptions/{Uri.EscapeDataString(uri)}",h);}
        public Task<string> GetConfigDescriptionAsync(string uri,string?l=null){var h=new Dictionary<string,string>{["Accept"]="application/json"};if(l!=null)h["Accept-Language"]=l;return _c.GetAsync($"/config-descriptions/{Uri.EscapeDataString(uri)}",h);}
        private static string Uri_EscapeDataString_local(string s) => System.Uri.EscapeDataString(s);
    }

    // ═══════════════════════════════════════════════════════════════════════════
    // Discovery
    // ═══════════════════════════════════════════════════════════════════════════

    /// <summary>openHAB Discovery REST API.</summary>
    public class Discovery
    {
        private readonly OpenHABClient _c;
        public Discovery(OpenHABClient client) => _c = client;
        public string GetDiscoveryBindings() => _c.Get("/discovery");
        public Task<string> GetDiscoveryBindingsAsync() => _c.GetAsync("/discovery");
        public string GetBindingInfo(string id,string?language=null){var h=new Dictionary<string,string>{["Accept"]="application/json"};if(language!=null)h["Accept-Language"]=language;return _c.Get($"/bindings/{id}",h);}
        public Task<string> GetBindingInfoAsync(string id,string?l=null){var h=new Dictionary<string,string>{["Accept"]="application/json"};if(l!=null)h["Accept-Language"]=l;return _c.GetAsync($"/bindings/{id}",h);}
        public string StartBindingScan(string id,string?input=null) => _c.Post($"/discovery/bindings/{id}/scan",null,input);
        public Task<string> StartBindingScanAsync(string id,string?input=null) => _c.PostAsync($"/discovery/bindings/{id}/scan",null,input);
    }

    // ═══════════════════════════════════════════════════════════════════════════
    // Iconsets
    // ═══════════════════════════════════════════════════════════════════════════

    /// <summary>openHAB Iconsets REST API.</summary>
    public class Iconsets
    {
        private readonly OpenHABClient _c;
        public Iconsets(OpenHABClient client) => _c = client;
        public string GetIconsets(string?language=null){var h=new Dictionary<string,string>{["Accept"]="application/json"};if(language!=null)h["Accept-Language"]=language;return _c.Get("/iconsets",h);}
        public Task<string> GetIconsetsAsync(string?l=null){var h=new Dictionary<string,string>{["Accept"]="application/json"};if(l!=null)h["Accept-Language"]=l;return _c.GetAsync("/iconsets",h);}
    }

    // ═══════════════════════════════════════════════════════════════════════════
    // Inbox
    // ═══════════════════════════════════════════════════════════════════════════

    /// <summary>openHAB Inbox REST API.</summary>
    public class Inbox
    {
        private readonly OpenHABClient _c;
        public Inbox(OpenHABClient client) => _c = client;
        public string GetDiscoveredThings(bool includeIgnored=true) => _c.Get("/inbox",null,Q("includeIgnored",includeIgnored.ToString().ToLower()));
        public Task<string> GetDiscoveredThingsAsync(bool includeIgnored=true) => _c.GetAsync("/inbox",null,Q("includeIgnored",includeIgnored.ToString().ToLower()));
        public string RemoveDiscoveryResult(string uid) => _c.Delete($"/inbox/{uid}");
        public Task<string> RemoveDiscoveryResultAsync(string uid) => _c.DeleteAsync($"/inbox/{uid}");
        public string ApproveDiscoveryResult(string uid,string label,string?newId=null,string?language=null){var h=new Dictionary<string,string>{["Content-Type"]="text/plain"};if(language!=null)h["Accept-Language"]=language;return _c.Post($"/inbox/{uid}/approve",h,label,newId!=null?Q("newThingId",newId):null);}
        public Task<string> ApproveDiscoveryResultAsync(string uid,string label,string?newId=null,string?language=null){var h=new Dictionary<string,string>{["Content-Type"]="text/plain"};if(language!=null)h["Accept-Language"]=language;return _c.PostAsync($"/inbox/{uid}/approve",h,label,newId!=null?Q("newThingId",newId):null);}
        public string IgnoreDiscoveryResult(string uid)   => _c.Post($"/inbox/{uid}/ignore");
        public Task<string> IgnoreDiscoveryResultAsync(string uid)   => _c.PostAsync($"/inbox/{uid}/ignore");
        public string UnignoreDiscoveryResult(string uid) => _c.Post($"/inbox/{uid}/unignore");
        public Task<string> UnignoreDiscoveryResultAsync(string uid) => _c.PostAsync($"/inbox/{uid}/unignore");
    }

    // ═══════════════════════════════════════════════════════════════════════════
    // Links
    // ═══════════════════════════════════════════════════════════════════════════

    /// <summary>openHAB Links REST API.</summary>
    public class Links
    {
        private readonly OpenHABClient _c;
        public Links(OpenHABClient client) => _c = client;
        public string GetLinks(string?channelUID=null,string?itemName=null) => _c.Get("/links",null,Q("channelUID",channelUID,"itemName",itemName));
        public Task<string> GetLinksAsync(string?ch=null,string?item=null) => _c.GetAsync("/links",null,Q("channelUID",ch,"itemName",item));
        public string GetLink(string item,string ch) => _c.Get($"/links/{item}/{System.Uri.EscapeDataString(ch)}");
        public Task<string> GetLinkAsync(string item,string ch) => _c.GetAsync($"/links/{item}/{System.Uri.EscapeDataString(ch)}");
        public string LinkItemToChannel(string item,string ch,string configJson) => _c.Put($"/links/{item}/{System.Uri.EscapeDataString(ch)}",H("Content-Type","application/json"),configJson);
        public Task<string> LinkItemToChannelAsync(string item,string ch,string configJson) => _c.PutAsync($"/links/{item}/{System.Uri.EscapeDataString(ch)}",H("Content-Type","application/json"),configJson);
        public string UnlinkItemFromChannel(string item,string ch) => _c.Delete($"/links/{item}/{System.Uri.EscapeDataString(ch)}");
        public Task<string> UnlinkItemFromChannelAsync(string item,string ch) => _c.DeleteAsync($"/links/{item}/{System.Uri.EscapeDataString(ch)}");
        public string DeleteAllLinks(string obj) => _c.Delete($"/links/{obj}");
        public Task<string> DeleteAllLinksAsync(string obj) => _c.DeleteAsync($"/links/{obj}");
        public string GetOrphanLinks() => _c.Get("/links/orphan");
        public Task<string> GetOrphanLinksAsync() => _c.GetAsync("/links/orphan");
        public string PurgeUnusedLinks() => _c.Post("/links/purge");
        public Task<string> PurgeUnusedLinksAsync() => _c.PostAsync("/links/purge");
    }

    // ═══════════════════════════════════════════════════════════════════════════
    // Logging
    // ═══════════════════════════════════════════════════════════════════════════

    /// <summary>openHAB Logging REST API.</summary>
    public class Logging
    {
        private readonly OpenHABClient _c;
        public Logging(OpenHABClient client) => _c = client;
        public string GetLoggers() => _c.Get("/loggers");
        public Task<string> GetLoggersAsync() => _c.GetAsync("/loggers");
        public string GetLogger(string name) => _c.Get($"/loggers/{name}");
        public Task<string> GetLoggerAsync(string name) => _c.GetAsync($"/loggers/{name}");
        public string ModifyOrAddLogger(string name,string level) => _c.Put($"/loggers/{name}",H("Content-Type","application/json"),$"{{\"level\":\"{level}\"}}");
        public Task<string> ModifyOrAddLoggerAsync(string name,string level) => _c.PutAsync($"/loggers/{name}",H("Content-Type","application/json"),$"{{\"level\":\"{level}\"}}");
        public string RemoveLogger(string name) => _c.Delete($"/loggers/{name}");
        public Task<string> RemoveLoggerAsync(string name) => _c.DeleteAsync($"/loggers/{name}");
    }

    // ═══════════════════════════════════════════════════════════════════════════
    // ModuleTypes
    // ═══════════════════════════════════════════════════════════════════════════

    /// <summary>openHAB ModuleTypes REST API.</summary>
    public class ModuleTypes
    {
        private readonly OpenHABClient _c;
        public ModuleTypes(OpenHABClient client) => _c = client;
        public string GetModuleTypes(string?tags=null,string?typeFilter=null,string?language=null){var h=new Dictionary<string,string>{["Accept"]="application/json"};if(language!=null)h["Accept-Language"]=language;return _c.Get("/module-types",h,Q("tags",tags,"type",typeFilter));}
        public Task<string> GetModuleTypesAsync(string?tags=null,string?tf=null,string?l=null){var h=new Dictionary<string,string>{["Accept"]="application/json"};if(l!=null)h["Accept-Language"]=l;return _c.GetAsync("/module-types",h,Q("tags",tags,"type",tf));}
        public string GetModuleType(string uid,string?language=null){var h=new Dictionary<string,string>{["Accept"]="application/json"};if(language!=null)h["Accept-Language"]=language;return _c.Get($"/module-types/{uid}",h);}
        public Task<string> GetModuleTypeAsync(string uid,string?l=null){var h=new Dictionary<string,string>{["Accept"]="application/json"};if(l!=null)h["Accept-Language"]=l;return _c.GetAsync($"/module-types/{uid}",h);}
    }

    // ═══════════════════════════════════════════════════════════════════════════
    // Persistence
    // ═══════════════════════════════════════════════════════════════════════════

    /// <summary>openHAB Persistence REST API.</summary>
    public class Persistence
    {
        private readonly OpenHABClient _c;
        public Persistence(OpenHABClient client) => _c = client;
        public string GetServices(string?language=null){var h=new Dictionary<string,string>{["Accept"]="application/json"};if(language!=null)h["Accept-Language"]=language;return _c.Get("/persistence",h);}
        public Task<string> GetServicesAsync(string?l=null){var h=new Dictionary<string,string>{["Accept"]="application/json"};if(l!=null)h["Accept-Language"]=l;return _c.GetAsync("/persistence",h);}
        public string GetServiceConfiguration(string id) => _c.Get($"/persistence/{id}");
        public Task<string> GetServiceConfigurationAsync(string id) => _c.GetAsync($"/persistence/{id}");
        public string SetServiceConfiguration(string id,string json) => _c.Put($"/persistence/{id}",H("Content-Type","application/json"),json);
        public Task<string> SetServiceConfigurationAsync(string id,string json) => _c.PutAsync($"/persistence/{id}",H("Content-Type","application/json"),json);
        public string DeleteServiceConfiguration(string id) => _c.Delete($"/persistence/{id}");
        public Task<string> DeleteServiceConfigurationAsync(string id) => _c.DeleteAsync($"/persistence/{id}");
        public string GetItemsFromService(string?serviceID=null) => _c.Get("/persistence/items",null,serviceID!=null?Q("serviceId",serviceID):null);
        public Task<string> GetItemsFromServiceAsync(string?serviceID=null) => _c.GetAsync("/persistence/items",null,serviceID!=null?Q("serviceId",serviceID):null);
        public string GetItemPersistenceData(string item,string serviceID,string?startTime=null,string?endTime=null,int page=1,int pageLength=50,bool boundary=false,bool itemState=false)
            => _c.Get($"/persistence/items/{item}",null,Q("serviceId",serviceID,"starttime",startTime,"endtime",endTime,"page",page.ToString(),"pagelength",pageLength.ToString(),"boundary",boundary.ToString().ToLower(),"itemState",itemState.ToString().ToLower()));
        public Task<string> GetItemPersistenceDataAsync(string item,string serviceID,string?startTime=null,string?endTime=null,int page=1,int pageLength=50,bool boundary=false,bool itemState=false)
            => _c.GetAsync($"/persistence/items/{item}",null,Q("serviceId",serviceID,"starttime",startTime,"endtime",endTime,"page",page.ToString(),"pagelength",pageLength.ToString(),"boundary",boundary.ToString().ToLower(),"itemState",itemState.ToString().ToLower()));
        public string StoreItemData(string item,string time,string state,string?serviceID=null){var p=Q("time",time);if(serviceID!=null)p["serviceId"]=serviceID;return _c.Put($"/persistence/items/{item}",H("Content-Type","text/plain"),state,p);}
        public Task<string> StoreItemDataAsync(string item,string time,string state,string?serviceID=null){var p=Q("time",time);if(serviceID!=null)p["serviceId"]=serviceID;return _c.PutAsync($"/persistence/items/{item}",H("Content-Type","text/plain"),state,p);}
        public string DeleteItemData(string item,string start,string end,string serviceID)
            => _c.Delete($"/persistence/items/{item}",null,null,Q("serviceId",serviceID,"starttime",start,"endtime",end));
        public Task<string> DeleteItemDataAsync(string item,string start,string end,string serviceID)
            => _c.DeleteAsync($"/persistence/items/{item}",null,null,Q("serviceId",serviceID,"starttime",start,"endtime",end));
    }

    // ═══════════════════════════════════════════════════════════════════════════
    // ProfileTypes / Services / Sitemaps / Systeminfo / Tags / Templates
    // ThingTypes / Transformations / UI / UUID / Voice
    // ═══════════════════════════════════════════════════════════════════════════

    /// <summary>openHAB ProfileTypes REST API.</summary>
    public class ProfileTypes
    {
        private readonly OpenHABClient _c;
        public ProfileTypes(OpenHABClient client) => _c = client;
        public string GetProfileTypes(string?channelTypeUID=null,string?itemType=null,string?language=null){var h=new Dictionary<string,string>{["Accept"]="application/json"};if(language!=null)h["Accept-Language"]=language;return _c.Get("/profile-types",h,Q("channelTypeUID",channelTypeUID,"itemType",itemType));}
        public Task<string> GetProfileTypesAsync(string?ch=null,string?it=null,string?l=null){var h=new Dictionary<string,string>{["Accept"]="application/json"};if(l!=null)h["Accept-Language"]=l;return _c.GetAsync("/profile-types",h,Q("channelTypeUID",ch,"itemType",it));}
    }

    /// <summary>openHAB Services REST API.</summary>
    public class Services
    {
        private readonly OpenHABClient _c;
        public Services(OpenHABClient client) => _c = client;
        public string GetServices(string?l=null){var h=new Dictionary<string,string>{["Accept"]="application/json"};if(l!=null)h["Accept-Language"]=l;return _c.Get("/services",h);}
        public Task<string> GetServicesAsync(string?l=null){var h=new Dictionary<string,string>{["Accept"]="application/json"};if(l!=null)h["Accept-Language"]=l;return _c.GetAsync("/services",h);}
        public string GetService(string id,string?l=null){var h=new Dictionary<string,string>{["Accept"]="application/json"};if(l!=null)h["Accept-Language"]=l;return _c.Get($"/services/{id}",h);}
        public Task<string> GetServiceAsync(string id,string?l=null){var h=new Dictionary<string,string>{["Accept"]="application/json"};if(l!=null)h["Accept-Language"]=l;return _c.GetAsync($"/services/{id}",h);}
        public string GetServiceConfig(string id) => _c.Get($"/services/{id}/config");
        public Task<string> GetServiceConfigAsync(string id) => _c.GetAsync($"/services/{id}/config");
        public string UpdateServiceConfig(string id,string json,string?l=null){var h=new Dictionary<string,string>{["Content-Type"]="application/json"};if(l!=null)h["Accept-Language"]=l;return _c.Put($"/services/{id}/config",h,json);}
        public Task<string> UpdateServiceConfigAsync(string id,string json,string?l=null){var h=new Dictionary<string,string>{["Content-Type"]="application/json"};if(l!=null)h["Accept-Language"]=l;return _c.PutAsync($"/services/{id}/config",h,json);}
        public string DeleteServiceConfig(string id) => _c.Delete($"/services/{id}/config");
        public Task<string> DeleteServiceConfigAsync(string id) => _c.DeleteAsync($"/services/{id}/config");
        public string GetServiceContexts(string id,string?l=null){var h=new Dictionary<string,string>{["Accept"]="application/json"};if(l!=null)h["Accept-Language"]=l;return _c.Get($"/services/{id}/contexts",h);}
        public Task<string> GetServiceContextsAsync(string id,string?l=null){var h=new Dictionary<string,string>{["Accept"]="application/json"};if(l!=null)h["Accept-Language"]=l;return _c.GetAsync($"/services/{id}/contexts",h);}
    }

    /// <summary>openHAB Sitemaps REST API.</summary>
    public class Sitemaps
    {
        private readonly OpenHABClient _c;
        public Sitemaps(OpenHABClient client) => _c = client;
        public string GetSitemaps() => _c.Get("/sitemaps");
        public Task<string> GetSitemapsAsync() => _c.GetAsync("/sitemaps");
        public string GetSitemap(string name,string?type=null,string?cb=null,bool hidden=false,string?l=null){var h=new Dictionary<string,string>();if(l!=null)h["Accept-Language"]=l;return _c.Get($"/sitemaps/{name}",h,Q("type",type,"jsoncallback",cb,"includeHidden",hidden.ToString().ToLower()));}
        public Task<string> GetSitemapAsync(string name,string?type=null,string?cb=null,bool hidden=false,string?l=null){var h=new Dictionary<string,string>();if(l!=null)h["Accept-Language"]=l;return _c.GetAsync($"/sitemaps/{name}",h,Q("type",type,"jsoncallback",cb,"includeHidden",hidden.ToString().ToLower()));}
        public string GetSitemapPage(string name,string page,string?subId=null,bool hidden=false,string?l=null){var h=new Dictionary<string,string>();if(l!=null)h["Accept-Language"]=l;return _c.Get($"/sitemaps/{name}/{page}",h,Q("subscriptionid",subId,"includeHidden",hidden.ToString().ToLower()));}
        public Task<string> GetSitemapPageAsync(string name,string page,string?subId=null,bool hidden=false,string?l=null){var h=new Dictionary<string,string>();if(l!=null)h["Accept-Language"]=l;return _c.GetAsync($"/sitemaps/{name}/{page}",h,Q("subscriptionid",subId,"includeHidden",hidden.ToString().ToLower()));}
        public SSEConnection GetSitemapEvents(string subId,string?name=null,string?pageId=null){var url=_c.BaseUrl+$"/rest/sitemaps/events/{subId}";if(name!=null)url+=$"?sitemap={name}";if(pageId!=null)url+=(name!=null?"&":"?")+"pageid="+pageId;return _c.ExecuteSSE(url);}
        public SSEConnection GetFullSitemapEvents(string subId,string?name=null){var url=_c.BaseUrl+$"/rest/sitemaps/events/{subId}";if(name!=null)url+=$"?sitemap={name}";return _c.ExecuteSSE(url);}
        public string SubscribeToSitemapEvents() => _c.Post("/sitemaps/events/subscribe");
        public Task<string> SubscribeToSitemapEventsAsync() => _c.PostAsync("/sitemaps/events/subscribe");
    }

    /// <summary>openHAB Systeminfo REST API.</summary>
    public class Systeminfo
    {
        private readonly OpenHABClient _c;
        public Systeminfo(OpenHABClient client) => _c = client;
        public string GetSystemInfo() => _c.Get("/systeminfo");
        public Task<string> GetSystemInfoAsync() => _c.GetAsync("/systeminfo");
        public string GetUoMInfo() => _c.Get("/systeminfo/uom");
        public Task<string> GetUoMInfoAsync() => _c.GetAsync("/systeminfo/uom");
    }

    /// <summary>openHAB Tags REST API.</summary>
    public class Tags
    {
        private readonly OpenHABClient _c;
        public Tags(OpenHABClient client) => _c = client;
        public string GetTags(string?l=null){var h=new Dictionary<string,string>{["Accept"]="application/json"};if(l!=null)h["Accept-Language"]=l;return _c.Get("/tags",h);}
        public Task<string> GetTagsAsync(string?l=null){var h=new Dictionary<string,string>{["Accept"]="application/json"};if(l!=null)h["Accept-Language"]=l;return _c.GetAsync("/tags",h);}
        public string CreateTag(string json,string?l=null){var h=new Dictionary<string,string>{["Content-Type"]="application/json"};if(l!=null)h["Accept-Language"]=l;return _c.Post("/tags",h,json);}
        public Task<string> CreateTagAsync(string json,string?l=null){var h=new Dictionary<string,string>{["Content-Type"]="application/json"};if(l!=null)h["Accept-Language"]=l;return _c.PostAsync("/tags",h,json);}
        public string GetTag(string id,string?l=null){var h=new Dictionary<string,string>{["Accept"]="application/json"};if(l!=null)h["Accept-Language"]=l;return _c.Get($"/tags/{id}",h);}
        public Task<string> GetTagAsync(string id,string?l=null){var h=new Dictionary<string,string>{["Accept"]="application/json"};if(l!=null)h["Accept-Language"]=l;return _c.GetAsync($"/tags/{id}",h);}
        public string UpdateTag(string id,string json,string?l=null){var h=new Dictionary<string,string>{["Content-Type"]="application/json"};if(l!=null)h["Accept-Language"]=l;return _c.Put($"/tags/{id}",h,json);}
        public Task<string> UpdateTagAsync(string id,string json,string?l=null){var h=new Dictionary<string,string>{["Content-Type"]="application/json"};if(l!=null)h["Accept-Language"]=l;return _c.PutAsync($"/tags/{id}",h,json);}
        public string DeleteTag(string id,string?l=null){var h=new Dictionary<string,string>();if(l!=null)h["Accept-Language"]=l;return _c.Delete($"/tags/{id}",h);}
        public Task<string> DeleteTagAsync(string id,string?l=null){var h=new Dictionary<string,string>();if(l!=null)h["Accept-Language"]=l;return _c.DeleteAsync($"/tags/{id}",h);}
    }

    /// <summary>openHAB Templates REST API.</summary>
    public class Templates
    {
        private readonly OpenHABClient _c;
        public Templates(OpenHABClient client) => _c = client;
        public string GetTemplates(string?l=null){var h=new Dictionary<string,string>{["Accept"]="application/json"};if(l!=null)h["Accept-Language"]=l;return _c.Get("/templates",h);}
        public Task<string> GetTemplatesAsync(string?l=null){var h=new Dictionary<string,string>{["Accept"]="application/json"};if(l!=null)h["Accept-Language"]=l;return _c.GetAsync("/templates",h);}
        public string GetTemplate(string uid,string?l=null){var h=new Dictionary<string,string>{["Accept"]="application/json"};if(l!=null)h["Accept-Language"]=l;return _c.Get($"/templates/{uid}",h);}
        public Task<string> GetTemplateAsync(string uid,string?l=null){var h=new Dictionary<string,string>{["Accept"]="application/json"};if(l!=null)h["Accept-Language"]=l;return _c.GetAsync($"/templates/{uid}",h);}
    }

    /// <summary>openHAB ThingTypes REST API.</summary>
    public class ThingTypes
    {
        private readonly OpenHABClient _c;
        public ThingTypes(OpenHABClient client) => _c = client;
        public string GetThingTypes(string?bindingID=null,string?l=null){var h=new Dictionary<string,string>{["Accept"]="application/json"};if(l!=null)h["Accept-Language"]=l;return _c.Get("/thing-types",h,bindingID!=null?Q("bindingId",bindingID):null);}
        public Task<string> GetThingTypesAsync(string?b=null,string?l=null){var h=new Dictionary<string,string>{["Accept"]="application/json"};if(l!=null)h["Accept-Language"]=l;return _c.GetAsync("/thing-types",h,b!=null?Q("bindingId",b):null);}
        public string GetThingType(string uid,string?l=null){var h=new Dictionary<string,string>{["Accept"]="application/json"};if(l!=null)h["Accept-Language"]=l;return _c.Get($"/thing-types/{uid}",h);}
        public Task<string> GetThingTypeAsync(string uid,string?l=null){var h=new Dictionary<string,string>{["Accept"]="application/json"};if(l!=null)h["Accept-Language"]=l;return _c.GetAsync($"/thing-types/{uid}",h);}
    }

    /// <summary>openHAB Transformations REST API.</summary>
    public class Transformations
    {
        private readonly OpenHABClient _c;
        public Transformations(OpenHABClient client) => _c = client;
        public string GetTransformations() => _c.Get("/transformations");
        public Task<string> GetTransformationsAsync() => _c.GetAsync("/transformations");
        public string GetTransformation(string uid) => _c.Get($"/transformations/{uid}");
        public Task<string> GetTransformationAsync(string uid) => _c.GetAsync($"/transformations/{uid}");
        public string UpdateTransformation(string uid,string json) => _c.Put($"/transformations/{uid}",H("Content-Type","application/json"),json);
        public Task<string> UpdateTransformationAsync(string uid,string json) => _c.PutAsync($"/transformations/{uid}",H("Content-Type","application/json"),json);
        public string DeleteTransformation(string uid) => _c.Delete($"/transformations/{uid}");
        public Task<string> DeleteTransformationAsync(string uid) => _c.DeleteAsync($"/transformations/{uid}");
        public string GetTransformationServices() => _c.Get("/transformations/services");
        public Task<string> GetTransformationServicesAsync() => _c.GetAsync("/transformations/services");
    }

    /// <summary>openHAB UI REST API.</summary>
    public class UI
    {
        private readonly OpenHABClient _c;
        public UI(OpenHABClient client) => _c = client;
        public string GetUIComponents(string ns,bool summary=false) => _c.Get($"/ui/components/{ns}",null,Q("summary",summary.ToString().ToLower()));
        public Task<string> GetUIComponentsAsync(string ns,bool summary=false) => _c.GetAsync($"/ui/components/{ns}",null,Q("summary",summary.ToString().ToLower()));
        public string AddUIComponent(string ns,string json) => _c.Post($"/ui/components/{ns}",H("Content-Type","application/json"),json);
        public Task<string> AddUIComponentAsync(string ns,string json) => _c.PostAsync($"/ui/components/{ns}",H("Content-Type","application/json"),json);
        public string GetUIComponent(string ns,string uid) => _c.Get($"/ui/components/{ns}/{uid}");
        public Task<string> GetUIComponentAsync(string ns,string uid) => _c.GetAsync($"/ui/components/{ns}/{uid}");
        public string UpdateUIComponent(string ns,string uid,string json) => _c.Put($"/ui/components/{ns}/{uid}",H("Content-Type","application/json"),json);
        public Task<string> UpdateUIComponentAsync(string ns,string uid,string json) => _c.PutAsync($"/ui/components/{ns}/{uid}",H("Content-Type","application/json"),json);
        public string DeleteUIComponent(string ns,string uid) => _c.Delete($"/ui/components/{ns}/{uid}");
        public Task<string> DeleteUIComponentAsync(string ns,string uid) => _c.DeleteAsync($"/ui/components/{ns}/{uid}");
        public string GetUITiles() => _c.Get("/ui/tiles");
        public Task<string> GetUITilesAsync() => _c.GetAsync("/ui/tiles");
    }

    /// <summary>openHAB UUID REST API.</summary>
    public class UUID
    {
        private readonly OpenHABClient _c;
        public UUID(OpenHABClient client) => _c = client;
        public string GetUUID() => _c.Get("/uuid");
        public Task<string> GetUUIDAsync() => _c.GetAsync("/uuid");
    }

    /// <summary>openHAB Voice REST API.</summary>
    public class Voice
    {
        private readonly OpenHABClient _c;
        public Voice(OpenHABClient client) => _c = client;
        public string GetDefaultVoice() => _c.Get("/voice/defaultvoice");
        public Task<string> GetDefaultVoiceAsync() => _c.GetAsync("/voice/defaultvoice");
        public string StartDialog(string sourceID,string?ksID=null,string?sttID=null,string?ttsID=null,string?voiceID=null,string?hliIDs=null,string?sinkID=null,string?keyword=null,string?listeningItem=null)
            => _c.Post("/voice/dialog/start",null,null,Q("sourceId",sourceID,"ksId",ksID,"sttId",sttID,"ttsId",ttsID,"voiceId",voiceID,"hliIds",hliIDs,"sinkId",sinkID,"keyword",keyword,"listeningItem",listeningItem));
        public Task<string> StartDialogAsync(string sid,string?ks=null,string?stt=null,string?tts=null,string?v=null,string?hli=null,string?sink=null,string?kw=null,string?li=null)
            => _c.PostAsync("/voice/dialog/start",null,null,Q("sourceId",sid,"ksId",ks,"sttId",stt,"ttsId",tts,"voiceId",v,"hliIds",hli,"sinkId",sink,"keyword",kw,"listeningItem",li));
        public string StopDialog(string sourceID) => _c.Post("/voice/dialog/stop",null,null,Q("sourceId",sourceID));
        public Task<string> StopDialogAsync(string sid) => _c.PostAsync("/voice/dialog/stop",null,null,Q("sourceId",sid));
        public string GetInterpreters(string?l=null){var h=new Dictionary<string,string>();if(l!=null)h["Accept-Language"]=l;return _c.Get("/voice/interpreters",h);}
        public Task<string> GetInterpretersAsync(string?l=null){var h=new Dictionary<string,string>();if(l!=null)h["Accept-Language"]=l;return _c.GetAsync("/voice/interpreters",h);}
        public string InterpretText(string text,string?l=null){var h=new Dictionary<string,string>{["Content-Type"]="text/plain"};if(l!=null)h["Accept-Language"]=l;return _c.Post("/voice/interpreters",h,text);}
        public Task<string> InterpretTextAsync(string text,string?l=null){var h=new Dictionary<string,string>{["Content-Type"]="text/plain"};if(l!=null)h["Accept-Language"]=l;return _c.PostAsync("/voice/interpreters",h,text);}
        public string GetInterpreter(string id,string?l=null){var h=new Dictionary<string,string>();if(l!=null)h["Accept-Language"]=l;return _c.Get($"/voice/interpreters/{id}",h);}
        public Task<string> GetInterpreterAsync(string id,string?l=null){var h=new Dictionary<string,string>();if(l!=null)h["Accept-Language"]=l;return _c.GetAsync($"/voice/interpreters/{id}",h);}
        public string InterpretTextBatch(string text,string ids,string?l=null){var h=new Dictionary<string,string>{["Content-Type"]="text/plain"};if(l!=null)h["Accept-Language"]=l;return _c.Post($"/voice/interpreters/{ids}",h,text);}
        public Task<string> InterpretTextBatchAsync(string text,string ids,string?l=null){var h=new Dictionary<string,string>{["Content-Type"]="text/plain"};if(l!=null)h["Accept-Language"]=l;return _c.PostAsync($"/voice/interpreters/{ids}",h,text);}
        public string ListenAndAnswer(string sid,string stt,string tts,string v,string?hli=null,string?sink=null,string?li=null)
            => _c.Post("/voice/listenandanswer",null,null,Q("sourceId",sid,"sttId",stt,"ttsId",tts,"voiceId",v,"hliIds",hli,"sinkId",sink,"listeningItem",li));
        public Task<string> ListenAndAnswerAsync(string sid,string stt,string tts,string v,string?hli=null,string?sink=null,string?li=null)
            => _c.PostAsync("/voice/listenandanswer",null,null,Q("sourceId",sid,"sttId",stt,"ttsId",tts,"voiceId",v,"hliIds",hli,"sinkId",sink,"listeningItem",li));
        public string SayText(string text,string voiceID,string sinkID,string volume="100")
            => _c.Post("/voice/say",null,null,Q("text",text,"voiceId",voiceID,"sinkId",sinkID,"volume",volume));
        public Task<string> SayTextAsync(string text,string voiceID,string sinkID,string volume="100")
            => _c.PostAsync("/voice/say",null,null,Q("text",text,"voiceId",voiceID,"sinkId",sinkID,"volume",volume));
        public string GetVoices() => _c.Get("/voice/voices");
        public Task<string> GetVoicesAsync() => _c.GetAsync("/voice/voices");
    }
}
