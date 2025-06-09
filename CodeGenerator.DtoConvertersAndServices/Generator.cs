using CodeGenerator.DtoConvertersAndServices.Entities;

namespace CodeGenerator.DtoConvertersAndServices;

public class Generator
{
    public void GenerateCode(
        Type applicationDbContextType,
        string dtoFolderPath,
        string dtoNamespace,
        string dtoConvertersFolderPath,
        string dtoConvertersNamespace,
        string servicesFolderPath,
        string servicesNamespace)
    {
        var dbContext = new DbContext(applicationDbContextType);
    }
}
