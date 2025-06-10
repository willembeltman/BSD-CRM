using CodeGenerator.Dtos_Converters_Services.Generators;
using CodeGenerator.Step1.DtosConvertersAndServices.Entities;

namespace CodeGenerator.Step1.DtosConvertersAndServices.Generators
{
    public class StateDtoGenerator : BaseGenerator
    {
        public StateDtoGenerator(BaseRequestGenerator baseRequest, DirectoryInfo dtoDirectory, string dtoNamespace)
        {
            BaseRequest = baseRequest;
            Directory = dtoDirectory;
            Namespace = dtoNamespace;

            DbContext = BaseRequest.DbContext;

            Name = "State";
        }

        public BaseRequestGenerator BaseRequest { get; }
        public DbContext DbContext { get; }

        public void GenerateCode()
        {
            /// User wijst naar: 
            /// Company, en die wijst weer naar: 
            /// Country.

            //namespace BSD.Shared.Dtos;

            //public class State
            //{
            //    public string? BearerId { get; set; }
            //    public User? User { get; set; }
            //    public Company? CurrentCompany { get; set; }
            //    public Country? Country { get; set; }
            //}

            var propertieCode  = string.Join("", DbContext.UserPointers
                .Select(a => $"    public {a.Type.Name}? {a.PropertyName} {{ get; set; }}\r\n"));
            Code = $@"namespace {Namespace};

public class {Name}
{{
    public string? BearerId {{ get; set; }}
    public {DbContext.UserEntity.Name}? {DbContext.UserEntity.Name} {{ get; set; }}
{propertieCode}}}
";

            Save();
        }
    }
}