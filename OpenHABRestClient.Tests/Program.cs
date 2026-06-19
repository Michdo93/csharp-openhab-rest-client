using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using OpenHABRestClient;

// ── Konfiguration ─────────────────────────────────────────────────────────────
const string URL      = "http://127.0.0.1:8080";
const string USERNAME = "openhab";
const string PASSWORD = "habopen";
const string? TOKEN   = null;   // Alternative: Token statt Basic Auth

const string TEST_ITEM        = "testSwitch";
const string TEST_NUMBER_ITEM = "testNumber";
const string TEST_GROUP       = "Static";
const string TEST_THING_UID   = "astro:sun:b54938fe5c";
const string TEST_LOGGER      = "org.openhab.test.csharp";
const string TEST_RULE_UID    = "test_color-4";

// ── ANSI-Farben ───────────────────────────────────────────────────────────────
const string GREEN  = "\u001B[32m";
const string RED    = "\u001B[31m";
const string YELLOW = "\u001B[33m";
const string BLUE   = "\u001B[34m";
const string BOLD   = "\u001B[1m";
const string DIM    = "\u001B[2m";
const string RESET  = "\u001B[0m";

int passed = 0, failed = 0, total = 0;

void Header(int num, string name) =>
    Console.WriteLine($"\n{DIM}────{RESET} {BOLD}Test #{num}: {name}(){RESET} {DIM}{"─".PadRight(Math.Max(2, 44 - name.Length), '─')}{RESET}");

void Ok(string label, string? value = null)
{
    string preview = "";
    if (value != null)
    {
        string trimmed = value.Trim();
        string disp = trimmed.Length > 100 ? trimmed[..100] + "…" : trimmed;
        preview = $" → {disp}";
    }
    Console.WriteLine($"  {GREEN}✓{RESET} {label}{DIM}{preview}{RESET}");
    passed++;
}

void Fail(string label, Exception e)
{
    Console.WriteLine($"  {RED}✗{RESET} {label}: {RED}{e.Message}{RESET}");
    failed++;
}

void Info(string msg) => Console.WriteLine($"  {BLUE}ℹ{RESET} {DIM}{msg}{RESET}");

void Run(int num, string name, Action fn)
{
    total++;
    Header(num, name);
    try { fn(); }
    catch (Exception e) { Fail(name, e); }
}

async Task RunAsync(int num, string name, Func<Task> fn)
{
    total++;
    Header(num, name);
    try { await fn(); }
    catch (Exception e) { Fail(name, e); }
}

// ── Banner ────────────────────────────────────────────────────────────────────
Console.WriteLine();
Console.WriteLine($"{BOLD}╔═══════════════════════════════════════════════════════╗");
Console.WriteLine(     "║   openhab-rest-client — C# Testanwendung             ║");
Console.WriteLine(     "╚═══════════════════════════════════════════════════════╝" + RESET);
Console.WriteLine($"  URL: {YELLOW}{URL}{RESET}   Auth: {(TOKEN != null ? "Token" : "Basic")}\n");

// ── Client ────────────────────────────────────────────────────────────────────
using var client = TOKEN != null
    ? new OpenHABClient(URL, token: TOKEN)
    : new OpenHABClient(URL, USERNAME, PASSWORD);

if (!client.IsLoggedIn)
{
    Console.WriteLine($"{RED}{BOLD}Verbindung fehlgeschlagen. URL / Zugangsdaten prüfen.{RESET}");
    return;
}
Console.WriteLine($"  {GREEN}✓{RESET} Verbunden  IsCloud={client.IsCloud}  IsLoggedIn={client.IsLoggedIn}\n");

// ════════════════════════════════════════════════════════════════════════════
// UUID / Systeminfo
// ════════════════════════════════════════════════════════════════════════════

Run(1, "GetUUID", () => Ok("UUID", new UUID(client).GetUUID()));
Run(2, "GetSystemInfo", () => Ok("systemInfo", new Systeminfo(client).GetSystemInfo()));
Run(3, "GetUoMInfo",    () => Ok("UoMInfo",    new Systeminfo(client).GetUoMInfo()));

// ════════════════════════════════════════════════════════════════════════════
// Items
// ════════════════════════════════════════════════════════════════════════════

var itemsAPI = new Items(client);

Run(4,  "GetItems",           () => { var r=itemsAPI.GetItems(); Ok("GetItems", r); if(r.TrimStart().StartsWith("["))Info("Array-Antwort empfangen"); });
Run(5,  "GetItems (Switch)",  () => Ok("Switch-Items", itemsAPI.GetItems(type:"Switch")));
Run(6,  "GetItem",            () => Ok($"GetItem {TEST_ITEM}", itemsAPI.GetItem(TEST_ITEM)));
Run(7,  "GetItemState",       () => Ok($"State von {TEST_ITEM}", itemsAPI.GetItemState(TEST_ITEM)));
Run(8,  "SendCommand ON",     () => Ok("SendCommand ON",  itemsAPI.SendCommand(TEST_ITEM, "ON")));
Run(9,  "SendCommand OFF",    () => Ok("SendCommand OFF", itemsAPI.SendCommand(TEST_ITEM, "OFF")));
Run(10, "UpdateItemState",    () => Ok("UpdateItemState → 42", itemsAPI.UpdateItemState(TEST_NUMBER_ITEM, "42")));
Run(11, "PostUpdate",         () => Ok("PostUpdate → 100",     itemsAPI.PostUpdate(TEST_NUMBER_ITEM, "100")));
Run(12, "AddOrUpdateItem",    () => {
    var json = """{"type":"Switch","name":"csTestSwitch","label":"C# Test Switch","groupNames":[],"tags":[]}""";
    Ok("AddOrUpdateItem", itemsAPI.AddOrUpdateItem("csTestSwitch", json));
});
Run(13, "AddOrUpdateItems",   () => {
    var json = """[{"type":"Number","name":"csTestNumber","label":"C# Test Number"}]""";
    Ok("AddOrUpdateItems", itemsAPI.AddOrUpdateItems(json));
});
Run(14, "AddTag",             () => Ok("AddTag",    itemsAPI.AddTag(TEST_ITEM, "Lighting")));
Run(15, "RemoveTag",          () => Ok("RemoveTag", itemsAPI.RemoveTag(TEST_ITEM, "Lighting")));
Run(16, "AddMetadata",        () => Ok("AddMetadata", itemsAPI.AddMetadata(TEST_ITEM, "csTestNS", """{"value":"csValue","config":{}}""")));
Run(17, "GetMetadataNamespaces", () => Ok("GetMetadataNamespaces", itemsAPI.GetMetadataNamespaces(TEST_ITEM)));
Run(18, "RemoveMetadata",     () => Ok("RemoveMetadata", itemsAPI.RemoveMetadata(TEST_ITEM, "csTestNS")));
Run(19, "AddGroupMember",     () => Ok("AddGroupMember",    itemsAPI.AddGroupMember(TEST_GROUP, "csTestNumber")));
Run(20, "RemoveGroupMember",  () => Ok("RemoveGroupMember", itemsAPI.RemoveGroupMember(TEST_GROUP, "csTestNumber")));
Run(21, "PurgeOrphanedMetadata", () => Ok("PurgeOrphanedMetadata", itemsAPI.PurgeOrphanedMetadata()));
Run(22, "DeleteItem",         () => {
    try { itemsAPI.DeleteItem("csTestSwitch"); } catch {}
    try { itemsAPI.DeleteItem("csTestNumber"); } catch {}
    Ok("DeleteItem (beide Test-Items)");
});

// ════════════════════════════════════════════════════════════════════════════
// Items — Async Demo
// ════════════════════════════════════════════════════════════════════════════

await RunAsync(23, "GetItemsAsync (await)", async () => {
    var r = await itemsAPI.GetItemsAsync(type: "Switch");
    Ok("GetItemsAsync Switch", r);
});

await RunAsync(24, "GetItemStateAsync + SendCommandAsync", async () => {
    var state = await itemsAPI.GetItemStateAsync(TEST_ITEM);
    Ok("GetItemStateAsync", state);
    await itemsAPI.SendCommandAsync(TEST_ITEM, "ON");
    Ok("SendCommandAsync ON");
    await itemsAPI.SendCommandAsync(TEST_ITEM, "OFF");
    Ok("SendCommandAsync OFF");
});

// ════════════════════════════════════════════════════════════════════════════
// Things
// ════════════════════════════════════════════════════════════════════════════

var thingsAPI = new Things(client);
Run(25, "GetThings",      () => { var r=thingsAPI.GetThings(); Ok("GetThings",r); });
Run(26, "GetThing",       () => Ok($"GetThing {TEST_THING_UID}", thingsAPI.GetThing(TEST_THING_UID)));
Run(27, "GetThingStatus", () => Ok("GetThingStatus", thingsAPI.GetThingStatus(TEST_THING_UID)));
Run(28, "EnableThing / DisableThing", () => {
    thingsAPI.EnableThing(TEST_THING_UID);  Ok("EnableThing");
    thingsAPI.DisableThing(TEST_THING_UID); Ok("DisableThing");
    thingsAPI.EnableThing(TEST_THING_UID);  Ok("EnableThing (wiederherstellen)");
});
Run(29, "GetThingFirmwares", () => Ok("GetThingFirmwares", thingsAPI.GetThingFirmwares(TEST_THING_UID)));

// ════════════════════════════════════════════════════════════════════════════
// Rules
// ════════════════════════════════════════════════════════════════════════════

var rulesAPI = new Rules(client);
Run(30, "GetRules",    () => { var r=rulesAPI.GetRules(); Ok("GetRules",r); });
Run(31, "GetRule",     () => Ok($"GetRule {TEST_RULE_UID}", rulesAPI.GetRule(TEST_RULE_UID)));
Run(32, "CRUD Rule",   () => {
    var uid = $"csTestRule_{DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}";
    var json = $$"""{"uid":"{{uid}}","name":"C# Test Rule","description":"Created by C# test","triggers":[],"conditions":[],"actions":[]}""";
    rulesAPI.CreateRule(json);  Ok("CreateRule");
    rulesAPI.Enable(uid);       Ok("Enable");
    rulesAPI.Disable(uid);      Ok("Disable");
    rulesAPI.DeleteRule(uid);   Ok("DeleteRule");
});

// ════════════════════════════════════════════════════════════════════════════
// Actions / Addons / Audio / Logging / Links
// ════════════════════════════════════════════════════════════════════════════

Run(33, "GetActions",         () => Ok("GetActions",     new Actions(client).GetActions(TEST_THING_UID)));
Run(34, "GetAddons",          () => Ok("GetAddons",      new Addons(client).GetAddons()));
Run(35, "GetAddonTypes",      () => Ok("GetAddonTypes",  new Addons(client).GetAddonTypes()));
Run(36, "GetAddonSuggestions",() => Ok("GetAddonSuggestions", new Addons(client).GetAddonSuggestions()));
Run(37, "GetAddonServices",   () => Ok("GetAddonServices", new Addons(client).GetAddonServices()));
Run(38, "GetDefaultSink",     () => Ok("GetDefaultSink",   new Audio(client).GetDefaultSink()));
Run(39, "GetDefaultSource",   () => Ok("GetDefaultSource", new Audio(client).GetDefaultSource()));
Run(40, "GetSinks",           () => Ok("GetSinks",         new Audio(client).GetSinks()));
Run(41, "GetSources",         () => Ok("GetSources",       new Audio(client).GetSources()));
Run(42, "GetLoggers",         () => Ok("GetLoggers",       new Logging(client).GetLoggers()));
Run(43, "Logger CRUD",        () => {
    var log = new Logging(client);
    log.ModifyOrAddLogger(TEST_LOGGER, "DEBUG"); Ok("ModifyOrAddLogger");
    Ok("GetLogger", log.GetLogger(TEST_LOGGER));
    log.RemoveLogger(TEST_LOGGER);               Ok("RemoveLogger");
});
Run(44, "GetLinks",       () => Ok("GetLinks",       new Links(client).GetLinks()));
Run(45, "GetOrphanLinks", () => Ok("GetOrphanLinks", new Links(client).GetOrphanLinks()));

// ════════════════════════════════════════════════════════════════════════════
// ChannelTypes / ThingTypes / ConfigDescriptions
// ════════════════════════════════════════════════════════════════════════════

Run(46, "GetChannelTypes",       () => Ok("GetChannelTypes",      new ChannelTypes(client).GetChannelTypes()));
Run(47, "GetThingTypes",         () => Ok("GetThingTypes",        new ThingTypes(client).GetThingTypes()));
Run(48, "GetConfigDescriptions", () => Ok("GetConfigDescriptions",new ConfigDescriptions(client).GetConfigDescriptions()));

// ════════════════════════════════════════════════════════════════════════════
// Persistence / Discovery / Inbox / Sitemaps
// ════════════════════════════════════════════════════════════════════════════

Run(49, "GetServices (Persistence)", () => Ok("Persistence.GetServices",  new Persistence(client).GetServices()));
Run(50, "GetDiscoveryBindings",      () => Ok("GetDiscoveryBindings",      new Discovery(client).GetDiscoveryBindings()));
Run(51, "GetDiscoveredThings",       () => Ok("GetDiscoveredThings",       new Inbox(client).GetDiscoveredThings()));
Run(52, "GetSitemaps",               () => Ok("GetSitemaps",               new Sitemaps(client).GetSitemaps()));

// ════════════════════════════════════════════════════════════════════════════
// Tags / Templates / ModuleTypes / ProfileTypes
// ════════════════════════════════════════════════════════════════════════════

Run(53, "GetTags",        () => Ok("GetTags",        new Tags(client).GetTags()));
Run(54, "GetTemplates",   () => Ok("GetTemplates",   new Templates(client).GetTemplates()));
Run(55, "GetModuleTypes", () => Ok("GetModuleTypes", new ModuleTypes(client).GetModuleTypes()));
Run(56, "GetProfileTypes",() => Ok("GetProfileTypes",new ProfileTypes(client).GetProfileTypes()));

// ════════════════════════════════════════════════════════════════════════════
// Transformations / UI / Services / Iconsets / Auth / Voice
// ════════════════════════════════════════════════════════════════════════════

Run(57, "GetTransformations",      () => Ok("GetTransformations",      new Transformations(client).GetTransformations()));
Run(58, "GetTransformationServices",()=> Ok("GetTransformationServices",new Transformations(client).GetTransformationServices()));
Run(59, "GetUITiles",              () => Ok("GetUITiles",              new UI(client).GetUITiles()));
Run(60, "GetServices",             () => Ok("GetServices",             new Services(client).GetServices()));
Run(61, "GetIconsets",             () => Ok("GetIconsets",             new Iconsets(client).GetIconsets()));
Run(62, "GetAPITokens",            () => Ok("GetAPITokens",            new Auth(client).GetAPITokens()));
Run(63, "GetSessions",             () => Ok("GetSessions",             new Auth(client).GetSessions()));
Run(64, "GetVoices",               () => Ok("GetVoices",               new Voice(client).GetVoices()));

// ════════════════════════════════════════════════════════════════════════════
// SSE Demo (10 Sekunden, dann automatisch stopp)
// ════════════════════════════════════════════════════════════════════════════

Console.WriteLine($"\n{DIM}═══ SSE Demo (10s) ══════════════════════════════════════{RESET}");
Console.WriteLine($"  {BLUE}⚡{RESET} Öffne ItemStateChangedEvent Stream für '{TEST_ITEM}'…");
Console.WriteLine($"  {DIM}(sendet ON/OFF alle 2s zur Triggerung){RESET}\n");

using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(10));
int sseCount = 0;

// Sende Befehle im Hintergrund
var sender = Task.Run(async () => {
    bool toggle = true;
    while (!cts.Token.IsCancellationRequested)
    {
        try { await itemsAPI.SendCommandAsync(TEST_ITEM, toggle ? "ON" : "OFF"); }
        catch { /* ignorieren */ }
        toggle = !toggle;
        await Task.Delay(2000, cts.Token).ContinueWith(_ => { });
    }
});

using var sse = new ItemEvents(client).ItemStateChangedEvent(TEST_ITEM);
try
{
    await foreach (var data in sse.ReadAllAsync(cts.Token))
    {
        sseCount++;
        Console.WriteLine($"  {BLUE}⚡{RESET} [{DateTime.Now:HH:mm:ss}] {DIM}{data[..Math.Min(100, data.Length)]}{RESET}");
    }
}
catch (OperationCanceledException) { /* normal */ }

await sender;
Console.WriteLine($"\n  {GREEN}✓{RESET} SSE beendet — {sseCount} Event(s) empfangen\n");

// ════════════════════════════════════════════════════════════════════════════
// Zusammenfassung
// ════════════════════════════════════════════════════════════════════════════

Console.WriteLine($"{BOLD}{"═".PadRight(55, '═')}{RESET}");
Console.WriteLine($"  Ergebnis: {total} Tests   {GREEN}{BOLD}{passed} bestanden{RESET}   {(failed > 0 ? RED + BOLD : "")}{failed} fehlgeschlagen{RESET}");
Console.WriteLine($"{BOLD}{"═".PadRight(55, '═')}{RESET}\n");

Environment.Exit(failed > 0 ? 1 : 0);
