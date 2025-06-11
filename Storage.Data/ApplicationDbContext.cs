using EntityFrameworkZip;
using Storage.Data.Entities;

namespace Storage.Data;

#nullable disable

public class ApplicationDbContext : DbContext
{
    static DirectoryInfo Directory = new DirectoryInfo("Database");

    public DbSet<StorageFolder> StorageFolders { get; set; }
    public DbSet<StorageFile> StorageFiles { get; set; }
    public DbSet<StorageFileToken> StorageFileTokens { get; set; }

    public ApplicationDbContext() : base(Directory)
    {
    }
}