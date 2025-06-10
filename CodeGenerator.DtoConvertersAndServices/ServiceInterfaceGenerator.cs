using CodeGenerator.Dtos_Converters_Services.Generators;

namespace CodeGenerator.DtoConvertersAndServices;

public class ServiceInterfaceGenerator
{
    private Generator generator;
    private DtoConverterGenerator dtoConverter;
    private DirectoryInfo dtoConvertersDirectory;
    private string dtoConvertersNamespace;

    public ServiceInterfaceGenerator(Generator generator, DtoConverterGenerator dtoConverter, DirectoryInfo dtoConvertersDirectory, string dtoConvertersNamespace)
    {
        this.generator = generator;
        this.dtoConverter = dtoConverter;
        this.dtoConvertersDirectory = dtoConvertersDirectory;
        this.dtoConvertersNamespace = dtoConvertersNamespace;
    }

    internal void GenerateCode()
    {
        throw new NotImplementedException();
    }
}