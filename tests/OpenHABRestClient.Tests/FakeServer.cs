using System.Net;
using System.Text;

namespace OpenHABRestClient.Tests;

/// <summary>A recorded request.</summary>
public sealed record Seen(string Method, string Url, Dictionary<string, string> Headers, string Body);

/// <summary>Answers requests in memory – no network, no openHAB.</summary>
public sealed class FakeHandler : HttpMessageHandler
{
    public List<Seen> Requests { get; } = new();
    public Func<HttpRequestMessage, Task<HttpResponseMessage>> Respond { get; set; } =
        _ => Task.FromResult(Reply(200));

    public static HttpResponseMessage Reply(int status, string body = "", string type = "application/json")
    {
        var r = new HttpResponseMessage((HttpStatusCode)status) { Content = new StringContent(body, Encoding.UTF8) };
        r.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(type);
        return r;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken ct)
    {
        var h = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        foreach (var x in request.Headers) h[x.Key] = string.Join(",", x.Value);
        var body = "";
        if (request.Content != null)
        {
            foreach (var x in request.Content.Headers) h[x.Key] = string.Join(",", x.Value);
            body = await request.Content.ReadAsStringAsync(ct);
        }
        if (request.RequestUri!.AbsolutePath != "/rest/")
            Requests.Add(new Seen(request.Method.Method, request.RequestUri.AbsoluteUri, h, body));
        var resp = await Respond(request).WaitAsync(ct);
        resp.RequestMessage ??= request;
        return resp;
    }

    protected override HttpResponseMessage Send(HttpRequestMessage request, CancellationToken ct) =>
        SendAsync(request, ct).GetAwaiter().GetResult();
}

/// <summary>An event stream whose lines are written by the test.</summary>
public sealed class FeedStream : Stream
{
    readonly System.Threading.Channels.Channel<byte[]> _ch = System.Threading.Channels.Channel.CreateUnbounded<byte[]>();
    byte[] _cur = Array.Empty<byte>();
    int _pos;

    public void Write(string text) => _ch.Writer.TryWrite(Encoding.UTF8.GetBytes(text));
    public void End() => _ch.Writer.TryComplete();

    public override async ValueTask<int> ReadAsync(Memory<byte> buffer, CancellationToken ct = default)
    {
        if (_pos >= _cur.Length)
        {
            if (!await _ch.Reader.WaitToReadAsync(ct)) return 0;
            _cur = await _ch.Reader.ReadAsync(ct);
            _pos = 0;
        }
        var n = Math.Min(buffer.Length, _cur.Length - _pos);
        _cur.AsMemory(_pos, n).CopyTo(buffer);
        _pos += n;
        return n;
    }

    public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken ct) =>
        ReadAsync(buffer.AsMemory(offset, count), ct).AsTask();
    public override int Read(byte[] buffer, int offset, int count) => ReadAsync(buffer, offset, count, default).Result;
    public override bool CanRead => true;
    public override bool CanSeek => false;
    public override bool CanWrite => false;
    public override long Length => throw new NotSupportedException();
    public override long Position { get => 0; set => throw new NotSupportedException(); }
    public override void Flush() { }
    public override long Seek(long o, SeekOrigin s) => throw new NotSupportedException();
    public override void SetLength(long v) => throw new NotSupportedException();
    public override void Write(byte[] b, int o, int c) => throw new NotSupportedException();
}
