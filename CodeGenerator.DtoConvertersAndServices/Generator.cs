using CodeGenerator.Step1.DtosConvertersAndServices.Entities;
using CodeGenerator.Dtos_Converters_Services.Generators;

namespace CodeGenerator.Step1.DtosConvertersAndServices;

public class Generator
{
    public Generator(GeneratorConfig config)
    {
        DbContext = new DbContext(config.DbContextType);
        // Generate DTOs
        Dtos = DbContext.DbSets
            .Where(a => !a.Entity.IsHidden)
            .Select(dbSet => new DtoGenerator(
                dbSet,
                config.DtoDirectory, config.DtoNamespace,
                config.RequestDtoDirectory, config.RequestDtoNamespace,
                config.ResponseDtoDirectory, config.ResponseDtoNamespace))
            .ToArray();

        // Generate DTO Converters
        DtoConverters = Dtos
            .Select(dto => new DtoConverterGenerator(
                dto,
                config.ConvertersDirectory,
                config.ConvertersNamespace))
            .ToArray();

        // Generate Service Handlers
        ServiceHandlers = DtoConverters
            .Select(dtoConverter => new ServiceHandlerGenerator(
                dtoConverter,
                config.ServiceHandlersDirectory,
                config.ServiceHandlersNamespace))
            .ToArray();

        // Generate Service Interfaces
        ServiceInterfaces = ServiceHandlers
            .Select(serviceHandler => new ServiceInterfaceGenerator(
                serviceHandler,
                config.ConvertersDirectory,
                config.ConvertersNamespace))
            .ToArray();

        // Generate Services
        Services = ServiceInterfaces
            .Select(serviceInterface => new ServiceGenerator(
                serviceInterface,
                config.ConvertersDirectory,
                config.ConvertersNamespace))
            .ToArray();
    }

    public DbContext DbContext { get; }

    public DtoGenerator[] Dtos { get; private set; }
    public DtoConverterGenerator[] DtoConverters { get; private set; }
    public ServiceHandlerGenerator[] ServiceHandlers { get; private set; }
    public ServiceInterfaceGenerator[] ServiceInterfaces { get; private set; }
    public ServiceGenerator[] Services { get; private set; }

    public void Run()
    {
        // To render:
        // Requests/BaseRequest
        // Interfaces/IAuthenticationStateService
        // Models/AuthenticationState
        // Shared/Dtos/State

        foreach (var dto in Dtos) dto.GenerateCode();
        foreach (var dtoConverter in DtoConverters) dtoConverter.GenerateCode();
        foreach (var serviceHandler in ServiceHandlers) serviceHandler.GenerateCode();
        foreach (var serviceInterface in ServiceInterfaces) serviceInterface.GenerateCode();
        foreach (var service in Services) service.GenerateCode();
    }
}
