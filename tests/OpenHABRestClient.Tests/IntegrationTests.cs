using System.Text.Json.Nodes;
using Xunit;

namespace OpenHABRestClient.Tests;

/// <summary>
/// Against a real openHAB with the exercise configuration of the book series
/// (OPENHAB_URL, OPENHAB_TOKEN). Without OPENHAB_URL the tests are skipped.
/// </summary>
public class IntegrationTests
{
    static readonly string? Url = Environment.GetEnvironmentVariable("OPENHAB_URL");

    static OpenHABClient Client()
    {
        Assert.SkipWhen(string.IsNullOrEmpty(Url), "OPENHAB_URL is not set");
        return new OpenHABClient(Url!, token: Environment.GetEnvironmentVariable("OPENHAB_TOKEN"));
    }

    [Fact]
    public void Connects()
    {
        using var c = Client();
        Assert.True(c.IsLoggedIn, c.LastError);
        Assert.False(new Systeminfo(c).GetSystemInfo().IsError());
    }

    [Fact]
    public void ItemLifecycle()
    {
        using var c = Client();
        var items = new Items(c);
        items.DeleteItem("CsTest_Schalter");
        var r = items.AddOrUpdateItem("CsTest_Schalter", new { type = "Switch", name = "CsTest_Schalter", label = "Test" });
        Assert.False(r.IsError(), r.ErrorMessage());
        Assert.Equal("OK", items.SendCommand("CsTest_Schalter", "ON").Str("message"));
        Thread.Sleep(300);
        Assert.Equal("ON", items.GetItemState("CsTest_Schalter").Str());
        Assert.Equal("Invalid command for this item.", items.SendCommand("CsTest_Schalter", "BLAU").ErrorMessage());
        Assert.Equal("OK", items.DeleteItem("CsTest_Schalter").Str("message"));
        Assert.True(items.GetItem("CsTest_Schalter").IsError());
    }

    [Fact]
    public async Task CommandArrivesAsEvent()
    {
        using var c = Client();
        var items = new Items(c);
        var before = items.GetItemState("Wohnzimmer_Licht").Str();
        var target = before == "ON" ? "OFF" : "ON";
        await using var s = await new ItemEvents(c).ItemStateChangedEventAsync("Wohnzimmer_Licht");
        Assert.False(s.IsError, s.Error);
        await items.SendCommandAsync("Wohnzimmer_Licht", target);
        var e = await s.NextEventAsync(TimeSpan.FromSeconds(10));
        Assert.Equal(target, e.Str("payload.value"));
        items.SendCommand("Wohnzimmer_Licht", before.Length > 0 && before != "NULL" ? before : "OFF");
    }

    [Fact]
    public void ChannelUidWithHash()
    {
        using var c = Client();
        var items = new Items(c);
        var links = new Links(c);
        items.AddOrUpdateItem("CsTest_Link", new { type = "DateTime", name = "CsTest_Link" });
        Assert.False(links.LinkItemToChannel("CsTest_Link", "astro:sun:zuhause:rise#start", new JsonObject()).IsError());
        Assert.Equal("CsTest_Link", links.GetLink("CsTest_Link", "astro:sun:zuhause:rise#start").Str("itemName"));
        Assert.Equal(1, links.DeleteAllLinks("CsTest_Link").Num("count"));
        items.DeleteItem("CsTest_Link");
    }

    [Fact]
    public void PersistenceStoreAndRead()
    {
        using var c = Client();
        var p = new Persistence(c);
        var t = DateTime.UtcNow.AddMinutes(-30).ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
        Assert.Equal("OK", p.StoreItemData("Werkstatt_Temperatur", t, "19.5", "inmemory").Str("message"));
        var r = p.GetItemPersistenceData("Werkstatt_Temperatur", "inmemory",
            DateTime.UtcNow.AddHours(-1).ToString("yyyy-MM-ddTHH:mm:ss.fffZ"), DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"));
        Assert.Contains(r.List("data"), d => d.Str("state") == "19.5");
        p.DeleteItemData("Werkstatt_Temperatur", DateTime.UtcNow.AddHours(-1).ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
            DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"), "inmemory");
    }

    [Fact]
    public void ErrorsOfUnknownThings()
    {
        using var c = Client();
        Assert.Equal("Thing not found.", new Things(c).GetThing("astro:gibts:nicht").ErrorMessage());
        Assert.Equal("Rule not found.", new Rules(c).GetRule("gibtsnicht").ErrorMessage());
        using var s = new Events(c).GetEvents("");
        Assert.True(s.IsOpen || s.IsError);
    }

    [Fact]
    public void SitemapStream()
    {
        using var c = Client();
        var sitemaps = new Sitemaps(c);
        var id = sitemaps.SubscribeToSitemapEvents().Str("subscriptionID");
        Assert.NotEqual("", id);
        using var s = sitemaps.GetSitemapEvents(id, "restbuch", "restbuch");
        Assert.False(s.IsError, s.Error);
        var e = s.NextEvent(TimeSpan.FromSeconds(10), includeAlive: true);
        Assert.NotNull(e);
    }

    /// <summary>A stream without events stays open longer than 5 minutes (OPENHAB_LONG=1).</summary>
    [Fact]
    public void LongQuietStream()
    {
        Assert.SkipUnless(Environment.GetEnvironmentVariable("OPENHAB_LONG") == "1", "OPENHAB_LONG is not set");
        using var c = Client();
        using var s = new ItemEvents(c).ItemStateChangedEvent("Wohnzimmer_Licht");
        var end = DateTime.UtcNow.AddMinutes(6);
        while (DateTime.UtcNow < end)
        {
            s.NextEvent(TimeSpan.FromSeconds(30));
            Assert.True(s.IsOpen, s.Error ?? "closed");
        }
        var items = new Items(c);
        var before = items.GetItemState("Wohnzimmer_Licht").Str();
        items.SendCommand("Wohnzimmer_Licht", before == "ON" ? "OFF" : "ON");
        Assert.NotNull(s.NextEvent(TimeSpan.FromSeconds(10)));
        items.SendCommand("Wohnzimmer_Licht", before == "ON" ? "ON" : "OFF");
    }
}
