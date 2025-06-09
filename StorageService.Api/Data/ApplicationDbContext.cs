using EntityFrameworkZip;
using StorageServer.Data.Entities;

namespace StorageServer.Data;

public class ApplicationDbContext : DbContext
{
    static DirectoryInfo Directory = new DirectoryInfo("Database");

    public virtual DbSet<StorageFolder>? StorageFolders { get; set; }
    public virtual DbSet<StorageFile>? StorageFiles { get; set; }
    public virtual DbSet<StorageFileToken>? StorageFileTokens { get; set; }

    public ApplicationDbContext() : base(Directory)
    {
    }
}
