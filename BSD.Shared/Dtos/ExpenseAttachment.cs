namespace BSD.Shared.Dtos;

public class ExpenseAttachment
{
    public long Id { get; set; }
    public long? ExpenseId { get; set; }
    public string? Description { get; set; }
    public string? EmailUniqueId { get; set; }
    public string? StorageFileName { get; set; }
    public long? StorageLength { get; set; }
    public string? StorageMimeType { get; set; }
    public string StorageFolder { get; set; } = string.Empty;
    public string? StorageFileUrl { get; set; }
}