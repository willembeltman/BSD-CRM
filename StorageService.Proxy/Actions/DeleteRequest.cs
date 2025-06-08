namespace StorageServer.Proxy.Actions;

public class DeleteRequest : Request
{
    public bool ThrowIfNotFound { get; set; } = true;
}
