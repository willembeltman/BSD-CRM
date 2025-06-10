
namespace CodeGenerator.Dtos_Converters_Services.Generators;

public class UpdateRequestDtoGenerator : BaseGenerator
{
    public UpdateRequestDtoGenerator(DtoGenerator dtoGenerator, DirectoryInfo directory, string @namespace)
    {
        DtoGenerator = dtoGenerator;
        Directory = directory;
        RequestDtoNamespace = @namespace;
        Name = $"{dtoGenerator.Entity.Name}UpdateRequest";
    }

    public DtoGenerator DtoGenerator { get; }
    public string RequestDtoNamespace { get; private set; }

    public void GenerateCode()
    {
        //using BSD.Shared.Dtos;

        //namespace BSD.Shared.RequestDtos;

        //public class CompanyUpdateRequest : BaseRequest
        //{
        //    public Company Company { get; set; } = new Company();
        //}

        Code = string.Empty;

        Code += $"using {DtoGenerator.Namespace};\r\n";
        Code += $"\r\n";
        Code += $"namespace {RequestDtoNamespace};\r\n";
        Code += $"\r\n";
        Code += $"public class {Name} : BaseRequest\r\n";
        Code += $"{{\r\n";
        Code += $"    public {DtoGenerator.Entity.Name} {DtoGenerator.Entity.Name} {{ get; set; }} = new {DtoGenerator.Entity.Name}();\r\n";
        Code += $"}}";

        Save();
    }
}