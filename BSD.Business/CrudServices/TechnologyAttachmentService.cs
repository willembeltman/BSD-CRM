using BSD.Business.Converters;
using BSD.Business.ServiceHandlers;
using BSD.Business.Interfaces;
using BSD.Data;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using CodeGenerator.Shared.Attributes;

namespace BSD.Business.CrudServices;

public class TechnologyAttachmentService(
    ApplicationDbContext db,
    IAuthenticationStateService authenticationService)
    : ITechnologyAttachmentService
{
    [TsServiceMethod("TechnologyAttachment", "Create")]
    public TechnologyAttachmentCreateResponse Create(TechnologyAttachmentCreateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new TechnologyAttachmentCreateResponse() { State = state, ErrorGettingState = true };

        var handler = new TechnologyAttachmentServiceHandler(state);
        var entity = handler.FindByMatch(db, request.TechnologyAttachment);
        if (entity != null)
            return new TechnologyAttachmentCreateResponse() { State = state, ErrorAlreadyUsed = true };

        entity = request.TechnologyAttachment.ToEntity();
        if (!handler.AttachToState(db, entity))
            return new TechnologyAttachmentCreateResponse() { State = state, ErrorAttachingState = true };

        if (!handler.CanCreate(db, entity))
            return new TechnologyAttachmentCreateResponse() { State = state, ErrorNotAuthorized = true };

        db.TechnologyAttachments.Add(entity);
        db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new TechnologyAttachmentCreateResponse() { State = state, ErrorUpdatingState = true };

        return new TechnologyAttachmentCreateResponse() { State = state, TechnologyAttachment = dto, Success = true };
    }

    [TsServiceMethod("TechnologyAttachment", "Read")]
    public TechnologyAttachmentReadResponse Read(TechnologyAttachmentReadRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new TechnologyAttachmentReadResponse() { State = state, ErrorGettingState = true };

        var handler = new TechnologyAttachmentServiceHandler(state);
        var entity = handler.FindById(db, request.TechnologyAttachmentId);
        if (entity == null)
            return new TechnologyAttachmentReadResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanRead(db, entity))
            return new TechnologyAttachmentReadResponse() { State = state, ErrorNotAuthorized = true };

        var dto = entity.ToDto();
        return new TechnologyAttachmentReadResponse() { State = state, TechnologyAttachment = dto, Success = true, };
    }

    [TsServiceMethod("TechnologyAttachment", "Update")]
    public TechnologyAttachmentUpdateResponse Update(TechnologyAttachmentUpdateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new TechnologyAttachmentUpdateResponse() { State = state, ErrorGettingState = true };

        var handler = new TechnologyAttachmentServiceHandler(state);
        var entity = handler.FindById(db, request.TechnologyAttachment.Id);
        if (entity == null)
            return new TechnologyAttachmentUpdateResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanUpdate(db, entity))
            return new TechnologyAttachmentUpdateResponse() { State = state, ErrorNotAuthorized = true };

        if (request.TechnologyAttachment.CopyTo(entity))
            db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new TechnologyAttachmentUpdateResponse() { State = state, ErrorUpdatingState = true };

        return new TechnologyAttachmentUpdateResponse() { State = state, TechnologyAttachment = dto, Success = true };
    }

    [TsServiceMethod("TechnologyAttachment", "Delete")]
    public TechnologyAttachmentDeleteResponse Delete(TechnologyAttachmentDeleteRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new TechnologyAttachmentDeleteResponse() { State = state, ErrorGettingState = true };

        var handler = new TechnologyAttachmentServiceHandler(state);
        var entity = handler.FindById(db, request.TechnologyAttachmentId);
        if (entity == null)
            return new TechnologyAttachmentDeleteResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanDelete(db, entity))
            return new TechnologyAttachmentDeleteResponse() { State = state, ErrorNotAuthorized = true };

        if (!handler.DeleteFromState(db, entity))
            return new TechnologyAttachmentDeleteResponse() { State = state, ErrorUpdatingState = true };

        db.TechnologyAttachments.Remove(entity);
        db.SaveChanges();

        return new TechnologyAttachmentDeleteResponse() { State = state, Success = true };
    }

    [TsServiceMethod("TechnologyAttachment", "List")]
    public TechnologyAttachmentListResponse List(TechnologyAttachmentListRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new TechnologyAttachmentListResponse() { State = state, ErrorGettingState = true };

        var handler = new TechnologyAttachmentServiceHandler(state);
        if (!handler.CanList(db))
            return new TechnologyAttachmentListResponse() { State = state, ErrorNotAuthorized = true };

        var entities = handler.ListAll(db);
        var dtos = entities
            .Select(a => a.ToDto()!)
            .ToArray();

        return new TechnologyAttachmentListResponse()
        {
            Success = true,
            State = state,
            TechnologyAttachments = dtos
        };
    }
}