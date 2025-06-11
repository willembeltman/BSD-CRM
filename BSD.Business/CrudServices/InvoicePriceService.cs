using BSD.Business.Converters;
using BSD.Business.CrudHandlers;
using BSD.Business.Interfaces;
using BSD.Data;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using CodeGenerator.Shared.Attributes;

namespace BSD.Business.CrudServices;

public class InvoicePriceService(
    ApplicationDbContext db,
    IAuthenticationStateService authenticationService)
    : IInvoicePriceService
{
    [TsServiceMethod("InvoicePrice", "Create")]
    public InvoicePriceCreateResponse Create(InvoicePriceCreateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new InvoicePriceCreateResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new InvoicePriceCreateResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new InvoicePriceServiceHandler(state);
        var entity = handler.FindByMatch(db, request.InvoicePrice);
        if (entity != null)
            return new InvoicePriceCreateResponse() { State = state, ErrorAlreadyUsed = true };

        entity = request.InvoicePrice.ToEntity();
        if (!handler.AttachToState(db, entity))
            return new InvoicePriceCreateResponse() { State = state, ErrorAttachingState = true };

        if (!handler.CanCreate(db, entity))
            return new InvoicePriceCreateResponse() { State = state, ErrorNotAuthorized = true };

        db.InvoicePrices.Add(entity);
        db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new InvoicePriceCreateResponse() { State = state, ErrorUpdatingState = true };

        return new InvoicePriceCreateResponse() { State = state, InvoicePrice = dto, Success = true };
    }

    [TsServiceMethod("InvoicePrice", "Read")]
    public InvoicePriceReadResponse Read(InvoicePriceReadRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new InvoicePriceReadResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new InvoicePriceReadResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new InvoicePriceServiceHandler(state);
        var entity = handler.FindById(db, request.InvoicePriceId);
        if (entity == null)
            return new InvoicePriceReadResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanRead(db, entity))
            return new InvoicePriceReadResponse() { State = state, ErrorNotAuthorized = true };

        var dto = entity.ToDto();
        return new InvoicePriceReadResponse() { State = state, InvoicePrice = dto, Success = true, };
    }

    [TsServiceMethod("InvoicePrice", "Update")]
    public InvoicePriceUpdateResponse Update(InvoicePriceUpdateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new InvoicePriceUpdateResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new InvoicePriceUpdateResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new InvoicePriceServiceHandler(state);
        var entity = handler.FindById(db, request.InvoicePrice.Id);
        if (entity == null)
            return new InvoicePriceUpdateResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanUpdate(db, entity))
            return new InvoicePriceUpdateResponse() { State = state, ErrorNotAuthorized = true };

        if (request.InvoicePrice.CopyTo(entity))
            db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new InvoicePriceUpdateResponse() { State = state, ErrorUpdatingState = true };

        return new InvoicePriceUpdateResponse() { State = state, InvoicePrice = dto, Success = true };
    }

    [TsServiceMethod("InvoicePrice", "Delete")]
    public InvoicePriceDeleteResponse Delete(InvoicePriceDeleteRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new InvoicePriceDeleteResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new InvoicePriceDeleteResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new InvoicePriceServiceHandler(state);
        var entity = handler.FindById(db, request.InvoicePriceId);
        if (entity == null)
            return new InvoicePriceDeleteResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanDelete(db, entity))
            return new InvoicePriceDeleteResponse() { State = state, ErrorNotAuthorized = true };

        if (!handler.DeleteFromState(db, entity))
            return new InvoicePriceDeleteResponse() { State = state, ErrorUpdatingState = true };

        db.InvoicePrices.Remove(entity);
        db.SaveChanges();

        return new InvoicePriceDeleteResponse() { State = state, Success = true };
    }

    [TsServiceMethod("InvoicePrice", "List")]
    public InvoicePriceListResponse List(InvoicePriceListRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new InvoicePriceListResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new InvoicePriceListResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new InvoicePriceServiceHandler(state);
        if (!handler.CanList(db))
            return new InvoicePriceListResponse() { State = state, ErrorNotAuthorized = true };

        var entities = handler.ListAll(db);
        var dtos = entities
            .Select(a => a.ToDto()!)
            .ToArray();

        return new InvoicePriceListResponse()
        {
            Success = true,
            State = state,
            InvoicePrices = dtos
        };
    }
}