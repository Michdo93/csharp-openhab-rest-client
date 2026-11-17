// Generated from python-openhab-rest-client by tools/py2cs.py – do not edit.
#pragma warning disable CS1998, CS0168, CS0219, IDE0059
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using OpenHABRestClient.Internal;

namespace OpenHABRestClient
{
    /// <summary>
    /// openHAB REST API: Events.
    /// </summary>
    public sealed class Events
    {
        readonly OpenHABClient _client;

        /// <summary>Creates the Events class for a connected client.</summary>
        public Events(OpenHABClient client) => _client = client;

        /// <summary>
        /// Get all available events, optionally filtered by topic.
        /// </summary>
        /// <param name="topics">A comma-separated list of topics to filter the events by (e.g. "openhab/items/*/statechanged,openhab/things/*/statuschanged"). The wildcard * also matches slashes.</param>
        /// <returns>A SSE stream of events (requests.Response) or {"error": ...}.</returns>
        public EventStream GetEvents(string? topics = null)
            => R.FinishStream(() => getEvents_S(_client, R.Arg(topics)));

        /// <summary>Asynchronous <see cref="GetEvents"/>.</summary>
        public Task<EventStream> GetEventsAsync(string? topics = null,
                                                CancellationToken cancellationToken = default)
            => R.FinishStreamAsync(() => getEvents_A(_client, cancellationToken, R.Arg(topics)));

        /// <summary>
        /// Initiates a new item state tracker connection.
        ///
        /// The first event of the stream carries the connection ID, which is needed for
        /// updateSSEConnectionItems().
        /// </summary>
        /// <returns>A SSE stream (requests.Response) or {"error": ...}.</returns>
        public EventStream InitiateStateTracker()
            => R.FinishStream(() => initiateStateTracker_S(_client));

        /// <summary>Asynchronous <see cref="InitiateStateTracker"/>.</summary>
        public Task<EventStream> InitiateStateTrackerAsync(CancellationToken cancellationToken = default)
            => R.FinishStreamAsync(() => initiateStateTracker_A(_client, cancellationToken));

        /// <summary>
        /// Changes the list of items a SSE connection will receive state updates for.
        /// </summary>
        /// <param name="connectionID">The ID of the existing connection.</param>
        /// <param name="items">A list of item names to subscribe to for state updates.</param>
        /// <returns>A success message when the update is completed.</returns>
        public JsonNode? UpdateSSEConnectionItems(string connectionID, object items)
            => R.Finish(() => updateSSEConnectionItems_S(_client, R.Arg(connectionID), R.Arg(items)));

        /// <summary>Asynchronous <see cref="UpdateSSEConnectionItems"/>.</summary>
        public Task<JsonNode?> UpdateSSEConnectionItemsAsync(string connectionID, object items,
                                                             CancellationToken cancellationToken = default)
            => R.FinishAsync(() => updateSSEConnectionItems_A(_client, cancellationToken, R.Arg(connectionID), R.Arg(items)));

        static EventStream getEvents_S(OpenHABClient C, V v_topics)
        {
            return R.OpenStream(C, v_topics, V.None, V.None, R.Dict(("400", R.S("Topic is empty or contains invalid characters."))));
        }

        static async Task<EventStream> getEvents_A(OpenHABClient C, CancellationToken ct, V v_topics)
        {
            return (await R.OpenStreamAsync(C, v_topics, V.None, V.None, R.Dict(("400", R.S("Topic is empty or contains invalid characters."))), ct).ConfigureAwait(false));
        }

        static EventStream initiateStateTracker_S(OpenHABClient C)
        {
            return R.OpenStream(C, V.None, R.S("/rest/events/states"), R.Dict(("Accept", R.S("*/*"))), V.None);
        }

        static async Task<EventStream> initiateStateTracker_A(OpenHABClient C, CancellationToken ct)
        {
            return (await R.OpenStreamAsync(C, V.None, R.S("/rest/events/states"), R.Dict(("Accept", R.S("*/*"))), V.None, ct).ConfigureAwait(false));
        }

        static V updateSSEConnectionItems_S(OpenHABClient C, V v_connectionID, V v_items)
        {
            V v_response = V.None;
            V v_statusCode = V.None;
            try
            {
                v_response = R.Http(C, "post", R.Cat(R.S("/events/states/"), v_connectionID), R.Dict(("Content-Type", R.S("application/json"))), R.Dumps(v_items), V.None);
                if (R.IsStatus(v_response))
                {
                    v_statusCode = R.Get(v_response, R.S("status"));
                }
                else
                {
                    return v_response;
                }
            }
            catch (HttpError e_err)
            {
                v_statusCode = R.ExcStatus(e_err);
                if (R.Eq(v_statusCode, R.I(404)))
                {
                    return R.Dict(("error", R.S("Unknown connectionID.")));
                }
                return R.Dict(("error", R.Cat(R.S("HTTP error "), v_statusCode, R.S(": "), R.ExcStr(e_err))));
            }
            catch (RequestException e_err)
            {
                return R.Dict(("error", R.Cat(R.S("Request error: "), R.ExcStr(e_err))));
            }
            if (R.Eq(v_statusCode, R.I(200)))
            {
                return R.Dict(("message", R.S("OK")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_statusCode)));
        }

        static async Task<V> updateSSEConnectionItems_A(OpenHABClient C, CancellationToken ct,
                                                        V v_connectionID, V v_items)
        {
            V v_response = V.None;
            V v_statusCode = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "post", R.Cat(R.S("/events/states/"), v_connectionID), R.Dict(("Content-Type", R.S("application/json"))), R.Dumps(v_items), V.None, ct).ConfigureAwait(false));
                if (R.IsStatus(v_response))
                {
                    v_statusCode = R.Get(v_response, R.S("status"));
                }
                else
                {
                    return v_response;
                }
            }
            catch (HttpError e_err)
            {
                v_statusCode = R.ExcStatus(e_err);
                if (R.Eq(v_statusCode, R.I(404)))
                {
                    return R.Dict(("error", R.S("Unknown connectionID.")));
                }
                return R.Dict(("error", R.Cat(R.S("HTTP error "), v_statusCode, R.S(": "), R.ExcStr(e_err))));
            }
            catch (RequestException e_err)
            {
                return R.Dict(("error", R.Cat(R.S("Request error: "), R.ExcStr(e_err))));
            }
            if (R.Eq(v_statusCode, R.I(200)))
            {
                return R.Dict(("message", R.S("OK")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_statusCode)));
        }
    }

    /// <summary>
    /// openHAB REST API: ItemEvents.
    /// </summary>
    public sealed class ItemEvents
    {
        readonly OpenHABClient _client;

        /// <summary>Creates the ItemEvents class for a connected client.</summary>
        public ItemEvents(OpenHABClient client) => _client = client;

        /// <summary>
        /// Get all item-related events.
        /// </summary>
        /// <returns>A SSE stream of item events.</returns>
        public EventStream ItemEvent()
            => R.FinishStream(() => ItemEvent_S(_client));

        /// <summary>Asynchronous <see cref="ItemEvent"/>.</summary>
        public Task<EventStream> ItemEventAsync(CancellationToken cancellationToken = default)
            => R.FinishStreamAsync(() => ItemEvent_A(_client, cancellationToken));

        /// <summary>
        /// Get events for added items.
        /// </summary>
        /// <param name="itemName">The name of the item (default is "*").</param>
        /// <returns>A SSE stream of added item events.</returns>
        public EventStream ItemAddedEvent(string itemName = "*")
            => R.FinishStream(() => ItemAddedEvent_S(_client, R.Arg(itemName)));

        /// <summary>Asynchronous <see cref="ItemAddedEvent"/>.</summary>
        public Task<EventStream> ItemAddedEventAsync(string itemName = "*",
                                                     CancellationToken cancellationToken = default)
            => R.FinishStreamAsync(() => ItemAddedEvent_A(_client, cancellationToken, R.Arg(itemName)));

        /// <summary>
        /// Get events for removed items.
        /// </summary>
        /// <param name="itemName">The name of the item (default is "*").</param>
        /// <returns>A SSE stream of removed item events.</returns>
        public EventStream ItemRemovedEvent(string itemName = "*")
            => R.FinishStream(() => ItemRemovedEvent_S(_client, R.Arg(itemName)));

        /// <summary>Asynchronous <see cref="ItemRemovedEvent"/>.</summary>
        public Task<EventStream> ItemRemovedEventAsync(string itemName = "*",
                                                       CancellationToken cancellationToken = default)
            => R.FinishStreamAsync(() => ItemRemovedEvent_A(_client, cancellationToken, R.Arg(itemName)));

        /// <summary>
        /// Get events for updated items.
        /// </summary>
        /// <param name="itemName">The name of the item (default is "*").</param>
        /// <returns>A SSE stream of updated item events.</returns>
        public EventStream ItemUpdatedEvent(string itemName = "*")
            => R.FinishStream(() => ItemUpdatedEvent_S(_client, R.Arg(itemName)));

        /// <summary>Asynchronous <see cref="ItemUpdatedEvent"/>.</summary>
        public Task<EventStream> ItemUpdatedEventAsync(string itemName = "*",
                                                       CancellationToken cancellationToken = default)
            => R.FinishStreamAsync(() => ItemUpdatedEvent_A(_client, cancellationToken, R.Arg(itemName)));

        /// <summary>
        /// Get events for item commands.
        /// </summary>
        /// <param name="itemName">The name of the item (default is "*").</param>
        /// <returns>A SSE stream of item command events.</returns>
        public EventStream ItemCommandEvent(string itemName = "*")
            => R.FinishStream(() => ItemCommandEvent_S(_client, R.Arg(itemName)));

        /// <summary>Asynchronous <see cref="ItemCommandEvent"/>.</summary>
        public Task<EventStream> ItemCommandEventAsync(string itemName = "*",
                                                       CancellationToken cancellationToken = default)
            => R.FinishStreamAsync(() => ItemCommandEvent_A(_client, cancellationToken, R.Arg(itemName)));

        /// <summary>
        /// Get events for item state updates.
        /// </summary>
        /// <param name="itemName">The name of the item (default is "*").</param>
        /// <returns>A SSE stream of item state events.</returns>
        public EventStream ItemStateEvent(string itemName = "*")
            => R.FinishStream(() => ItemStateEvent_S(_client, R.Arg(itemName)));

        /// <summary>Asynchronous <see cref="ItemStateEvent"/>.</summary>
        public Task<EventStream> ItemStateEventAsync(string itemName = "*",
                                                     CancellationToken cancellationToken = default)
            => R.FinishStreamAsync(() => ItemStateEvent_A(_client, cancellationToken, R.Arg(itemName)));

        /// <summary>
        /// Get events for predicted item state changes.
        /// </summary>
        /// <param name="itemName">The name of the item (default is "*").</param>
        /// <returns>A SSE stream of item state predicted events.</returns>
        public EventStream ItemStatePredictedEvent(string itemName = "*")
            => R.FinishStream(() => ItemStatePredictedEvent_S(_client, R.Arg(itemName)));

        /// <summary>Asynchronous <see cref="ItemStatePredictedEvent"/>.</summary>
        public Task<EventStream> ItemStatePredictedEventAsync(string itemName = "*",
                                                              CancellationToken cancellationToken = default)
            => R.FinishStreamAsync(() => ItemStatePredictedEvent_A(_client, cancellationToken, R.Arg(itemName)));

        /// <summary>
        /// Get events for item state changes.
        ///
        /// Note: with the default "*", state changes of group items are included as
        /// well, because their topic openhab/items/&lt;group&gt;/&lt;member&gt;/statechanged also
        /// matches the pattern.
        /// </summary>
        /// <param name="itemName">The name of the item (default is "*").</param>
        /// <returns>A SSE stream of item state changed events.</returns>
        public EventStream ItemStateChangedEvent(string itemName = "*")
            => R.FinishStream(() => ItemStateChangedEvent_S(_client, R.Arg(itemName)));

        /// <summary>Asynchronous <see cref="ItemStateChangedEvent"/>.</summary>
        public Task<EventStream> ItemStateChangedEventAsync(string itemName = "*",
                                                            CancellationToken cancellationToken = default)
            => R.FinishStreamAsync(() => ItemStateChangedEvent_A(_client, cancellationToken, R.Arg(itemName)));

        /// <summary>
        /// Get events for state changes of group items.
        /// </summary>
        /// <param name="itemName">The name of the group item (default is "*").</param>
        /// <param name="memberName">The name of the group member that caused the change (default is "*").</param>
        /// <returns>A SSE stream of group item state changed events.</returns>
        public EventStream GroupItemStateChangedEvent(string itemName = "*", string memberName = "*")
            => R.FinishStream(() => GroupItemStateChangedEvent_S(_client, R.Arg(itemName), R.Arg(memberName)));

        /// <summary>Asynchronous <see cref="GroupItemStateChangedEvent"/>.</summary>
        public Task<EventStream> GroupItemStateChangedEventAsync(string itemName = "*",
                                                                 string memberName = "*",
                                                                 CancellationToken cancellationToken = default)
            => R.FinishStreamAsync(() => GroupItemStateChangedEvent_A(_client, cancellationToken, R.Arg(itemName), R.Arg(memberName)));

        static EventStream ItemEvent_S(OpenHABClient C)
        {
            return R.OpenStream(C, R.S("openhab/items/*"), V.None, V.None, V.None);
        }

        static async Task<EventStream> ItemEvent_A(OpenHABClient C, CancellationToken ct)
        {
            return (await R.OpenStreamAsync(C, R.S("openhab/items/*"), V.None, V.None, V.None, ct).ConfigureAwait(false));
        }

        static EventStream ItemAddedEvent_S(OpenHABClient C, V v_itemName)
        {
            return R.OpenStream(C, R.Cat(R.S("openhab/items/"), v_itemName, R.S("/added")), V.None, V.None, V.None);
        }

        static async Task<EventStream> ItemAddedEvent_A(OpenHABClient C, CancellationToken ct, V v_itemName)
        {
            return (await R.OpenStreamAsync(C, R.Cat(R.S("openhab/items/"), v_itemName, R.S("/added")), V.None, V.None, V.None, ct).ConfigureAwait(false));
        }

        static EventStream ItemRemovedEvent_S(OpenHABClient C, V v_itemName)
        {
            return R.OpenStream(C, R.Cat(R.S("openhab/items/"), v_itemName, R.S("/removed")), V.None, V.None, V.None);
        }

        static async Task<EventStream> ItemRemovedEvent_A(OpenHABClient C, CancellationToken ct, V v_itemName)
        {
            return (await R.OpenStreamAsync(C, R.Cat(R.S("openhab/items/"), v_itemName, R.S("/removed")), V.None, V.None, V.None, ct).ConfigureAwait(false));
        }

        static EventStream ItemUpdatedEvent_S(OpenHABClient C, V v_itemName)
        {
            return R.OpenStream(C, R.Cat(R.S("openhab/items/"), v_itemName, R.S("/updated")), V.None, V.None, V.None);
        }

        static async Task<EventStream> ItemUpdatedEvent_A(OpenHABClient C, CancellationToken ct, V v_itemName)
        {
            return (await R.OpenStreamAsync(C, R.Cat(R.S("openhab/items/"), v_itemName, R.S("/updated")), V.None, V.None, V.None, ct).ConfigureAwait(false));
        }

        static EventStream ItemCommandEvent_S(OpenHABClient C, V v_itemName)
        {
            return R.OpenStream(C, R.Cat(R.S("openhab/items/"), v_itemName, R.S("/command")), V.None, V.None, V.None);
        }

        static async Task<EventStream> ItemCommandEvent_A(OpenHABClient C, CancellationToken ct, V v_itemName)
        {
            return (await R.OpenStreamAsync(C, R.Cat(R.S("openhab/items/"), v_itemName, R.S("/command")), V.None, V.None, V.None, ct).ConfigureAwait(false));
        }

        static EventStream ItemStateEvent_S(OpenHABClient C, V v_itemName)
        {
            return R.OpenStream(C, R.Cat(R.S("openhab/items/"), v_itemName, R.S("/state")), V.None, V.None, V.None);
        }

        static async Task<EventStream> ItemStateEvent_A(OpenHABClient C, CancellationToken ct, V v_itemName)
        {
            return (await R.OpenStreamAsync(C, R.Cat(R.S("openhab/items/"), v_itemName, R.S("/state")), V.None, V.None, V.None, ct).ConfigureAwait(false));
        }

        static EventStream ItemStatePredictedEvent_S(OpenHABClient C, V v_itemName)
        {
            return R.OpenStream(C, R.Cat(R.S("openhab/items/"), v_itemName, R.S("/statepredicted")), V.None, V.None, V.None);
        }

        static async Task<EventStream> ItemStatePredictedEvent_A(OpenHABClient C, CancellationToken ct,
                                                                 V v_itemName)
        {
            return (await R.OpenStreamAsync(C, R.Cat(R.S("openhab/items/"), v_itemName, R.S("/statepredicted")), V.None, V.None, V.None, ct).ConfigureAwait(false));
        }

        static EventStream ItemStateChangedEvent_S(OpenHABClient C, V v_itemName)
        {
            return R.OpenStream(C, R.Cat(R.S("openhab/items/"), v_itemName, R.S("/statechanged")), V.None, V.None, V.None);
        }

        static async Task<EventStream> ItemStateChangedEvent_A(OpenHABClient C, CancellationToken ct,
                                                               V v_itemName)
        {
            return (await R.OpenStreamAsync(C, R.Cat(R.S("openhab/items/"), v_itemName, R.S("/statechanged")), V.None, V.None, V.None, ct).ConfigureAwait(false));
        }

        static EventStream GroupItemStateChangedEvent_S(OpenHABClient C, V v_itemName, V v_memberName)
        {
            return R.OpenStream(C, R.Cat(R.S("openhab/items/"), v_itemName, R.S("/"), v_memberName, R.S("/statechanged")), V.None, V.None, V.None);
        }

        static async Task<EventStream> GroupItemStateChangedEvent_A(OpenHABClient C, CancellationToken ct,
                                                                    V v_itemName, V v_memberName)
        {
            return (await R.OpenStreamAsync(C, R.Cat(R.S("openhab/items/"), v_itemName, R.S("/"), v_memberName, R.S("/statechanged")), V.None, V.None, V.None, ct).ConfigureAwait(false));
        }
    }

    /// <summary>
    /// openHAB REST API: ThingEvents.
    /// </summary>
    public sealed class ThingEvents
    {
        readonly OpenHABClient _client;

        /// <summary>Creates the ThingEvents class for a connected client.</summary>
        public ThingEvents(OpenHABClient client) => _client = client;

        /// <summary>
        /// Get events for added things.
        /// </summary>
        /// <param name="thingUID">The UID of the thing (default is "*").</param>
        /// <returns>A SSE stream of added thing events.</returns>
        public EventStream ThingAddedEvent(string thingUID = "*")
            => R.FinishStream(() => ThingAddedEvent_S(_client, R.Arg(thingUID)));

        /// <summary>Asynchronous <see cref="ThingAddedEvent"/>.</summary>
        public Task<EventStream> ThingAddedEventAsync(string thingUID = "*",
                                                      CancellationToken cancellationToken = default)
            => R.FinishStreamAsync(() => ThingAddedEvent_A(_client, cancellationToken, R.Arg(thingUID)));

        /// <summary>
        /// Get events for removed things.
        /// </summary>
        /// <param name="thingUID">The UID of the thing (default is "*").</param>
        /// <returns>A SSE stream of removed thing events.</returns>
        public EventStream ThingRemovedEvent(string thingUID = "*")
            => R.FinishStream(() => ThingRemovedEvent_S(_client, R.Arg(thingUID)));

        /// <summary>Asynchronous <see cref="ThingRemovedEvent"/>.</summary>
        public Task<EventStream> ThingRemovedEventAsync(string thingUID = "*",
                                                        CancellationToken cancellationToken = default)
            => R.FinishStreamAsync(() => ThingRemovedEvent_A(_client, cancellationToken, R.Arg(thingUID)));

        /// <summary>
        /// Get events for updated things.
        /// </summary>
        /// <param name="thingUID">The UID of the thing (default is "*").</param>
        /// <returns>A SSE stream of updated thing events.</returns>
        public EventStream ThingUpdatedEvent(string thingUID = "*")
            => R.FinishStream(() => ThingUpdatedEvent_S(_client, R.Arg(thingUID)));

        /// <summary>Asynchronous <see cref="ThingUpdatedEvent"/>.</summary>
        public Task<EventStream> ThingUpdatedEventAsync(string thingUID = "*",
                                                        CancellationToken cancellationToken = default)
            => R.FinishStreamAsync(() => ThingUpdatedEvent_A(_client, cancellationToken, R.Arg(thingUID)));

        /// <summary>
        /// Get events for thing status information.
        /// </summary>
        /// <param name="thingUID">The UID of the thing (default is "*").</param>
        /// <returns>A SSE stream of thing status information events.</returns>
        public EventStream ThingStatusInfoEvent(string thingUID = "*")
            => R.FinishStream(() => ThingStatusInfoEvent_S(_client, R.Arg(thingUID)));

        /// <summary>Asynchronous <see cref="ThingStatusInfoEvent"/>.</summary>
        public Task<EventStream> ThingStatusInfoEventAsync(string thingUID = "*",
                                                           CancellationToken cancellationToken = default)
            => R.FinishStreamAsync(() => ThingStatusInfoEvent_A(_client, cancellationToken, R.Arg(thingUID)));

        /// <summary>
        /// Get events for thing status information changes.
        /// </summary>
        /// <param name="thingUID">The UID of the thing (default is "*").</param>
        /// <returns>A SSE stream of thing status information changed events.</returns>
        public EventStream ThingStatusInfoChangedEvent(string thingUID = "*")
            => R.FinishStream(() => ThingStatusInfoChangedEvent_S(_client, R.Arg(thingUID)));

        /// <summary>Asynchronous <see cref="ThingStatusInfoChangedEvent"/>.</summary>
        public Task<EventStream> ThingStatusInfoChangedEventAsync(string thingUID = "*",
                                                                  CancellationToken cancellationToken = default)
            => R.FinishStreamAsync(() => ThingStatusInfoChangedEvent_A(_client, cancellationToken, R.Arg(thingUID)));

        static EventStream ThingAddedEvent_S(OpenHABClient C, V v_thingUID)
        {
            return R.OpenStream(C, R.Cat(R.S("openhab/things/"), v_thingUID, R.S("/added")), V.None, V.None, V.None);
        }

        static async Task<EventStream> ThingAddedEvent_A(OpenHABClient C, CancellationToken ct, V v_thingUID)
        {
            return (await R.OpenStreamAsync(C, R.Cat(R.S("openhab/things/"), v_thingUID, R.S("/added")), V.None, V.None, V.None, ct).ConfigureAwait(false));
        }

        static EventStream ThingRemovedEvent_S(OpenHABClient C, V v_thingUID)
        {
            return R.OpenStream(C, R.Cat(R.S("openhab/things/"), v_thingUID, R.S("/removed")), V.None, V.None, V.None);
        }

        static async Task<EventStream> ThingRemovedEvent_A(OpenHABClient C, CancellationToken ct,
                                                           V v_thingUID)
        {
            return (await R.OpenStreamAsync(C, R.Cat(R.S("openhab/things/"), v_thingUID, R.S("/removed")), V.None, V.None, V.None, ct).ConfigureAwait(false));
        }

        static EventStream ThingUpdatedEvent_S(OpenHABClient C, V v_thingUID)
        {
            return R.OpenStream(C, R.Cat(R.S("openhab/things/"), v_thingUID, R.S("/updated")), V.None, V.None, V.None);
        }

        static async Task<EventStream> ThingUpdatedEvent_A(OpenHABClient C, CancellationToken ct,
                                                           V v_thingUID)
        {
            return (await R.OpenStreamAsync(C, R.Cat(R.S("openhab/things/"), v_thingUID, R.S("/updated")), V.None, V.None, V.None, ct).ConfigureAwait(false));
        }

        static EventStream ThingStatusInfoEvent_S(OpenHABClient C, V v_thingUID)
        {
            return R.OpenStream(C, R.Cat(R.S("openhab/things/"), v_thingUID, R.S("/status")), V.None, V.None, V.None);
        }

        static async Task<EventStream> ThingStatusInfoEvent_A(OpenHABClient C, CancellationToken ct,
                                                              V v_thingUID)
        {
            return (await R.OpenStreamAsync(C, R.Cat(R.S("openhab/things/"), v_thingUID, R.S("/status")), V.None, V.None, V.None, ct).ConfigureAwait(false));
        }

        static EventStream ThingStatusInfoChangedEvent_S(OpenHABClient C, V v_thingUID)
        {
            return R.OpenStream(C, R.Cat(R.S("openhab/things/"), v_thingUID, R.S("/statuschanged")), V.None, V.None, V.None);
        }

        static async Task<EventStream> ThingStatusInfoChangedEvent_A(OpenHABClient C, CancellationToken ct,
                                                                     V v_thingUID)
        {
            return (await R.OpenStreamAsync(C, R.Cat(R.S("openhab/things/"), v_thingUID, R.S("/statuschanged")), V.None, V.None, V.None, ct).ConfigureAwait(false));
        }
    }

    /// <summary>
    /// openHAB REST API: InboxEvents.
    /// </summary>
    public sealed class InboxEvents
    {
        readonly OpenHABClient _client;

        /// <summary>Creates the InboxEvents class for a connected client.</summary>
        public InboxEvents(OpenHABClient client) => _client = client;

        /// <summary>
        /// Get events for added things in the inbox.
        /// </summary>
        /// <param name="thingUID">The UID of the thing (default is "*").</param>
        /// <returns>A SSE stream of added inbox events.</returns>
        public EventStream InboxAddedEvent(string thingUID = "*")
            => R.FinishStream(() => InboxAddedEvent_S(_client, R.Arg(thingUID)));

        /// <summary>Asynchronous <see cref="InboxAddedEvent"/>.</summary>
        public Task<EventStream> InboxAddedEventAsync(string thingUID = "*",
                                                      CancellationToken cancellationToken = default)
            => R.FinishStreamAsync(() => InboxAddedEvent_A(_client, cancellationToken, R.Arg(thingUID)));

        /// <summary>
        /// Get events for removed things in the inbox.
        /// </summary>
        /// <param name="thingUID">The UID of the thing (default is "*").</param>
        /// <returns>A SSE stream of removed inbox events.</returns>
        public EventStream InboxRemovedEvent(string thingUID = "*")
            => R.FinishStream(() => InboxRemovedEvent_S(_client, R.Arg(thingUID)));

        /// <summary>Asynchronous <see cref="InboxRemovedEvent"/>.</summary>
        public Task<EventStream> InboxRemovedEventAsync(string thingUID = "*",
                                                        CancellationToken cancellationToken = default)
            => R.FinishStreamAsync(() => InboxRemovedEvent_A(_client, cancellationToken, R.Arg(thingUID)));

        /// <summary>
        /// Get events for updated things in the inbox.
        /// </summary>
        /// <param name="thingUID">The UID of the thing (default is "*").</param>
        /// <returns>A SSE stream of updated inbox events.</returns>
        public EventStream InboxUpdatedEvent(string thingUID = "*")
            => R.FinishStream(() => InboxUpdatedEvent_S(_client, R.Arg(thingUID)));

        /// <summary>Asynchronous <see cref="InboxUpdatedEvent"/>.</summary>
        public Task<EventStream> InboxUpdatedEventAsync(string thingUID = "*",
                                                        CancellationToken cancellationToken = default)
            => R.FinishStreamAsync(() => InboxUpdatedEvent_A(_client, cancellationToken, R.Arg(thingUID)));

        static EventStream InboxAddedEvent_S(OpenHABClient C, V v_thingUID)
        {
            return R.OpenStream(C, R.Cat(R.S("openhab/inbox/"), v_thingUID, R.S("/added")), V.None, V.None, V.None);
        }

        static async Task<EventStream> InboxAddedEvent_A(OpenHABClient C, CancellationToken ct, V v_thingUID)
        {
            return (await R.OpenStreamAsync(C, R.Cat(R.S("openhab/inbox/"), v_thingUID, R.S("/added")), V.None, V.None, V.None, ct).ConfigureAwait(false));
        }

        static EventStream InboxRemovedEvent_S(OpenHABClient C, V v_thingUID)
        {
            return R.OpenStream(C, R.Cat(R.S("openhab/inbox/"), v_thingUID, R.S("/removed")), V.None, V.None, V.None);
        }

        static async Task<EventStream> InboxRemovedEvent_A(OpenHABClient C, CancellationToken ct,
                                                           V v_thingUID)
        {
            return (await R.OpenStreamAsync(C, R.Cat(R.S("openhab/inbox/"), v_thingUID, R.S("/removed")), V.None, V.None, V.None, ct).ConfigureAwait(false));
        }

        static EventStream InboxUpdatedEvent_S(OpenHABClient C, V v_thingUID)
        {
            return R.OpenStream(C, R.Cat(R.S("openhab/inbox/"), v_thingUID, R.S("/updated")), V.None, V.None, V.None);
        }

        static async Task<EventStream> InboxUpdatedEvent_A(OpenHABClient C, CancellationToken ct,
                                                           V v_thingUID)
        {
            return (await R.OpenStreamAsync(C, R.Cat(R.S("openhab/inbox/"), v_thingUID, R.S("/updated")), V.None, V.None, V.None, ct).ConfigureAwait(false));
        }
    }

    /// <summary>
    /// openHAB REST API: LinkEvents.
    /// </summary>
    public sealed class LinkEvents
    {
        readonly OpenHABClient _client;

        /// <summary>Creates the LinkEvents class for a connected client.</summary>
        public LinkEvents(OpenHABClient client) => _client = client;

        /// <summary>
        /// Get events for added item-channel links.
        /// </summary>
        /// <param name="itemName">The name of the item (default is "*").</param>
        /// <param name="channelUID">The UID of the channel (default is "*").</param>
        /// <returns>A SSE stream of added item-channel link events.</returns>
        public EventStream ItemChannelLinkAddedEvent(string itemName = "*", string channelUID = "*")
            => R.FinishStream(() => ItemChannelLinkAddedEvent_S(_client, R.Arg(itemName), R.Arg(channelUID)));

        /// <summary>Asynchronous <see cref="ItemChannelLinkAddedEvent"/>.</summary>
        public Task<EventStream> ItemChannelLinkAddedEventAsync(string itemName = "*",
                                                                string channelUID = "*",
                                                                CancellationToken cancellationToken = default)
            => R.FinishStreamAsync(() => ItemChannelLinkAddedEvent_A(_client, cancellationToken, R.Arg(itemName), R.Arg(channelUID)));

        /// <summary>
        /// Get events for removed item-channel links.
        /// </summary>
        /// <param name="itemName">The name of the item (default is "*").</param>
        /// <param name="channelUID">The UID of the channel (default is "*").</param>
        /// <returns>A SSE stream of removed item-channel link events.</returns>
        public EventStream ItemChannelLinkRemovedEvent(string itemName = "*", string channelUID = "*")
            => R.FinishStream(() => ItemChannelLinkRemovedEvent_S(_client, R.Arg(itemName), R.Arg(channelUID)));

        /// <summary>Asynchronous <see cref="ItemChannelLinkRemovedEvent"/>.</summary>
        public Task<EventStream> ItemChannelLinkRemovedEventAsync(string itemName = "*",
                                                                  string channelUID = "*",
                                                                  CancellationToken cancellationToken = default)
            => R.FinishStreamAsync(() => ItemChannelLinkRemovedEvent_A(_client, cancellationToken, R.Arg(itemName), R.Arg(channelUID)));

        static EventStream ItemChannelLinkAddedEvent_S(OpenHABClient C, V v_itemName, V v_channelUID)
        {
            return R.OpenStream(C, R.Cat(R.S("openhab/links/"), v_itemName, R.S("-"), v_channelUID, R.S("/added")), V.None, V.None, V.None);
        }

        static async Task<EventStream> ItemChannelLinkAddedEvent_A(OpenHABClient C, CancellationToken ct,
                                                                   V v_itemName, V v_channelUID)
        {
            return (await R.OpenStreamAsync(C, R.Cat(R.S("openhab/links/"), v_itemName, R.S("-"), v_channelUID, R.S("/added")), V.None, V.None, V.None, ct).ConfigureAwait(false));
        }

        static EventStream ItemChannelLinkRemovedEvent_S(OpenHABClient C, V v_itemName, V v_channelUID)
        {
            return R.OpenStream(C, R.Cat(R.S("openhab/links/"), v_itemName, R.S("-"), v_channelUID, R.S("/removed")), V.None, V.None, V.None);
        }

        static async Task<EventStream> ItemChannelLinkRemovedEvent_A(OpenHABClient C, CancellationToken ct,
                                                                     V v_itemName, V v_channelUID)
        {
            return (await R.OpenStreamAsync(C, R.Cat(R.S("openhab/links/"), v_itemName, R.S("-"), v_channelUID, R.S("/removed")), V.None, V.None, V.None, ct).ConfigureAwait(false));
        }
    }

    /// <summary>
    /// openHAB REST API: ChannelEvents.
    /// </summary>
    public sealed class ChannelEvents
    {
        readonly OpenHABClient _client;

        /// <summary>Creates the ChannelEvents class for a connected client.</summary>
        public ChannelEvents(OpenHABClient client) => _client = client;

        /// <summary>
        /// Get events for changes in channel descriptions.
        /// </summary>
        /// <param name="channelUID">The UID of the channel (default is "*").</param>
        /// <returns>A SSE stream of channel description changed events.</returns>
        public EventStream ChannelDescriptionChangedEvent(string channelUID = "*")
            => R.FinishStream(() => ChannelDescriptionChangedEvent_S(_client, R.Arg(channelUID)));

        /// <summary>Asynchronous <see cref="ChannelDescriptionChangedEvent"/>.</summary>
        public Task<EventStream> ChannelDescriptionChangedEventAsync(string channelUID = "*",
                                                                     CancellationToken cancellationToken = default)
            => R.FinishStreamAsync(() => ChannelDescriptionChangedEvent_A(_client, cancellationToken, R.Arg(channelUID)));

        /// <summary>
        /// Get events for triggered channels.
        /// </summary>
        /// <param name="channelUID">The UID of the channel (default is "*").</param>
        /// <returns>A SSE stream of channel triggered events.</returns>
        public EventStream ChannelTriggeredEvent(string channelUID = "*")
            => R.FinishStream(() => ChannelTriggeredEvent_S(_client, R.Arg(channelUID)));

        /// <summary>Asynchronous <see cref="ChannelTriggeredEvent"/>.</summary>
        public Task<EventStream> ChannelTriggeredEventAsync(string channelUID = "*",
                                                            CancellationToken cancellationToken = default)
            => R.FinishStreamAsync(() => ChannelTriggeredEvent_A(_client, cancellationToken, R.Arg(channelUID)));

        static EventStream ChannelDescriptionChangedEvent_S(OpenHABClient C, V v_channelUID)
        {
            return R.OpenStream(C, R.Cat(R.S("openhab/channels/"), v_channelUID, R.S("/descriptionchanged")), V.None, V.None, V.None);
        }

        static async Task<EventStream> ChannelDescriptionChangedEvent_A(OpenHABClient C, CancellationToken ct,
                                                                        V v_channelUID)
        {
            return (await R.OpenStreamAsync(C, R.Cat(R.S("openhab/channels/"), v_channelUID, R.S("/descriptionchanged")), V.None, V.None, V.None, ct).ConfigureAwait(false));
        }

        static EventStream ChannelTriggeredEvent_S(OpenHABClient C, V v_channelUID)
        {
            return R.OpenStream(C, R.Cat(R.S("openhab/channels/"), v_channelUID, R.S("/triggered")), V.None, V.None, V.None);
        }

        static async Task<EventStream> ChannelTriggeredEvent_A(OpenHABClient C, CancellationToken ct,
                                                               V v_channelUID)
        {
            return (await R.OpenStreamAsync(C, R.Cat(R.S("openhab/channels/"), v_channelUID, R.S("/triggered")), V.None, V.None, V.None, ct).ConfigureAwait(false));
        }
    }
}
