namespace CodeGenerator.Step1.DtosConvertersAndServices;

public class GeneratorConfig
{
    public GeneratorConfig(
        Type dbContextType,
        DirectoryInfo dtoDirectory, string dtoNamespace,
        DirectoryInfo requestDtoDirectory, string requestDtoNamespace,
        DirectoryInfo responseDtoDirectory, string responseDtoNamespace,
        DirectoryInfo convertersDirectory, string convertersNamespace,
        DirectoryInfo crudHandlersDirectory, string crudHandlersNamespace,
        DirectoryInfo interfacesDirectory, string interfacesNamespace,
        DirectoryInfo crudServicesDirectory, string crudServicesNamespace,
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
        CrudHandlersDirectory = crudHandlersDirectory;
        CrudHandlersNamespace = crudHandlersNamespace;
        InterfacesDirectory = interfacesDirectory;
        InterfacesNamespace = interfacesNamespace;
        CrudServicesDirectory = crudServicesDirectory;
        CrudServicesNamespace = crudServicesNamespace;
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
    public DirectoryInfo CrudHandlersDirectory { get; }
    public string CrudHandlersNamespace { get; }
    public DirectoryInfo InterfacesDirectory { get; }
    public string InterfacesNamespace { get; }
    public DirectoryInfo CrudServicesDirectory { get; }
    public string CrudServicesNamespace { get; }
    public DirectoryInfo ModelsDirectory { get; }
    public string ModelsNamespace { get; }
}
