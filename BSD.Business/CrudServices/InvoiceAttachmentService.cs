using BSD.Business.Converters;
using BSD.Business.ServiceHandlers;
using BSD.Business.Interfaces;
using BSD.Data;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using CodeGenerator.Shared.Attributes;

namespace BSD.Business.CrudServices;

public class InvoiceAttachmentService(
    ApplicationDbContext db,
    IAuthenticationStateService authenticationService)
    : IInvoiceAttachmentService
{
    [TsServiceMethod("InvoiceAttachment", "Create")]
    public InvoiceAttachmentCreateResponse Create(InvoiceAttachmentCreateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new InvoiceAttachmentCreateResponse() { State = state, ErrorGettingState = true };

        var handler = new InvoiceAttachmentServiceHandler(state);
        var entity = handler.FindByMatch(db, request.InvoiceAttachment);
        if (entity != null)
            return new InvoiceAttachmentCreateResponse() { State = state, ErrorAlreadyUsed = true };

        entity = request.InvoiceAttachment.ToEntity();
        if (!handler.AttachToState(db, entity))
            return new InvoiceAttachmentCreateResponse() { State = state, ErrorAttachingState = true };

        if (!handler.CanCreate(db, entity))
            return new InvoiceAttachmentCreateResponse() { State = state, ErrorNotAuthorized = true };

        db.InvoiceAttachments.Add(entity);
        db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new InvoiceAttachmentCreateResponse() { State = state, ErrorUpdatingState = true };

        return new InvoiceAttachmentCreateResponse() { State = state, InvoiceAttachment = dto, Success = true };
    }

    [TsServiceMethod("InvoiceAttachment", "Read")]
    public InvoiceAttachmentReadResponse Read(InvoiceAttachmentReadRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new InvoiceAttachmentReadResponse() { State = state, ErrorGettingState = true };

        var handler = new InvoiceAttachmentServiceHandler(state);
        var entity = handler.FindById(db, request.InvoiceAttachmentId);
        if (entity == null)
            return new InvoiceAttachmentReadResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanRead(db, entity))
            return new InvoiceAttachmentReadResponse() { State = state, ErrorNotAuthorized = true };

        var dto = entity.ToDto();
        return new InvoiceAttachmentReadResponse() { State = state, InvoiceAttachment = dto, Success = true, };
    }

    [TsServiceMethod("InvoiceAttachment", "Update")]
    public InvoiceAttachmentUpdateResponse Update(InvoiceAttachmentUpdateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new InvoiceAttachmentUpdateResponse() { State = state, ErrorGettingState = true };

        var handler = new InvoiceAttachmentServiceHandler(state);
        var entity = handler.FindById(db, request.InvoiceAttachment.Id);
        if (entity == null)
            return new InvoiceAttachmentUpdateResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanUpdate(db, entity))
            return new InvoiceAttachmentUpdateResponse() { State = state, ErrorNotAuthorized = true };

        if (request.InvoiceAttachment.CopyTo(entity))
            db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new InvoiceAttachmentUpdateResponse() { State = state, ErrorUpdatingState = true };

        return new InvoiceAttachmentUpdateResponse() { State = state, InvoiceAttachment = dto, Success = true };
    }

    [TsServiceMethod("InvoiceAttachment", "Delete")]
    public InvoiceAttachmentDeleteResponse Delete(InvoiceAttachmentDeleteRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new InvoiceAttachmentDeleteResponse() { State = state, ErrorGettingState = true };

        var handler = new InvoiceAttachmentServiceHandler(state);
        var entity = handler.FindById(db, request.InvoiceAttachmentId);
        if (entity == null)
            return new InvoiceAttachmentDeleteResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanDelete(db, entity))
            return new InvoiceAttachmentDeleteResponse() { State = state, ErrorNotAuthorized = true };

        if (!handler.DeleteFromState(db, entity))
            return new InvoiceAttachmentDeleteResponse() { State = state, ErrorUpdatingState = true };

        db.InvoiceAttachments.Remove(entity);
        db.SaveChanges();

        return new InvoiceAttachmentDeleteResponse() { State = state, Success = true };
    }

    [TsServiceMethod("InvoiceAttachment", "List")]
    public InvoiceAttachmentListResponse List(InvoiceAttachmentListRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new InvoiceAttachmentListResponse() { State = state, ErrorGettingState = true };

        var handler = new InvoiceAttachmentServiceHandler(state);
        if (!handler.CanList(db))
            return new InvoiceAttachmentListResponse() { State = state, ErrorNotAuthorized = true };

        var entities = handler.ListAll(db);
        var dtos = entities
            .Select(a => a.ToDto()!)
            .ToArray();

        return new InvoiceAttachmentListResponse()
        {
            Success = true,
            State = state,
            InvoiceAttachments = dtos
        };
    }
}