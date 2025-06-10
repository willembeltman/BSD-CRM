using CodeGenerator.DtoConvertersAndServices;
using CodeGenerator.DtoConvertersAndServices.Entities;

namespace CodeGenerator.Dtos_Converters_Services.Generators;

public class DtoGenerator
{
    public DtoGenerator(Generator generator, DbSet dbSet, DirectoryInfo directory, string @namespace)
    {
        DbSet = dbSet;
        Entity = DbSet.Entity;
        Directory = directory;
        Namespace = @namespace;
    }

    public DbSet DbSet { get; }
    public Entity Entity { get; }
    public DirectoryInfo Directory { get; }
    public string Namespace { get; }
    public string FullName => $"{Namespace}.{Entity.Name}";

    public string? Code { get; private set; }

    public string GenerateCode()
    {
        //namespace BSD.Shared.Dtos;

        //public class Company 
        //{
        //    public long Id { get; set; }

        //    public long? CountryId { get; set; }
        //    public string? CountryName { get; set; }

        //    public string Name { get; set; } = string.Empty;
        //    public string? Address { get; set; }
        //    public string? Postalcode { get; set; }
        //    public string? Place { get; set; }
        //    public string? PhoneNumber { get; set; }
        //    public string Email { get; set; } = string.Empty;
        //    public string? Website { get; set; }
        //    public string? BtwNumber { get; set; }
        //    public string? KvkNumber { get; set; }
        //    public string? Iban { get; set; }
        //}

        var usingCode = string.Empty;
        var propertiesCode = string.Empty;

        propertiesCode += $"namespace {Namespace};\r\n";
        propertiesCode += $"\r\n";
        propertiesCode += $"public class {Entity.Name}\r\n";
        propertiesCode += $"{{\r\n";

        foreach (var property in Entity.Properties)
        {
            if (property.IsHidden) continue;
            if (property.IsLijst) continue;
            if (property.DbSet != null)
            {
                var foreignDbSet = property.DbSet;
                var foreignEntity = foreignDbSet.Entity;
                var foreignNameProperty = foreignEntity.Properties.FirstOrDefault(a => a.IsName);
                continue;
            }

            if (property.IsPrimitiveTypeOrEnumOrValueType || property.IsNullable)
            {
                if (property.TypeSimpleName == "DateOnly")
                {
                    usingCode = AddNamespace(usingCode, $"using System;");
                    propertiesCode += $"    public {property.TypeSimpleName} {property.PropertyName} {{ get; set; }} = DateOnly.FromDateTime(DateTime.Now);\r\n";
                }
                else if (property.TypeSimpleName == "TimeOnly")
                {
                    usingCode = AddNamespace(usingCode, $"using System;");
                    propertiesCode += $"    public {property.TypeSimpleName} {property.PropertyName} {{ get; set; }} = TimeOnly.FromDateTime(DateTime.Now);\r\n";
                }
                else if (property.TypeSimpleName == "DateTime")
                {
                    usingCode = AddNamespace(usingCode, $"using System;");
                    propertiesCode += $"    public {property.TypeSimpleName} {property.PropertyName} {{ get; set; }} = DateTime.Now;\r\n";
                }
                else
                {
                    if (!string.IsNullOrEmpty(property.Type.Namespace))
                        usingCode = AddNamespace(usingCode, $"using {property.Type.Namespace};");
                    propertiesCode += $"    public {property.TypeSimpleName} {property.PropertyName} {{ get; set; }}\r\n";
                }
            }
            else
            {
                if (property.TypeSimpleName == "string")
                {
                    usingCode = AddNamespace(usingCode, $"using System;");
                    propertiesCode += $"    public {property.TypeSimpleName} {property.PropertyName} {{ get; set; }} = string.Empty;\r\n";
                }
                else 
                {
                    if (!string.IsNullOrEmpty(property.Type.Namespace))
                        usingCode = AddNamespace(usingCode, $"using {property.Type.Namespace};");
                    propertiesCode += $"    public {property.TypeSimpleName} {property.PropertyName} {{ get; set; }} = new();\r\n";
                }
            }
        }

        propertiesCode += $"}}";

        Code = usingCode + "\r\n\r\n" + propertiesCode;

        return Code;
    }

    private string AddNamespace(string usingCode, string @using)
    {
        if (!usingCode.Contains(@using))
        {
            usingCode += $"{@using}\r\n";
        }
        return usingCode;
    }
}