
namespace CodeGenerator.Dtos_Converters_Services.Generators;

public class DeleteRequestDtoGenerator : BaseGenerator
{
    public DeleteRequestDtoGenerator(DtoGenerator dtoGenerator, DirectoryInfo directory, string @namespace)
    {
        DtoGenerator = dtoGenerator;
        Directory = directory;
        Namespace = @namespace;
        Name = $"{dtoGenerator.Entity.Name}DeleteRequest";
    }

    public DtoGenerator DtoGenerator { get; }

    public void GenerateCode()
    {
        //namespace BSD.Shared.RequestDtos;

        //public class CompanyDeleteRequest : BaseRequest
        //{
        //    public long CompanyId { get; set; }
        //}

        var id = DtoGenerator.Entity.Properties.First(a => a.IsKey);

        Code = @$"namespace {Namespace};

public class {Name} : BaseRequest
{{
    public {id.TypeSimpleName} {DtoGenerator.Entity.Name}{id.PropertyName} {{ get; set; }}
}}";

        Save();
    }
}