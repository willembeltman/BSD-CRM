
namespace CodeGenerator.Dtos_Converters_Services.Generators;

public class ReadRequestDtoGenerator : BaseGenerator
{
    public ReadRequestDtoGenerator(DtoGenerator dtoGenerator, DirectoryInfo directory, string @namespace)
    {
        DtoGenerator = dtoGenerator;
        Directory = directory;
        Namespace = @namespace;
        Name = $"{dtoGenerator.Entity.Name}ReadRequest";
    }

    public DtoGenerator DtoGenerator { get; }

    public void GenerateCode()
    {
        //namespace BSD.Shared.RequestDtos;

        //public class CompanyReadRequest : BaseRequest
        //{
        //    public long CompanyId { get; set; }
        //}


        var id = DtoGenerator.Entity.Properties.First(a => a.IsKey);

        Code = string.Empty;

        Code += $"namespace {Namespace};\r\n";
        Code += $"\r\n";
        Code += $"public class {Name} : BaseRequest\r\n";
        Code += $"{{\r\n";
        Code += $"    public {id.TypeSimpleName} {DtoGenerator.Entity.Name}{id.PropertyName} {{ get; set; }}\r\n";
        Code += $"}}";

        Save();
    }
}