using BSD.Business.Converters;
using BSD.Business.CrudHandlers;
using BSD.Business.Interfaces;
using BSD.Data;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using CodeGenerator.Shared.Attributes;

namespace BSD.Business.CrudServices;

public class SettingService(
    ApplicationDbContext db,
    IAuthenticationStateService authenticationService)
    : ISettingService
{
    [TsServiceMethod("Setting", "Create")]
    public SettingCreateResponse Create(SettingCreateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new SettingCreateResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new SettingCreateResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new SettingServiceHandler(state);
        var entity = handler.FindByMatch(db, request.Setting);
        if (entity != null)
            return new SettingCreateResponse() { State = state, ErrorAlreadyUsed = true };

        entity = request.Setting.ToEntity();
        if (!handler.AttachToState(db, entity))
            return new SettingCreateResponse() { State = state, ErrorAttachingState = true };

        if (!handler.CanCreate(db, entity))
            return new SettingCreateResponse() { State = state, ErrorNotAuthorized = true };

        db.Settings.Add(entity);
        db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new SettingCreateResponse() { State = state, ErrorUpdatingState = true };

        return new SettingCreateResponse() { State = state, Setting = dto, Success = true };
    }

    [TsServiceMethod("Setting", "Read")]
    public SettingReadResponse Read(SettingReadRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new SettingReadResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new SettingReadResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new SettingServiceHandler(state);
        var entity = handler.FindById(db, request.SettingId);
        if (entity == null)
            return new SettingReadResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanRead(db, entity))
            return new SettingReadResponse() { State = state, ErrorNotAuthorized = true };

        var dto = entity.ToDto();
        return new SettingReadResponse() { State = state, Setting = dto, Success = true, };
    }

    [TsServiceMethod("Setting", "Update")]
    public SettingUpdateResponse Update(SettingUpdateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new SettingUpdateResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new SettingUpdateResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new SettingServiceHandler(state);
        var entity = handler.FindById(db, request.Setting.Id);
        if (entity == null)
            return new SettingUpdateResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanUpdate(db, entity))
            return new SettingUpdateResponse() { State = state, ErrorNotAuthorized = true };

        if (request.Setting.CopyTo(entity))
            db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new SettingUpdateResponse() { State = state, ErrorUpdatingState = true };

        return new SettingUpdateResponse() { State = state, Setting = dto, Success = true };
    }

    [TsServiceMethod("Setting", "Delete")]
    public SettingDeleteResponse Delete(SettingDeleteRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new SettingDeleteResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new SettingDeleteResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new SettingServiceHandler(state);
        var entity = handler.FindById(db, request.SettingId);
        if (entity == null)
            return new SettingDeleteResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanDelete(db, entity))
            return new SettingDeleteResponse() { State = state, ErrorNotAuthorized = true };

        if (!handler.DeleteFromState(db, entity))
            return new SettingDeleteResponse() { State = state, ErrorUpdatingState = true };

        db.Settings.Remove(entity);
        db.SaveChanges();

        return new SettingDeleteResponse() { State = state, Success = true };
    }

    [TsServiceMethod("Setting", "List")]
    public SettingListResponse List(SettingListRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new SettingListResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new SettingListResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new SettingServiceHandler(state);
        if (!handler.CanList(db))
            return new SettingListResponse() { State = state, ErrorNotAuthorized = true };

        var entities = handler.ListAll(db);
        var dtos = entities
            .Select(a => a.ToDto()!)
            .ToArray();

        return new SettingListResponse()
        {
            Success = true,
            State = state,
            Settings = dtos
        };
    }
}