namespace StorageServer.Proxy.Actions;

public class DownloadRequest : Request
{
    public string Token { get; set; } = string.Empty;
}