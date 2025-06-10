
namespace CodeGenerator.Dtos_Converters_Services.Generators;

public class UpdateRequestDtoGenerator : BaseGenerator
{
    public UpdateRequestDtoGenerator(DtoGenerator dtoGenerator, DirectoryInfo directory, string @namespace)
    {
        DtoGenerator = dtoGenerator;
        Directory = directory;
        Namespace = @namespace;
        Name = $"{dtoGenerator.Entity.Name}UpdateRequest";
    }

    public DtoGenerator DtoGenerator { get; }

    public void GenerateCode()
    {
        //using BSD.Shared.Dtos;

        //namespace BSD.Shared.RequestDtos;

        //public class CompanyUpdateRequest : BaseRequest
        //{
        //    public Company Company { get; set; } = new Company();
        //}

        Code = string.Empty;

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

        if (DtoGenerator.Entity.IsStorageFile)
        {
            Code += $"    public IFormFile? File {{ get; set; }}\r\n";
        }
        
        Code += $"}}";

        Save();
    }
}