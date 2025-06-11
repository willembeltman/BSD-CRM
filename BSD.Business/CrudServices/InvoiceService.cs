using BSD.Business.Converters;
using BSD.Business.CrudHandlers;
using BSD.Business.CrudInterfaces;
using BSD.Business.Interfaces;
using BSD.Data;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using CodeGenerator.Shared.Attributes;

namespace BSD.Business.CrudServices;

public class InvoiceService(
    ApplicationDbContext db,
    IAuthenticationStateService authenticationService)
    : IInvoiceService
{
    [TsServiceMethod("Invoice", "Create")]
    public InvoiceCreateResponse Create(InvoiceCreateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new InvoiceCreateResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new InvoiceCreateResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new InvoiceServiceHandler(state);
        var entity = handler.FindByMatch(db, request.Invoice);
        if (entity != null)
            return new InvoiceCreateResponse() { State = state, ErrorAlreadyUsed = true };

        entity = request.Invoice.ToEntity();
        if (!handler.AttachToState(db, entity))
            return new InvoiceCreateResponse() { State = state, ErrorAttachingState = true };

        if (!handler.CanCreate(db, entity))
            return new InvoiceCreateResponse() { State = state, ErrorNotAuthorized = true };

        db.Invoices.Add(entity);
        db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new InvoiceCreateResponse() { State = state, ErrorUpdatingState = true };

        return new InvoiceCreateResponse() { State = state, Invoice = dto, Success = true };
    }

    [TsServiceMethod("Invoice", "Read")]
    public InvoiceReadResponse Read(InvoiceReadRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new InvoiceReadResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new InvoiceReadResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new InvoiceServiceHandler(state);
        var entity = handler.FindById(db, request.InvoiceId);
        if (entity == null)
            return new InvoiceReadResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanRead(db, entity))
            return new InvoiceReadResponse() { State = state, ErrorNotAuthorized = true };

        var dto = entity.ToDto();
        return new InvoiceReadResponse() { State = state, Invoice = dto, Success = true, };
    }

    [TsServiceMethod("Invoice", "Update")]
    public InvoiceUpdateResponse Update(InvoiceUpdateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new InvoiceUpdateResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new InvoiceUpdateResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new InvoiceServiceHandler(state);
        var entity = handler.FindById(db, request.Invoice.Id);
        if (entity == null)
            return new InvoiceUpdateResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanUpdate(db, entity))
            return new InvoiceUpdateResponse() { State = state, ErrorNotAuthorized = true };

        if (request.Invoice.CopyTo(entity))
            db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new InvoiceUpdateResponse() { State = state, ErrorUpdatingState = true };

        return new InvoiceUpdateResponse() { State = state, Invoice = dto, Success = true };
    }

    [TsServiceMethod("Invoice", "Delete")]
    public InvoiceDeleteResponse Delete(InvoiceDeleteRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new InvoiceDeleteResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new InvoiceDeleteResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new InvoiceServiceHandler(state);
        var entity = handler.FindById(db, request.InvoiceId);
        if (entity == null)
            return new InvoiceDeleteResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanDelete(db, entity))
            return new InvoiceDeleteResponse() { State = state, ErrorNotAuthorized = true };

        if (!handler.DeleteFromState(db, entity))
            return new InvoiceDeleteResponse() { State = state, ErrorUpdatingState = true };

        db.Invoices.Remove(entity);
        db.SaveChanges();

        return new InvoiceDeleteResponse() { State = state, Success = true };
    }

    [TsServiceMethod("Invoice", "List")]
    public InvoiceListResponse List(InvoiceListRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new InvoiceListResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new InvoiceListResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new InvoiceServiceHandler(state);
        if (!handler.CanList(db))
            return new InvoiceListResponse() { State = state, ErrorNotAuthorized = true };

        var entities = handler.ListAll(db);
        var dtos = entities
            .Select(a => a.ToDto()!)
            .ToArray();

        return new InvoiceListResponse()
        {
            Success = true,
            State = state,
            Invoices = dtos
        };
    }
}