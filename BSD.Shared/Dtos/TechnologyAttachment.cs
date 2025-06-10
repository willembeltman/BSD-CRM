using System;

namespace BSD.Shared.Dtos;

public class TechnologyAttachment
{
    public long Id { get; set; }
    public long TechnologyId { get; set; }
    public string? StorageFileName { get; set; }
    public long? StorageLength { get; set; }
    public string? StorageMimeType { get; set; }
    public string StorageFolder { get; set; } = string.Empty;
    public string? StorageFileUrl { get; set; }
}