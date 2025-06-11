namespace Storage.Shared.Responses;

public class SaveResponse : Response
{
    public long Length { get; set; }
    public long StorageFileId { get; set; }
    public string EntityId { get; set; } = string.Empty;
    public string? EntityFileName { get; set; }
    public string? FileName { get; set; }
    public string? MimeType { get; set; }
    public string? Sha256 { get; set; }
    public string? Url { get; set; }
}