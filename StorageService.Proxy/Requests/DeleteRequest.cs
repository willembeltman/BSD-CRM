namespace StorageServer.Proxy.Requests;

public class DeleteRequest : Request
{
    public bool ThrowIfNotFound { get; set; } = true;
}
