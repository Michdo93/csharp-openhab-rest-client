# csharp-openhab-rest-client 1.0.0 – findings and what 2.0.0 changes

Checked on 17 November 2026 against openHAB 5.2.3 and python-openhab-rest-client 21.4.1 (the
reference), with the NuGet package `CSharpOpenHABRestClient` 1.0.0.

## Differential test

The same 79 calls (all classes: read, create, change, delete, error cases) were run with Python
and with the C# library; the results were compared after normalisation (time stamps, UUIDs,
memory values). 1.0.0: **40 of 79 differ**. 2.0.0: **0 of 79**, for the synchronous and for the
`…Async` methods.

| Call | 1.0.0 | Python / 2.0.0 |
|---|---|---|
| `Items.GetItem("Gibtsnicht")` | `OpenHABException` (HTTP 404) | `{"error": "Item not found."}` |
| `Items.SendCommand(…, "ON")` | `{"status": 200}` | `{"message": "OK"}` |
| `Items.SendCommand("Wohnzimmer_Dimmer", "BLAU")` | `OpenHABException` (HTTP 400) | `{"error": "Invalid command for this item."}` |
| `Items.PostUpdate` | `{"status": 202}` | `{"message": "Accepted."}` |
| `Items.GetItemState("Wohnzimmer_Dimmer")` | `40` (number) | `"40"` (text, like openHAB sends it) |
| `Items.GetItem(…, parents: true)` | parameter missing | parent groups included |
| `Items.AddTag`, `AddMetadata`, `RemoveMetadata`, `RemoveTag`, `AddGroupMember`, `RemoveGroupMember`, `DeleteItem` | `{"status": …}` | `{"message": …}` |
| `Items.DeleteItem` (again) | `OpenHABException` | `{"error": "Item not found or item is not editable."}` |
| `Links.LinkItemToChannel(…, "astro:sun:zuhause:rise#start", {})` | HTTP 400 – `#` starts a URL fragment | `{"message": "OK"}` |
| `Links.GetLink`, `Links.GetLinks` with `#` in the channel UID | 404 / empty list | the link |
| `Links.DeleteAllLinks` | HTTP 500 (no `Accept: application/json`) | `{"count": 1}` |
| `Links.GetOrphanLinks` | HTTP 405 (`/links/orphan` instead of `/links/orphans`) | `[]` |
| `Things.GetThing("astro:gibts:nicht")` | `OpenHABException` | `{"error": "Thing not found."}` |
| `Discovery.GetBindingInfo("astro")` | HTTP 404 (`/bindings/{id}` instead of `/discovery/bindings/{id}/info`) | `{"inputSupported": false}` |
| `Rules.GetRule("gibtsnicht")` | `OpenHABException` | `{"error": "Rule not found."}` |
| `Rules.CreateRule`, `SetModuleConfigParam`, `Enable`, `Disable`, `RunNow`, `DeleteRule` | `{"status": …}` | `{"message": …}` |
| `Persistence.StoreItemData` | HTTP 400 "State could not be parsed: null" – state sent in the body | state as query parameter `state`, `{"message": "OK"}` |
| `Persistence.GetItemPersistenceData` afterwards | no data | the stored value |
| `Persistence.GetItemsFromService("rrd4j")` | `OpenHABException` (405) | `{"error": "The persistence service does not provide item information."}` |
| `Transformations.GetTransformation("gibts:nicht")` | `OpenHABException` | `{"error": "Not found."}` |
| `Sitemaps.GetSitemap("gibtsnicht")` | `OpenHABException` | `{"error": "HTTP error 404: …"}` |
| `Tags.DeleteTag` | `{"status": 200}` | `{"message": "OK, was deleted."}` |
| `Logging.GetLogger`, `ModifyOrAddLogger`, `RemoveLogger` | HTTP 404 (`/loggers/…` instead of `/logging/…`) | logger / `{"message": "OK"}` |
| `Events.UpdateSSEConnectionItems("gibtsnicht", …)` | `OpenHABException` | `{"error": "Unknown connectionID."}` |

## Found in the code

| Finding | 1.0.0 | 2.0.0 |
|---|---|---|
| Results | JSON as `string`; every caller parses again | `JsonNode?` (System.Text.Json), keys in the order of openHAB; helpers `IsError()`, `ErrorMessage()`, `Str("payload.value")`, `Num()`, `Bool()`, `List()` |
| Errors | `OpenHABException` for every status ≥ 400 – the messages of the Python library never appear | `{"error": "…"}` with the texts of Python, nothing is thrown (except `OperationCanceledException` for a cancelled `CancellationToken`) |
| TLS | every certificate accepted (`ServerCertificateCustomValidationCallback = true`) – also for myopenhab.org | verified; `verify: false` only on request |
| Timeout | 10 s for event streams too – a quiet stream breaks off | normal requests `timeout` (10 s), streams without read timeout, 10 s for the connection |
| Event streams | `SSEConnection` connects only in `ReadAll()`; HTTP errors as exception from the iterator; only the raw text after `data: ` (payload not decoded); `ReadAll` blocks without time limit | `EventStream`: opened at once, errors in `IsError`/`Error`/`ErrorStatus`; events with decoded payload (Python `iterSSEEvents`); `NextEvent(timeout)`, `foreach`, `await foreach`, `Interrupt()`, `CancellationToken`; partial lines are buffered |
| `ItemEvents.ItemEvent()` | topic `openhab/items` – matches no event | `openhab/items/*` (Python) |
| `#` in UIDs | not encoded | encoded as `%23` (channel and action UIDs) |
| Parameters | partly different from Python (`itemsJson` strings, missing `parents`, `source`, `language` …) | names, order and defaults of Python; objects, records, dictionaries or `JsonNode` as JSON parameters |
| Synchronous calls | `.GetAwaiter().GetResult()` on `SendAsync` | `HttpClient.Send` on .NET 8/10, `ConfigureAwait(false)` everywhere – no deadlock in UI threads |
| Classes | partly written by hand, several methods missing or with wrong paths | all 33 classes and 178 methods generated from Python (`tools/py2cs.py`), each synchronous and `…Async` |

## Package

- 1.0.0: `netstandard2.1;net8.0`, no README in the package, no tests.
- 2.0.0: `netstandard2.1` (Unity, with System.Text.Json as dependency), `net8.0` and `net10.0`
  (no dependency), XML documentation, symbols (`.snupkg`), README in the package.
- Tests: 23 unit tests without network (fake `HttpMessageHandler`, event stream fed by the test:
  partial lines, time limit, interrupt, cancellation) and 8 integration tests against openHAB
  (including a quiet event stream for 6 minutes, `OPENHAB_LONG=1`).

## Notes on openHAB

- `GET /rest/sitemaps/events/{id}` sends its response headers only with the first event; a
  stream therefore opens without a read timeout.
- `rrd4j` does not list its items (`GET /rest/persistence/items?serviceId=rrd4j` → 405) and does
  not accept stored values (400) – for tests `inmemory` is used.
