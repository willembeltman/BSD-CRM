namespace CodeGenerator.Step1.DtosConvertersAndServices;

public class GeneratorConfig
{
    public GeneratorConfig(
        Type dbContextType,
        DirectoryInfo dtoDirectory, string dtoNamespace,
        DirectoryInfo requestDtoDirectory, string requestDtoNamespace,
        DirectoryInfo responseDtoDirectory, string responseDtoNamespace,
        DirectoryInfo convertersDirectory, string convertersNamespace,
        DirectoryInfo interfacesDirectory, string interfacesNamespace,
        DirectoryInfo crudHandlersDirectory, string crudHandlersNamespace,
        DirectoryInfo crudServicesDirectory, string crudServicesNamespace,
        DirectoryInfo crudInterfacesDirectory, string crudInterfacesNamespace,
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
        InterfacesDirectory = interfacesDirectory;
        InterfacesNamespace = interfacesNamespace;
        ModelsDirectory = modelsDirectory;
        ModelsNamespace = modelsNamespace;
        CrudHandlersDirectory = crudHandlersDirectory;
        CrudHandlersNamespace = crudHandlersNamespace;
        CrudServicesDirectory = crudServicesDirectory;
        CrudServicesNamespace = crudServicesNamespace;
        CrudInterfacesDirectory = crudInterfacesDirectory;
        CrudInterfacesNamespace = crudInterfacesNamespace;
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
    public DirectoryInfo CrudInterfacesDirectory { get; }
    public string CrudInterfacesNamespace { get; }
    public DirectoryInfo ModelsDirectory { get; }
    public string ModelsNamespace { get; }
}
