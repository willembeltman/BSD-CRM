using CodeGenerator.Shared.Attributes;
using CodeGenerator.Shared.Helpers;
using CodeGenerator.Shared.Interfaces;
using System.Reflection;

namespace CodeGenerator.DtoConvertersAndServices.Entities;

public class EntityProperty : IProperty
{
    public EntityProperty(Entity entity, PropertyInfo propertyInfo)
    {
        Entity = entity;
        PropertyInfo = propertyInfo;
        Name = propertyInfo.Name;
        IsReadOnly = !propertyInfo.CanWrite;
        IsName = propertyInfo
            .GetCustomAttribute<NameAttribute>() != null;
        IsHidden = propertyInfo
            .GetCustomAttribute<HiddenAttribute>() != null;
        Type = ReflectionHelper
            .GetUnderlyingType(propertyInfo.PropertyType, this);
    }

    public Entity Entity { get; }
    public PropertyInfo PropertyInfo { get; }
    public string Name { get; }
    public bool IsReadOnly { get; }
    public bool IsName { get; }
    public bool IsHidden { get; }
    public Type Type { get; }

    public bool IsAsync { get; set; }
    public bool IsNullable { get; set; }
    public bool IsIEnumerable { get; set; }
    public bool IsICollection { get; set; }
    public bool IsList { get; set; }
    public bool IsArray { get; set; }
    public bool IsLijst { get; set; }

    public DbSet? DbSet => Entity.DbSet.ApplicationDbContext.DbSets
        .FirstOrDefault(DbSet => DbSet.Type == Type);
}