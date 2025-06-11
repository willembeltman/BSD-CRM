using BSD.Business.Converters;
using BSD.Business.ServiceHandlers;
using BSD.Business.Interfaces;
using BSD.Data;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using CodeGenerator.Shared.Attributes;

namespace BSD.Business.Services;

public class WorkorderService(
    ApplicationDbContext db,
    IAuthenticationStateService authenticationService)
    : IWorkorderService
{
    [TsServiceMethod("Workorder", "Create")]
    public WorkorderCreateResponse Create(WorkorderCreateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new WorkorderCreateResponse() { State = state, ErrorGettingState = true };

        var handler = new WorkorderServiceHandler(state);
        var entity = handler.FindByMatch(db, request.Workorder);
        if (entity != null)
            return new WorkorderCreateResponse() { State = state, ErrorAlreadyUsed = true };

        entity = request.Workorder.ToEntity();
        if (!handler.AttachToState(db, entity))
            return new WorkorderCreateResponse() { State = state, ErrorAttachingState = true };

        if (!handler.CanCreate(db, entity))
            return new WorkorderCreateResponse() { State = state, ErrorNotAuthorized = true };

        db.Workorders.Add(entity);
        db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new WorkorderCreateResponse() { State = state, ErrorUpdatingState = true };

        return new WorkorderCreateResponse() { State = state, Workorder = dto, Success = true };
    }

    [TsServiceMethod("Workorder", "Read")]
    public WorkorderReadResponse Read(WorkorderReadRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new WorkorderReadResponse() { State = state, ErrorGettingState = true };

        var handler = new WorkorderServiceHandler(state);
        var entity = handler.FindById(db, request.WorkorderId);
        if (entity == null)
            return new WorkorderReadResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanRead(db, entity))
            return new WorkorderReadResponse() { State = state, ErrorNotAuthorized = true };

        var dto = entity.ToDto();
        return new WorkorderReadResponse() { State = state, Workorder = dto, Success = true, };
    }

    [TsServiceMethod("Workorder", "Update")]
    public WorkorderUpdateResponse Update(WorkorderUpdateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new WorkorderUpdateResponse() { State = state, ErrorGettingState = true };

        var handler = new WorkorderServiceHandler(state);
        var entity = handler.FindById(db, request.Workorder.Id);
        if (entity == null)
            return new WorkorderUpdateResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanUpdate(db, entity))
            return new WorkorderUpdateResponse() { State = state, ErrorNotAuthorized = true };

        if (request.Workorder.CopyTo(entity))
            db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new WorkorderUpdateResponse() { State = state, ErrorUpdatingState = true };

        return new WorkorderUpdateResponse() { State = state, Workorder = dto, Success = true };
    }

    [TsServiceMethod("Workorder", "Delete")]
    public WorkorderDeleteResponse Delete(WorkorderDeleteRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new WorkorderDeleteResponse() { State = state, ErrorGettingState = true };

        var handler = new WorkorderServiceHandler(state);
        var entity = handler.FindById(db, request.WorkorderId);
        if (entity == null)
            return new WorkorderDeleteResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanDelete(db, entity))
            return new WorkorderDeleteResponse() { State = state, ErrorNotAuthorized = true };

        if (!handler.DeleteFromState(db, entity))
            return new WorkorderDeleteResponse() { State = state, ErrorUpdatingState = true };

        db.Workorders.Remove(entity);
        db.SaveChanges();

        return new WorkorderDeleteResponse() { State = state, Success = true };
    }

    [TsServiceMethod("Workorder", "List")]
    public WorkorderListResponse List(WorkorderListRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new WorkorderListResponse() { State = state, ErrorGettingState = true };

        var handler = new WorkorderServiceHandler(state);
        if (!handler.CanList(db))
            return new WorkorderListResponse() { State = state, ErrorNotAuthorized = true };

        var entities = handler.ListAll(db);
        var dtos = entities
            .Select(a => a.ToDto()!)
            .ToArray();

        return new WorkorderListResponse()
        {
            Success = true,
            State = state,
            Workorders = dtos
        };
    }
}