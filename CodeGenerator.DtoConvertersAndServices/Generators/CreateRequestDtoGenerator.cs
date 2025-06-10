
namespace CodeGenerator.Dtos_Converters_Services.Generators;

public class CreateRequestDtoGenerator : BaseGenerator
{
    public CreateRequestDtoGenerator(DtoGenerator dtoGenerator, DirectoryInfo directory, string @namespace)
    {
        DtoGenerator = dtoGenerator;
        Directory = directory;
        RequestDtoNamespace = @namespace;
        Name = $"{dtoGenerator.Entity.Name}CreateRequest";
    }

    public DtoGenerator DtoGenerator { get; }
    public string RequestDtoNamespace { get; private set; }

    public void GenerateCode()
    {
        //using BSD.Shared.Dtos;

        //namespace BSD.Shared.RequestDtos;

        //public class CompanyCreateRequest : BaseRequest
        //{
        //    public Company Company { get; set; } = new Company();
        //}

        Code = @$"using {DtoGenerator.Namespace};

namespace {RequestDtoNamespace};

public class {Name} : BaseRequest
{{
    public {DtoGenerator.Entity.Name} {DtoGenerator.Entity.Name} {{ get; set; }} = new {DtoGenerator.Entity.Name}();
}}";

        Save();
    }
}