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

        public IEnumerable<EntityProperty> UserPointers
        {
            get
            {
                return GetList(UserEntity);
            }
        }

        private IEnumerable<EntityProperty> GetList(Entity entity)
        {
            //yield return entity;

            var list = entity
                .Properties
                .Where(p => p.DbSet != null && p.IsLijst == false)
                .ToArray();

            foreach (var item in list)
            {
                yield return item;

                foreach (var subItem in GetList(item.DbSet!.Entity))
                {
                    yield return subItem;
                }
            }
        }
    }
}