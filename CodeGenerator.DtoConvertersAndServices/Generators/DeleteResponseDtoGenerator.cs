
namespace CodeGenerator.Dtos_Converters_Services.Generators;

public class DeleteResponseDtoGenerator : BaseGenerator
{
    public DeleteResponseDtoGenerator(DtoGenerator dtoGenerator, DirectoryInfo directory, string @namespace)
    {
        DtoGenerator = dtoGenerator;
        Directory = directory;
        ResponseDtoNamespace = @namespace;
        Name = $"{dtoGenerator.Entity.Name}DeleteResponse";
    }

    public DtoGenerator DtoGenerator { get; }
    public string ResponseDtoNamespace { get; private set; }

    public void GenerateCode()
    {
        //namespace BSD.Shared.ResponseDtos;

        //public class CompanyDeleteResponse : BaseResponse
        //{
        //}

        Code = @$"using {DtoGenerator.Namespace};

namespace {ResponseDtoNamespace};

public class {Name} : BaseResponse
{{
}}";

        Save();
    }
}