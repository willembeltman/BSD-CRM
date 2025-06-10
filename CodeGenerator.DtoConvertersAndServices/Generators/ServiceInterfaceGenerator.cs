using CodeGenerator.DtoConvertersAndServices;

namespace CodeGenerator.Dtos_Converters_Services.Generators;

public class ServiceInterfaceGenerator : BaseGenerator
{
    public ServiceInterfaceGenerator(Generator generator, DtoConverterGenerator dtoConverter, DirectoryInfo dtoConvertersDirectory, string dtoConvertersNamespace)
    {
        Generator = generator;
    }

    public Generator Generator { get; }

    internal void GenerateCode()
    {
    }
}