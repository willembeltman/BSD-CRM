namespace CodeGenerator.Step1.DtosConvertersAndServices;

public class GeneratorConfig
{
    public GeneratorConfig(
        Type dbContextType,
        DirectoryInfo dtoDirectory, string dtoNamespace,
        DirectoryInfo requestDtoDirectory, string requestDtoNamespace,
        DirectoryInfo responseDtoDirectory, string responseDtoNamespace,
        DirectoryInfo dtoConvertersDirectory, string dtoConvertersNamespace,
        DirectoryInfo interfacesDirectory, string interfacesNamespace,
        DirectoryInfo servicesDirectory, string servicesNamespace)
    {
        DbContextType = dbContextType;
        DtoDirectory = dtoDirectory;
        DtoNamespace = dtoNamespace;
        RequestDtoDirectory = requestDtoDirectory;
        RequestDtoNamespace = requestDtoNamespace;
        ResponseDtoDirectory = responseDtoDirectory;
        ResponseDtoNamespace = responseDtoNamespace;
        DtoConvertersDirectory = dtoConvertersDirectory;
        DtoConvertersNamespace = dtoConvertersNamespace;
        InterfacesDirectory = interfacesDirectory;
        InterfacesNamespace = interfacesNamespace;
        ServicesDirectory = servicesDirectory;
        ServicesNamespace = servicesNamespace;
    }
    public Type DbContextType { get; }
    public DirectoryInfo DtoDirectory { get; }
    public string DtoNamespace { get; }
    public DirectoryInfo RequestDtoDirectory { get; }
    public string RequestDtoNamespace { get; }
    public DirectoryInfo ResponseDtoDirectory { get; }
    public string ResponseDtoNamespace { get; }
    public DirectoryInfo DtoConvertersDirectory { get; }
    public string DtoConvertersNamespace { get; }
    public DirectoryInfo InterfacesDirectory { get; }
    public string InterfacesNamespace { get; }
    public DirectoryInfo ServicesDirectory { get; }
    public string ServicesNamespace { get; }
}
