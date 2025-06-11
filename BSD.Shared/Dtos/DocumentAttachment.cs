namespace BSD.Shared.Dtos;

public class DocumentAttachment
{
    public long Id { get; set; }
    public long? DocumentId { get; set; }
    public string? Description { get; set; }
    public string? StorageFileUrl { get; set; }
}