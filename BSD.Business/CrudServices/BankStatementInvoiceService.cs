using BSD.Business.Converters;
using BSD.Business.CrudHandlers;
using BSD.Business.CrudInterfaces;
using BSD.Business.Interfaces;
using BSD.Data;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using CodeGenerator.Shared.Attributes;

namespace BSD.Business.CrudServices;

public class BankStatementInvoiceService(
    ApplicationDbContext db,
    IAuthenticationStateService authenticationService)
    : IBankStatementInvoiceService
{
    [TsServiceMethod("BankStatementInvoice", "Create")]
    public BankStatementInvoiceCreateResponse Create(BankStatementInvoiceCreateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new BankStatementInvoiceCreateResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new BankStatementInvoiceCreateResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new BankStatementInvoiceServiceHandler(state);
        var entity = handler.FindByMatch(db, request.BankStatementInvoice);
        if (entity != null)
            return new BankStatementInvoiceCreateResponse() { State = state, ErrorAlreadyUsed = true };

        entity = request.BankStatementInvoice.ToEntity();
        if (!handler.AttachToState(db, entity))
            return new BankStatementInvoiceCreateResponse() { State = state, ErrorAttachingState = true };

        if (!handler.CanCreate(db, entity))
            return new BankStatementInvoiceCreateResponse() { State = state, ErrorNotAuthorized = true };

        db.BankStatementInvoices.Add(entity);
        db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new BankStatementInvoiceCreateResponse() { State = state, ErrorUpdatingState = true };

        return new BankStatementInvoiceCreateResponse() { State = state, BankStatementInvoice = dto, Success = true };
    }

    [TsServiceMethod("BankStatementInvoice", "Read")]
    public BankStatementInvoiceReadResponse Read(BankStatementInvoiceReadRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new BankStatementInvoiceReadResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new BankStatementInvoiceReadResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new BankStatementInvoiceServiceHandler(state);
        var entity = handler.FindById(db, request.BankStatementInvoiceId);
        if (entity == null)
            return new BankStatementInvoiceReadResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanRead(db, entity))
            return new BankStatementInvoiceReadResponse() { State = state, ErrorNotAuthorized = true };

        var dto = entity.ToDto();
        return new BankStatementInvoiceReadResponse() { State = state, BankStatementInvoice = dto, Success = true, };
    }

    [TsServiceMethod("BankStatementInvoice", "Update")]
    public BankStatementInvoiceUpdateResponse Update(BankStatementInvoiceUpdateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new BankStatementInvoiceUpdateResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new BankStatementInvoiceUpdateResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new BankStatementInvoiceServiceHandler(state);
        var entity = handler.FindById(db, request.BankStatementInvoice.Id);
        if (entity == null)
            return new BankStatementInvoiceUpdateResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanUpdate(db, entity))
            return new BankStatementInvoiceUpdateResponse() { State = state, ErrorNotAuthorized = true };

        if (request.BankStatementInvoice.CopyTo(entity))
            db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new BankStatementInvoiceUpdateResponse() { State = state, ErrorUpdatingState = true };

        return new BankStatementInvoiceUpdateResponse() { State = state, BankStatementInvoice = dto, Success = true };
    }

    [TsServiceMethod("BankStatementInvoice", "Delete")]
    public BankStatementInvoiceDeleteResponse Delete(BankStatementInvoiceDeleteRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new BankStatementInvoiceDeleteResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new BankStatementInvoiceDeleteResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new BankStatementInvoiceServiceHandler(state);
        var entity = handler.FindById(db, request.BankStatementInvoiceId);
        if (entity == null)
            return new BankStatementInvoiceDeleteResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanDelete(db, entity))
            return new BankStatementInvoiceDeleteResponse() { State = state, ErrorNotAuthorized = true };

        if (!handler.DeleteFromState(db, entity))
            return new BankStatementInvoiceDeleteResponse() { State = state, ErrorUpdatingState = true };

        db.BankStatementInvoices.Remove(entity);
        db.SaveChanges();

        return new BankStatementInvoiceDeleteResponse() { State = state, Success = true };
    }

    [TsServiceMethod("BankStatementInvoice", "List")]
    public BankStatementInvoiceListResponse List(BankStatementInvoiceListRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new BankStatementInvoiceListResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new BankStatementInvoiceListResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new BankStatementInvoiceServiceHandler(state);
        if (!handler.CanList(db))
            return new BankStatementInvoiceListResponse() { State = state, ErrorNotAuthorized = true };

        var entities = handler.ListAll(db);
        var dtos = entities
            .Select(a => a.ToDto()!)
            .ToArray();

        return new BankStatementInvoiceListResponse()
        {
            Success = true,
            State = state,
            BankStatementInvoices = dtos
        };
    }
}