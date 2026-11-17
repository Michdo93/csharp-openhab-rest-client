using System.Diagnostics;
using System.Net;
using System.Text.Json.Nodes;
using Xunit;

namespace OpenHABRestClient.Tests;

public class UnitTests
{
    static (OpenHABClient, FakeHandler) Client(double timeout = 10)
    {
        var h = new FakeHandler();
        return (new OpenHABClient("http://oh.test:8080/", token: "t0k", timeout: timeout, handler: h), h);
    }

    [Fact]
    public void LoginAndToken()
    {
        var (c, h) = Client();
        Assert.True(c.IsLoggedIn);
        Assert.Equal("http://oh.test:8080", c.Url);
        new Items(c).GetItems();
        Assert.Equal("Bearer t0k", h.Requests[0].Headers["Authorization"]);
        Assert.StartsWith("csharp-openhab-rest-client/2.0.0", h.Requests[0].Headers["User-Agent"]);
    }

    [Fact]
    public void BasicAuthWithoutToken()
    {
        var h = new FakeHandler();
        var c = new OpenHABClient("https://myopenhab.org", "me@example.com", "geheim", handler: h);
        Assert.True(c.IsCloud);
        new Items(c).GetItems();
        Assert.Equal("Basic bWVAZXhhbXBsZS5jb206Z2VoZWlt", h.Requests[0].Headers["Authorization"]);
    }

    [Fact]
    public void LoginFails()
    {
        var h = new FakeHandler { Respond = _ => Task.FromResult(FakeHandler.Reply(401)) };
        var c = new OpenHABClient("http://oh.test:8080", token: "falsch", handler: h);
        Assert.False(c.IsLoggedIn);
        Assert.Contains("401", c.LastError);
    }

    [Fact]
    public void QueryParametersLikePython()
    {
        var (c, h) = Client();
        new Items(c).GetItems(tags: "Light", fields: "name,state");
        Assert.Equal("http://oh.test:8080/rest/items?tags=Light&metadata=.%2A&recursive=false&fields=name%2Cstate&staticDataOnly=false",
                     h.Requests[0].Url);
        Assert.Equal("application/json", h.Requests[0].Headers["Accept"]);
    }

    [Fact]
    public void HashInUidIsEncoded()
    {
        var (c, h) = Client();
        new Links(c).GetLink("Licht", "astro:sun:home:rise#start");
        Assert.Contains("/rest/links/Licht/astro%3Asun%3Ahome%3Arise%23start", h.Requests[0].Url);
    }

    [Fact]
    public void SendCommandAsTextPlain()
    {
        var (c, h) = Client();
        var r = new Items(c).SendCommand("Wohnzimmer_Licht", "ON");
        Assert.Equal("POST", h.Requests[0].Method);
        Assert.Equal("ON", h.Requests[0].Body);
        Assert.StartsWith("text/plain", h.Requests[0].Headers["Content-Type"]);
        Assert.Equal("""{"message":"OK"}""", r!.ToJsonString());
    }

    [Fact]
    public void ErrorsAreObjectsNotExceptions()
    {
        var (c, h) = Client();
        h.Respond = _ => Task.FromResult(FakeHandler.Reply(404, """{"error":{"message":"Item X does not exist!","http-code":404}}"""));
        var r = new Items(c).SendCommand("X", "ON");
        Assert.True(r.IsError());
        Assert.Equal("Item not found.", r.ErrorMessage());
        var raw = c.Get("/items/X");
        Assert.Equal("HTTP error 404: 404 Client Error: Not Found for url: http://oh.test:8080/rest/items/X (Item X does not exist!)",
                     raw.ErrorMessage());
    }

    [Fact]
    public void StoreItemDataSendsStateAsQuery()
    {
        var (c, h) = Client();
        new Persistence(c).StoreItemData("Temp", "2026-11-06T10:00:00.000Z", "19.5", "inmemory");
        Assert.Equal("PUT", h.Requests[0].Method);
        Assert.Contains("state=19.5", h.Requests[0].Url);
        Assert.Equal("", h.Requests[0].Body);
    }

    [Fact]
    public void DeleteAllLinksAcceptsJson()
    {
        var (c, h) = Client();
        new Links(c).DeleteAllLinks("Licht");
        Assert.Equal("application/json", h.Requests[0].Headers["Accept"]);
    }

    [Fact]
    public void BindingInfoPath()
    {
        var (c, h) = Client();
        new Discovery(c).GetBindingInfo("astro");
        Assert.Equal("http://oh.test:8080/rest/discovery/bindings/astro/info", h.Requests[0].Url);
    }

    [Fact]
    public void ObjectsBecomeJson()
    {
        var (c, h) = Client();
        new Items(c).AddOrUpdateItem("Test", new { type = "Switch", name = "Test", tags = new[] { "Light" } });
        Assert.Equal("""{"type":"Switch","name":"Test","tags":["Light"]}""", h.Requests[0].Body);
        Assert.StartsWith("application/json", h.Requests[0].Headers["Content-Type"]);
    }

    [Fact]
    public void JsonKeepsOrderAndText()
    {
        var (c, h) = Client();
        h.Respond = _ => Task.FromResult(FakeHandler.Reply(200, """{"state":"21.5 °C","name":"T"}"""));
        Assert.Equal("""{"state":"21.5 °C","name":"T"}""", c.Get("/items/T")!.ToJsonString(
            new System.Text.Json.JsonSerializerOptions { Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping }));
        h.Respond = _ => Task.FromResult(FakeHandler.Reply(200, "ON", "text/plain"));
        Assert.Equal("ON", new Items(c).GetItemState("Licht").Str());
        h.Respond = _ => { var r = FakeHandler.Reply(201); r.Headers.Location = new Uri("rules/x", UriKind.Relative); return Task.FromResult(r); };
        Assert.Equal("""{"status":201,"location":"rules/x"}""", c.Post("/rules", data: "{}")!.ToJsonString());
    }

    [Fact]
    public void TimeoutIsReported()
    {
        var (c, h) = Client(timeout: 0.3);
        h.Respond = async r => { await Task.Delay(5000); return FakeHandler.Reply(200); };
        var sw = Stopwatch.StartNew();
        var r = new Items(c).GetItems();
        Assert.True(sw.ElapsedMilliseconds < 3000);
        Assert.StartsWith("Request error: ", r.ErrorMessage());
    }

    [Fact]
    public async Task AsyncGivesTheSameResult()
    {
        var (c, h) = Client();
        h.Respond = _ => Task.FromResult(FakeHandler.Reply(404, ""));
        var s = new Rules(c).GetRule("x");
        var a = await new Rules(c).GetRuleAsync("x");
        Assert.Equal(s!.ToJsonString(), a!.ToJsonString());
        Assert.Equal(h.Requests[0].Url, h.Requests[1].Url);
    }

    [Fact]
    public async Task CancellationTokenIsHonoured()
    {
        var (c, h) = Client();
        h.Respond = async r => { await Task.Delay(5000); return FakeHandler.Reply(200); };
        using var cts = new CancellationTokenSource(200);
        await Assert.ThrowsAnyAsync<OperationCanceledException>(() => new Items(c).GetItemsAsync(cancellationToken: cts.Token));
    }

    // ── event streams ────────────────────────────────────────────────────

    static (OpenHABClient, FakeHandler, FeedStream) StreamClient()
    {
        var (c, h) = Client();
        var feed = new FeedStream();
        h.Respond = r =>
        {
            if (!r.RequestUri!.AbsolutePath.StartsWith("/rest/events")) return Task.FromResult(FakeHandler.Reply(200));
            var resp = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StreamContent(feed) };
            resp.Content.Headers.ContentType = new("text/event-stream");
            return Task.FromResult(resp);
        };
        return (c, h, feed);
    }

    const string Changed = "data: {\"topic\":\"openhab/items/Licht/statechanged\",\"payload\":\"{\\\"type\\\":\\\"OnOff\\\",\\\"value\\\":\\\"ON\\\",\\\"oldType\\\":\\\"OnOff\\\",\\\"oldValue\\\":\\\"OFF\\\"}\",\"type\":\"ItemStateChangedEvent\"}\n\n";

    [Fact]
    public void EventsWithDecodedPayload()
    {
        var (c, h, feed) = StreamClient();
        using var s = new ItemEvents(c).ItemStateChangedEvent("Licht");
        Assert.False(s.IsError);
        Assert.Contains("topics=openhab%2Fitems%2FLicht%2Fstatechanged", h.Requests[^1].Url);
        Assert.Equal("text/event-stream", h.Requests[^1].Headers["Accept"]);
        feed.Write("data: {\"type\":\"ALIVE\",\"interval\":10}\n\n");
        feed.Write(Changed.Substring(0, 40));                 // half a line
        Assert.Null(s.NextEvent(TimeSpan.FromMilliseconds(200)));
        feed.Write(Changed.Substring(40));
        var e = s.NextEvent(TimeSpan.FromSeconds(2));
        Assert.Equal("ON", e.Str("payload.value"));
        Assert.Equal("ItemStateChangedEvent", e.Str("type"));
    }

    [Fact]
    public void TimeLimitHoldsWithoutEvents()
    {
        var (c, _, _) = StreamClient();
        using var s = new Events(c).GetEvents();
        var sw = Stopwatch.StartNew();
        Assert.Null(s.NextEvent(TimeSpan.FromMilliseconds(500)));
        Assert.InRange(sw.ElapsedMilliseconds, 450, 2000);
        Assert.True(s.IsOpen);
    }

    [Fact]
    public async Task AwaitForeachAndInterrupt()
    {
        var (c, _, feed) = StreamClient();
        await using var s = await new ItemEvents(c).ItemStateChangedEventAsync("Licht");
        feed.Write(Changed + Changed);
        _ = Task.Delay(500).ContinueWith(_ => s.Interrupt());
        var n = 0;
        await foreach (var e in s) n++;
        Assert.Equal(2, n);
        Assert.False(s.IsOpen);
    }

    [Fact]
    public async Task CancelEndsAwaitForeach()
    {
        var (c, _, _) = StreamClient();
        using var s = await new Events(c).GetEventsAsync();
        using var cts = new CancellationTokenSource(300);
        await Assert.ThrowsAnyAsync<OperationCanceledException>(async () =>
        {
            await foreach (var e in s.EventsAsync(cancellationToken: cts.Token)) { }
        });
    }

    [Fact]
    public void StreamEndsWithServer()
    {
        var (c, _, feed) = StreamClient();
        using var s = new Events(c).GetEvents();
        feed.Write(Changed);
        feed.End();
        Assert.Single(s.Events());
        Assert.False(s.IsOpen);
        Assert.False(s.IsError);
    }

    [Fact]
    public void StreamErrorsAreReported()
    {
        var (c, h) = Client();
        h.Respond = _ => Task.FromResult(FakeHandler.Reply(400, ""));
        using var s = new Events(c).GetEvents("");
        Assert.True(s.IsOpen == false);
        h.Respond = _ => Task.FromResult(FakeHandler.Reply(400, ""));
        using var s2 = new Events(c).GetEvents("bad topic");
        Assert.True(s2.IsError);
        Assert.Equal(400, s2.ErrorStatus);
        Assert.Equal("Topic is empty or contains invalid characters.", s2.Error);
        Assert.Equal("Topic is empty or contains invalid characters.", s2.ErrorResult.ErrorMessage());
    }

    [Fact]
    public void ParseData()
    {
        Assert.Null(EventStream.ParseData("event: message"));
        Assert.Equal("ALIVE", EventStream.ParseData("data: {\"type\":\"ALIVE\"}").Str("type"));
        Assert.Equal("OnOff", EventStream.ParseData(Changed.Trim()).Str("payload.type"));
    }

    [Fact]
    public void ResultHelpers()
    {
        var r = JsonNode.Parse("""{"members":[{"name":"A","state":"21.5 °C"}],"ok":true}""");
        Assert.Equal("A", r.Str("members.0.name"));
        Assert.Equal(21.5, r.Num("members.0.state"));
        Assert.True(r.Bool("ok"));
        Assert.Single(r.List("members"));
        Assert.Empty(r.List("gibtsnicht"));
        Assert.False(r.IsError());
        Assert.Equal("", r.ErrorMessage());
        Assert.True(double.IsNaN(r.Num("gibtsnicht")));
    }
}
