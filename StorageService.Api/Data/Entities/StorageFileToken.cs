using EntityFrameworkZip;

namespace StorageServer.Data.Entities;

#nullable disable

public class StorageFileToken : IEntity
{
    public long Id { set; get; }
    public long? StorageFileId { set; get; }

    public DateTime DateTime { set; get; } = DateTime.Now;
    public string Token { get; set; } = Guid.NewGuid().ToString().Replace("-", "");

    public virtual ILazy<StorageFile> StorageFile { set; get; }
}