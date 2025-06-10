namespace CodeGenerator.Step1.DtosConvertersAndServices;

public class GeneratorConfig
{
    public GeneratorConfig(
        Type dbContextType,
        DirectoryInfo dtoDirectory, string dtoNamespace,
        DirectoryInfo requestDtoDirectory, string requestDtoNamespace,
        DirectoryInfo responseDtoDirectory, string responseDtoNamespace,
        DirectoryInfo convertersDirectory, string convertersNamespace,
        DirectoryInfo serviceHandlersDirectory, string serviceHandlersNamespace,
        DirectoryInfo interfacesDirectory, string interfacesNamespace,
        DirectoryInfo servicesDirectory, string servicesNamespace,
        DirectoryInfo modelsDirectory, string modelsNamespace)
    {
        DbContextType = dbContextType;
        DtoDirectory = dtoDirectory;
        DtoNamespace = dtoNamespace;
        RequestDtoDirectory = requestDtoDirectory;
        RequestDtoNamespace = requestDtoNamespace;
        ResponseDtoDirectory = responseDtoDirectory;
        ResponseDtoNamespace = responseDtoNamespace;
        ConvertersDirectory = convertersDirectory;
        ConvertersNamespace = convertersNamespace;
        ServiceHandlersDirectory = serviceHandlersDirectory;
        ServiceHandlersNamespace = serviceHandlersNamespace;
        InterfacesDirectory = interfacesDirectory;
        InterfacesNamespace = interfacesNamespace;
        ServicesDirectory = servicesDirectory;
        ServicesNamespace = servicesNamespace;
        ModelsDirectory = modelsDirectory;
        ModelsNamespace = modelsNamespace;
    }
    public Type DbContextType { get; }
    public DirectoryInfo DtoDirectory { get; }
    public string DtoNamespace { get; }
    public DirectoryInfo RequestDtoDirectory { get; }
    public string RequestDtoNamespace { get; }
    public DirectoryInfo ResponseDtoDirectory { get; }
    public string ResponseDtoNamespace { get; }
    public DirectoryInfo ConvertersDirectory { get; }
    public string ConvertersNamespace { get; }
    public DirectoryInfo ServiceHandlersDirectory { get; }
    public string ServiceHandlersNamespace { get; }
    public DirectoryInfo InterfacesDirectory { get; }
    public string InterfacesNamespace { get; }
    public DirectoryInfo ServicesDirectory { get; }
    public string ServicesNamespace { get; }
    public DirectoryInfo ModelsDirectory { get; }
    public string ModelsNamespace { get; }
}
