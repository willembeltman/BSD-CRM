using EntityFrameworkZip;

namespace Storage.Data.Entities;

#nullable disable

public class StorageFile : IEntity
{
    public long Id { set; get; }
    public long? StorageFolderId { set; get; }

    public string EntityFileName { set; get; }
    public long EntityId { get; set; }
    public string FileName { get; set; }
    public long Length { set; get; }
    public string MimeType { set; get; }
    public string Sha256 { get; set; }

    public virtual ILazy<StorageFolder> StorageFolder { set; get; }
    public virtual ICollection<StorageFileToken> StorageFileTokens { set; get; }
}