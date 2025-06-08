using EntityFrameworkZip;

namespace StorageServer.Data.Entities;

#nullable disable

public class StorageFolder : IEntity
{
    public long Id { set; get; }
    public string Name { set; get; }
    public virtual ICollection<StorageFile> StorageFiles { set; get; }
}