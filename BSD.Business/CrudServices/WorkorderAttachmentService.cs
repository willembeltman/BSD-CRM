using BSD.Business.Converters;
using BSD.Business.CrudHandlers;
using BSD.Business.Interfaces;
using BSD.Data;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using CodeGenerator.Shared.Attributes;

namespace BSD.Business.CrudServices;

public class WorkorderAttachmentService(
    ApplicationDbContext db,
    IAuthenticationStateService authenticationService)
    : IWorkorderAttachmentService
{
    [TsServiceMethod("WorkorderAttachment", "Create")]
    public WorkorderAttachmentCreateResponse Create(WorkorderAttachmentCreateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new WorkorderAttachmentCreateResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new WorkorderAttachmentCreateResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new WorkorderAttachmentServiceHandler(state);
        var entity = handler.FindByMatch(db, request.WorkorderAttachment);
        if (entity != null)
            return new WorkorderAttachmentCreateResponse() { State = state, ErrorAlreadyUsed = true };

        entity = request.WorkorderAttachment.ToEntity();
        if (!handler.AttachToState(db, entity))
            return new WorkorderAttachmentCreateResponse() { State = state, ErrorAttachingState = true };

        if (!handler.CanCreate(db, entity))
            return new WorkorderAttachmentCreateResponse() { State = state, ErrorNotAuthorized = true };

        db.WorkorderAttachments.Add(entity);
        db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new WorkorderAttachmentCreateResponse() { State = state, ErrorUpdatingState = true };

        return new WorkorderAttachmentCreateResponse() { State = state, WorkorderAttachment = dto, Success = true };
    }

    [TsServiceMethod("WorkorderAttachment", "Read")]
    public WorkorderAttachmentReadResponse Read(WorkorderAttachmentReadRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new WorkorderAttachmentReadResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new WorkorderAttachmentReadResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new WorkorderAttachmentServiceHandler(state);
        var entity = handler.FindById(db, request.WorkorderAttachmentId);
        if (entity == null)
            return new WorkorderAttachmentReadResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanRead(db, entity))
            return new WorkorderAttachmentReadResponse() { State = state, ErrorNotAuthorized = true };

        var dto = entity.ToDto();
        return new WorkorderAttachmentReadResponse() { State = state, WorkorderAttachment = dto, Success = true, };
    }

    [TsServiceMethod("WorkorderAttachment", "Update")]
    public WorkorderAttachmentUpdateResponse Update(WorkorderAttachmentUpdateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new WorkorderAttachmentUpdateResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new WorkorderAttachmentUpdateResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new WorkorderAttachmentServiceHandler(state);
        var entity = handler.FindById(db, request.WorkorderAttachment.Id);
        if (entity == null)
            return new WorkorderAttachmentUpdateResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanUpdate(db, entity))
            return new WorkorderAttachmentUpdateResponse() { State = state, ErrorNotAuthorized = true };

        if (request.WorkorderAttachment.CopyTo(entity))
            db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new WorkorderAttachmentUpdateResponse() { State = state, ErrorUpdatingState = true };

        return new WorkorderAttachmentUpdateResponse() { State = state, WorkorderAttachment = dto, Success = true };
    }

    [TsServiceMethod("WorkorderAttachment", "Delete")]
    public WorkorderAttachmentDeleteResponse Delete(WorkorderAttachmentDeleteRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new WorkorderAttachmentDeleteResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new WorkorderAttachmentDeleteResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new WorkorderAttachmentServiceHandler(state);
        var entity = handler.FindById(db, request.WorkorderAttachmentId);
        if (entity == null)
            return new WorkorderAttachmentDeleteResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanDelete(db, entity))
            return new WorkorderAttachmentDeleteResponse() { State = state, ErrorNotAuthorized = true };

        if (!handler.DeleteFromState(db, entity))
            return new WorkorderAttachmentDeleteResponse() { State = state, ErrorUpdatingState = true };

        db.WorkorderAttachments.Remove(entity);
        db.SaveChanges();

        return new WorkorderAttachmentDeleteResponse() { State = state, Success = true };
    }

    [TsServiceMethod("WorkorderAttachment", "List")]
    public WorkorderAttachmentListResponse List(WorkorderAttachmentListRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new WorkorderAttachmentListResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new WorkorderAttachmentListResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new WorkorderAttachmentServiceHandler(state);
        if (!handler.CanList(db))
            return new WorkorderAttachmentListResponse() { State = state, ErrorNotAuthorized = true };

        var entities = handler.ListAll(db);
        var dtos = entities
            .Select(a => a.ToDto()!)
            .ToArray();

        return new WorkorderAttachmentListResponse()
        {
            Success = true,
            State = state,
            WorkorderAttachments = dtos
        };
    }
}