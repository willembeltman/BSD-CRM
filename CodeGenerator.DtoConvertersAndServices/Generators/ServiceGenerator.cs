using CodeGenerator.DtoConvertersAndServices;

namespace CodeGenerator.Dtos_Converters_Services.Generators
{
    public class ServiceGenerator
    {
        private Generator generator;
        private ServiceInterfaceGenerator serviceInterface;
        private DirectoryInfo dtoConvertersDirectory;
        private string dtoConvertersNamespace;

        public ServiceGenerator(Generator generator, ServiceInterfaceGenerator serviceInterface, DirectoryInfo dtoConvertersDirectory, string dtoConvertersNamespace)
        {
            this.generator = generator;
            this.serviceInterface = serviceInterface;
            this.dtoConvertersDirectory = dtoConvertersDirectory;
            this.dtoConvertersNamespace = dtoConvertersNamespace;
        }

        internal void GenerateCode()
        {
            throw new NotImplementedException();
        }
    }
}