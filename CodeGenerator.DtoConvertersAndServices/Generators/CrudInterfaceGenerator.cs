using CodeGenerator.Step1.DtosConvertersAndServices.Entities;
using CodeGenerator.Step1.DtosConvertersAndServices.Generators;

namespace CodeGenerator.Dtos_Converters_Services.Generators;

public class CrudInterfaceGenerator : BaseGenerator
{
    public CrudInterfaceGenerator(
        CrudHandlerGenerator serviceHandler,
        DirectoryInfo dtoConvertersDirectory,
        string dtoConvertersNamespace)
    {
        ServiceHandler = serviceHandler;
        Directory = dtoConvertersDirectory;
        Namespace = dtoConvertersNamespace;

        DtoConverter = serviceHandler.DtoConverter;
        Dto = DtoConverter.Dto;
        DbSet = Dto.DbSet;
        Entity = DbSet.Entity;
        IAuthenticationStateService = Dto.IAuthenticationStateService;
        AuthenticationState = IAuthenticationStateService.AuthenticationState;
        BaseResponse = AuthenticationState.BaseResponse;
        StateDto = BaseResponse.StateDto;
        BaseRequest = StateDto.BaseRequest;
        DbContext = BaseRequest.DbContext;

        Name = $"I{Entity.Name}Service";
    }

    public CrudHandlerGenerator ServiceHandler { get; }
    public DtoConverterGenerator DtoConverter { get; }
    public DtoGenerator Dto { get; }
    public DbSet DbSet { get; }
    public Entity Entity { get; }
    public IAuthenticationStateServiceGenerator IAuthenticationStateService { get; }
    public AuthenticationStateGenerator AuthenticationState { get; private set; }
    public BaseResponseGenerator BaseResponse { get; }
    public StateDtoGenerator StateDto { get; }
    public BaseRequestGenerator BaseRequest { get; }
    public DbContext DbContext { get; }

    public void GenerateCode()
    {
        //// Example output:
        //using BSD.Shared.RequestDtos;
        //using BSD.Shared.ResponseDtos;

        //namespace BSD.Business.Interfaces;

        //public interface ICompanyService
        //{
        //    CompanyCreateResponse Create(CompanyCreateRequest request);
        //    CompanyDeleteResponse Delete(CompanyDeleteRequest request);
        //    CompanyListResponse List(CompanyListRequest request);
        //    CompanyReadResponse Read(CompanyReadRequest request);
        //    CompanyUpdateResponse Update(CompanyUpdateRequest request);
        //}


        Code = $@"using {BaseRequest.Namespace};
using {BaseResponse.Namespace};

namespace {Namespace};

public interface {Name}
{{
    {Dto.CreateResponse.Name} Create({Dto.CreateRequest.Name} request);
    {Dto.DeleteResponse.Name} Delete({Dto.DeleteRequest.Name} request);
    {Dto.ListResponse.Name} List({Dto.ListRequest.Name} request);
    {Dto.ReadResponse.Name} Read({Dto.ReadRequest.Name} request);
    {Dto.UpdateResponse.Name} Update({Dto.UpdateRequest.Name} request);
}}";
        Save();
    }
}