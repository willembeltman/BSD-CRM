namespace BSD.Shared.Dtos;

public class WorkorderAttachment
{
    public long Id { get; set; }
    public long WorkorderId { get; set; }
    public string? WorkorderName { get; set; }
    public string? StorageFileName { get; set; }
    public long? StorageLength { get; set; }
    public string? StorageMimeType { get; set; }
    public string StorageFolder { get; set; } = string.Empty;
    public string? StorageFileUrl { get; set; }
}