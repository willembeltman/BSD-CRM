using CodeGenerator.DtoConvertersAndServices;

namespace CodeGenerator.Dtos_Converters_Services.Generators;

public class ServiceGenerator : BaseGenerator
{
    public ServiceGenerator(Generator generator, ServiceInterfaceGenerator serviceInterface, DirectoryInfo dtoConvertersDirectory, string dtoConvertersNamespace)
    {
        Generator = generator;
    }

    public Generator Generator { get; }

    internal void GenerateCode()
    {
    }
}