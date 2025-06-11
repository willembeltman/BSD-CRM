using BSD.Business.Converters;
using BSD.Business.ServiceHandlers;
using BSD.Business.Interfaces;
using BSD.Data;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using CodeGenerator.Shared.Attributes;

namespace BSD.Business.CrudServices;

public class InvoiceEmailService(
    ApplicationDbContext db,
    IAuthenticationStateService authenticationService)
    : IInvoiceEmailService
{
    [TsServiceMethod("InvoiceEmail", "Create")]
    public InvoiceEmailCreateResponse Create(InvoiceEmailCreateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new InvoiceEmailCreateResponse() { State = state, ErrorGettingState = true };

        var handler = new InvoiceEmailServiceHandler(state);
        var entity = handler.FindByMatch(db, request.InvoiceEmail);
        if (entity != null)
            return new InvoiceEmailCreateResponse() { State = state, ErrorAlreadyUsed = true };

        entity = request.InvoiceEmail.ToEntity();
        if (!handler.AttachToState(db, entity))
            return new InvoiceEmailCreateResponse() { State = state, ErrorAttachingState = true };

        if (!handler.CanCreate(db, entity))
            return new InvoiceEmailCreateResponse() { State = state, ErrorNotAuthorized = true };

        db.InvoiceEmails.Add(entity);
        db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new InvoiceEmailCreateResponse() { State = state, ErrorUpdatingState = true };

        return new InvoiceEmailCreateResponse() { State = state, InvoiceEmail = dto, Success = true };
    }

    [TsServiceMethod("InvoiceEmail", "Read")]
    public InvoiceEmailReadResponse Read(InvoiceEmailReadRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new InvoiceEmailReadResponse() { State = state, ErrorGettingState = true };

        var handler = new InvoiceEmailServiceHandler(state);
        var entity = handler.FindById(db, request.InvoiceEmailId);
        if (entity == null)
            return new InvoiceEmailReadResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanRead(db, entity))
            return new InvoiceEmailReadResponse() { State = state, ErrorNotAuthorized = true };

        var dto = entity.ToDto();
        return new InvoiceEmailReadResponse() { State = state, InvoiceEmail = dto, Success = true, };
    }

    [TsServiceMethod("InvoiceEmail", "Update")]
    public InvoiceEmailUpdateResponse Update(InvoiceEmailUpdateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new InvoiceEmailUpdateResponse() { State = state, ErrorGettingState = true };

        var handler = new InvoiceEmailServiceHandler(state);
        var entity = handler.FindById(db, request.InvoiceEmail.Id);
        if (entity == null)
            return new InvoiceEmailUpdateResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanUpdate(db, entity))
            return new InvoiceEmailUpdateResponse() { State = state, ErrorNotAuthorized = true };

        if (request.InvoiceEmail.CopyTo(entity))
            db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new InvoiceEmailUpdateResponse() { State = state, ErrorUpdatingState = true };

        return new InvoiceEmailUpdateResponse() { State = state, InvoiceEmail = dto, Success = true };
    }

    [TsServiceMethod("InvoiceEmail", "Delete")]
    public InvoiceEmailDeleteResponse Delete(InvoiceEmailDeleteRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new InvoiceEmailDeleteResponse() { State = state, ErrorGettingState = true };

        var handler = new InvoiceEmailServiceHandler(state);
        var entity = handler.FindById(db, request.InvoiceEmailId);
        if (entity == null)
            return new InvoiceEmailDeleteResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanDelete(db, entity))
            return new InvoiceEmailDeleteResponse() { State = state, ErrorNotAuthorized = true };

        if (!handler.DeleteFromState(db, entity))
            return new InvoiceEmailDeleteResponse() { State = state, ErrorUpdatingState = true };

        db.InvoiceEmails.Remove(entity);
        db.SaveChanges();

        return new InvoiceEmailDeleteResponse() { State = state, Success = true };
    }

    [TsServiceMethod("InvoiceEmail", "List")]
    public InvoiceEmailListResponse List(InvoiceEmailListRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new InvoiceEmailListResponse() { State = state, ErrorGettingState = true };

        var handler = new InvoiceEmailServiceHandler(state);
        if (!handler.CanList(db))
            return new InvoiceEmailListResponse() { State = state, ErrorNotAuthorized = true };

        var entities = handler.ListAll(db);
        var dtos = entities
            .Select(a => a.ToDto()!)
            .ToArray();

        return new InvoiceEmailListResponse()
        {
            Success = true,
            State = state,
            InvoiceEmails = dtos
        };
    }
}