
namespace CodeGenerator.Dtos_Converters_Services.Generators;

public class ListRequestDtoGenerator : BaseGenerator
{
    public ListRequestDtoGenerator(DtoGenerator dtoGenerator, DirectoryInfo directory, string @namespace)
    {
        DtoGenerator = dtoGenerator;
        Directory = directory;
        RequestDtoNamespace = @namespace;
        Name = $"{dtoGenerator.Entity.Name}ListRequest";
    }

    public DtoGenerator DtoGenerator { get; }
    public string RequestDtoNamespace { get; private set; }

    public void GenerateCode()
    {
        //namespace BSD.Shared.RequestDtos;

        //public class CompanyListRequest : BaseRequest
        //{
        //}

        Code = string.Empty;

        Code += $"using {DtoGenerator.Namespace};\r\n";
        Code += $"\r\n";
        Code += $"namespace {RequestDtoNamespace};\r\n";
        Code += $"\r\n";
        Code += $"public class {Name} : BaseRequest\r\n";
        Code += $"{{\r\n";
        Code += $"}}";

        Save();
    }
}