using BSD.Business.Converters;
using BSD.Business.ServiceHandlers;
using BSD.Business.Interfaces;
using BSD.Data;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using CodeGenerator.Shared.Attributes;

namespace BSD.Business.CrudServices;

public class TransactionService(
    ApplicationDbContext db,
    IAuthenticationStateService authenticationService)
    : ITransactionService
{
    [TsServiceMethod("Transaction", "Create")]
    public TransactionCreateResponse Create(TransactionCreateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new TransactionCreateResponse() { State = state, ErrorGettingState = true };

        var handler = new TransactionServiceHandler(state);
        var entity = handler.FindByMatch(db, request.Transaction);
        if (entity != null)
            return new TransactionCreateResponse() { State = state, ErrorAlreadyUsed = true };

        entity = request.Transaction.ToEntity();
        if (!handler.AttachToState(db, entity))
            return new TransactionCreateResponse() { State = state, ErrorAttachingState = true };

        if (!handler.CanCreate(db, entity))
            return new TransactionCreateResponse() { State = state, ErrorNotAuthorized = true };

        db.Transactions.Add(entity);
        db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new TransactionCreateResponse() { State = state, ErrorUpdatingState = true };

        return new TransactionCreateResponse() { State = state, Transaction = dto, Success = true };
    }

    [TsServiceMethod("Transaction", "Read")]
    public TransactionReadResponse Read(TransactionReadRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new TransactionReadResponse() { State = state, ErrorGettingState = true };

        var handler = new TransactionServiceHandler(state);
        var entity = handler.FindById(db, request.TransactionId);
        if (entity == null)
            return new TransactionReadResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanRead(db, entity))
            return new TransactionReadResponse() { State = state, ErrorNotAuthorized = true };

        var dto = entity.ToDto();
        return new TransactionReadResponse() { State = state, Transaction = dto, Success = true, };
    }

    [TsServiceMethod("Transaction", "Update")]
    public TransactionUpdateResponse Update(TransactionUpdateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new TransactionUpdateResponse() { State = state, ErrorGettingState = true };

        var handler = new TransactionServiceHandler(state);
        var entity = handler.FindById(db, request.Transaction.Id);
        if (entity == null)
            return new TransactionUpdateResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanUpdate(db, entity))
            return new TransactionUpdateResponse() { State = state, ErrorNotAuthorized = true };

        if (request.Transaction.CopyTo(entity))
            db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new TransactionUpdateResponse() { State = state, ErrorUpdatingState = true };

        return new TransactionUpdateResponse() { State = state, Transaction = dto, Success = true };
    }

    [TsServiceMethod("Transaction", "Delete")]
    public TransactionDeleteResponse Delete(TransactionDeleteRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new TransactionDeleteResponse() { State = state, ErrorGettingState = true };

        var handler = new TransactionServiceHandler(state);
        var entity = handler.FindById(db, request.TransactionId);
        if (entity == null)
            return new TransactionDeleteResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanDelete(db, entity))
            return new TransactionDeleteResponse() { State = state, ErrorNotAuthorized = true };

        if (!handler.DeleteFromState(db, entity))
            return new TransactionDeleteResponse() { State = state, ErrorUpdatingState = true };

        db.Transactions.Remove(entity);
        db.SaveChanges();

        return new TransactionDeleteResponse() { State = state, Success = true };
    }

    [TsServiceMethod("Transaction", "List")]
    public TransactionListResponse List(TransactionListRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new TransactionListResponse() { State = state, ErrorGettingState = true };

        var handler = new TransactionServiceHandler(state);
        if (!handler.CanList(db))
            return new TransactionListResponse() { State = state, ErrorNotAuthorized = true };

        var entities = handler.ListAll(db);
        var dtos = entities
            .Select(a => a.ToDto()!)
            .ToArray();

        return new TransactionListResponse()
        {
            Success = true,
            State = state,
            Transactions = dtos
        };
    }
}