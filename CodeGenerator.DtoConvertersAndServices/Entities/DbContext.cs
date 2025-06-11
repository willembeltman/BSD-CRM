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
        public DbSet[] DbSets { get; }

        public DbSet UserDbSet => DbSets
            .FirstOrDefault(d => d.Entity.IsUser) ?? throw new InvalidOperationException("No User DbSet found.");
        public Entity UserEntity => DbSets
            .Select(a => a.Entity)
            .FirstOrDefault(d => d.IsUser) ?? throw new InvalidOperationException("No User DbSet found.");

        public IEnumerable<EntityProperty> UserPointers =>
            UserEntity
                .Properties
                .Where(p => p.DbSet != null && p.IsLijst == false)
                .ToArray();
    }
}