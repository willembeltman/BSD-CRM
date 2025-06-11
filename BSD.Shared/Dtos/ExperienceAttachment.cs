namespace BSD.Shared.Dtos;

public class ExperienceAttachment
{
    public long Id { get; set; }
    public long ExperienceId { get; set; }
    public bool Spotlight { get; set; }
    public string? StorageFileName { get; set; }
    public long? StorageLength { get; set; }
    public string? StorageMimeType { get; set; }
    public string StorageFolder { get; set; } = string.Empty;
    public string? StorageFileUrl { get; set; }
}