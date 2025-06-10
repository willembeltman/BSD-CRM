using CodeGenerator.DtoConvertersAndServices.Entities;
using CodeGenerator.Dtos_Converters_Services.Generators;

namespace CodeGenerator.DtoConvertersAndServices;

public class Generator
{
    public Generator(Type dbContextType)
    {
        DbContext = new DbContext(dbContextType);
    }

    public DbContext DbContext { get; }

    public DtoGenerator[]? Dtos { get; private set; }
    public DtoConverterGenerator[]? DtoConverters { get; private set; }
    public ServiceInterfaceGenerator[]? ServiceInterfaces { get; private set; }
    public ServiceGenerator[]? Services { get; private set; }

    public void Run(
        DirectoryInfo dtoDirectory, string dtoNamespace,
        DirectoryInfo requestDtoDirectory, string requestDtoNamespace,
        DirectoryInfo responseDtoDirectory, string responseDtoNamespace,
        DirectoryInfo dtoConvertersDirectory, string dtoConvertersNamespace,
        DirectoryInfo interfacesDirectory, string interfacesNamespace,
        DirectoryInfo servicesDirectory, string servicesNamespace)
    {
        // Generate DTOs
        Dtos = DbContext.DbSets
            .Select(dbSet => new DtoGenerator(
                this, 
                dbSet,
                dtoDirectory, dtoNamespace,
                requestDtoDirectory, requestDtoNamespace,
                responseDtoDirectory, responseDtoNamespace))
            .ToArray();

        // Generate DTO Converters
        DtoConverters = Dtos
            .Select(dto => new DtoConverterGenerator(this, dto, dtoConvertersDirectory, dtoConvertersNamespace))
            .ToArray();

        // Generate Service Interfaces
        ServiceInterfaces = DtoConverters
            .Select(dtoConverter => new ServiceInterfaceGenerator(this, dtoConverter, dtoConvertersDirectory, dtoConvertersNamespace))
            .ToArray();

        // Generate Services
        Services = ServiceInterfaces
            .Select(serviceInterface => new ServiceGenerator(this, serviceInterface, dtoConvertersDirectory, dtoConvertersNamespace))
            .ToArray();

        foreach (var dto in Dtos) dto.GenerateCode();
        foreach (var dtoConverter in DtoConverters) dtoConverter.GenerateCode();
        foreach (var serviceInterface in ServiceInterfaces) serviceInterface.GenerateCode();
        foreach (var service in Services) service.GenerateCode();
    }
}
