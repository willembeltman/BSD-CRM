using CodeGenerator.DtoConvertersAndServices;
using CodeGenerator.DtoConvertersAndServices.Entities;

namespace CodeGenerator.Dtos_Converters_Services.Generators;

public class DtoConverterGenerator
{
    public DtoConverterGenerator(Generator generator, DtoGenerator dto, DirectoryInfo directory, string @namespace)
    {
        Dto = dto;
        DbSet = dto.DbSet;
        Entity = DbSet.Entity;
        Directory = directory;
        Namespace = @namespace;
    }

    public DtoGenerator Dto { get; }
    public DbSet DbSet { get; }
    public Entity Entity { get; }
    public DirectoryInfo Directory { get; }
    public string Namespace { get; }
    public string? Code { get; private set; }

    public string GenerateCode()
    {
        //namespace BSD.Data.Converters;

        //    public bool Copy(Shared.Dtos.Company source, Entities.Company dest)
        //    {
        //        var dirty = false;
        //        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        //        if (dest.Name != source.Name) { dest.Name = source.Name; dirty = true; }
        //        if (dest.Address != source.Address) { dest.Address = source.Address; dirty = true; }
        //        if (dest.BtwNumber != source.BtwNumber) { dest.BtwNumber = source.BtwNumber; dirty = true; }
        //        if (dest.CountryId != source.CountryId) { dest.CountryId = source.CountryId; dirty = true; }
        //        //if (dest.DateDelete != source.DateDelete) { dest.DateDelete = source.DateDelete; dirty = true; }
        //        //if (dest.DateInsert != source.DateInsert) { dest.DateInsert = source.DateInsert; dirty = true; }
        //        //if (dest.DateUpdate != source.DateUpdate) { dest.DateUpdate = source.DateUpdate; dirty = true; }
        //        if (dest.Email != source.Email) { dest.Email = source.Email; dirty = true; }
        //        if (dest.Iban != source.Iban) { dest.Iban = source.Iban; dirty = true; }
        //        if (dest.KvkNumber != source.KvkNumber) { dest.KvkNumber = source.KvkNumber; dirty = true; }
        //        if (dest.Place != source.Place) { dest.Place = source.Place; dirty = true; }
        //        if (dest.Postalcode != source.Postalcode) { dest.Postalcode = source.Postalcode; dirty = true; }
        //        if (dest.PhoneNumber != source.PhoneNumber) { dest.PhoneNumber = source.PhoneNumber; dirty = true; }
        //        if (dest.Website != source.Website) { dest.Website = source.Website; dirty = true; }
        //        return dirty;
        //    }
        //}


        var toDtoCode = string.Empty;
        var toEntityCode = string.Empty;

        foreach (var property in Entity.Properties)
        {
            if (property.IsHidden) continue;
            if (property.IsLijst) continue;
            if (property.DbSet != null) continue;

            toDtoCode += $"        if (dest.{property.PropertyName} != source.{property.PropertyName}) {{ dest.{property.PropertyName} = source.{property.PropertyName}; dirty = true; }}\r\n";
            toEntityCode += $"        if (dest.{property.PropertyName} != source.{property.PropertyName}) {{ dest.{property.PropertyName} = source.{property.PropertyName}; dirty = true; }}\r\n";
        }

        Code = string.Empty;
        Code += $"namespace {Namespace};\r\n";
        Code += $"\r\n";
        Code += $"public static class {Entity.Name}Converter\r\n";
        Code += $"{{\r\n";

        Code += $"    public static {Dto.FullName} ToDto(this {Entity.FullName} item)\r\n";
        Code += $"    {{\r\n";
        Code += $"        var newItem = new {Dto.FullName}();\r\n";
        Code += $"        item.CopyTo(newItem);\r\n";
        Code += $"        return newItem;\r\n";
        Code += $"    }}\r\n";

        Code += $"    public static {Entity.FullName} ToEntity(this {Dto.FullName} item)\r\n";
        Code += $"    {{\r\n";
        Code += $"        var newItem = new {Entity.FullName}();\r\n";
        Code += $"        item.CopyTo(newItem);\r\n";
        Code += $"        return newItem;\r\n";
        Code += $"    }}\r\n";

        Code += $"    public static bool CopyTo(this {Dto.FullName} source, {Entity.FullName} dest)\r\n";
        Code += $"    {{\r\n";
        Code += $"        var dirty = false;\r\n";
        Code += toEntityCode;
        Code += $"        return dirty;\r\n";
        Code += $"    }}\r\n";

        Code += $"    public static bool CopyTo(this {Entity.FullName} source, {Dto.FullName} dest)\r\n";
        Code += $"    {{\r\n";
        Code += $"        var dirty = false;\r\n";
        Code += toDtoCode;
        Code += $"        return dirty;\r\n";
        Code += $"    }}\r\n";

        Code += $"}}";

        return Code;
    }

}