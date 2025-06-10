using CodeGenerator.Step1.DtosConvertersAndServices.Entities;

namespace CodeGenerator.Dtos_Converters_Services.Generators;

public class DtoGenerator : BaseGenerator
{
    public DtoGenerator(
        DbSet dbSet,
        DirectoryInfo dtoDirectory, string dtoNamespace,
        DirectoryInfo requestDtoDirectory, string requestDtoNamespace,
        DirectoryInfo responseDtoDirectory, string responseDtoNamespace)
    {
        DbSet = dbSet;
        Entity = DbSet.Entity;
        Directory = dtoDirectory;
        Namespace = dtoNamespace;

        CreateRequest = new CreateRequestDtoGenerator(this, requestDtoDirectory, requestDtoNamespace);
        ReadRequest = new ReadRequestDtoGenerator(this, requestDtoDirectory, requestDtoNamespace);
        UpdateRequest = new UpdateRequestDtoGenerator(this, requestDtoDirectory, requestDtoNamespace);
        DeleteRequest = new DeleteRequestDtoGenerator(this, requestDtoDirectory, requestDtoNamespace);
        ListRequest = new ListRequestDtoGenerator(this, requestDtoDirectory, requestDtoNamespace);

        CreateResponse = new CreateResponseDtoGenerator(this, responseDtoDirectory, responseDtoNamespace);
        ReadResponse = new ReadResponseDtoGenerator(this, responseDtoDirectory, responseDtoNamespace);
        UpdateResponse = new UpdateResponseDtoGenerator(this, responseDtoDirectory, responseDtoNamespace);
        DeleteResponse = new DeleteResponseDtoGenerator(this, responseDtoDirectory, responseDtoNamespace);
        ListResponse = new ListResponseDtoGenerator(this, responseDtoDirectory, responseDtoNamespace);

        Name = Entity.Name;
    }

    public DbSet DbSet { get; }
    public Entity Entity { get; }
    public string Namespace { get; }

    internal CreateRequestDtoGenerator CreateRequest { get; }
    internal ReadRequestDtoGenerator ReadRequest { get; }
    internal UpdateRequestDtoGenerator UpdateRequest { get; }
    internal DeleteRequestDtoGenerator DeleteRequest { get; }
    internal ListRequestDtoGenerator ListRequest { get; }

    internal CreateResponseDtoGenerator CreateResponse { get; }
    internal ReadResponseDtoGenerator ReadResponse { get; }
    internal UpdateResponseDtoGenerator UpdateResponse { get; }
    internal DeleteResponseDtoGenerator DeleteResponse { get; }
    internal ListResponseDtoGenerator ListResponse { get; }

    public string FullName => $"{Namespace}.{Entity.Name}";

    public void GenerateCode()
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
        propertiesCode += $"public class {Name}\r\n";
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
                if (foreignNameProperty == null) continue;

                usingCode = AddNamespace(usingCode, $"using System;");
                propertiesCode += $"    public string? {property.PropertyName}Name {{ get; set; }}\r\n";

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

        if (Entity.IsStorageFile)
        {
            usingCode = AddNamespace(usingCode, $"using System;");
            propertiesCode += $"    public string? StorageFileUrl {{ get; set; }}\r\n";
        }

        propertiesCode += $"}}";

        Code = usingCode + "\r\n\r\n" + propertiesCode;

        Save();

        CreateRequest.GenerateCode();
        ReadRequest.GenerateCode();
        UpdateRequest.GenerateCode();
        DeleteRequest.GenerateCode();
        ListRequest.GenerateCode();
        CreateResponse.GenerateCode();
        ReadResponse.GenerateCode();
        UpdateResponse.GenerateCode();
        DeleteResponse.GenerateCode();
        ListResponse.GenerateCode();
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