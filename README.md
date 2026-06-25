# csharp-openhab-rest-client

A C# client for the openHAB REST API. This library enables easy interaction with the openHAB REST API to control smart home devices, retrieve status information, and process events — from any .NET application.

It mirrors the [python-openhab-rest-client](https://github.com/Michdo93/python-openhab-rest-client) library: same class names, same method names, same usage pattern.

**Zero external dependencies** — built entirely on `System.Net.Http.HttpClient`, which is part of the .NET standard library. Every API method exists in both a synchronous and an asynchronous (`Async`) variant.

## Features

Supports the following openHAB REST API endpoints:

- Actions
- Addons
- Audio
- Auth
- ChannelTypes
- ConfigDescriptions
- Discovery
- Events (general + ItemEvents, ThingEvents, InboxEvents, LinkEvents, ChannelEvents)
- Iconsets
- Inbox
- Items
- Links
- Logging
- ModuleTypes
- Persistence
- ProfileTypes
- Rules
- Services
- Sitemaps
- Systeminfo
- Tags
- Templates
- ThingTypes
- Things
- Transformations
- UI
- UUID
- Voice

Server-Sent Events (SSE) are supported via `SSEConnection`, which exposes both `ReadAll()` (synchronous `IEnumerable<string>`) and `ReadAllAsync()` (asynchronous `IAsyncEnumerable<string>` for `await foreach`).

## Requirements

- **.NET Standard 2.1** or **.NET 8.0** (or later)
- No external NuGet dependencies
- C# 11 or later (for `await foreach` with SSE)

---

## Adding the Library to Your Project

There are four ways to add `CSharpOpenHABRestClient` to your project.

---

### Option 1: NuGet Package Manager (recommended)

The library is published to NuGet as `CSharpOpenHABRestClient`.

#### .NET CLI

```bash
dotnet add package CSharpOpenHABRestClient
```

#### Visual Studio — NuGet Package Manager UI

1. Right-click your project in Solution Explorer → **Manage NuGet Packages**.
2. Click the **Browse** tab.
3. Search for `CSharpOpenHABRestClient`.
4. Select the package and click **Install**.

#### Visual Studio — Package Manager Console

```powershell
Install-Package CSharpOpenHABRestClient
```

#### `.csproj` — PackageReference (direct edit)

```xml
<ItemGroup>
  <PackageReference Include="CSharpOpenHABRestClient" Version="1.0.0" />
</ItemGroup>
```

#### `packages.config` (legacy .NET Framework projects)

```xml
<packages>
  <package id="CSharpOpenHABRestClient" version="1.0.0" targetFramework="net48" />
</packages>
```

---

### Option 2: NuGet in ASP.NET Core

For **ASP.NET Core** projects (Web APIs, Blazor, MVC) the installation is identical to the .NET CLI approach above. After installation you can register the client as a singleton or scoped service:

```csharp
// Program.cs (Minimal API / .NET 6+)
builder.Services.AddSingleton<OpenHABClient>(sp =>
    new OpenHABClient("http://127.0.0.1:8080", "openhab", "habopen"));

builder.Services.AddScoped<Items>();
builder.Services.AddScoped<Things>();
builder.Services.AddScoped<Rules>();
```

Then inject it in controllers or minimal API handlers:

```csharp
app.MapGet("/items", async (Items itemsAPI) =>
{
    var result = await itemsAPI.GetItemsAsync();
    return Results.Ok(result);
});
```

Or in a controller:

```csharp
[ApiController]
[Route("[controller]")]
public class OpenHABController : ControllerBase
{
    private readonly Items _items;
    public OpenHABController(Items items) => _items = items;

    [HttpGet("items")]
    public async Task<IActionResult> GetItems()
    {
        var result = await _items.GetItemsAsync();
        return Ok(result);
    }
}
```

For **Blazor Server** or **Blazor WebAssembly**, use `AddScoped` or `AddSingleton` depending on the hosting model, and inject via `@inject` or constructor injection.

---

### Option 3: Download the DLL / NuGet package manually

Download the `.nupkg` or pre-built `.dll` from the [GitHub Releases page](https://github.com/Michdo93/csharp-openhab-rest-client/releases).

#### Install `.nupkg` locally

Add a local NuGet source in `nuget.config` at your solution root:

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <add key="local" value="./local-packages" />
    <add key="nuget.org" value="https://api.nuget.org/v3/index.json" />
  </packageSources>
</configuration>
```

Place the `.nupkg` in `./local-packages/`, then:

```bash
dotnet add package CSharpOpenHABRestClient --source ./local-packages
```

#### Add DLL directly (`.csproj`)

Place the DLL in e.g. `libs/` and reference it:

```xml
<ItemGroup>
  <Reference Include="OpenHABRestClient">
    <HintPath>libs\OpenHABRestClient.dll</HintPath>
  </Reference>
</ItemGroup>
```

#### Visual Studio — Add Reference

1. Right-click your project → **Add** → **Project Reference** → **Browse**.
2. Select `OpenHABRestClient.dll`.
3. Click **OK**.

---

### Option 4: Add the source project directly

Clone the repository and reference the `.csproj` in your solution.

```bash
git clone https://github.com/Michdo93/csharp-openhab-rest-client.git
```

Add a project reference in your `.csproj`:

```xml
<ItemGroup>
  <ProjectReference Include="..\csharp-openhab-rest-client\OpenHABRestClient\OpenHABRestClient.csproj" />
</ItemGroup>
```

Or add it via Visual Studio Solution Explorer:
1. Right-click your project → **Add** → **Project Reference**.
2. Browse to `OpenHABRestClient.csproj` and add it.

Or add both projects to one solution:

```bash
dotnet sln MyApp.sln add csharp-openhab-rest-client/OpenHABRestClient/OpenHABRestClient.csproj
dotnet sln MyApp.sln add MyApp/MyApp.csproj
```

---

## Namespace & Using

All classes are in the `OpenHABRestClient` namespace:

```csharp
using OpenHABRestClient;
```

---

## Usage

### Authentication

#### Basic Authentication

```csharp
var client = new OpenHABClient("http://127.0.0.1:8080", "openhab", "habopen");
```

#### Token-based Authentication

```csharp
var client = new OpenHABClient(
    "http://127.0.0.1:8080",
    token: "oh.openhab.U0doM1Lz4kJ6tPlVGjH17jjm4ZcTHIHi7sMwESzrIybKbCGySmBMtysPnObQLuLf7PgqnI7jWQ5LosySY8Q"
);
```

#### myopenhab.org Cloud

```csharp
var client = new OpenHABClient("https://myopenhab.org", "your@email.com", "yourpassword");
```

The constructor automatically calls `Login()` and sets `IsLoggedIn`:

```csharp
if (!client.IsLoggedIn)
{
    Console.Error.WriteLine("Connection failed.");
    return;
}
```

### Synchronous Requests

All API methods have a synchronous variant that blocks until the response arrives:

```csharp
using OpenHABRestClient;

var client  = new OpenHABClient("http://127.0.0.1:8080", "openhab", "habopen");
var items   = new Items(client);

string result = items.GetItems();
Console.WriteLine(result); // raw JSON string

items.SendCommand("MyLightSwitch", "ON");
```

### Asynchronous Requests (async/await)

Every method has an `Async` counterpart returning `Task<string>`:

```csharp
using OpenHABRestClient;

var client  = new OpenHABClient("http://127.0.0.1:8080", "openhab", "habopen");
var items   = new Items(client);

string result = await items.GetItemsAsync();
Console.WriteLine(result);

await items.SendCommandAsync("MyLightSwitch", "ON");
```

### AsyncOpenHABClient

Use `AsyncOpenHABClient` when you want explicit async naming or need `await LoginAsync()`:

```csharp
var client = new AsyncOpenHABClient("http://127.0.0.1:8080", "openhab", "habopen");
await client.LoginAsync();

var items = new Items(client); // all API classes accept both client types
string result = await items.GetItemsAsync();
```

### Server-Sent Events (SSE)

SSE streams return an `SSEConnection` object that supports both synchronous and asynchronous consumption. Always dispose it with `using` or `await using`.

#### Synchronous (`foreach`)

```csharp
var itemEvents = new ItemEvents(client);

using var sse = itemEvents.ItemStateChangedEvent("MyLightSwitch");
foreach (var data in sse.ReadAll())
{
    // data = raw JSON payload after "data: "
    Console.WriteLine(data);
}
```

#### Asynchronous (`await foreach`, C# 8+)

```csharp
var itemEvents = new ItemEvents(client);

await using var sse = itemEvents.ItemStateChangedEvent("MyLightSwitch");
await foreach (var data in sse.ReadAllAsync())
{
    Console.WriteLine(data);
}
```

#### With CancellationToken (stop after timeout)

```csharp
using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));

await using var sse = itemEvents.ItemStateChangedEvent();
await foreach (var data in sse.ReadAllAsync(cts.Token))
{
    Console.WriteLine(data);
}
```

### Parsing Responses

All REST methods return raw JSON `string`. Parse with `System.Text.Json` or any other JSON library:

```csharp
using System.Text.Json;

string json   = items.GetItem("MyLightSwitch");
var    doc    = JsonDocument.Parse(json);
string state  = doc.RootElement.GetProperty("state").GetString() ?? "";
Console.WriteLine(state);
```

### Error Handling

All REST methods throw `OpenHABException` on HTTP errors or connection failures:

```csharp
try
{
    items.SendCommand("NonExistent", "ON");
}
catch (OpenHABException ex)
{
    Console.Error.WriteLine($"HTTP {ex.StatusCode}: {ex.Message}");
}
```

### `IDisposable`

`OpenHABClient` implements `IDisposable`. Use `using` in long-running applications:

```csharp
using var client = new OpenHABClient("http://127.0.0.1:8080", "openhab", "habopen");
var items = new Items(client);
// ...
```

---

## Full List of Methods

Every synchronous method has an identical `Async` counterpart that returns `Task<string>` instead of `string`. They are listed together in this documentation. All methods throw `OpenHABException` on error.

---

### OpenHABClient

The core HTTP client. All API classes take an `OpenHABClient` in their constructor.

#### Namespace

```csharp
using OpenHABRestClient;
```

#### Constructor

```csharp
OpenHABClient(string url, string? username = null, string? password = null, string? token = null)
```

**Parameters:**
- `url` — Base URL of the openHAB server (e.g. `"http://127.0.0.1:8080"`). Trailing slash is stripped automatically.
- `username` — Username for Basic Authentication, or `null`.
- `password` — Password for Basic Authentication, or `null`.
- `token` — Bearer token for Token Authentication, or `null`.

The constructor calls `Login()` automatically.

**Examples:**

```csharp
// Basic Auth
var client = new OpenHABClient("http://127.0.0.1:8080", "openhab", "habopen");

// Token Auth (named parameter)
var client = new OpenHABClient("http://127.0.0.1:8080", token: "oh.openhab.xxxx");

// Cloud
var client = new OpenHABClient("https://myopenhab.org", "user@example.com", "pass");
```

#### Properties

| Property | Type | Description |
|---|---|---|
| `BaseUrl` | `string` | Base URL without trailing slash |
| `Username` | `string?` | Username (Basic Auth) |
| `IsCloud` | `bool` | `true` when connected to `myopenhab.org` |
| `IsLoggedIn` | `bool` | `true` after a successful `Login()` |

#### Methods

##### `Login()`

Verifies connectivity. Called automatically by the constructor. Sets `IsLoggedIn` and `IsCloud`.

```csharp
client.Login();
Console.WriteLine(client.IsLoggedIn); // true
```

##### `Get(string path, Dictionary<string,string>? headers = null, Dictionary<string,string?>? query = null)`

Sends a GET request. Returns raw JSON or plain-text `string`.

##### `Post(string path, Dictionary<string,string>? headers = null, string? body = null, Dictionary<string,string?>? query = null)`

Sends a POST request.

##### `Put(string path, Dictionary<string,string>? headers = null, string? body = null, Dictionary<string,string?>? query = null)`

Sends a PUT request.

##### `Delete(string path, Dictionary<string,string>? headers = null, string? body = null, Dictionary<string,string?>? query = null)`

Sends a DELETE request.

All four methods have async counterparts: `GetAsync`, `PostAsync`, `PutAsync`, `DeleteAsync`.

##### `ExecuteSSE(string url)`

Opens an SSE stream. Returns `SSEConnection`.

##### Static helper methods

```csharp
// Build a header dictionary from key-value pairs
// OpenHABClient.H("Content-Type", "application/json", "Accept", "*/*")
public static Dictionary<string, string> H(params string[] kv)

// Build a query-parameter dictionary, skipping null values
// OpenHABClient.Q("type", "Switch", "tags", null)
public static Dictionary<string, string?> Q(params string?[] kv)
```

##### `Dispose()`

Disposes the internal `HttpClient`. Call via `using` statement.

---

### AsyncOpenHABClient

Subclass of `OpenHABClient` with an explicit async name and `LoginAsync()` method.

```csharp
var client = new AsyncOpenHABClient("http://127.0.0.1:8080", "openhab", "habopen");
await client.LoginAsync();
```

All API classes accept both `OpenHABClient` and `AsyncOpenHABClient`.

---

### OpenHABException

Thrown when a REST request fails.

```csharp
using OpenHABRestClient;
```

#### Properties

| Property | Type | Description |
|---|---|---|
| `StatusCode` | `int` | HTTP status code, or `-1` if not applicable |
| `Message` | `string` | Error description |

```csharp
try
{
    items.GetItem("nonExistent");
}
catch (OpenHABException ex) when (ex.StatusCode == 404)
{
    Console.WriteLine("Item not found.");
}
```

---

### SSEConnection

Wraps an active SSE HTTP stream. Implements `IDisposable` and `IAsyncDisposable`.

#### Methods

##### `ReadAll(CancellationToken ct = default)`

Reads SSE events synchronously. Each `string` is the raw payload after `"data: "`.

**Returns:** `IEnumerable<string>`

```csharp
using var sse = itemEvents.ItemStateChangedEvent("testSwitch");
foreach (var data in sse.ReadAll())
    Console.WriteLine(data);
```

##### `ReadAllAsync(CancellationToken ct = default)`

Reads SSE events asynchronously with `await foreach`.

**Returns:** `IAsyncEnumerable<string>`

```csharp
await using var sse = itemEvents.ItemStateChangedEvent("testSwitch");
await foreach (var data in sse.ReadAllAsync())
    Console.WriteLine(data);
```

##### `Cancel()`

Stops the SSE stream immediately. Also called by `Dispose()` / `DisposeAsync()`.

---

### Actions

Provides methods to retrieve and execute thing actions.

#### Constructor

```csharp
var actions = new Actions(client);
```

#### Methods

| Method | Async | Description |
|---|---|---|
| `GetActions(string thingUID, string? language = null)` | `GetActionsAsync` | Gets all available actions for a thing |
| `ExecuteAction(string thingUID, string actionUID, string inputsJson, string? language = null)` | `ExecuteActionAsync` | Executes an action on a thing |

**Parameters for `ExecuteAction`:**
- `thingUID` — The UID of the thing.
- `actionUID` — The UID of the action.
- `inputsJson` — JSON string with input parameters.
- `language` — Optional `Accept-Language` header.

```csharp
actions.ExecuteAction("myThingUID", "myActionUID", "{\"param1\":\"value1\"}");
```

---

### Addons

Provides methods to manage openHAB add-ons.

#### Constructor

```csharp
var addons = new Addons(client);
```

#### Methods

| Method | Async | Description |
|---|---|---|
| `GetAddons(string? serviceID = null, string? language = null)` | `GetAddonsAsync` | Gets all available add-ons |
| `GetAddon(string id, string? serviceID = null, string? language = null)` | `GetAddonAsync` | Gets a specific add-on |
| `GetAddonConfig(string id, string? serviceID = null)` | `GetAddonConfigAsync` | Gets the add-on configuration |
| `UpdateAddonConfig(string id, string json, string? serviceID = null)` | `UpdateAddonConfigAsync` | Updates the add-on configuration |
| `InstallAddon(string id, string? serviceID = null)` | `InstallAddonAsync` | Installs an add-on |
| `UninstallAddon(string id, string? serviceID = null)` | `UninstallAddonAsync` | Uninstalls an add-on |
| `GetAddonServices(string? language = null)` | `GetAddonServicesAsync` | Gets all add-on services |
| `GetAddonSuggestions(string? language = null)` | `GetAddonSuggestionsAsync` | Gets suggested add-ons |
| `GetAddonTypes(string? serviceID = null, string? language = null)` | `GetAddonTypesAsync` | Gets all add-on types |
| `InstallAddonFromUrl(string url)` | `InstallAddonFromUrlAsync` | Installs an add-on from a URL |

---

### Audio

Provides methods to interact with the openHAB audio system.

#### Constructor

```csharp
var audio = new Audio(client);
```

#### Methods

| Method | Async | Description |
|---|---|---|
| `GetDefaultSink(string? language = null)` | `GetDefaultSinkAsync` | Gets the default audio sink |
| `GetDefaultSource(string? language = null)` | `GetDefaultSourceAsync` | Gets the default audio source |
| `GetSinks(string? language = null)` | `GetSinksAsync` | Gets all available sinks |
| `GetSources(string? language = null)` | `GetSourcesAsync` | Gets all available sources |

---

### Auth

Provides methods for authentication token and session management.

#### Constructor

```csharp
var auth = new Auth(client);
```

#### Methods

| Method | Async | Description |
|---|---|---|
| `GetAPITokens()` | `GetAPITokensAsync` | Gets all API tokens for the current user |
| `RevokeAPIToken(string name)` | `RevokeAPITokenAsync` | Revokes an API token by name |
| `Logout(string refreshToken, string sessionID)` | `LogoutAsync` | Terminates a session |
| `GetSessions()` | `GetSessionsAsync` | Gets all active sessions |
| `GetToken(string? grantType, string? code, string? redirectUri, string? clientId, string? refreshToken, string? codeVerifier)` | `GetTokenAsync` | Obtains OAuth access and refresh tokens |

All parameters of `GetToken` are optional (default `null`).

```csharp
var token = auth.GetToken(grantType: "password", clientId: "my-app");
```

---

### ChannelTypes

Provides methods to retrieve channel type information.

#### Constructor

```csharp
var channelTypes = new ChannelTypes(client);
```

#### Methods

| Method | Async | Description |
|---|---|---|
| `GetChannelTypes(string? prefixes = null, string? language = null)` | `GetChannelTypesAsync` | Gets all channel types |
| `GetChannelType(string uid, string? language = null)` | `GetChannelTypeAsync` | Gets a specific channel type |
| `GetLinkableItemTypes(string uid)` | `GetLinkableItemTypesAsync` | Gets item types linkable to a trigger channel type |

---

### ConfigDescriptions

Provides methods to retrieve configuration descriptions.

#### Constructor

```csharp
var configDescriptions = new ConfigDescriptions(client);
```

#### Methods

| Method | Async | Description |
|---|---|---|
| `GetConfigDescriptions(string? scheme = null, string? language = null)` | `GetConfigDescriptionsAsync` | Gets all configuration descriptions |
| `GetConfigDescription(string uri, string? language = null)` | `GetConfigDescriptionAsync` | Gets a specific configuration description by URI |

---

### Discovery

Provides methods to interact with the openHAB discovery service.

#### Constructor

```csharp
var discovery = new Discovery(client);
```

#### Methods

| Method | Async | Description |
|---|---|---|
| `GetDiscoveryBindings()` | `GetDiscoveryBindingsAsync` | Gets all bindings that support discovery |
| `GetBindingInfo(string id, string? language = null)` | `GetBindingInfoAsync` | Gets information about a binding |
| `StartBindingScan(string id, string? input = null)` | `StartBindingScanAsync` | Starts a discovery scan for a binding |

```csharp
discovery.StartBindingScan("zwave");
```

---

### Events

Provides general openHAB event bus access via SSE.

#### Constructor

```csharp
var events = new Events(client);
```

#### Methods

| Method | Returns | Description |
|---|---|---|
| `GetEvents(string? topics = null)` | `SSEConnection` | All events, optionally filtered by topic |
| `InitiateStateTracker()` | `SSEConnection` | Initiates a new SSE state tracker connection |
| `UpdateSSEConnectionItems(string connectionId, string itemsJson)` | `string` | Updates tracked items for a state tracker |
| `UpdateSSEConnectionItemsAsync(...)` | `Task<string>` | Async variant |

```csharp
await using var sse = events.GetEvents("openhab/items/*/statechanged");
await foreach (var data in sse.ReadAllAsync())
    Console.WriteLine(data);
```

---

### ItemEvents

Provides SSE streams for item-related events. All methods return `SSEConnection`. The optional `itemName` parameter defaults to `"*"` (all items).

#### Constructor

```csharp
var itemEvents = new ItemEvents(client);
```

#### Methods

| Method | Description |
|---|---|
| `ItemEvent()` | All item events |
| `ItemAddedEvent(string itemName = "*")` | Item added events |
| `ItemRemovedEvent(string itemName = "*")` | Item removed events |
| `ItemUpdatedEvent(string itemName = "*")` | Item updated events |
| `ItemCommandEvent(string itemName = "*")` | Item command events |
| `ItemStateEvent(string itemName = "*")` | Item state events |
| `ItemStatePredictedEvent(string itemName = "*")` | Item state predicted events |
| `ItemStateChangedEvent(string itemName = "*")` | Item state changed events |
| `GroupItemStateChangedEvent(string item, string memberName)` | Group item state changed events for a specific member |

```csharp
// Synchronous
using var sse = itemEvents.ItemStateChangedEvent("MyLightSwitch");
foreach (var data in sse.ReadAll())
    Console.WriteLine(data);

// Asynchronous with cancellation after 30s
using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));
await using var sse = itemEvents.ItemStateChangedEvent("MyLightSwitch");
await foreach (var data in sse.ReadAllAsync(cts.Token))
    Console.WriteLine(data);
```

---

### ThingEvents

Provides SSE streams for thing-related events. All methods return `SSEConnection`. The optional `uid` parameter defaults to `"*"`.

#### Constructor

```csharp
var thingEvents = new ThingEvents(client);
```

#### Methods

| Method | Description |
|---|---|
| `ThingAddedEvent(string uid = "*")` | Thing added events |
| `ThingRemovedEvent(string uid = "*")` | Thing removed events |
| `ThingUpdatedEvent(string uid = "*")` | Thing updated events |
| `ThingStatusInfoEvent(string uid = "*")` | Thing status info events |
| `ThingStatusInfoChangedEvent(string uid = "*")` | Thing status info changed events |

---

### InboxEvents

Provides SSE streams for inbox (discovery) events. All methods return `SSEConnection`. The optional `uid` parameter defaults to `"*"`.

#### Constructor

```csharp
var inboxEvents = new InboxEvents(client);
```

#### Methods

| Method | Description |
|---|---|
| `InboxAddedEvent(string uid = "*")` | Inbox added events |
| `InboxRemovedEvent(string uid = "*")` | Inbox removed events |
| `InboxUpdatedEvent(string uid = "*")` | Inbox updated events |

---

### LinkEvents

Provides SSE streams for item-channel link events. Both methods return `SSEConnection`.

#### Constructor

```csharp
var linkEvents = new LinkEvents(client);
```

#### Methods

| Method | Description |
|---|---|
| `ItemChannelLinkAddedEvent(string item = "*", string ch = "*")` | Link added events |
| `ItemChannelLinkRemovedEvent(string item = "*", string ch = "*")` | Link removed events |

---

### ChannelEvents

Provides SSE streams for channel events. Both methods return `SSEConnection`.

#### Constructor

```csharp
var channelEvents = new ChannelEvents(client);
```

#### Methods

| Method | Description |
|---|---|
| `ChannelDescriptionChangedEvent(string uid = "*")` | Channel description changed events |
| `ChannelTriggeredEvent(string uid = "*")` | Channel triggered events |

---

### Iconsets

Provides methods to retrieve available iconsets.

#### Constructor

```csharp
var iconsets = new Iconsets(client);
```

#### Methods

| Method | Async | Description |
|---|---|---|
| `GetIconsets(string? language = null)` | `GetIconsetsAsync` | Gets all available iconsets |

---

### Inbox

Provides methods to manage the openHAB inbox (discovery results).

#### Constructor

```csharp
var inbox = new Inbox(client);
```

#### Methods

| Method | Async | Description |
|---|---|---|
| `GetDiscoveredThings(bool includeIgnored = true)` | `GetDiscoveredThingsAsync` | Gets all discovered things |
| `RemoveDiscoveryResult(string uid)` | `RemoveDiscoveryResultAsync` | Removes a discovery result |
| `ApproveDiscoveryResult(string uid, string label, string? newId = null, string? language = null)` | `ApproveDiscoveryResultAsync` | Approves a discovery result and creates the thing |
| `IgnoreDiscoveryResult(string uid)` | `IgnoreDiscoveryResultAsync` | Marks a discovery result as ignored |
| `UnignoreDiscoveryResult(string uid)` | `UnignoreDiscoveryResultAsync` | Removes the ignore flag |

---

### Items

Provides methods to manage openHAB items.

#### Constructor

```csharp
var items = new Items(client);
```

#### Methods

| Method | Async | Description |
|---|---|---|
| `GetItems(string? type = null, string? tags = null, string metadata = ".*", bool recursive = false, string? fields = null, bool staticDataOnly = false, string? language = null)` | `GetItemsAsync` | Gets all items with optional filters |
| `AddOrUpdateItems(string itemsJson)` | `AddOrUpdateItemsAsync` | Adds or updates a list of items |
| `GetItem(string itemName, string metadata = ".*", bool recursive = true, string? language = null)` | `GetItemAsync` | Gets a single item |
| `AddOrUpdateItem(string itemName, string itemDataJson, string? language = null)` | `AddOrUpdateItemAsync` | Adds or updates a single item |
| `SendCommand(string itemName, string command)` | `SendCommandAsync` | Sends a command to an item |
| `PostUpdate(string itemName, string state)` | `PostUpdateAsync` | Updates the state of an item (alias for `UpdateItemState`) |
| `DeleteItem(string itemName)` | `DeleteItemAsync` | Removes an item from the registry |
| `AddGroupMember(string itemName, string memberItemName)` | `AddGroupMemberAsync` | Adds a member to a group item |
| `RemoveGroupMember(string itemName, string memberItemName)` | `RemoveGroupMemberAsync` | Removes a member from a group item |
| `AddMetadata(string itemName, string ns, string metadataJson)` | `AddMetadataAsync` | Adds metadata to an item |
| `RemoveMetadata(string itemName, string ns)` | `RemoveMetadataAsync` | Removes metadata from an item |
| `GetMetadataNamespaces(string itemName, string? language = null)` | `GetMetadataNamespacesAsync` | Gets all metadata namespaces of an item |
| `GetSemanticItem(string itemName, string semanticClass, string? language = null)` | `GetSemanticItemAsync` | Gets the item defining the requested semantics |
| `GetItemState(string itemName)` | `GetItemStateAsync` | Gets the current state of an item |
| `UpdateItemState(string itemName, string state, string? language = null)` | `UpdateItemStateAsync` | Updates the state of an item |
| `AddTag(string itemName, string tag)` | `AddTagAsync` | Adds a tag to an item |
| `RemoveTag(string itemName, string tag)` | `RemoveTagAsync` | Removes a tag from an item |
| `PurgeOrphanedMetadata()` | `PurgeOrphanedMetadataAsync` | Removes unused/orphaned metadata from all items |

```csharp
// Send a command
items.SendCommand("MyLightSwitch", "ON");

// Get state
string state = items.GetItemState("MyLightSwitch");
Console.WriteLine(state); // "ON"

// Get filtered items
string switches = await items.GetItemsAsync(type: "Switch", recursive: true);
```

---

### Links

Provides methods to manage item-channel links.

#### Constructor

```csharp
var links = new Links(client);
```

#### Methods

| Method | Async | Description |
|---|---|---|
| `GetLinks(string? channelUID = null, string? itemName = null)` | `GetLinksAsync` | Gets all links, optionally filtered |
| `GetLink(string item, string ch)` | `GetLinkAsync` | Gets a specific link |
| `LinkItemToChannel(string item, string ch, string configJson)` | `LinkItemToChannelAsync` | Links an item to a channel |
| `UnlinkItemFromChannel(string item, string ch)` | `UnlinkItemFromChannelAsync` | Unlinks an item from a channel |
| `DeleteAllLinks(string obj)` | `DeleteAllLinksAsync` | Deletes all links for an item or thing |
| `GetOrphanLinks()` | `GetOrphanLinksAsync` | Gets all orphan links |
| `PurgeUnusedLinks()` | `PurgeUnusedLinksAsync` | Removes all unused/orphaned links |

---

### Logging

Provides methods to manage openHAB loggers.

#### Constructor

```csharp
var logging = new Logging(client);
```

#### Methods

| Method | Async | Description |
|---|---|---|
| `GetLoggers()` | `GetLoggersAsync` | Gets all loggers and their levels |
| `GetLogger(string name)` | `GetLoggerAsync` | Gets a specific logger |
| `ModifyOrAddLogger(string name, string level)` | `ModifyOrAddLoggerAsync` | Modifies or adds a logger |
| `RemoveLogger(string name)` | `RemoveLoggerAsync` | Removes a logger |

```csharp
logging.ModifyOrAddLogger("org.openhab.core", "DEBUG");
```

---

### ModuleTypes

Provides methods to retrieve rule module types.

#### Constructor

```csharp
var moduleTypes = new ModuleTypes(client);
```

#### Methods

| Method | Async | Description |
|---|---|---|
| `GetModuleTypes(string? tags = null, string? typeFilter = null, string? language = null)` | `GetModuleTypesAsync` | Gets all module types |
| `GetModuleType(string uid, string? language = null)` | `GetModuleTypeAsync` | Gets a specific module type |

---

### Persistence

Provides methods to interact with openHAB persistence services.

#### Constructor

```csharp
var persistence = new Persistence(client);
```

#### Methods

| Method | Async | Description |
|---|---|---|
| `GetServices(string? language = null)` | `GetServicesAsync` | Gets all persistence services |
| `GetServiceConfiguration(string id)` | `GetServiceConfigurationAsync` | Gets a service configuration |
| `SetServiceConfiguration(string id, string json)` | `SetServiceConfigurationAsync` | Sets a service configuration |
| `DeleteServiceConfiguration(string id)` | `DeleteServiceConfigurationAsync` | Deletes a service configuration |
| `GetItemsFromService(string? serviceID = null)` | `GetItemsFromServiceAsync` | Gets all items available via a service |
| `GetItemPersistenceData(string item, string serviceID, string? startTime = null, string? endTime = null, int page = 1, int pageLength = 50, bool boundary = false, bool itemState = false)` | `GetItemPersistenceDataAsync` | Gets item persistence data |
| `StoreItemData(string item, string time, string state, string? serviceID = null)` | `StoreItemDataAsync` | Stores a data point |
| `DeleteItemData(string item, string start, string end, string serviceID)` | `DeleteItemDataAsync` | Deletes item data within a time range |

```csharp
var data = await persistence.GetItemPersistenceDataAsync(
    "MyTemperatureSensor",
    "rrd4j",
    startTime: "2024-01-01T00:00:00.000+0000",
    endTime:   "2024-01-02T00:00:00.000+0000",
    pageLength: 100
);
```

---

### ProfileTypes

Provides methods to retrieve profile types.

#### Constructor

```csharp
var profileTypes = new ProfileTypes(client);
```

#### Methods

| Method | Async | Description |
|---|---|---|
| `GetProfileTypes(string? channelTypeUID = null, string? itemType = null, string? language = null)` | `GetProfileTypesAsync` | Gets all available profile types |

---

### Rules

Provides methods to manage openHAB rules.

#### Constructor

```csharp
var rules = new Rules(client);
```

#### Methods

| Method | Async | Description |
|---|---|---|
| `GetRules(string? prefix = null, string? tags = null, bool summary = false, bool staticDataOnly = false)` | `GetRulesAsync` | Gets all rules |
| `CreateRule(string json)` | `CreateRuleAsync` | Creates a new rule |
| `GetRule(string uid)` | `GetRuleAsync` | Gets a specific rule |
| `UpdateRule(string uid, string json)` | `UpdateRuleAsync` | Updates an existing rule |
| `DeleteRule(string uid)` | `DeleteRuleAsync` | Deletes a rule |
| `GetModule(string uid, string cat, string mid)` | `GetModuleAsync` | Gets a specific module of a rule |
| `GetModuleConfig(string uid, string cat, string mid)` | `GetModuleConfigAsync` | Gets the configuration of a module |
| `GetModuleConfigParam(string uid, string cat, string mid, string param)` | `GetModuleConfigParamAsync` | Gets a module configuration parameter |
| `SetModuleConfigParam(string uid, string cat, string mid, string param, string val)` | `SetModuleConfigParamAsync` | Sets a module configuration parameter |
| `GetActions(string uid)` | `GetActionsAsync` | Gets all action modules of a rule |
| `GetConditions(string uid)` | `GetConditionsAsync` | Gets all condition modules of a rule |
| `GetTriggers(string uid)` | `GetTriggersAsync` | Gets all trigger modules of a rule |
| `GetConfiguration(string uid)` | `GetConfigurationAsync` | Gets the configuration of a rule |
| `UpdateConfiguration(string uid, string json)` | `UpdateConfigurationAsync` | Updates the rule configuration |
| `SetRuleState(string uid, bool enable)` | `SetRuleStateAsync` | Enables or disables a rule |
| `Enable(string uid)` | `EnableAsync` | Enables a rule |
| `Disable(string uid)` | `DisableAsync` | Disables a rule |
| `RunNow(string uid, string? contextJson = null)` | `RunNowAsync` | Executes a rule immediately |
| `SimulateSchedule(string from, string until)` | `SimulateScheduleAsync` | Simulates the rule schedule |

```csharp
rules.Enable("my-rule-uid");
await rules.RunNowAsync("my-rule-uid");
```

---

### Services

Provides methods to manage openHAB configurable services.

#### Constructor

```csharp
var services = new Services(client);
```

#### Methods

| Method | Async | Description |
|---|---|---|
| `GetServices(string? language = null)` | `GetServicesAsync` | Gets all configurable services |
| `GetService(string id, string? language = null)` | `GetServiceAsync` | Gets a specific service |
| `GetServiceConfig(string id)` | `GetServiceConfigAsync` | Gets the service configuration |
| `UpdateServiceConfig(string id, string json, string? language = null)` | `UpdateServiceConfigAsync` | Updates the service configuration |
| `DeleteServiceConfig(string id)` | `DeleteServiceConfigAsync` | Deletes the service configuration |
| `GetServiceContexts(string id, string? language = null)` | `GetServiceContextsAsync` | Gets all contexts of a multi-context service |

---

### Sitemaps

Provides methods to interact with openHAB sitemaps.

#### Constructor

```csharp
var sitemaps = new Sitemaps(client);
```

#### Methods

| Method | Async / Returns | Description |
|---|---|---|
| `GetSitemaps()` | `GetSitemapsAsync` | Gets all available sitemaps |
| `GetSitemap(string name, string? type = null, string? cb = null, bool hidden = false, string? language = null)` | `GetSitemapAsync` | Gets a specific sitemap |
| `GetSitemapPage(string name, string page, string? subId = null, bool hidden = false, string? language = null)` | `GetSitemapPageAsync` | Gets a sitemap page |
| `GetSitemapEvents(string subId, string? name = null, string? pageId = null)` | `SSEConnection` | Gets sitemap events as SSE stream |
| `GetFullSitemapEvents(string subId, string? name = null)` | `SSEConnection` | Gets full sitemap events as SSE stream |
| `SubscribeToSitemapEvents()` | `SubscribeToSitemapEventsAsync` | Creates a sitemap event subscription |

---

### Systeminfo

Provides methods to retrieve openHAB system information.

#### Constructor

```csharp
var systeminfo = new Systeminfo(client);
```

#### Methods

| Method | Async | Description |
|---|---|---|
| `GetSystemInfo()` | `GetSystemInfoAsync` | Gets general system information |
| `GetUoMInfo()` | `GetUoMInfoAsync` | Gets units of measurement information |

---

### Tags

Provides methods to manage openHAB semantic tags.

#### Constructor

```csharp
var tags = new Tags(client);
```

#### Methods

| Method | Async | Description |
|---|---|---|
| `GetTags(string? language = null)` | `GetTagsAsync` | Gets all semantic tags |
| `CreateTag(string json, string? language = null)` | `CreateTagAsync` | Creates a new semantic tag |
| `GetTag(string id, string? language = null)` | `GetTagAsync` | Gets a specific tag |
| `UpdateTag(string id, string json, string? language = null)` | `UpdateTagAsync` | Updates a semantic tag |
| `DeleteTag(string id, string? language = null)` | `DeleteTagAsync` | Deletes a semantic tag |

---

### Templates

Provides methods to retrieve rule templates.

#### Constructor

```csharp
var templates = new Templates(client);
```

#### Methods

| Method | Async | Description |
|---|---|---|
| `GetTemplates(string? language = null)` | `GetTemplatesAsync` | Gets all available rule templates |
| `GetTemplate(string uid, string? language = null)` | `GetTemplateAsync` | Gets a specific rule template |

---

### ThingTypes

Provides methods to retrieve thing types.

#### Constructor

```csharp
var thingTypes = new ThingTypes(client);
```

#### Methods

| Method | Async | Description |
|---|---|---|
| `GetThingTypes(string? bindingID = null, string? language = null)` | `GetThingTypesAsync` | Gets all available thing types |
| `GetThingType(string uid, string? language = null)` | `GetThingTypeAsync` | Gets a specific thing type |

---

### Things

Provides methods to manage openHAB things.

#### Constructor

```csharp
var things = new Things(client);
```

#### Methods

| Method | Async | Description |
|---|---|---|
| `GetThings(bool summary = false, bool staticDataOnly = false, string? language = null)` | `GetThingsAsync` | Gets all things |
| `CreateThing(string json, string? language = null)` | `CreateThingAsync` | Creates a new thing |
| `GetThing(string uid, string? language = null)` | `GetThingAsync` | Gets a specific thing |
| `UpdateThing(string uid, string json, string? language = null)` | `UpdateThingAsync` | Updates a thing |
| `DeleteThing(string uid, bool force = false, string? language = null)` | `DeleteThingAsync` | Deletes a thing |
| `UpdateThingConfiguration(string uid, string json, string? language = null)` | `UpdateThingConfigurationAsync` | Updates the thing configuration |
| `GetThingConfigStatus(string uid, string? language = null)` | `GetThingConfigStatusAsync` | Gets the configuration status |
| `SetThingStatus(string uid, bool enabled, string? language = null)` | `SetThingStatusAsync` | Enables or disables a thing |
| `EnableThing(string uid)` | `EnableThingAsync` | Enables a thing |
| `DisableThing(string uid)` | `DisableThingAsync` | Disables a thing |
| `UpdateThingFirmware(string uid, string version, string? language = null)` | `UpdateThingFirmwareAsync` | Updates the thing firmware |
| `GetThingFirmwareStatus(string uid, string? language = null)` | `GetThingFirmwareStatusAsync` | Gets the firmware status |
| `GetThingFirmwares(string uid, string? language = null)` | `GetThingFirmwaresAsync` | Gets available firmware versions |
| `GetThingStatus(string uid, string? language = null)` | `GetThingStatusAsync` | Gets the thing status |

```csharp
things.EnableThing("zwave:device:controller:node5");
await things.UpdateThingConfigurationAsync("my:thing:uid", "{\"port\":\"/dev/ttyUSB0\"}");
```

---

### Transformations

Provides methods to manage openHAB transformations.

#### Constructor

```csharp
var transformations = new Transformations(client);
```

#### Methods

| Method | Async | Description |
|---|---|---|
| `GetTransformations()` | `GetTransformationsAsync` | Gets all transformations |
| `GetTransformation(string uid)` | `GetTransformationAsync` | Gets a specific transformation |
| `UpdateTransformation(string uid, string json)` | `UpdateTransformationAsync` | Updates a transformation |
| `DeleteTransformation(string uid)` | `DeleteTransformationAsync` | Deletes a transformation |
| `GetTransformationServices()` | `GetTransformationServicesAsync` | Gets all transformation services |

---

### UI

Provides methods to manage UI components and tiles.

#### Constructor

```csharp
var ui = new UI(client);
```

#### Methods

| Method | Async | Description |
|---|---|---|
| `GetUIComponents(string ns, bool summary = false)` | `GetUIComponentsAsync` | Gets all UI components in a namespace |
| `AddUIComponent(string ns, string json)` | `AddUIComponentAsync` | Adds a UI component |
| `GetUIComponent(string ns, string uid)` | `GetUIComponentAsync` | Gets a specific UI component |
| `UpdateUIComponent(string ns, string uid, string json)` | `UpdateUIComponentAsync` | Updates a UI component |
| `DeleteUIComponent(string ns, string uid)` | `DeleteUIComponentAsync` | Deletes a UI component |
| `GetUITiles()` | `GetUITilesAsync` | Gets all registered UI tiles |

---

### UUID

Provides a method to retrieve the openHAB instance UUID.

#### Constructor

```csharp
var uuid = new UUID(client);
```

#### Methods

| Method | Async | Description |
|---|---|---|
| `GetUUID()` | `GetUUIDAsync` | Gets the UUID of the openHAB instance |

```csharp
string id = uuid.GetUUID();
Console.WriteLine(id);
```

---

### Voice

Provides methods to interact with the openHAB voice system.

#### Constructor

```csharp
var voice = new Voice(client);
```

#### Methods

| Method | Async | Description |
|---|---|---|
| `GetDefaultVoice()` | `GetDefaultVoiceAsync` | Gets the default voice |
| `GetVoices()` | `GetVoicesAsync` | Gets all available voices |
| `GetInterpreters(string? language = null)` | `GetInterpretersAsync` | Gets all human language interpreters |
| `GetInterpreter(string id, string? language = null)` | `GetInterpreterAsync` | Gets a specific interpreter |
| `InterpretText(string text, string? language = null)` | `InterpretTextAsync` | Sends text to the default interpreter |
| `InterpretTextBatch(string text, string ids, string? language = null)` | `InterpretTextBatchAsync` | Sends text to multiple interpreters |
| `StartDialog(string sourceID, string? ksID = null, string? sttID = null, string? ttsID = null, string? voiceID = null, string? hliIDs = null, string? sinkID = null, string? keyword = null, string? listeningItem = null)` | `StartDialogAsync` | Starts dialog processing |
| `StopDialog(string sourceID)` | `StopDialogAsync` | Stops dialog processing |
| `ListenAndAnswer(string sid, string stt, string tts, string v, string? hli = null, string? sink = null, string? li = null)` | `ListenAndAnswerAsync` | Single listen-and-answer dialog |
| `SayText(string text, string voiceID, string sinkID, string volume = "100")` | `SayTextAsync` | Speaks text aloud |

```csharp
voice.SayText("Hello from openHAB!", "voicerss:en-us", "javasound:sink:default");
await voice.StartDialogAsync("javasound:source:microphone", sttID: "googlestt", ttsID: "googletts");
```

---

## C# vs. Python — Key Differences

| Topic | C# | Python |
|---|---|---|
| Package manager | NuGet (`CSharpOpenHABRestClient`) | PyPI (`pip install python-openhab-rest-client`) |
| Namespace | `using OpenHABRestClient;` | `from openhab import Items` |
| Sync methods | Every method has a sync variant | `requests`-based, always sync |
| Async methods | Every method has an `Async` variant returning `Task<string>` | `AsyncOpenHABClient` + `aiohttp` |
| SSE | `SSEConnection` with `ReadAll()` / `ReadAllAsync()` + `await foreach` | `response.iter_lines()` |
| Error handling | `OpenHABException` with `StatusCode` property | `requests.exceptions.*` |
| Return type | `string` (raw JSON or plain text) | `dict`, `list`, or `str` |
| JSON parsing | `System.Text.Json` or Newtonsoft.Json | Built-in `json.loads()` |
| Naming convention | PascalCase (`GetItems`, `SendCommand`) | camelCase (`getItems`, `sendCommand`) |
| Config data | JSON `string` (e.g. `"{\"state\":\"ON\"}"`) | Python `dict` |
| Client lifetime | `IDisposable` — use `using` | GC-managed session |
| SSL | Self-signed certs accepted by default | Requires `verify=False` |
| `GetToken` | All parameters positional with defaults | Named/keyword arguments |
| `InterpretTextBatch` | `ids` as comma-separated `string` | `IDs` as `List[str]` |
| Target framework | `netstandard2.1` + `net8.0` | Python 3.x |

---

## Contributing

Contributions are welcome! Please create an issue or pull request to suggest changes.

### How to contribute:
1. Fork the repository.
2. Create a new branch:
   ```bash
   git checkout -b feature/your-feature-name
   ```
3. Commit your changes:
   ```bash
   git commit -m "Add your feature description"
   ```
4. Push to the branch:
   ```bash
   git push origin feature/your-feature-name
   ```
5. Open a pull request.

Please ensure your code compiles without warnings, has zero external dependencies, and follows the existing style (PascalCase, XML doc comments, sync + async for every method).

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
