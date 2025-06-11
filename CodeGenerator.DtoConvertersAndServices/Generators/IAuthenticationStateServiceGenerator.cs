using CodeGenerator.Dtos_Converters_Services.Generators;
using CodeGenerator.Step1.DtosConvertersAndServices.Entities;

namespace CodeGenerator.Step1.DtosConvertersAndServices.Generators;

public class IAuthenticationStateServiceGenerator : BaseGenerator
{
    public IAuthenticationStateServiceGenerator(AuthenticationStateGenerator authenticationState, DirectoryInfo interfacesDirectory, string interfacesNamespace)
    {
        AuthenticationState = authenticationState;
        Directory = interfacesDirectory;
        Namespace = interfacesNamespace;

        BaseResponse = AuthenticationState.BaseResponse;
        StateDto = BaseResponse.StateDto;
        BaseRequest = StateDto.BaseRequest;
        DbContext = BaseRequest.DbContext;

        Name = "IAuthenticationStateService";
    }

    public AuthenticationStateGenerator AuthenticationState { get; }
    public StateDtoGenerator StateDto { get; }
    public BaseResponseGenerator BaseResponse { get; }
    public BaseRequestGenerator BaseRequest { get; }
    public DbContext DbContext { get; }

    public void GenerateCode()
    {
        //using BSD.Business.Models;
        //using BSD.Shared.RequestDtos;

        //namespace BSD.Business.Interfaces;

        //public interface IAuthenticationStateService
        //{
        //    AuthenticationState GetState(BaseRequest request);
        //}

        Code = $@"using {AuthenticationState.Namespace};
using {BaseRequest.Namespace};

namespace {Namespace};

public interface {Name}
{{
    {AuthenticationState.Name} GetState({BaseRequest.Name} request);
}}";

        Save(false);
    }
}