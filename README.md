# OpenHABRestClient — C# Library

C# client for the openHAB REST API.  
Mirrors **python-openhab-rest-client** exactly: same class names, same method names, same usage pattern.  
Zero external dependencies — only `System.Net.Http` from the .NET standard library.

---

## Plattform-Unterstützung

| Plattform | Target Framework | Unterstützt |
|---|---|---|
| .NET 8 / .NET 6 | `net6.0` / `net8.0` | ✅ |
| Unity 2021+ | `netstandard2.1` | ✅ (siehe unten) |
| Xamarin / MAUI | `netstandard2.1` | ✅ |
| .NET Framework 4.8 | — | ❌ (nur .NET Core/5+) |

---

## Installation

### Via NuGet (empfohlen)

```
dotnet add package OpenHABRestClient
```

Oder in Visual Studio: **Tools → NuGet Package Manager → Manage NuGet Packages** → `OpenHABRestClient` suchen.

### Via DLL (manuell)

1. `OpenHABRestClient.dll` herunterladen
2. Projekt → **Add Reference** → DLL auswählen

---

## Quick Start

```csharp
using OpenHABRestClient;

// Basic Authentication
using var client = new OpenHABClient("http://127.0.0.1:8080", "openhab", "habopen");

// Token Authentication
using var client = new OpenHABClient("http://127.0.0.1:8080", token: "oh.openhab.xxx");

// Items
var items = new Items(client);
string allItems   = items.GetItems();
string state      = items.GetItemState("LivingRoomLight");
items.SendCommand("LivingRoomLight", "ON");
items.UpdateItemState("Thermostat", "21.5");

// Things
var things = new Things(client);
string allThings = things.GetThings();
things.EnableThing("astro:sun:local");

// Rules
var rules = new Rules(client);
rules.Enable("my-rule-uid");
rules.RunNow("my-rule-uid");
```

### Async/Await

Jede Methode hat eine `*Async`-Variante:

```csharp
var items = new Items(client);
string result = await items.GetItemsAsync(type: "Switch");
await items.SendCommandAsync("LivingRoomLight", "ON");
string state  = await items.GetItemStateAsync("LivingRoomLight");
```

### Server-Sent Events (SSE)

```csharp
var itemEvents = new ItemEvents(client);

// Async (empfohlen)
using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));
await using var sse = itemEvents.ItemStateChangedEvent("LivingRoomLight");
await foreach (var data in sse.ReadAllAsync(cts.Token))
{
    Console.WriteLine(data);   // raw JSON string
}

// Synchron
using var sse2 = itemEvents.ItemCommandEvent("*");
foreach (var data in sse2.ReadAll())
    Console.WriteLine(data);
```

### JSON parsen

Die Library gibt rohe JSON-Strings zurück. Mit `System.Text.Json`:

```csharp
using System.Text.Json;

string json  = items.GetItems();
var doc      = JsonDocument.Parse(json);
foreach (var item in doc.RootElement.EnumerateArray())
    Console.WriteLine(item.GetProperty("name").GetString());
```

Oder mit Newtonsoft.Json (NuGet: `Newtonsoft.Json`):

```csharp
var list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<dynamic>>(json);
```

---

## Unity Integration

### Einschränkungen in Unity

Unity verwendet eine eigene C#-Runtime (Mono oder IL2CPP). Es gibt einige Punkte zu beachten:

- Unity unterstützt **`netstandard2.1`** ab Unity **2021.2+**
- `async/await` funktioniert, aber SSE-Streams mit `await foreach` benötigen **Unity 2021.2+** (C# 8)
- `HttpClient` ist in Unity verfügbar, aber **nicht** auf dem **Main Thread** für UI-Operationen

### Schritt 1: DLL in Unity importieren

1. `OpenHABRestClient.dll` bauen (Release-Build, Target: `netstandard2.1`)
2. In Unity: Ordner `Assets/Plugins/` erstellen
3. `OpenHABRestClient.dll` in `Assets/Plugins/` ziehen
4. Unity erkennt die DLL automatisch — kein weiterer Import nötig

### Schritt 2: Script schreiben

```csharp
// Assets/Scripts/OpenHABBridge.cs
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using OpenHABRestClient;

public class OpenHABBridge : MonoBehaviour
{
    private OpenHABClient _client;
    private Items         _items;

    [SerializeField] private string serverUrl   = "http://192.168.1.100:8080";
    [SerializeField] private string username    = "openhab";
    [SerializeField] private string password    = "habopen";
    [SerializeField] private string lightItem   = "LivingRoomLight";

    void Start()
    {
        // Client NICHT auf dem Main Thread verbinden (blockiert sonst Unity)
        Task.Run(() =>
        {
            _client = new OpenHABClient(serverUrl, username, password);
            _items  = new Items(_client);

            if (_client.IsLoggedIn)
                Debug.Log("openHAB verbunden!");
            else
                Debug.LogError("openHAB Verbindung fehlgeschlagen!");
        });
    }

    // Aufruf via Button.OnClick() etc.
    public void TurnLightOn()
    {
        Task.Run(async () =>
        {
            try
            {
                await _items.SendCommandAsync(lightItem, "ON");
                // Zurück auf den Main Thread für UI-Updates:
                UnityMainThreadDispatcher.Instance().Enqueue(() =>
                    Debug.Log("Licht eingeschaltet!"));
            }
            catch (OpenHABException ex)
            {
                Debug.LogError($"openHAB Fehler: {ex.Message}");
            }
        });
    }

    public void TurnLightOff()
    {
        Task.Run(async () =>
            await _items.SendCommandAsync(lightItem, "OFF"));
    }

    public void GetLightState()
    {
        Task.Run(async () =>
        {
            string state = await _items.GetItemStateAsync(lightItem);
            // Main Thread für UI:
            UnityMainThreadDispatcher.Instance().Enqueue(() =>
                Debug.Log($"Lichtstatus: {state}"));
        });
    }

    void OnDestroy()
    {
        _client?.Dispose();
    }
}
```

### Schritt 3: UnityMainThreadDispatcher (benötigt für UI-Updates)

Für UI-Operationen vom Background-Thread braucht man einen Dispatcher. Einen einfachen findest du auf [GitHub: PimDeWitte/UnityMainThreadDispatcher](https://github.com/PimDeWitte/UnityMainThreadDispatcher) — einfach `UnityMainThreadDispatcher.cs` in `Assets/Scripts/` legen.

### Schritt 4: SSE in Unity (Echtzeit-Events)

```csharp
// SSE auf einem separaten Thread — NICHT auf dem Main Thread!
private CancellationTokenSource _sseCts;

public void StartListening()
{
    _sseCts = new CancellationTokenSource();
    Task.Run(async () =>
    {
        var itemEvents = new ItemEvents(_client);
        await using var sse = itemEvents.ItemStateChangedEvent(lightItem);
        await foreach (var data in sse.ReadAllAsync(_sseCts.Token))
        {
            // JSON parsen
            using var doc = System.Text.Json.JsonDocument.Parse(data);
            string? topic = doc.RootElement.GetProperty("topic").GetString();

            // UI auf Main Thread updaten
            UnityMainThreadDispatcher.Instance().Enqueue(() =>
                Debug.Log($"Event: {topic}"));
        }
    }, _sseCts.Token);
}

public void StopListening() => _sseCts?.Cancel();
```

### Unity-Kompatibilitäts-Tabelle

| Feature | Unity 2020 | Unity 2021.2+ | Unity 2022+ |
|---|---|---|---|
| Basis-REST (sync) | ✅ | ✅ | ✅ |
| async/await | ✅ | ✅ | ✅ |
| SSE ReadAll() | ✅ | ✅ | ✅ |
| SSE ReadAllAsync() | ⚠️ (kein C#8) | ✅ | ✅ |
| await foreach | ❌ | ✅ | ✅ |
| IL2CPP | ✅ | ✅ | ✅ |

---

## NuGet-Paket veröffentlichen

### Schritt 1: Account erstellen

Unter [nuget.org](https://www.nuget.org/) einen kostenlosen Account erstellen.

### Schritt 2: API-Key erstellen

Auf nuget.org → **Account** → **API Keys** → **Create** → Scope: `Push new packages`.

### Schritt 3: Paket bauen

```bash
# Release-Build mit Paket-Erstellung
dotnet pack OpenHABRestClient/OpenHABRestClient.csproj \
    --configuration Release \
    --output ./nupkg

# Erzeugt: ./nupkg/OpenHABRestClient.1.0.0.nupkg
```

Oder in Visual Studio: Rechtsklick auf Projekt → **Pack**.

### Schritt 4: Paket veröffentlichen

```bash
dotnet nuget push ./nupkg/OpenHABRestClient.1.0.0.nupkg \
    --api-key DEIN_API_KEY \
    --source https://api.nuget.org/v3/index.json
```

Das Paket erscheint nach 10–30 Minuten auf nuget.org.

### Schritt 5: Version hochzählen

In `OpenHABRestClient.csproj`:
```xml
<Version>1.0.1</Version>
```

Dann wieder `dotnet pack` und `dotnet nuget push`.

### Lokal testen vor Veröffentlichung

```bash
# Lokales NuGet-Feed erstellen
mkdir ~/local-nuget
dotnet pack --output ~/local-nuget

# In einem anderen Projekt:
dotnet nuget add source ~/local-nuget --name local
dotnet add package OpenHABRestClient --source local
```

### GitHub Actions (automatisches Publizieren)

`.github/workflows/publish.yml`:
```yaml
name: Publish NuGet

on:
  push:
    tags: ['v*']

jobs:
  publish:
    runs-on: ubuntu-latest
    steps:
      - uses: actions/checkout@v4
      - uses: actions/setup-dotnet@v4
        with: { dotnet-version: '8.x' }
      - run: dotnet pack OpenHABRestClient/OpenHABRestClient.csproj -c Release -o nupkg
      - run: dotnet nuget push nupkg/*.nupkg --api-key ${{ secrets.NUGET_API_KEY }} --source https://api.nuget.org/v3/index.json
```

---

## Vergleich: NuGet vs. andere Wege

| | NuGet | DLL direkt | GitHub Packages |
|---|---|---|---|
| Globale Verfügbarkeit | ✅ | ❌ | ❌ (Token nötig) |
| Visual Studio Integration | ✅ | Manuell | ✅ |
| Unity Import | Via DLL | ✅ | Via DLL |
| Versions-Management | ✅ | Manuell | ✅ |
| Setup-Aufwand | Gering | Keiner | Mittel |

**NuGet ist die optimale Wahl für Visual Studio** — es ist genau dafür gemacht. Einzige Ausnahme: Unity verwendet DLLs direkt, weil Unity kein NuGet-CLI kennt. Es gibt aber das **NuGetForUnity**-Package, das NuGet-Pakete direkt in Unity verfügbar macht.

---

## Klassen-Referenz

Alle Klassen akzeptieren `OpenHABClient` oder `AsyncOpenHABClient`.  
Jede Methode hat eine synchrone und eine `*Async`-Variante.

`Items`, `Things`, `Rules`, `Events`, `ItemEvents`, `ThingEvents`, `InboxEvents`,
`LinkEvents`, `ChannelEvents`, `Actions`, `Addons`, `Audio`, `Auth`,
`ChannelTypes`, `ConfigDescriptions`, `Discovery`, `Iconsets`, `Inbox`,
`Links`, `Logging`, `ModuleTypes`, `Persistence`, `ProfileTypes`,
`Services`, `Sitemaps`, `Systeminfo`, `Tags`, `Templates`, `ThingTypes`,
`Transformations`, `UI`, `UUID`, `Voice`

---

## License

MIT
