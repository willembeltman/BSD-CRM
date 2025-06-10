
namespace CodeGenerator.Dtos_Converters_Services.Generators;

public class ListResponseDtoGenerator : BaseGenerator
{
    public ListResponseDtoGenerator(DtoGenerator dtoGenerator, DirectoryInfo directory, string @namespace)
    {
        DtoGenerator = dtoGenerator;
        Directory = directory;
        ResponseDtoNamespace = @namespace;
        Name = $"{dtoGenerator.Entity.Name}ListResponse";
    }

    public DtoGenerator DtoGenerator { get; }
    public string ResponseDtoNamespace { get; private set; }

    public void GenerateCode()
    {
        //using BSD.Shared.Dtos;

        //namespace BSD.Shared.ResponseDtos;

        //public class CompanyListResponse : BaseResponse
        //{
        //    public Company[] Companies { get; set; } = [];
        //}

        Code = string.Empty;

        Code += $"using {DtoGenerator.Namespace};\r\n";
        Code += $"\r\n";
        Code += $"namespace {ResponseDtoNamespace};\r\n";
        Code += $"\r\n";
        Code += $"public class {Name} : BaseResponse\r\n";
        Code += $"{{\r\n";
        Code += $"    public {DtoGenerator.Entity.Name}[] {DtoGenerator.Entity.Name}s {{ get; set; }} = [];\r\n";
        Code += $"}}";

        Save();
    }
}