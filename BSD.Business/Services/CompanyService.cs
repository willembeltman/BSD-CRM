using BSD.Business.Converters;
using BSD.Business.ServiceHandlers;
using BSD.Business.Interfaces;
using BSD.Data;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using CodeGenerator.Shared.Attributes;

namespace BSD.Business.Services;

public class CompanyService(
    ApplicationDbContext db,
    IAuthenticationStateService authenticationService)
    : ICompanyService
{
    [TsServiceMethod("Company", "Create")]
    public CompanyCreateResponse Create(CompanyCreateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new CompanyCreateResponse() { State = state, ErrorGettingState = true };

        var handler = new CompanyServiceHandler(state);
        var entity = handler.FindByMatch(db, request.Company);
        if (entity != null)
            return new CompanyCreateResponse() { State = state, ErrorAlreadyUsed = true };

        entity = request.Company.ToEntity();
        if (!handler.AttachToState(db, entity))
            return new CompanyCreateResponse() { State = state, ErrorAttachingState = true };

        if (!handler.CanCreate(db, entity))
            return new CompanyCreateResponse() { State = state, ErrorNotAuthorized = true };

        db.Companies.Add(entity);
        db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new CompanyCreateResponse() { State = state, ErrorUpdatingState = true };

        return new CompanyCreateResponse() { State = state, Company = dto, Success = true };
    }

    [TsServiceMethod("Company", "Read")]
    public CompanyReadResponse Read(CompanyReadRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new CompanyReadResponse() { State = state, ErrorGettingState = true };

        var handler = new CompanyServiceHandler(state);
        var entity = handler.FindById(db, request.CompanyId);
        if (entity == null)
            return new CompanyReadResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanRead(db, entity))
            return new CompanyReadResponse() { State = state, ErrorNotAuthorized = true };

        var dto = entity.ToDto();
        return new CompanyReadResponse() { State = state, Company = dto, Success = true, };
    }

    [TsServiceMethod("Company", "Update")]
    public CompanyUpdateResponse Update(CompanyUpdateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new CompanyUpdateResponse() { State = state, ErrorGettingState = true };

        var handler = new CompanyServiceHandler(state);
        var entity = handler.FindById(db, request.Company.Id);
        if (entity == null)
            return new CompanyUpdateResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanUpdate(db, entity))
            return new CompanyUpdateResponse() { State = state, ErrorNotAuthorized = true };

        if (request.Company.CopyTo(entity))
            db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new CompanyUpdateResponse() { State = state, ErrorUpdatingState = true };

        return new CompanyUpdateResponse() { State = state, Company = dto, Success = true };
    }

    [TsServiceMethod("Company", "Delete")]
    public CompanyDeleteResponse Delete(CompanyDeleteRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new CompanyDeleteResponse() { State = state, ErrorGettingState = true };

        var handler = new CompanyServiceHandler(state);
        var entity = handler.FindById(db, request.CompanyId);
        if (entity == null)
            return new CompanyDeleteResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanDelete(db, entity))
            return new CompanyDeleteResponse() { State = state, ErrorNotAuthorized = true };

        if (!handler.DeleteFromState(db, entity))
            return new CompanyDeleteResponse() { State = state, ErrorUpdatingState = true };

        db.Companies.Remove(entity);
        db.SaveChanges();

        return new CompanyDeleteResponse() { State = state, Success = true };
    }

    [TsServiceMethod("Company", "List")]
    public CompanyListResponse List(CompanyListRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new CompanyListResponse() { State = state, ErrorGettingState = true };

        var handler = new CompanyServiceHandler(state);
        if (!handler.CanList(db))
            return new CompanyListResponse() { State = state, ErrorNotAuthorized = true };

        var entities = handler.ListAll(db);
        var dtos = entities
            .Select(a => a.ToDto()!)
            .ToArray();

        return new CompanyListResponse()
        {
            Success = true,
            State = state,
            Companys = dtos
        };
    }
}