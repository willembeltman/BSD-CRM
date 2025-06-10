using Microsoft.EntityFrameworkCore;

namespace CodeGenerator.Step1.DtosConvertersAndServices.Entities
{
    public class DbContext
    {
        public DbContext(Type type)
        {
            Type = type;
            FullName = type.FullName ?? type.Name;
            Name = type.Name;
            DbSets = type.GetProperties()
                .Where(p =>
                    p.PropertyType.IsGenericType &&
                    p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
                .Select(p => new DbSet(this, p))
                .ToArray();
        }

        public Type Type { get; }
        public string FullName { get; }
        public string Name { get; }
        internal DbSet[] DbSets { get; }
    }
}