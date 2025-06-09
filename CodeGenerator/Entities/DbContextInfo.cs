namespace CodeGenerator.Entities
{
    public class DbContextInfo
    {
        static string dbsetnamestart = "Microsoft.EntityFrameworkCore.DbSet`1[[";

        public DbContextInfo(Type dbContextType)
        {
            Name = dbContextType.Name;
            Type = dbContextType;
            var properties = dbContextType
                .GetProperties();
            DbSetInfos = properties
                .Where(a =>
                    a.PropertyType.FullName != null &&
                    a.PropertyType.FullName.StartsWith(dbsetnamestart, StringComparison.OrdinalIgnoreCase) ||
                    a.Name == "Users")
                .Select(a => new DbSetInfo(this, a))
                .OrderBy(a => a.Name)
                .ToList();
        }

        public string Name { get; set; }
        public Type Type { get; }
        public List<DbSetInfo> DbSetInfos { get; }

        public override string ToString()
        {
            return Name;
        }
    }
}
