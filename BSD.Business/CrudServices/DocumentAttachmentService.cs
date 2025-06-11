using BSD.Business.Converters;
using BSD.Business.CrudHandlers;
using BSD.Business.Interfaces;
using BSD.Data;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using CodeGenerator.Shared.Attributes;

namespace BSD.Business.CrudServices;

public class DocumentAttachmentService(
    ApplicationDbContext db,
    IAuthenticationStateService authenticationService)
    : IDocumentAttachmentService
{
    [TsServiceMethod("DocumentAttachment", "Create")]
    public DocumentAttachmentCreateResponse Create(DocumentAttachmentCreateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new DocumentAttachmentCreateResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new DocumentAttachmentCreateResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new DocumentAttachmentServiceHandler(state);
        var entity = handler.FindByMatch(db, request.DocumentAttachment);
        if (entity != null)
            return new DocumentAttachmentCreateResponse() { State = state, ErrorAlreadyUsed = true };

        entity = request.DocumentAttachment.ToEntity();
        if (!handler.AttachToState(db, entity))
            return new DocumentAttachmentCreateResponse() { State = state, ErrorAttachingState = true };

        if (!handler.CanCreate(db, entity))
            return new DocumentAttachmentCreateResponse() { State = state, ErrorNotAuthorized = true };

        db.DocumentAttachments.Add(entity);
        db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new DocumentAttachmentCreateResponse() { State = state, ErrorUpdatingState = true };

        return new DocumentAttachmentCreateResponse() { State = state, DocumentAttachment = dto, Success = true };
    }

    [TsServiceMethod("DocumentAttachment", "Read")]
    public DocumentAttachmentReadResponse Read(DocumentAttachmentReadRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new DocumentAttachmentReadResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new DocumentAttachmentReadResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new DocumentAttachmentServiceHandler(state);
        var entity = handler.FindById(db, request.DocumentAttachmentId);
        if (entity == null)
            return new DocumentAttachmentReadResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanRead(db, entity))
            return new DocumentAttachmentReadResponse() { State = state, ErrorNotAuthorized = true };

        var dto = entity.ToDto();
        return new DocumentAttachmentReadResponse() { State = state, DocumentAttachment = dto, Success = true, };
    }

    [TsServiceMethod("DocumentAttachment", "Update")]
    public DocumentAttachmentUpdateResponse Update(DocumentAttachmentUpdateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new DocumentAttachmentUpdateResponse() { State = state, ErrorGettingState = true };

            if (state.User == null || state.DbUser == null)
                return new DocumentAttachmentUpdateResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new DocumentAttachmentServiceHandler(state);
        var entity = handler.FindById(db, request.DocumentAttachment.Id);
        if (entity == null)
            return new DocumentAttachmentUpdateResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanUpdate(db, entity))
            return new DocumentAttachmentUpdateResponse() { State = state, ErrorNotAuthorized = true };

        if (request.DocumentAttachment.CopyTo(entity))
            db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new DocumentAttachmentUpdateResponse() { State = state, ErrorUpdatingState = true };

        return new DocumentAttachmentUpdateResponse() { State = state, DocumentAttachment = dto, Success = true };
    }

    [TsServiceMethod("DocumentAttachment", "Delete")]
    public DocumentAttachmentDeleteResponse Delete(DocumentAttachmentDeleteRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new DocumentAttachmentDeleteResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new DocumentAttachmentDeleteResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new DocumentAttachmentServiceHandler(state);
        var entity = handler.FindById(db, request.DocumentAttachmentId);
        if (entity == null)
            return new DocumentAttachmentDeleteResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanDelete(db, entity))
            return new DocumentAttachmentDeleteResponse() { State = state, ErrorNotAuthorized = true };

        if (!handler.DeleteFromState(db, entity))
            return new DocumentAttachmentDeleteResponse() { State = state, ErrorUpdatingState = true };

        db.DocumentAttachments.Remove(entity);
        db.SaveChanges();

        return new DocumentAttachmentDeleteResponse() { State = state, Success = true };
    }

    [TsServiceMethod("DocumentAttachment", "List")]
    public DocumentAttachmentListResponse List(DocumentAttachmentListRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new DocumentAttachmentListResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new DocumentAttachmentListResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new DocumentAttachmentServiceHandler(state);
        if (!handler.CanList(db))
            return new DocumentAttachmentListResponse() { State = state, ErrorNotAuthorized = true };

        var entities = handler.ListAll(db);
        var dtos = entities
            .Select(a => a.ToDto()!)
            .ToArray();

        return new DocumentAttachmentListResponse()
        {
            Success = true,
            State = state,
            DocumentAttachments = dtos
        };
    }
}