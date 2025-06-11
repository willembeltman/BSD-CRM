using CodeGenerator.Dtos_Converters_Services.Generators;
using CodeGenerator.Step1.DtosConvertersAndServices.Entities;
using CodeGenerator.Step1.DtosConvertersAndServices.Generators;

namespace CodeGenerator.Step1.DtosConvertersAndServices;

public class Generator
{
    public Generator(GeneratorConfig config)
    {
        DbContext = new DbContext(config.DbContextType);

        // RequestDtos/BaseRequest
        BaseRequest = new BaseRequestGenerator(
            DbContext,
            config.RequestDtoDirectory, config.RequestDtoNamespace);

        // Dtos/State
        StateDto = new StateDtoGenerator(
            BaseRequest,
            config.DtoDirectory, config.DtoNamespace);

        // ResponseDtos/BaseResponse
        BaseResponse = new BaseResponseGenerator(
            StateDto,
            config.ResponseDtoDirectory, config.ResponseDtoNamespace);

        // Models/AuthenticationState
        AuthenticationState = new AuthenticationStateGenerator(
            BaseResponse,
            config.ModelsDirectory, config.ModelsNamespace);

        // Interfaces/IAuthenticationStateService
        IAuthenticationStateService = new IAuthenticationStateServiceGenerator(
            AuthenticationState,
            config.InterfacesDirectory, config.InterfacesNamespace);

        // Generate DTOs
        Dtos = DbContext.DbSets
            .Where(a => !a.Entity.IsHidden)
            .Select(dbSet => new DtoGenerator(
                IAuthenticationStateService, dbSet,
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
                config.CrudHandlersDirectory,
                config.CrudHandlersNamespace))
            .ToArray();

        // Generate Service Interfaces
        ServiceInterfaces = ServiceHandlers
            .Select(serviceHandler => new ServiceInterfaceGenerator(
                serviceHandler,
                config.CrudInterfacesDirectory,
                config.CrudInterfacesNamespace))
            .ToArray();

        // Generate Services
        Services = ServiceInterfaces
            .Select(serviceInterface => new ServiceGenerator(
                serviceInterface,
                config.CrudServicesDirectory,
                config.CrudServicesNamespace))
            .ToArray();

    }

    public DbContext DbContext { get; }

    public BaseRequestGenerator BaseRequest { get; }
    public BaseResponseGenerator BaseResponse { get; }
    public StateDtoGenerator StateDto { get; }
    public AuthenticationStateGenerator AuthenticationState { get; }
    public IAuthenticationStateServiceGenerator IAuthenticationStateService { get; }

    public DtoGenerator[] Dtos { get; private set; }
    public DtoConverterGenerator[] DtoConverters { get; private set; }
    public ServiceHandlerGenerator[] ServiceHandlers { get; private set; }
    public ServiceInterfaceGenerator[] ServiceInterfaces { get; private set; }
    public ServiceGenerator[] Services { get; private set; }

    public void Run()
    {
        // RequestDtos/BaseRequest
        BaseRequest.GenerateCode();

        // Dtos/State
        StateDto.GenerateCode();

        // ResponseDtos/BaseResponse
        BaseResponse.GenerateCode();

        // Models/AuthenticationState
        AuthenticationState.GenerateCode();

        // Interfaces/IAuthenticationStateService
        IAuthenticationStateService.GenerateCode();

        foreach (var dto in Dtos) dto.GenerateCode();
        foreach (var dtoConverter in DtoConverters) dtoConverter.GenerateCode();
        foreach (var serviceHandler in ServiceHandlers) serviceHandler.GenerateCode();
        foreach (var serviceInterface in ServiceInterfaces) serviceInterface.GenerateCode();
        foreach (var service in Services) service.GenerateCode();
    }
}
