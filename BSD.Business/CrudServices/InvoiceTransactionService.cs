using BSD.Business.Converters;
using BSD.Business.CrudHandlers;
using BSD.Business.Interfaces;
using BSD.Data;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using CodeGenerator.Shared.Attributes;

namespace BSD.Business.CrudServices;

public class InvoiceTransactionService(
    ApplicationDbContext db,
    IAuthenticationStateService authenticationService)
    : IInvoiceTransactionService
{
    [TsServiceMethod("InvoiceTransaction", "Create")]
    public InvoiceTransactionCreateResponse Create(InvoiceTransactionCreateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new InvoiceTransactionCreateResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new InvoiceTransactionCreateResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new InvoiceTransactionServiceHandler(state);
        var entity = handler.FindByMatch(db, request.InvoiceTransaction);
        if (entity != null)
            return new InvoiceTransactionCreateResponse() { State = state, ErrorAlreadyUsed = true };

        entity = request.InvoiceTransaction.ToEntity();
        if (!handler.AttachToState(db, entity))
            return new InvoiceTransactionCreateResponse() { State = state, ErrorAttachingState = true };

        if (!handler.CanCreate(db, entity))
            return new InvoiceTransactionCreateResponse() { State = state, ErrorNotAuthorized = true };

        db.InvoiceTransactions.Add(entity);
        db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new InvoiceTransactionCreateResponse() { State = state, ErrorUpdatingState = true };

        return new InvoiceTransactionCreateResponse() { State = state, InvoiceTransaction = dto, Success = true };
    }

    [TsServiceMethod("InvoiceTransaction", "Read")]
    public InvoiceTransactionReadResponse Read(InvoiceTransactionReadRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new InvoiceTransactionReadResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new InvoiceTransactionReadResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new InvoiceTransactionServiceHandler(state);
        var entity = handler.FindById(db, request.InvoiceTransactionId);
        if (entity == null)
            return new InvoiceTransactionReadResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanRead(db, entity))
            return new InvoiceTransactionReadResponse() { State = state, ErrorNotAuthorized = true };

        var dto = entity.ToDto();
        return new InvoiceTransactionReadResponse() { State = state, InvoiceTransaction = dto, Success = true, };
    }

    [TsServiceMethod("InvoiceTransaction", "Update")]
    public InvoiceTransactionUpdateResponse Update(InvoiceTransactionUpdateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new InvoiceTransactionUpdateResponse() { State = state, ErrorGettingState = true };

            if (state.User == null || state.DbUser == null)
                return new InvoiceTransactionUpdateResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new InvoiceTransactionServiceHandler(state);
        var entity = handler.FindById(db, request.InvoiceTransaction.Id);
        if (entity == null)
            return new InvoiceTransactionUpdateResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanUpdate(db, entity))
            return new InvoiceTransactionUpdateResponse() { State = state, ErrorNotAuthorized = true };

        if (request.InvoiceTransaction.CopyTo(entity))
            db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new InvoiceTransactionUpdateResponse() { State = state, ErrorUpdatingState = true };

        return new InvoiceTransactionUpdateResponse() { State = state, InvoiceTransaction = dto, Success = true };
    }

    [TsServiceMethod("InvoiceTransaction", "Delete")]
    public InvoiceTransactionDeleteResponse Delete(InvoiceTransactionDeleteRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new InvoiceTransactionDeleteResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new InvoiceTransactionDeleteResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new InvoiceTransactionServiceHandler(state);
        var entity = handler.FindById(db, request.InvoiceTransactionId);
        if (entity == null)
            return new InvoiceTransactionDeleteResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanDelete(db, entity))
            return new InvoiceTransactionDeleteResponse() { State = state, ErrorNotAuthorized = true };

        if (!handler.DeleteFromState(db, entity))
            return new InvoiceTransactionDeleteResponse() { State = state, ErrorUpdatingState = true };

        db.InvoiceTransactions.Remove(entity);
        db.SaveChanges();

        return new InvoiceTransactionDeleteResponse() { State = state, Success = true };
    }

    [TsServiceMethod("InvoiceTransaction", "List")]
    public InvoiceTransactionListResponse List(InvoiceTransactionListRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new InvoiceTransactionListResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new InvoiceTransactionListResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new InvoiceTransactionServiceHandler(state);
        if (!handler.CanList(db))
            return new InvoiceTransactionListResponse() { State = state, ErrorNotAuthorized = true };

        var entities = handler.ListAll(db);
        var dtos = entities
            .Select(a => a.ToDto()!)
            .ToArray();

        return new InvoiceTransactionListResponse()
        {
            Success = true,
            State = state,
            InvoiceTransactions = dtos
        };
    }
}