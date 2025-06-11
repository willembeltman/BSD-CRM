using BSD.Business.Converters;
using BSD.Business.CrudHandlers;
using BSD.Business.Interfaces;
using BSD.Data;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using CodeGenerator.Shared.Attributes;

namespace BSD.Business.CrudServices;

public class UserService(
    ApplicationDbContext db,
    IAuthenticationStateService authenticationService)
    : IUserService
{
    [TsServiceMethod("User", "Create")]
    public UserCreateResponse Create(UserCreateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new UserCreateResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new UserCreateResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new UserServiceHandler(state);
        var entity = handler.FindByMatch(db, request.User);
        if (entity != null)
            return new UserCreateResponse() { State = state, ErrorAlreadyUsed = true };

        entity = request.User.ToEntity();
        if (!handler.AttachToState(db, entity))
            return new UserCreateResponse() { State = state, ErrorAttachingState = true };

        if (!handler.CanCreate(db, entity))
            return new UserCreateResponse() { State = state, ErrorNotAuthorized = true };

        db.Users.Add(entity);
        db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new UserCreateResponse() { State = state, ErrorUpdatingState = true };

        return new UserCreateResponse() { State = state, User = dto, Success = true };
    }

    [TsServiceMethod("User", "Read")]
    public UserReadResponse Read(UserReadRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new UserReadResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new UserReadResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new UserServiceHandler(state);
        var entity = handler.FindById(db, request.UserId);
        if (entity == null)
            return new UserReadResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanRead(db, entity))
            return new UserReadResponse() { State = state, ErrorNotAuthorized = true };

        var dto = entity.ToDto();
        return new UserReadResponse() { State = state, User = dto, Success = true, };
    }

    [TsServiceMethod("User", "Update")]
    public UserUpdateResponse Update(UserUpdateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new UserUpdateResponse() { State = state, ErrorGettingState = true };

            if (state.User == null || state.DbUser == null)
                return new UserUpdateResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new UserServiceHandler(state);
        var entity = handler.FindById(db, request.User.Id);
        if (entity == null)
            return new UserUpdateResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanUpdate(db, entity))
            return new UserUpdateResponse() { State = state, ErrorNotAuthorized = true };

        if (request.User.CopyTo(entity))
            db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new UserUpdateResponse() { State = state, ErrorUpdatingState = true };

        return new UserUpdateResponse() { State = state, User = dto, Success = true };
    }

    [TsServiceMethod("User", "Delete")]
    public UserDeleteResponse Delete(UserDeleteRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new UserDeleteResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new UserDeleteResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new UserServiceHandler(state);
        var entity = handler.FindById(db, request.UserId);
        if (entity == null)
            return new UserDeleteResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanDelete(db, entity))
            return new UserDeleteResponse() { State = state, ErrorNotAuthorized = true };

        if (!handler.DeleteFromState(db, entity))
            return new UserDeleteResponse() { State = state, ErrorUpdatingState = true };

        db.Users.Remove(entity);
        db.SaveChanges();

        return new UserDeleteResponse() { State = state, Success = true };
    }

    [TsServiceMethod("User", "List")]
    public UserListResponse List(UserListRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new UserListResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new UserListResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new UserServiceHandler(state);
        if (!handler.CanList(db))
            return new UserListResponse() { State = state, ErrorNotAuthorized = true };

        var entities = handler.ListAll(db);
        var dtos = entities
            .Select(a => a.ToDto()!)
            .ToArray();

        return new UserListResponse()
        {
            Success = true,
            State = state,
            Users = dtos
        };
    }
}