using CodeGenerator.Shared.Attributes;
using CodeGenerator.Shared.Helpers;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace CodeGenerator.DtoConvertersAndServices.Entities;

public class EntityProperty
{
    public EntityProperty(Entity entity, PropertyInfo propertyInfo)
    {
        PropertyEntity = entity;
        PropertyInfo = propertyInfo;
        PropertyName = propertyInfo.Name;

        IsReadOnly = !propertyInfo.CanWrite;
        IsKey = propertyInfo
            .GetCustomAttribute<KeyAttribute>() != null;
        IsName = propertyInfo
            .GetCustomAttribute<NameAttribute>() != null;
        IsHidden = propertyInfo
            .GetCustomAttribute<HiddenAttribute>() != null;

        IsVirtual = ReflectionHelper.IsVirtual(propertyInfo);
        IsAsync = ReflectionHelper.IsAsync(propertyInfo);

        Type = propertyInfo.PropertyType;
        if (IsAsync)
        {
            Type = Type.GenericTypeArguments[0];
        }

        IsNullable = ReflectionHelper.IsNullable(Type);

        IsIEnumerable = ReflectionHelper.IsIEnumerable(Type);
        IsICollection = ReflectionHelper.IsICollection(Type);
        IsList = ReflectionHelper.IsList(Type);
        IsArray = ReflectionHelper.IsArray(Type);

        IsLijst = IsIEnumerable || IsICollection || IsList || IsArray;

        if (IsArray)
        {
            Type = Type.GetElementType()!;
        }
        else if (IsLijst || (IsNullable && Type.GenericTypeArguments.Length > 0))
        {
            Type = Type.GenericTypeArguments[0];
        }

        if (Type == typeof(string))
        {
            var context = new NullabilityInfoContext();
            var nullabilityInfo = context.Create(propertyInfo);
            IsNullable = nullabilityInfo.ReadState == NullabilityState.Nullable;
        }

        TypeSimpleName = NameHelper.GetSimpleCsType(Type.FullName ?? Type.Name) ?? (Type.FullName ?? Type.Name);
        if (IsNullable)
        {
            TypeSimpleName += "?";
        }

        IsPrimitiveType = ReflectionHelper.IsPrimitiveType(Type);
        IsEnum = Type.IsEnum;
        IsValueType = Type.IsValueType;
        IsPrimitiveTypeOrEnumOrValueType = ReflectionHelper.IsPrimitiveType(Type) || Type.IsEnum || Type.IsValueType;
    }

    public Entity PropertyEntity { get; }
    public PropertyInfo PropertyInfo { get; }
    public string PropertyName { get; }

    public Type Type { get; }
    public string TypeSimpleName { get; }

    public bool IsReadOnly { get; }
    public bool IsKey { get; }
    public bool IsName { get; }
    public bool IsHidden { get; }
    public bool IsVirtual { get; }
    public bool IsAsync { get; }
    public bool IsNullable { get; }
    public bool IsIEnumerable { get; }
    public bool IsICollection { get; }
    public bool IsList { get; }
    public bool IsArray { get; }
    public bool IsLijst { get; }

    public DbSet? DbSet => PropertyEntity.DbSet.ApplicationDbContext.DbSets
        .FirstOrDefault(DbSet => DbSet.Type == Type);

    public bool IsPrimitiveType { get; }
    public bool IsEnum { get; }
    public bool IsValueType { get; }
    public bool IsPrimitiveTypeOrEnumOrValueType { get; }
}