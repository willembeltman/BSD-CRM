
namespace CodeGenerator.Dtos_Converters_Services.Generators;

public class DeleteResponseDtoGenerator : BaseGenerator
{
    public DeleteResponseDtoGenerator(DtoGenerator dtoGenerator, DirectoryInfo directory, string @namespace)
    {
        DtoGenerator = dtoGenerator;
        Directory = directory;
        Namespace = @namespace;
        Name = $"{dtoGenerator.Entity.Name}DeleteResponse";
    }

    public DtoGenerator DtoGenerator { get; }

    public void GenerateCode()
    {
        //namespace BSD.Shared.ResponseDtos;

        //public class CompanyDeleteResponse : BaseResponse
        //{
        //}

        Code = @$"using {DtoGenerator.Namespace};

namespace {Namespace};

public class {Name} : BaseResponse
{{
}}";

        Save();
    }
}