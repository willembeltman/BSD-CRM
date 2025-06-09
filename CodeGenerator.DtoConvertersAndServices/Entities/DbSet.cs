
using System.Reflection;

namespace CodeGenerator.DtoConvertersAndServices.Entities;

public class DbSet
{
    public DbSet(DbContext db, PropertyInfo propertyInfo)
    {
        ApplicationDbContext = db;
        PropertyInfo = propertyInfo;
        Type = propertyInfo.PropertyType.GenericTypeArguments[0];
        Name = propertyInfo.Name;
        Entity = new Entity(this, Type);
    }

    public DbContext ApplicationDbContext { get; }
    public PropertyInfo PropertyInfo { get; }
    public Type Type { get; }
    public string Name { get; }
    public Entity Entity { get; }

    public IEnumerable<EntityProperty> AllProperties => Entity.AllProperties;
}