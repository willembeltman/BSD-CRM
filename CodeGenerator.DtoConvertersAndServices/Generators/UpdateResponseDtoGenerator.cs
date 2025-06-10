namespace CodeGenerator.Dtos_Converters_Services.Generators;

public class UpdateResponseDtoGenerator : BaseGenerator
{
    public UpdateResponseDtoGenerator(DtoGenerator dtoGenerator, DirectoryInfo directory, string @namespace)
    {
        DtoGenerator = dtoGenerator;
        Directory = directory;
        Namespace = @namespace;
        Name = $"{dtoGenerator.Entity.Name}UpdateResponse";
    }

    public DtoGenerator DtoGenerator { get; }

    public void GenerateCode()
    {
        //using BSD.Shared.Dtos;

        //namespace BSD.Shared.ResponseDtos;

        //public class CompanyUpdateResponse : BaseResponse
        //{
        //    public Company? Company { get; set; }
        //}

        Code = string.Empty;

        Code += $"using {DtoGenerator.Namespace};\r\n";
        Code += $"\r\n";
        Code += $"namespace {Namespace};\r\n";
        Code += $"\r\n";
        Code += $"public class {Name} : BaseResponse\r\n";
        Code += $"{{\r\n";
        Code += $"    public {DtoGenerator.Entity.Name}? {DtoGenerator.Entity.Name} {{ get; set; }}\r\n";
        Code += $"}}";

        Save();
    }
}