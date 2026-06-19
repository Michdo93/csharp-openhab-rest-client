using System.Threading.Tasks;
using static OpenHABRestClient.OpenHABClient;

namespace OpenHABRestClient
{
    /// <summary>openHAB General Events SSE API.</summary>
    public class Events
    {
        private readonly OpenHABClient _c;
        public Events(OpenHABClient client) => _c = client;

        public SSEConnection GetEvents(string? topics = null)
            => _c.ExecuteSSE(_c.BaseUrl + "/rest/events" + (topics != null ? $"?topics={topics}" : ""));

        public SSEConnection InitiateStateTracker()
            => _c.ExecuteSSE(_c.BaseUrl + "/rest/events/states");

        public string UpdateSSEConnectionItems(string connectionId, string itemsJson)
            => _c.Post($"/events/states/{connectionId}", H("Content-Type","application/json"), itemsJson);

        public Task<string> UpdateSSEConnectionItemsAsync(string connectionId, string itemsJson)
            => _c.PostAsync($"/events/states/{connectionId}", H("Content-Type","application/json"), itemsJson);
    }

    /// <summary>openHAB Item Events SSE API.</summary>
    public class ItemEvents
    {
        private readonly OpenHABClient _c;
        public ItemEvents(OpenHABClient client) => _c = client;

        private SSEConnection Sse(string topic) => _c.ExecuteSSE(_c.BaseUrl + $"/rest/events?topics={topic}");

        public SSEConnection ItemEvent()                                         => Sse("openhab/items");
        public SSEConnection ItemAddedEvent(string itemName = "*")               => Sse($"openhab/items/{itemName}/added");
        public SSEConnection ItemRemovedEvent(string itemName = "*")             => Sse($"openhab/items/{itemName}/removed");
        public SSEConnection ItemUpdatedEvent(string itemName = "*")             => Sse($"openhab/items/{itemName}/updated");
        public SSEConnection ItemCommandEvent(string itemName = "*")             => Sse($"openhab/items/{itemName}/command");
        public SSEConnection ItemStateEvent(string itemName = "*")               => Sse($"openhab/items/{itemName}/state");
        public SSEConnection ItemStatePredictedEvent(string itemName = "*")      => Sse($"openhab/items/{itemName}/statepredicted");
        public SSEConnection ItemStateChangedEvent(string itemName = "*")        => Sse($"openhab/items/{itemName}/statechanged");
        public SSEConnection GroupItemStateChangedEvent(string item, string mem) => Sse($"openhab/items/{item}/{mem}/statechanged");
    }

    /// <summary>openHAB Thing Events SSE API.</summary>
    public class ThingEvents
    {
        private readonly OpenHABClient _c;
        public ThingEvents(OpenHABClient client) => _c = client;

        private SSEConnection Sse(string topic) => _c.ExecuteSSE(_c.BaseUrl + $"/rest/events?topics={topic}");

        public SSEConnection ThingAddedEvent(string uid = "*")             => Sse($"openhab/things/{uid}/added");
        public SSEConnection ThingRemovedEvent(string uid = "*")           => Sse($"openhab/things/{uid}/removed");
        public SSEConnection ThingUpdatedEvent(string uid = "*")           => Sse($"openhab/things/{uid}/updated");
        public SSEConnection ThingStatusInfoEvent(string uid = "*")        => Sse($"openhab/things/{uid}/status");
        public SSEConnection ThingStatusInfoChangedEvent(string uid = "*") => Sse($"openhab/things/{uid}/statuschanged");
    }

    /// <summary>openHAB Inbox Events SSE API.</summary>
    public class InboxEvents
    {
        private readonly OpenHABClient _c;
        public InboxEvents(OpenHABClient client) => _c = client;

        private SSEConnection Sse(string topic) => _c.ExecuteSSE(_c.BaseUrl + $"/rest/events?topics={topic}");

        public SSEConnection InboxAddedEvent(string uid = "*")   => Sse($"openhab/inbox/{uid}/added");
        public SSEConnection InboxRemovedEvent(string uid = "*") => Sse($"openhab/inbox/{uid}/removed");
        public SSEConnection InboxUpdatedEvent(string uid = "*") => Sse($"openhab/inbox/{uid}/updated");
    }

    /// <summary>openHAB Link Events SSE API.</summary>
    public class LinkEvents
    {
        private readonly OpenHABClient _c;
        public LinkEvents(OpenHABClient client) => _c = client;

        private SSEConnection Sse(string topic) => _c.ExecuteSSE(_c.BaseUrl + $"/rest/events?topics={topic}");

        public SSEConnection ItemChannelLinkAddedEvent(string item = "*", string ch = "*")   => Sse($"openhab/links/{item}-{ch}/added");
        public SSEConnection ItemChannelLinkRemovedEvent(string item = "*", string ch = "*") => Sse($"openhab/links/{item}-{ch}/removed");
    }

    /// <summary>openHAB Channel Events SSE API.</summary>
    public class ChannelEvents
    {
        private readonly OpenHABClient _c;
        public ChannelEvents(OpenHABClient client) => _c = client;

        private SSEConnection Sse(string topic) => _c.ExecuteSSE(_c.BaseUrl + $"/rest/events?topics={topic}");

        public SSEConnection ChannelDescriptionChangedEvent(string uid = "*") => Sse($"openhab/channels/{uid}/descriptionchanged");
        public SSEConnection ChannelTriggeredEvent(string uid = "*")          => Sse($"openhab/channels/{uid}/triggered");
    }
}
