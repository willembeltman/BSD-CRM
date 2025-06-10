using CodeGenerator.Dtos_Converters_Services.Generators;
using CodeGenerator.Step1.DtosConvertersAndServices.Entities;

namespace CodeGenerator.Step1.DtosConvertersAndServices.Generators
{
    public class AuthenticationStateGenerator : BaseGenerator
    {
        public AuthenticationStateGenerator(BaseResponseGenerator baseResponse, DirectoryInfo modelsDirectory, string modelsNamespace)
        {
            BaseResponse = baseResponse;

            Directory = modelsDirectory;
            Namespace = modelsNamespace;

            StateDto = BaseResponse.StateDto;
            BaseRequest = StateDto.BaseRequest;
            DbContext = BaseRequest.DbContext;

            Name = "AuthenticationState";
        }

        public BaseResponseGenerator BaseResponse { get; }
        public StateDtoGenerator StateDto { get; }
        public BaseRequestGenerator BaseRequest { get; }
        public DbContext DbContext { get; }

        public void GenerateCode()
        {
            /// User wijst naar: 
            /// Company, en die wijst weer naar: 
            /// Country.
            /// 

            //using BSD.Data.Entities;

            //namespace BSD.Business.Models;

            //public class AuthenticationState : Shared.Dtos.State
            //{
            //    public bool Success { get; set; }
            //    public User? DbUser { get; set; }
            //    public Company? DbCurrentCompany { get; set; }
            //    public Country? DbCountry { get; set; }
            //}

            var usingCode = "";
            var propertyCode = "";

            usingCode = AddNamespace(usingCode, $"using {DbContext.UserEntity.Type.Namespace};");

            foreach (var pointer in DbContext.UserPointers)
            {
                usingCode = AddNamespace(usingCode, $"using {pointer.Type.Namespace};");
                propertyCode += $"    public {pointer.Type.Name}? Db{pointer.PropertyName} {{ get; set; }}\r\n";
            }

            Code = $@"{usingCode}
namespace {Namespace};

public class {Name} : {StateDto.FullName}
{{
    public bool Success {{ get; set; }}
    public {DbContext.UserEntity.Name}? Db{DbContext.UserEntity.Name} {{ get; set; }}
{propertyCode}}}
";

            Save();
        }
    }
}