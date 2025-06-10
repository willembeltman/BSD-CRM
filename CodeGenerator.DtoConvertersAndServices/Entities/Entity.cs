using CodeGenerator.Shared.Attributes;
using CodeGenerator.Shared.Helpers;
using System.Reflection;

namespace CodeGenerator.DtoConvertersAndServices.Entities;

public class Entity
{
    public Entity(DbSet dbSet, Type type)
    {
        DbSet = dbSet;
        Type = type;
        FullName = type.FullName ?? type.Name;
        Name = type.Name;

        IsStorageFile = ReflectionHelper.IsStorageFile(Type);

        IsHidden = type
            .GetCustomAttribute<HiddenAttribute>() != null;

        Properties = type
            .GetProperties()
            .Where(p => p.CanRead)
            .Select(p => new EntityProperty(this, p))
            .ToArray();

        IsAuthorize = type
            .GetCustomAttribute<AuthorizeAttribute>() != null;
    }

    public DbSet DbSet { get; }
    public Type Type { get; }
    public string FullName { get; }
    public string Name { get; }
    public bool IsStorageFile { get; }
    public bool IsHidden { get; }
    public EntityProperty[] Properties { get; }
    public bool IsAuthorize { get; }

    public IEnumerable<EntityProperty> AllProperties => DbSet.ApplicationDbContext.DbSets
        .SelectMany(dbset => dbset.Entity.Properties)
        .Where(entityProperty => entityProperty.Type == Type);
}