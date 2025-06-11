using CodeGenerator.Step1.DtosConvertersAndServices.Entities;
using CodeGenerator.Step1.DtosConvertersAndServices.Generators;

namespace CodeGenerator.Dtos_Converters_Services.Generators;

public class CrudServiceGenerator : BaseGenerator
{
    public CrudServiceGenerator(
        CrudInterfaceGenerator serviceInterface,
        DirectoryInfo servicesDirectory,
        string servicesNamespace)
    {
        ServiceInterface = serviceInterface;
        Directory = servicesDirectory;
        Namespace = servicesNamespace;

        ServiceHandler = serviceInterface.ServiceHandler;
        DtoConverter = ServiceHandler.DtoConverter;
        Dto = DtoConverter.Dto;
        DbSet = Dto.DbSet;
        Entity = DbSet.Entity;
        IAuthenticationStateService = Dto.IAuthenticationStateService;
        AuthenticationState = IAuthenticationStateService.AuthenticationState;
        BaseResponse = AuthenticationState.BaseResponse;
        StateDto = BaseResponse.StateDto;
        BaseRequest = StateDto.BaseRequest;
        DbContext = BaseRequest.DbContext;

        Name = $"{Entity.Name}CrudService";
    }

    public CrudInterfaceGenerator ServiceInterface { get; }
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
        #region Example code
        //using BSD.Business.Converters;
        //using BSD.Business.ServiceHandlers;
        //using BSD.Business.Interfaces;
        //using BSD.Data;
        //using BSD.Shared.RequestDtos;
        //using BSD.Shared.ResponseDtos;
        //using CodeGenerator.Shared.Attributes;

        //namespace BSD.Business.Services;

        //public class CompanyService(
        //    ApplicationDbContext db,
        //    IAuthenticationStateService authenticationService)
        //    : ICompanyService
        //{
        //    [TsServiceMethod("Company", "Create")]
        //    public CompanyCreateResponse Create(CompanyCreateRequest request)
        //    {
        //        var state = authenticationService.GetState(request);
        //        if (!state.Success)
        //            return new CompanyCreateResponse() { State = state, ErrorGettingState = true };

        //        //if (handler.Authorize)
        //            if (state.User == null || state.DbUser == null)
        //                return new CompanyCreateResponse() { State = state, ErrorNotAuthorized = true };

        //        var handler = new CompanyServiceHandler(state);
        //        var entity = handler.FindByMatch(db, request.Company);
        //        if (entity != null)
        //            return new CompanyCreateResponse() { State = state, ErrorAlreadyUsed = true };

        //        entity = request.Company.ToEntity();
        //        if (!handler.AttachToState(db, entity))
        //            return new CompanyCreateResponse() { State = state, ErrorAttachingState = true };

        //        if (!handler.CanCreate(db, entity))
        //            return new CompanyCreateResponse() { State = state, ErrorNotAuthorized = true };

        //        db.Companies.Add(entity);
        //        db.SaveChanges();

        //        var dto = entity.ToDto();
        //        if (!handler.UpdateToState(db, entity, dto))
        //            return new CompanyCreateResponse() { State = state, ErrorUpdatingState = true };

        //        return new CompanyCreateResponse() { State = state, Company = dto, Success = true };
        //    }

        //    [TsServiceMethod("Company", "Read")]
        //    public CompanyReadResponse Read(CompanyReadRequest request)
        //    {
        //        var state = authenticationService.GetState(request);
        //        if (!state.Success)
        //            return new CompanyReadResponse() { State = state, ErrorGettingState = true };

        //        //if (handler.Authorize)
        //            if (state.User == null || state.DbUser == null)
        //                return new CompanyReadResponse() { State = state, ErrorNotAuthorized = true };

        //        var handler = new CompanyServiceHandler(state);
        //        var entity = handler.FindById(db, request.CompanyId);
        //        if (entity == null)
        //            return new CompanyReadResponse() { State = state, ErrorItemNotFound = true };

        //        if (!handler.CanRead(db, entity))
        //            return new CompanyReadResponse() { State = state, ErrorNotAuthorized = true };

        //        var dto = entity.ToDto();
        //        return new CompanyReadResponse() { State = state, Company = dto, Success = true, };
        //    }

        //    [TsServiceMethod("Company", "Update")]
        //    public CompanyUpdateResponse Update(CompanyUpdateRequest request)
        //    {
        //        var state = authenticationService.GetState(request);
        //        if (!state.Success)
        //            return new CompanyUpdateResponse() { State = state, ErrorGettingState = true };

        //        //if (handler.Authorize)
        //            if (state.User == null || state.DbUser == null)
        //                return new CompanyUpdateResponse() { State = state, ErrorNotAuthorized = true };

        //        var handler = new CompanyServiceHandler(state);
        //        var entity = handler.FindById(db, request.Company.Id);
        //        if (entity == null)
        //            return new CompanyUpdateResponse() { State = state, ErrorItemNotFound = true };

        //        if (!handler.CanUpdate(db, entity))
        //            return new CompanyUpdateResponse() { State = state, ErrorNotAuthorized = true };

        //        if (request.Company.CopyTo(entity))
        //            db.SaveChanges();

        //        var dto = entity.ToDto();
        //        if (!handler.UpdateToState(db, entity, dto))
        //            return new CompanyUpdateResponse() { State = state, ErrorUpdatingState = true };

        //        return new CompanyUpdateResponse() { State = state, Company = dto, Success = true };
        //    }

        //    [TsServiceMethod("Company", "Delete")]
        //    public CompanyDeleteResponse Delete(CompanyDeleteRequest request)
        //    {
        //        var state = authenticationService.GetState(request);
        //        if (!state.Success)
        //            return new CompanyDeleteResponse() { State = state, ErrorGettingState = true };

        //        //if (handler.Authorize)
        //            if (state.User == null || state.DbUser == null)
        //                return new CompanyDeleteResponse() { State = state, ErrorNotAuthorized = true };

        //        var handler = new CompanyServiceHandler(state);
        //        var entity = handler.FindById(db, request.CompanyId);
        //        if (entity == null)
        //            return new CompanyDeleteResponse() { State = state, ErrorItemNotFound = true };

        //        if (!handler.CanDelete(db, entity))
        //            return new CompanyDeleteResponse() { State = state, ErrorNotAuthorized = true };

        //        if (!handler.DeleteFromState(db, entity))
        //            return new CompanyDeleteResponse() { State = state, ErrorUpdatingState = true };

        //        db.CompanyUsers.RemoveRange(entity.CompanyUsers);
        //        db.Companies.Remove(entity);
        //        db.SaveChanges();

        //        return new CompanyDeleteResponse() { State = state, Success = true };
        //    }

        //    [TsServiceMethod("Company", "List")]
        //    public CompanyListResponse List(CompanyListRequest request)
        //    {
        //        var state = authenticationService.GetState(request);
        //        if (!state.Success)
        //            return new CompanyListResponse() { State = state, ErrorGettingState = true };

        //        //if (handler.Authorize)
        //            if (state.User == null || state.DbUser == null)
        //                return new CompanyListResponse() { State = state, ErrorNotAuthorized = true };

        //        var handler = new CompanyServiceHandler(state);
        //        if (!handler.CanList(db))
        //            return new CompanyListResponse() { State = state, ErrorNotAuthorized = true };

        //        var entities = handler.ListAll(db);
        //        var dtos = entities
        //            .Select(a => a.ToDto()!)
        //            .ToArray();

        //        return new CompanyListResponse()
        //        {
        //            Success = true,
        //            State = state,
        //            Companys = dtos
        //        };
        //    }
        //}
        #endregion

        Code = $@"using {DtoConverter.Namespace};
using {ServiceHandler.Namespace};
using {ServiceInterface.Namespace};
using {DbContext.Type.Namespace};
using {BaseRequest.Namespace};
using {BaseResponse.Namespace};
using CodeGenerator.Shared.Attributes;

namespace {Namespace};

public class {Name}(
    {DbContext.Name} db,
    {IAuthenticationStateService.Name} authenticationService)
    : {ServiceInterface.Name}
{{
    [TsServiceMethod(""{Entity.Name}"", ""Create"")]
    public {Dto.CreateResponse.Name} Create({Dto.CreateRequest.Name} request)
    {{
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new {Dto.CreateResponse.Name}() {{ State = state, ErrorGettingState = true }};
" + (Entity.IsAuthorize ? $@"
        if (state.User == null || state.DbUser == null)
            return new {Dto.CreateResponse.Name}() {{ State = state, ErrorNotAuthorized = true }};
" : "") + $@"
        var handler = new {ServiceHandler.Name}(state);
        var entity = handler.FindByMatch(db, request.{Entity.Name});
        if (entity != null)
            return new {Dto.CreateResponse.Name}() {{ State = state, ErrorAlreadyUsed = true }};

        entity = request.{Entity.Name}.ToEntity();
        if (!handler.AttachToState(db, entity))
            return new {Dto.CreateResponse.Name}() {{ State = state, ErrorAttachingState = true }};

        if (!handler.CanCreate(db, entity))
            return new {Dto.CreateResponse.Name}() {{ State = state, ErrorNotAuthorized = true }};

        db.{DbSet.Name}.Add(entity);
        db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new {Dto.CreateResponse.Name}() {{ State = state, ErrorUpdatingState = true }};

        return new {Dto.CreateResponse.Name}() {{ State = state, {Entity.Name} = dto, Success = true }};
    }}

    [TsServiceMethod(""{Entity.Name}"", ""Read"")]
    public {Dto.ReadResponse.Name} Read({Dto.ReadRequest.Name} request)
    {{
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new {Dto.ReadResponse.Name}() {{ State = state, ErrorGettingState = true }};
" + (Entity.IsAuthorize ? $@"
        if (state.User == null || state.DbUser == null)
            return new {Dto.ReadResponse.Name}() {{ State = state, ErrorNotAuthorized = true }};
" : "") + $@"
        var handler = new {ServiceHandler.Name}(state);
        var entity = handler.FindById(db, request.{Entity.Name}Id);
        if (entity == null)
            return new {Dto.ReadResponse.Name}() {{ State = state, ErrorItemNotFound = true }};

        if (!handler.CanRead(db, entity))
            return new {Dto.ReadResponse.Name}() {{ State = state, ErrorNotAuthorized = true }};

        var dto = entity.ToDto();
        return new {Dto.ReadResponse.Name}() {{ State = state, {Entity.Name} = dto, Success = true, }};
    }}

    [TsServiceMethod(""{Entity.Name}"", ""Update"")]
    public {Dto.UpdateResponse.Name} Update({Dto.UpdateRequest.Name} request)
    {{
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new {Dto.UpdateResponse.Name}() {{ State = state, ErrorGettingState = true }};
" + (Entity.IsAuthorize ? $@"
            if (state.User == null || state.DbUser == null)
                return new {Dto.UpdateResponse.Name}() {{ State = state, ErrorNotAuthorized = true }};
" : "") + $@"
        var handler = new {ServiceHandler.Name}(state);
        var entity = handler.FindById(db, request.{Entity.Name}.Id);
        if (entity == null)
            return new {Dto.UpdateResponse.Name}() {{ State = state, ErrorItemNotFound = true }};

        if (!handler.CanUpdate(db, entity))
            return new {Dto.UpdateResponse.Name}() {{ State = state, ErrorNotAuthorized = true }};

        if (request.{Entity.Name}.CopyTo(entity))
            db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new {Dto.UpdateResponse.Name}() {{ State = state, ErrorUpdatingState = true }};

        return new {Dto.UpdateResponse.Name}() {{ State = state, {Entity.Name} = dto, Success = true }};
    }}

    [TsServiceMethod(""{Entity.Name}"", ""Delete"")]
    public {Dto.DeleteResponse.Name} Delete({Dto.DeleteRequest.Name} request)
    {{
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new {Dto.DeleteResponse.Name}() {{ State = state, ErrorGettingState = true }};
" + (Entity.IsAuthorize ? $@"
        if (state.User == null || state.DbUser == null)
            return new {Dto.DeleteResponse.Name}() {{ State = state, ErrorNotAuthorized = true }};
" : "") + $@"
        var handler = new {ServiceHandler.Name}(state);
        var entity = handler.FindById(db, request.{Entity.Name}Id);
        if (entity == null)
            return new {Dto.DeleteResponse.Name}() {{ State = state, ErrorItemNotFound = true }};

        if (!handler.CanDelete(db, entity))
            return new {Dto.DeleteResponse.Name}() {{ State = state, ErrorNotAuthorized = true }};

        if (!handler.DeleteFromState(db, entity))
            return new {Dto.DeleteResponse.Name}() {{ State = state, ErrorUpdatingState = true }};

        db.{DbSet.Name}.Remove(entity);
        db.SaveChanges();

        return new {Dto.DeleteResponse.Name}() {{ State = state, Success = true }};
    }}

    [TsServiceMethod(""{Entity.Name}"", ""List"")]
    public {Dto.ListResponse.Name} List({Dto.ListRequest.Name} request)
    {{
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new {Dto.ListResponse.Name}() {{ State = state, ErrorGettingState = true }};
" + (Entity.IsAuthorize ? $@"
        if (state.User == null || state.DbUser == null)
            return new {Dto.ListResponse.Name}() {{ State = state, ErrorNotAuthorized = true }};
" : "") + $@"
        var handler = new {ServiceHandler.Name}(state);
        if (!handler.CanList(db))
            return new {Dto.ListResponse.Name}() {{ State = state, ErrorNotAuthorized = true }};

        var entities = handler.ListAll(db);
        var dtos = entities
            .Select(a => a.ToDto()!)
            .ToArray();

        return new {Dto.ListResponse.Name}()
        {{
            Success = true,
            State = state,
            {Entity.Name}s = dtos
        }};
    }}
}}";

        Save();
    }
}