using BSD.Business.Converters;
using BSD.Business.ServiceHandlers;
using BSD.Business.Interfaces;
using BSD.Data;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using CodeGenerator.Shared.Attributes;

namespace BSD.Business.CrudServices;

public class CompanyUserService(
    ApplicationDbContext db,
    IAuthenticationStateService authenticationService)
    : ICompanyUserService
{
    [TsServiceMethod("CompanyUser", "Create")]
    public CompanyUserCreateResponse Create(CompanyUserCreateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new CompanyUserCreateResponse() { State = state, ErrorGettingState = true };

        var handler = new CompanyUserServiceHandler(state);
        var entity = handler.FindByMatch(db, request.CompanyUser);
        if (entity != null)
            return new CompanyUserCreateResponse() { State = state, ErrorAlreadyUsed = true };

        entity = request.CompanyUser.ToEntity();
        if (!handler.AttachToState(db, entity))
            return new CompanyUserCreateResponse() { State = state, ErrorAttachingState = true };

        if (!handler.CanCreate(db, entity))
            return new CompanyUserCreateResponse() { State = state, ErrorNotAuthorized = true };

        db.CompanyUsers.Add(entity);
        db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new CompanyUserCreateResponse() { State = state, ErrorUpdatingState = true };

        return new CompanyUserCreateResponse() { State = state, CompanyUser = dto, Success = true };
    }

    [TsServiceMethod("CompanyUser", "Read")]
    public CompanyUserReadResponse Read(CompanyUserReadRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new CompanyUserReadResponse() { State = state, ErrorGettingState = true };

        var handler = new CompanyUserServiceHandler(state);
        var entity = handler.FindById(db, request.CompanyUserId);
        if (entity == null)
            return new CompanyUserReadResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanRead(db, entity))
            return new CompanyUserReadResponse() { State = state, ErrorNotAuthorized = true };

        var dto = entity.ToDto();
        return new CompanyUserReadResponse() { State = state, CompanyUser = dto, Success = true, };
    }

    [TsServiceMethod("CompanyUser", "Update")]
    public CompanyUserUpdateResponse Update(CompanyUserUpdateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new CompanyUserUpdateResponse() { State = state, ErrorGettingState = true };

        var handler = new CompanyUserServiceHandler(state);
        var entity = handler.FindById(db, request.CompanyUser.Id);
        if (entity == null)
            return new CompanyUserUpdateResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanUpdate(db, entity))
            return new CompanyUserUpdateResponse() { State = state, ErrorNotAuthorized = true };

        if (request.CompanyUser.CopyTo(entity))
            db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new CompanyUserUpdateResponse() { State = state, ErrorUpdatingState = true };

        return new CompanyUserUpdateResponse() { State = state, CompanyUser = dto, Success = true };
    }

    [TsServiceMethod("CompanyUser", "Delete")]
    public CompanyUserDeleteResponse Delete(CompanyUserDeleteRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new CompanyUserDeleteResponse() { State = state, ErrorGettingState = true };

        var handler = new CompanyUserServiceHandler(state);
        var entity = handler.FindById(db, request.CompanyUserId);
        if (entity == null)
            return new CompanyUserDeleteResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanDelete(db, entity))
            return new CompanyUserDeleteResponse() { State = state, ErrorNotAuthorized = true };

        if (!handler.DeleteFromState(db, entity))
            return new CompanyUserDeleteResponse() { State = state, ErrorUpdatingState = true };

        db.CompanyUsers.Remove(entity);
        db.SaveChanges();

        return new CompanyUserDeleteResponse() { State = state, Success = true };
    }

    [TsServiceMethod("CompanyUser", "List")]
    public CompanyUserListResponse List(CompanyUserListRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new CompanyUserListResponse() { State = state, ErrorGettingState = true };

        var handler = new CompanyUserServiceHandler(state);
        if (!handler.CanList(db))
            return new CompanyUserListResponse() { State = state, ErrorNotAuthorized = true };

        var entities = handler.ListAll(db);
        var dtos = entities
            .Select(a => a.ToDto()!)
            .ToArray();

        return new CompanyUserListResponse()
        {
            Success = true,
            State = state,
            CompanyUsers = dtos
        };
    }
}