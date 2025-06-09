using CodeGenerator.Helpers;

namespace CodeGenerator.Entities;

public class TypeInfo
{
    public TypeInfo(PropertyInfo entityProperty, Type type)
    {
        Parent = entityProperty;

        var dbContext = entityProperty.Parent.Parent.Parent;

        if (type.FullName == null) throw new Exception();

        Async = ReflectionHelper.IsAsync(type);
        if (Async)
        {
            type = type.GenericTypeArguments[0];
        }

        IsNullable = ReflectionHelper.IsNullable(type);
        if (IsNullable && type.GenericTypeArguments.Length > 0)
        {
            type = type.GenericTypeArguments[0];
        }

        var isIEnumerable = ReflectionHelper.IsIEnumerable(type);
        var isArray = ReflectionHelper.IsArray(type);

        IsList = isIEnumerable || isArray;

        if (isIEnumerable)
        {
            type = type.GenericTypeArguments[0];
        }
        if (isArray)
        {
            type = type.GetElementType()!;
        }

        CsFullName = type.FullName!;
        CsName = type.Name!;
        CsNamespace = type.Namespace!;

        if (type.IsEnum)
        {
            IsEnum = true;
            TsName = CsName;
            CsSimpleName = type.Name!;
        }
        else
        {
            DbSet = dbContext.DbSetInfos
                .FirstOrDefault(b => b.Entity.FullName == CsName);
            Entity = DbSet?.Entity;

            // Ken ik het type al?
            if (Entity == null)
            {
                TsName = NameHelper.GetTsType(CsName);
                CsSimpleName = NameHelper.GetSimpleCsType(CsName);
            }
            else
            {
                if (Entity.Namespace == null) throw new Exception();

                CsNamespace = Entity.Namespace;
                CsName = CsName.Substring(
                    CsNamespace.Length + 1,
                    CsName.Length - Entity.Namespace.Length - 1);
                CsSimpleName = CsName;
                TsName = CsName;

                if (!IsList)
                    Key = entityProperty.Parent.Properties.First(a => a.Name == entityProperty.Name + "Id");
            }
        }
    }

    public PropertyInfo Parent { get; }

    public string? CsNamespace { get; }
    public string CsName { get; }
    public bool Async { get; }
    public string CsFullName { get; }
    public string CsSimpleName { get; }
    public PropertyInfo? Key { get; }
    public string TsName { get; }

    public bool IsNullable { get; } = false;
    public bool IsList { get; } = false;
    public bool IsEnum { get; } = false;

    public DbSetInfo? DbSet { get; }
    public EntityInfo? Entity { get; }

    public override string ToString()
    {
        return CsName;
    }

    internal bool HasProperty(EntityInfo[] constrainedEntities)
    {
        if (Entity == null) return false;
        return Entity.Properties
            .Any(a => constrainedEntities.Any(b => a.Type.Entity == b));
    }

    internal bool HasPropertyInParents(EntityInfo[] constrainedEntities)
    {
        if (Entity == null) return false;
        return FindInParents(Entity, constrainedEntities);
    }
    private bool FindInParents(EntityInfo entity, EntityInfo[] entitiesToFind)
    {
        var constrainedProperties2 = entity.Properties
            .Where(a => entitiesToFind.Any(b => a.Type.Entity == b))
            .ToArray();
        if (constrainedProperties2.Any()) return true;

        var parents = entity.Properties
            .Where(a => a.Type.Entity != null && !a.Type.IsList)
            .ToArray();
        foreach (var parent in parents)
        {
            if (parent.Type.Entity == null) continue;
            var found = FindInParents(parent.Type.Entity, entitiesToFind);
            if (found) return true;
        }
        return false;
    }
}
