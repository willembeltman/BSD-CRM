
namespace CodeGenerator.Dtos_Converters_Services.Generators;

public class CreateResponseDtoGenerator : BaseGenerator
{
    public CreateResponseDtoGenerator(DtoGenerator dtoGenerator, DirectoryInfo directory, string @namespace)
    {
        DtoGenerator = dtoGenerator;
        Directory = directory;
        ResponseDtoNamespace = @namespace;
        Name = $"{dtoGenerator.Entity.Name}CreateResponse";
    }

    public DtoGenerator DtoGenerator { get; }
    public string ResponseDtoNamespace { get; private set; }

    public void GenerateCode()
    {
        //using BSD.Shared.Dtos;

        //namespace BSD.Shared.ResponseDtos;

        //public class CompanyCreateResponse : BaseResponse
        //{
        //    public Company? Company { get; set; }
        //}


        Code = @$"using {DtoGenerator.Namespace};

namespace {ResponseDtoNamespace};

public class {Name} : BaseResponse
{{
    public {DtoGenerator.Entity.Name}? {DtoGenerator.Entity.Name} {{ get; set; }}
}}";

        Save();
    }
}