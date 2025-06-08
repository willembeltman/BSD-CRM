namespace StorageServer.Shared.Requests;

public class DownloadRequest : Request
{
    public string Token { get; set; } = string.Empty;
}