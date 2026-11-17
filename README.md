# csharp-openhab-rest-client

A C# client for the openHAB REST API and its Server-Sent Events – for console programs,
desktop apps (Avalonia, WPF, WinUI), worker services, ASP.NET Core, Unity and every other .NET
application.

It is part of a family of libraries with **the same classes, methods, parameters and
results** in every language: [Python](https://github.com/Michdo93/python-openhab-rest-client)
(the reference), [JavaScript](https://github.com/Michdo93/js-openhab-rest-client),
[Node.js](https://github.com/Michdo93/nodejs-openhab-rest-client),
[Java](https://github.com/Michdo93/java-openhab-rest-client),
[Android/Kotlin](https://github.com/Michdo93/android-openhab-rest-client),
[C](https://github.com/Michdo93/c-openhab-rest-client),
[C++](https://github.com/Michdo93/cpp-openhab-rest-client) and C#.
Tests for openHAB installations: [csharp-openhab-test-suite](https://github.com/Michdo93/csharp-openhab-test-suite).

```csharp
using OpenHABRestClient;
using System.Text.Json.Nodes;

using var client = new OpenHABClient("http://127.0.0.1:8080",
                                     token: Environment.GetEnvironmentVariable("OPENHAB_TOKEN"));
var items = new Items(client);

JsonNode? r = items.SendCommand("Wohnzimmer_Licht", "ON");
if (r.IsError()) Console.WriteLine(r.ErrorMessage());

foreach (var item in items.GetItems(tags: "Light", fields: "name,state").List())
    Console.WriteLine($"{item.Str("name")} = {item.Str("state")}");

using var stream = new ItemEvents(client).ItemStateChangedEvent("Wohnzimmer_Licht");
await foreach (var e in stream.EventsAsync())
    Console.WriteLine(e.Str("payload.value"));
```

## What is new in 2.0.0

Version 2.0.0 is a rewrite (details: [BUGS-1.0.0.md](BUGS-1.0.0.md)). The REST classes are
generated from python-openhab-rest-client (`tools/py2cs.py`), statement by statement – same
endpoints, headers, query parameters, error messages and results. A differential test with 79
calls against openHAB 5 gives identical results for Python and C#, synchronous and async.

- all 33 classes and 178 methods, each as `Method(...)` and `MethodAsync(..., cancellationToken)`
- results as `JsonNode?` (System.Text.Json); errors as `{"error": "..."}`, empty successes as
  `{"message": "OK"}` – nothing is thrown
- Python parameter names, order and defaults; JSON parameters take objects, records,
  dictionaries or `JsonNode`
- event streams (`EventStream`) with decoded payload, time limit, `foreach`, `await foreach`,
  `Interrupt()` and `CancellationToken`; HTTP errors of streams are reported
- `#` in UIDs is encoded, TLS is verified, separate timeouts for requests and streams,
  thread-safe client
- targets `netstandard2.1` (Unity), `net8.0` and `net10.0`

## Installation

```bash
dotnet add package CSharpOpenHABRestClient --version 2.0.0
```

or in the project file `<PackageReference Include="CSharpOpenHABRestClient" Version="2.0.0" />`.
On .NET 8/10 the package has no dependencies; on .NET Standard 2.1 it uses System.Text.Json.

**Unity:** with [NuGetForUnity](https://github.com/GlitchEnzo/NuGetForUnity) install
`CSharpOpenHABRestClient`, or copy `OpenHABRestClient.dll` (netstandard2.1) and the
System.Text.Json DLLs to `Assets/Plugins`. Call the `…Async` methods from the main thread
(`async void Start()`), never the synchronous ones in `Update()`.

## Concepts

### Client

```csharp
using var c = new OpenHABClient("http://127.0.0.1:8080", token: token);
using var cloud = new OpenHABClient("https://myopenhab.org", "me@example.com", password);
using var slow = new OpenHABClient(url, token: token, timeout: 30);     // seconds, default 10
using var lab = new OpenHABClient("https://openhab.local:8443", token: token, verify: false);

c.IsLoggedIn;      // was openHAB reachable? (checked in the constructor, never throws)
c.LastError;       // why not
await c.LoginAsync();
```

A client may be used from several threads at the same time; create one per application (for
ASP.NET Core and worker services as singleton) and pass it to the REST classes:
`var items = new Items(c);`. An own `HttpMessageHandler` (proxy, tests) can be passed with
`handler:`.

### Methods and arguments

The classes have the names of the Python library, the methods start with a capital letter
(`getItems` → `GetItems`/`GetItemsAsync`). Required parameters come first, the optional ones
keep the Python order and defaults (`None` → `null`) – use named arguments:

```csharp
items.GetItem("Wohnzimmer_Licht");
items.GetItem("Wohnzimmer_Licht", metadata: "semantics", recursive: false);
await items.GetItemsAsync(type: "Switch", cancellationToken: ct);

items.AddOrUpdateItem("Test_Licht", new { type = "Switch", name = "Test_Licht", tags = new[] { "Light" } });
new Rules(c).CreateRule(JsonNode.Parse(File.ReadAllText("regel.json"))!);
```

### Results

| openHAB answers | Result |
|---|---|
| JSON | the JSON (`JsonObject`, `JsonArray`, `JsonValue`) |
| text (e.g. `GET /items/{name}/state`) | a `JsonValue` with the text: `r.Str()` |
| empty body, success | `{"message": "OK"}` and similar texts, as in Python |
| error | `{"error": "Item not found."}` or `{"error": "HTTP error 404: ..."}` |
| no connection, timeout | `{"error": "Request error: ..."}` |

Extension methods for `JsonNode?`:

```csharp
r.IsError();  r.ErrorMessage();
e.Str("payload.value");            // "" if missing
r.Num("state");                    // 21.5 from "21.5 °C", NaN if missing
r.Bool("editable");  r.List("members");  r.At("members.0.name");
```

### Event streams (Server-Sent Events)

Methods of `Events`, `ItemEvents`, `ThingEvents`, `InboxEvents`, `LinkEvents`, `ChannelEvents`
and the stream methods of `Sitemaps` return an `EventStream`:

```csharp
using var s = new ItemEvents(c).ItemStateChangedEvent("Wohnzimmer_Licht");
if (s.IsError) Console.WriteLine(s.Error);          // e.g. 401, no connection

JsonNode? e = s.NextEvent(TimeSpan.FromSeconds(10)); // null: nothing within 10 s
foreach (var ev in s) { ... }                       // until the stream ends or Interrupt()
await foreach (var ev in s.EventsAsync(cancellationToken: ct)) { ... }

s.Interrupt();                                      // from another thread, a timer, Ctrl+C
```

Events have the payload already decoded (`e.Str("payload.value")`); ALIVE messages are skipped
(`includeAlive: true` keeps them). `EventStream.ParseData(line)` decodes a single `data:` line.

### Low-level requests

```csharp
c.Get("/items/Wohnzimmer_Licht/state");
await c.PostAsync("/items/Wohnzimmer_Licht", data: "ON");
c.ExecuteSSE("/rest/events", @params: new { topics = "openhab/items/*/statechanged" });
```

## Development

```bash
dotnet build -c Release
dotnet test --project tests/OpenHABRestClient.Tests        # unit tests without openHAB
OPENHAB_URL=http://127.0.0.1:8080 OPENHAB_TOKEN=oh.xxx \
  dotnet test --project tests/OpenHABRestClient.Tests      # plus integration tests
dotnet pack src/OpenHABRestClient -c Release -o dist

# regenerate the REST classes from python-openhab-rest-client
python3 tools/py2cs.py ../python-openhab-rest-client/openhab .
```

The tests use xUnit v3 on Microsoft.Testing.Platform (`global.json`). The integration tests
expect the exercise configuration of the book series (`tests/openhab-conf`); GitHub Actions
starts a fresh openHAB 5 for them.

## Methods

### Actions

| Method | Required | Optional | Result |
|---|---|---|---|
| `GetActions` / `GetActionsAsync` | thingUID | language | `JsonNode?` |
| `ExecuteAction` / `ExecuteActionAsync` | thingUID, actionUID, actionInputs | language | `JsonNode?` |

### Addons

| Method | Required | Optional | Result |
|---|---|---|---|
| `GetAddons` / `GetAddonsAsync` |  | serviceID, language | `JsonNode?` |
| `GetAddon` / `GetAddonAsync` | addonID | serviceID, language | `JsonNode?` |
| `GetAddonConfig` / `GetAddonConfigAsync` | addonID | serviceID | `JsonNode?` |
| `UpdateAddonConfig` / `UpdateAddonConfigAsync` | addonID, configData | serviceID | `JsonNode?` |
| `InstallAddon` / `InstallAddonAsync` | addonID | serviceID | `JsonNode?` |
| `UninstallAddon` / `UninstallAddonAsync` | addonID | serviceID | `JsonNode?` |
| `GetAddonServices` / `GetAddonServicesAsync` |  | language | `JsonNode?` |
| `GetAddonSuggestions` / `GetAddonSuggestionsAsync` |  | language | `JsonNode?` |
| `GetAddonTypes` / `GetAddonTypesAsync` |  | serviceID, language | `JsonNode?` |
| `InstallAddonFromUrl` / `InstallAddonFromUrlAsync` | url |  | `JsonNode?` |

### Audio

| Method | Required | Optional | Result |
|---|---|---|---|
| `GetDefaultSink` / `GetDefaultSinkAsync` |  | language | `JsonNode?` |
| `GetDefaultSource` / `GetDefaultSourceAsync` |  | language | `JsonNode?` |
| `GetSinks` / `GetSinksAsync` |  | language | `JsonNode?` |
| `GetSources` / `GetSourcesAsync` |  | language | `JsonNode?` |

### Auth

| Method | Required | Optional | Result |
|---|---|---|---|
| `GetAPITokens` / `GetAPITokensAsync` |  |  | `JsonNode?` |
| `RevokeAPIToken` / `RevokeAPITokenAsync` | tokenName |  | `JsonNode?` |
| `Logout` / `LogoutAsync` | refreshToken, sessionID |  | `JsonNode?` |
| `GetSessions` / `GetSessionsAsync` |  |  | `JsonNode?` |
| `GetToken` / `GetTokenAsync` |  | useCookie, grantType, code, redirectURI, clientID, refreshToken, codeVerifier | `JsonNode?` |

### ChannelTypes

| Method | Required | Optional | Result |
|---|---|---|---|
| `GetChannelTypes` / `GetChannelTypesAsync` |  | prefixes, language | `JsonNode?` |
| `GetChannelType` / `GetChannelTypeAsync` | channelTypeUID | language | `JsonNode?` |
| `GetLinkableItemTypes` / `GetLinkableItemTypesAsync` | channelTypeUID |  | `JsonNode?` |

### ConfigDescriptions

| Method | Required | Optional | Result |
|---|---|---|---|
| `GetConfigDescriptions` / `GetConfigDescriptionsAsync` |  | scheme, language | `JsonNode?` |
| `GetConfigDescription` / `GetConfigDescriptionAsync` | uri | language | `JsonNode?` |

### Discovery

| Method | Required | Optional | Result |
|---|---|---|---|
| `GetDiscoveryBindings` / `GetDiscoveryBindingsAsync` |  |  | `JsonNode?` |
| `GetBindingInfo` / `GetBindingInfoAsync` | bindingID | language | `JsonNode?` |
| `StartBindingScan` / `StartBindingScanAsync` | bindingID | input | `JsonNode?` |

### Events

| Method | Required | Optional | Result |
|---|---|---|---|
| `GetEvents` / `GetEventsAsync` |  | topics | `EventStream` |
| `InitiateStateTracker` / `InitiateStateTrackerAsync` |  |  | `EventStream` |
| `UpdateSSEConnectionItems` / `UpdateSSEConnectionItemsAsync` | connectionID, items |  | `JsonNode?` |

### ItemEvents

| Method | Required | Optional | Result |
|---|---|---|---|
| `ItemEvent` / `ItemEventAsync` |  |  | `EventStream` |
| `ItemAddedEvent` / `ItemAddedEventAsync` |  | itemName | `EventStream` |
| `ItemRemovedEvent` / `ItemRemovedEventAsync` |  | itemName | `EventStream` |
| `ItemUpdatedEvent` / `ItemUpdatedEventAsync` |  | itemName | `EventStream` |
| `ItemCommandEvent` / `ItemCommandEventAsync` |  | itemName | `EventStream` |
| `ItemStateEvent` / `ItemStateEventAsync` |  | itemName | `EventStream` |
| `ItemStatePredictedEvent` / `ItemStatePredictedEventAsync` |  | itemName | `EventStream` |
| `ItemStateChangedEvent` / `ItemStateChangedEventAsync` |  | itemName | `EventStream` |
| `GroupItemStateChangedEvent` / `GroupItemStateChangedEventAsync` |  | itemName, memberName | `EventStream` |

### ThingEvents

| Method | Required | Optional | Result |
|---|---|---|---|
| `ThingAddedEvent` / `ThingAddedEventAsync` |  | thingUID | `EventStream` |
| `ThingRemovedEvent` / `ThingRemovedEventAsync` |  | thingUID | `EventStream` |
| `ThingUpdatedEvent` / `ThingUpdatedEventAsync` |  | thingUID | `EventStream` |
| `ThingStatusInfoEvent` / `ThingStatusInfoEventAsync` |  | thingUID | `EventStream` |
| `ThingStatusInfoChangedEvent` / `ThingStatusInfoChangedEventAsync` |  | thingUID | `EventStream` |

### InboxEvents

| Method | Required | Optional | Result |
|---|---|---|---|
| `InboxAddedEvent` / `InboxAddedEventAsync` |  | thingUID | `EventStream` |
| `InboxRemovedEvent` / `InboxRemovedEventAsync` |  | thingUID | `EventStream` |
| `InboxUpdatedEvent` / `InboxUpdatedEventAsync` |  | thingUID | `EventStream` |

### LinkEvents

| Method | Required | Optional | Result |
|---|---|---|---|
| `ItemChannelLinkAddedEvent` / `ItemChannelLinkAddedEventAsync` |  | itemName, channelUID | `EventStream` |
| `ItemChannelLinkRemovedEvent` / `ItemChannelLinkRemovedEventAsync` |  | itemName, channelUID | `EventStream` |

### ChannelEvents

| Method | Required | Optional | Result |
|---|---|---|---|
| `ChannelDescriptionChangedEvent` / `ChannelDescriptionChangedEventAsync` |  | channelUID | `EventStream` |
| `ChannelTriggeredEvent` / `ChannelTriggeredEventAsync` |  | channelUID | `EventStream` |

### Iconsets

| Method | Required | Optional | Result |
|---|---|---|---|
| `GetIconsets` / `GetIconsetsAsync` |  | language | `JsonNode?` |

### Inbox

| Method | Required | Optional | Result |
|---|---|---|---|
| `GetDiscoveredThings` / `GetDiscoveredThingsAsync` |  | includeIgnored | `JsonNode?` |
| `RemoveDiscoveryResult` / `RemoveDiscoveryResultAsync` | thingUID |  | `JsonNode?` |
| `ApproveDiscoveryResult` / `ApproveDiscoveryResultAsync` | thingUID, thingLabel | newThingID, language | `JsonNode?` |
| `IgnoreDiscoveryResult` / `IgnoreDiscoveryResultAsync` | thingUID |  | `JsonNode?` |
| `UnignoreDiscoveryResult` / `UnignoreDiscoveryResultAsync` | thingUID |  | `JsonNode?` |

### Items

| Method | Required | Optional | Result |
|---|---|---|---|
| `GetItems` / `GetItemsAsync` |  | type, tags, metadata, recursive, fields, staticDataOnly, language, parents | `JsonNode?` |
| `AddOrUpdateItems` / `AddOrUpdateItemsAsync` | items |  | `JsonNode?` |
| `GetItem` / `GetItemAsync` | itemName | metadata, recursive, language, parents | `JsonNode?` |
| `AddOrUpdateItem` / `AddOrUpdateItemAsync` | itemName, itemData | language | `JsonNode?` |
| `SendCommand` / `SendCommandAsync` | itemName, command | source | `JsonNode?` |
| `PostUpdate` / `PostUpdateAsync` | itemName, state | source | `JsonNode?` |
| `DeleteItem` / `DeleteItemAsync` | itemName |  | `JsonNode?` |
| `AddGroupMember` / `AddGroupMemberAsync` | itemName, memberItemName |  | `JsonNode?` |
| `RemoveGroupMember` / `RemoveGroupMemberAsync` | itemName, memberItemName |  | `JsonNode?` |
| `AddMetadata` / `AddMetadataAsync` | itemName, namespace, metadata |  | `JsonNode?` |
| `RemoveMetadata` / `RemoveMetadataAsync` | itemName, namespace |  | `JsonNode?` |
| `GetMetadataNamespaces` / `GetMetadataNamespacesAsync` | itemName | language | `JsonNode?` |
| `GetSemanticItem` / `GetSemanticItemAsync` | itemName, semanticClass | language | `JsonNode?` |
| `GetItemState` / `GetItemStateAsync` | itemName |  | `JsonNode?` |
| `UpdateItemState` / `UpdateItemStateAsync` | itemName, state | language, source | `JsonNode?` |
| `AddTag` / `AddTagAsync` | itemName, tag |  | `JsonNode?` |
| `RemoveTag` / `RemoveTagAsync` | itemName, tag |  | `JsonNode?` |
| `PurgeOrphanedMetadata` / `PurgeOrphanedMetadataAsync` |  |  | `JsonNode?` |

### Links

| Method | Required | Optional | Result |
|---|---|---|---|
| `GetLinks` / `GetLinksAsync` |  | channelUID, itemName | `JsonNode?` |
| `GetLink` / `GetLinkAsync` | itemName, channelUID |  | `JsonNode?` |
| `LinkItemToChannel` / `LinkItemToChannelAsync` | itemName, channelUID, configuration |  | `JsonNode?` |
| `UnlinkItemFromChannel` / `UnlinkItemFromChannelAsync` | itemName, channelUID |  | `JsonNode?` |
| `DeleteAllLinks` / `DeleteAllLinksAsync` | object |  | `JsonNode?` |
| `GetOrphanLinks` / `GetOrphanLinksAsync` |  |  | `JsonNode?` |
| `PurgeUnusedLinks` / `PurgeUnusedLinksAsync` |  |  | `JsonNode?` |

### Logging

| Method | Required | Optional | Result |
|---|---|---|---|
| `GetLoggers` / `GetLoggersAsync` |  |  | `JsonNode?` |
| `GetLogger` / `GetLoggerAsync` | loggerName |  | `JsonNode?` |
| `ModifyOrAddLogger` / `ModifyOrAddLoggerAsync` | loggerName, level |  | `JsonNode?` |
| `RemoveLogger` / `RemoveLoggerAsync` | loggerName |  | `JsonNode?` |

### ModuleTypes

| Method | Required | Optional | Result |
|---|---|---|---|
| `GetModuleTypes` / `GetModuleTypesAsync` |  | tags, typeFilter, language | `JsonNode?` |
| `GetModuleType` / `GetModuleTypeAsync` | moduleTypeUID | language | `JsonNode?` |

### Persistence

| Method | Required | Optional | Result |
|---|---|---|---|
| `GetServices` / `GetServicesAsync` |  | language | `JsonNode?` |
| `GetServiceConfiguration` / `GetServiceConfigurationAsync` | serviceID |  | `JsonNode?` |
| `SetServiceConfiguration` / `SetServiceConfigurationAsync` | serviceID, config |  | `JsonNode?` |
| `DeleteServiceConfiguration` / `DeleteServiceConfigurationAsync` | serviceID |  | `JsonNode?` |
| `GetItemsFromService` / `GetItemsFromServiceAsync` |  | serviceID, itemName | `JsonNode?` |
| `GetItemPersistenceData` / `GetItemPersistenceDataAsync` | itemName | serviceID, startTime, endTime, page, pageLength, boundary, itemState, displayState, language | `JsonNode?` |
| `StoreItemData` / `StoreItemDataAsync` | itemName, time, state | serviceID | `JsonNode?` |
| `DeleteItemData` / `DeleteItemDataAsync` | itemName, startTime, endTime, serviceID |  | `JsonNode?` |

### ProfileTypes

| Method | Required | Optional | Result |
|---|---|---|---|
| `GetProfileTypes` / `GetProfileTypesAsync` |  | channelTypeUID, itemType, language | `JsonNode?` |

### Rules

| Method | Required | Optional | Result |
|---|---|---|---|
| `GetRules` / `GetRulesAsync` |  | prefix, tags, summary, staticDataOnly | `JsonNode?` |
| `CreateRule` / `CreateRuleAsync` | ruleData |  | `JsonNode?` |
| `GetRule` / `GetRuleAsync` | ruleUID |  | `JsonNode?` |
| `UpdateRule` / `UpdateRuleAsync` | ruleUID, ruleData |  | `JsonNode?` |
| `DeleteRule` / `DeleteRuleAsync` | ruleUID |  | `JsonNode?` |
| `GetModule` / `GetModuleAsync` | ruleUID, moduleCategory, moduleID |  | `JsonNode?` |
| `GetModuleConfig` / `GetModuleConfigAsync` | ruleUID, moduleCategory, moduleID |  | `JsonNode?` |
| `GetModuleConfigParam` / `GetModuleConfigParamAsync` | ruleUID, moduleCategory, moduleID, param |  | `JsonNode?` |
| `SetModuleConfigParam` / `SetModuleConfigParamAsync` | ruleUID, moduleCategory, moduleID, param, value |  | `JsonNode?` |
| `GetActions` / `GetActionsAsync` | ruleUID |  | `JsonNode?` |
| `GetConditions` / `GetConditionsAsync` | ruleUID |  | `JsonNode?` |
| `GetConfiguration` / `GetConfigurationAsync` | ruleUID |  | `JsonNode?` |
| `UpdateConfiguration` / `UpdateConfigurationAsync` | ruleUID, configData |  | `JsonNode?` |
| `SetRuleState` / `SetRuleStateAsync` | ruleUID, enable |  | `JsonNode?` |
| `Enable` / `EnableAsync` | ruleUID |  | `JsonNode?` |
| `Disable` / `DisableAsync` | ruleUID |  | `JsonNode?` |
| `RunNow` / `RunNowAsync` | ruleUID | contextData | `JsonNode?` |
| `GetTriggers` / `GetTriggersAsync` | ruleUID |  | `JsonNode?` |
| `SimulateSchedule` / `SimulateScheduleAsync` | fromTime, untilTime |  | `JsonNode?` |

### Services

| Method | Required | Optional | Result |
|---|---|---|---|
| `GetServices` / `GetServicesAsync` |  | language | `JsonNode?` |
| `GetService` / `GetServiceAsync` | serviceID | language | `JsonNode?` |
| `GetServiceConfig` / `GetServiceConfigAsync` | serviceID |  | `JsonNode?` |
| `UpdateServiceConfig` / `UpdateServiceConfigAsync` | serviceID, configData | language | `JsonNode?` |
| `DeleteServiceConfig` / `DeleteServiceConfigAsync` | serviceID |  | `JsonNode?` |
| `GetServiceContexts` / `GetServiceContextsAsync` | serviceID | language | `JsonNode?` |

### Sitemaps

| Method | Required | Optional | Result |
|---|---|---|---|
| `GetSitemaps` / `GetSitemapsAsync` |  |  | `JsonNode?` |
| `GetSitemap` / `GetSitemapAsync` | sitemapName | type, jsonCallback, includeHidden, language | `JsonNode?` |
| `GetSitemapPage` / `GetSitemapPageAsync` | sitemapName, pageID | subscriptionID, includeHidden, language | `JsonNode?` |
| `GetFullSitemap` / `GetFullSitemapAsync` | sitemapName | subscriptionID, includeHidden, language | `JsonNode?` |
| `GetSitemapEvents` / `GetSitemapEventsAsync` | subscriptionID | sitemapName, pageID | `EventStream` |
| `GetFullSitemapEvents` / `GetFullSitemapEventsAsync` | subscriptionID | sitemapName | `EventStream` |
| `SubscribeToSitemapEvents` / `SubscribeToSitemapEventsAsync` |  |  | `JsonNode?` |

### Systeminfo

| Method | Required | Optional | Result |
|---|---|---|---|
| `GetSystemInfo` / `GetSystemInfoAsync` |  |  | `JsonNode?` |
| `GetUoMInfo` / `GetUoMInfoAsync` |  |  | `JsonNode?` |

### Tags

| Method | Required | Optional | Result |
|---|---|---|---|
| `GetTags` / `GetTagsAsync` |  | language | `JsonNode?` |
| `CreateTag` / `CreateTagAsync` | tagData | language | `JsonNode?` |
| `GetTag` / `GetTagAsync` | tagID | language | `JsonNode?` |
| `UpdateTag` / `UpdateTagAsync` | tagID, tagData | language | `JsonNode?` |
| `DeleteTag` / `DeleteTagAsync` | tagID | language | `JsonNode?` |

### Templates

| Method | Required | Optional | Result |
|---|---|---|---|
| `GetTemplates` / `GetTemplatesAsync` |  | language | `JsonNode?` |
| `GetTemplate` / `GetTemplateAsync` | templateUID | language | `JsonNode?` |

### ThingTypes

| Method | Required | Optional | Result |
|---|---|---|---|
| `GetThingTypes` / `GetThingTypesAsync` |  | bindingID, language | `JsonNode?` |
| `GetThingType` / `GetThingTypeAsync` | thingTypeUID | language | `JsonNode?` |

### Things

| Method | Required | Optional | Result |
|---|---|---|---|
| `GetThings` / `GetThingsAsync` |  | summary, staticDataOnly, language | `JsonNode?` |
| `CreateThing` / `CreateThingAsync` | thingData | language | `JsonNode?` |
| `GetThing` / `GetThingAsync` | thingUID | language | `JsonNode?` |
| `UpdateThing` / `UpdateThingAsync` | thingUID, thingData | language | `JsonNode?` |
| `DeleteThing` / `DeleteThingAsync` | thingUID | force, language | `JsonNode?` |
| `UpdateThingConfiguration` / `UpdateThingConfigurationAsync` | thingUID, configurationData | language | `JsonNode?` |
| `GetThingConfigStatus` / `GetThingConfigStatusAsync` | thingUID | language | `JsonNode?` |
| `SetThingStatus` / `SetThingStatusAsync` | thingUID, enabled | language | `JsonNode?` |
| `EnableThing` / `EnableThingAsync` | thingUID |  | `JsonNode?` |
| `DisableThing` / `DisableThingAsync` | thingUID |  | `JsonNode?` |
| `UpdateThingFirmware` / `UpdateThingFirmwareAsync` | thingUID, firmwareVersion | language | `JsonNode?` |
| `GetThingFirmwareStatus` / `GetThingFirmwareStatusAsync` | thingUID | language | `JsonNode?` |
| `GetThingFirmwares` / `GetThingFirmwaresAsync` | thingUID | language | `JsonNode?` |
| `GetThingStatus` / `GetThingStatusAsync` | thingUID | language | `JsonNode?` |

### Transformations

| Method | Required | Optional | Result |
|---|---|---|---|
| `GetTransformations` / `GetTransformationsAsync` |  |  | `JsonNode?` |
| `GetTransformation` / `GetTransformationAsync` | transformationUID |  | `JsonNode?` |
| `UpdateTransformation` / `UpdateTransformationAsync` | transformationUID, transformationData |  | `JsonNode?` |
| `DeleteTransformation` / `DeleteTransformationAsync` | transformationUID |  | `JsonNode?` |
| `GetTransformationServices` / `GetTransformationServicesAsync` |  |  | `JsonNode?` |

### UI

| Method | Required | Optional | Result |
|---|---|---|---|
| `GetUIComponents` / `GetUIComponentsAsync` | namespace | summary | `JsonNode?` |
| `AddUIComponent` / `AddUIComponentAsync` | namespace, componentData |  | `JsonNode?` |
| `GetUIComponent` / `GetUIComponentAsync` | namespace, componentUID |  | `JsonNode?` |
| `UpdateUIComponent` / `UpdateUIComponentAsync` | namespace, componentUID, componentData |  | `JsonNode?` |
| `DeleteUIComponent` / `DeleteUIComponentAsync` | namespace, componentUID |  | `JsonNode?` |
| `GetUITiles` / `GetUITilesAsync` |  |  | `JsonNode?` |

### UUID

| Method | Required | Optional | Result |
|---|---|---|---|
| `GetUUID` / `GetUUIDAsync` |  |  | `JsonNode?` |

### Voice

| Method | Required | Optional | Result |
|---|---|---|---|
| `GetDefaultVoice` / `GetDefaultVoiceAsync` |  | language | `JsonNode?` |
| `StartDialog` / `StartDialogAsync` | sourceID | ksID, sttID, ttsID, voiceID, hliIDs, sinkID, keyword, listeningItem, language | `JsonNode?` |
| `StopDialog` / `StopDialogAsync` | sourceID |  | `JsonNode?` |
| `GetInterpreters` / `GetInterpretersAsync` |  | language | `JsonNode?` |
| `InterpretText` / `InterpretTextAsync` | text | language | `JsonNode?` |
| `GetInterpreter` / `GetInterpreterAsync` | interpreterID | language | `JsonNode?` |
| `InterpretTextBatch` / `InterpretTextBatchAsync` | text, IDs | language | `JsonNode?` |
| `ListenAndAnswer` / `ListenAndAnswerAsync` | sourceID, sttID, ttsID, voiceID, hliIDs, sinkID, listeningItem | language | `JsonNode?` |
| `SayText` / `SayTextAsync` | text, voiceID, sinkID | volume | `JsonNode?` |
| `GetVoices` / `GetVoicesAsync` |  | language | `JsonNode?` |


## License

MIT – Michael Christian Dörflinger
