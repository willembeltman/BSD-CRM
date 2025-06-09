using Storage.Shared.Dtos;

namespace Storage.Proxy;

public class StorageServerConfig
{
    public static StorageServerConfig? Instance { get; set; }

    public string? ServerUrl { get; set; }
    public Credential? Credential { get; set; }
}
