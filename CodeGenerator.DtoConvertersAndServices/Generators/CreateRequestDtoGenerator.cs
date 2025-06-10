
using CodeGenerator.Step1.DtosConvertersAndServices.Entities;

namespace CodeGenerator.Dtos_Converters_Services.Generators;

public class CreateRequestDtoGenerator : BaseGenerator
{
    public CreateRequestDtoGenerator(DtoGenerator dtoGenerator, DirectoryInfo directory, string @namespace)
    {
        DtoGenerator = dtoGenerator;
        Directory = directory;
        Namespace = @namespace;
        Name = $"{dtoGenerator.Entity.Name}CreateRequest";
    }

    public DtoGenerator DtoGenerator { get; }

    public void GenerateCode()
    {
        //using BSD.Shared.Dtos;

        //namespace BSD.Shared.RequestDtos;

        //public class CompanyCreateRequest : BaseRequest
        //{
        //    public Company Company { get; set; } = new Company();
        //}

        Code = string.Empty;

        //if (DtoGenerator.Entity.IsStorageFile)
        //{
        //    Code += $"using System;\r\n";
        //    Code += $"using System.IO;\r\n";
        //}

        if (DtoGenerator.Entity.IsStorageFile)
        {
            Code += $"using Microsoft.AspNetCore.Http;\r\n";
        }

        Code += $"using {DtoGenerator.Namespace};\r\n";
        Code += $"\r\n";
        Code += $"namespace {Namespace};\r\n";
        Code += $"\r\n";
        Code += $"public class {Name} : BaseRequest\r\n";
        Code += $"{{\r\n";
        Code += $"    public {DtoGenerator.Entity.Name} {DtoGenerator.Entity.Name} {{ get; set; }} = new {DtoGenerator.Entity.Name}();\r\n";

        //if (DtoGenerator.Entity.IsStorageFile)
        //{
        //    Code += $"    public string FileName {{ get; set; }}\r\n";
        //    Code += $"    public string FileType {{ get; set; }}\r\n";
        //    Code += $"    public Stream FileStream {{ get; set; }}\r\n";
        //}
        if (DtoGenerator.Entity.IsStorageFile)
        {
            Code += $"    public IFormFile? File {{ get; set; }}\r\n";
        }

        Code += $"}}";

        Save();
    }
}