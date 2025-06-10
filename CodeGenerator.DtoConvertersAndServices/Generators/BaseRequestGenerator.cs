using CodeGenerator.Dtos_Converters_Services.Generators;
using CodeGenerator.Step1.DtosConvertersAndServices.Entities;

namespace CodeGenerator.Step1.DtosConvertersAndServices.Generators;

public class BaseRequestGenerator : BaseGenerator
{
    public BaseRequestGenerator(DbContext dbContext, DirectoryInfo requestDtoDirectory, string requestDtoNamespace)
    {
        DbContext = dbContext;
        Directory = requestDtoDirectory;
        Namespace = requestDtoNamespace;

        Name = "BaseRequest";
    }

    public DbContext DbContext { get; }
    public string Namespace { get; }

    public void GenerateCode()
    {
        //using CodeGenerator.Shared.Attributes;

        //namespace BSD.Shared.RequestDtos;

        //[TsHidden]
        //public class BaseRequest
        //{
        //    public string? BearerId { get; set; }
        //}

        Code = $@"
using CodeGenerator.Shared.Attributes;

namespace {Namespace};

[TsHidden]
public class {Name}
{{
    public string? BearerId {{ get; set; }}
}}
";

        Save();
    }
}