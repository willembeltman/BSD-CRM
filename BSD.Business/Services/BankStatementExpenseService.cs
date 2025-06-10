using BSD.Business.Converters;
using BSD.Business.ServiceHandlers;
using BSD.Business.Interfaces;
using BSD.Data;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using CodeGenerator.Shared.Attributes;

namespace BSD.Business.Services;

public class BankStatementExpenseService(
    ApplicationDbContext db,
    IAuthenticationStateService authenticationService)
    : IBankStatementExpenseService
{
    [TsServiceMethod("BankStatementExpense", "Create")]
    public BankStatementExpenseCreateResponse Create(BankStatementExpenseCreateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new BankStatementExpenseCreateResponse() { State = state, ErrorGettingState = true };

        var handler = new BankStatementExpenseServiceHander(state);
        var entity = handler.FindByMatch(db, request.BankStatementExpense);
        if (entity != null)
            return new BankStatementExpenseCreateResponse() { State = state, ErrorAlreadyUsed = true };

        entity = request.BankStatementExpense.ToEntity();
        if (!handler.AttachToState(db, entity))
            return new BankStatementExpenseCreateResponse() { State = state, ErrorAttachingState = true };

        if (!handler.CanCreate(db, entity))
            return new BankStatementExpenseCreateResponse() { State = state, ErrorNotAuthorized = true };

        db.BankStatementExpenses.Add(entity);
        db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new BankStatementExpenseCreateResponse() { State = state, ErrorUpdatingState = true };

        return new BankStatementExpenseCreateResponse() { State = state, BankStatementExpense = dto, Success = true };
    }

    [TsServiceMethod("BankStatementExpense", "Read")]
    public BankStatementExpenseReadResponse Read(BankStatementExpenseReadRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new BankStatementExpenseReadResponse() { State = state, ErrorGettingState = true };

        var handler = new BankStatementExpenseServiceHander(state);
        var entity = handler.FindById(db, request.BankStatementExpenseId);
        if (entity == null)
            return new BankStatementExpenseReadResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanRead(db, entity))
            return new BankStatementExpenseReadResponse() { State = state, ErrorNotAuthorized = true };

        var dto = entity.ToDto();
        return new BankStatementExpenseReadResponse() { State = state, BankStatementExpense = dto, Success = true, };
    }

    [TsServiceMethod("BankStatementExpense", "Update")]
    public BankStatementExpenseUpdateResponse Update(BankStatementExpenseUpdateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new BankStatementExpenseUpdateResponse() { State = state, ErrorGettingState = true };

        var handler = new BankStatementExpenseServiceHander(state);
        var entity = handler.FindById(db, request.BankStatementExpense.Id);
        if (entity == null)
            return new BankStatementExpenseUpdateResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanUpdate(db, entity))
            return new BankStatementExpenseUpdateResponse() { State = state, ErrorNotAuthorized = true };

        if (request.BankStatementExpense.CopyTo(entity))
            db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new BankStatementExpenseUpdateResponse() { State = state, ErrorUpdatingState = true };

        return new BankStatementExpenseUpdateResponse() { State = state, BankStatementExpense = dto, Success = true };
    }

    [TsServiceMethod("BankStatementExpense", "Delete")]
    public BankStatementExpenseDeleteResponse Delete(BankStatementExpenseDeleteRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new BankStatementExpenseDeleteResponse() { State = state, ErrorGettingState = true };

        var handler = new BankStatementExpenseServiceHander(state);
        var entity = handler.FindById(db, request.BankStatementExpenseId);
        if (entity == null)
            return new BankStatementExpenseDeleteResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanDelete(db, entity))
            return new BankStatementExpenseDeleteResponse() { State = state, ErrorNotAuthorized = true };

        if (!handler.DeleteFromState(db, entity))
            return new BankStatementExpenseDeleteResponse() { State = state, ErrorUpdatingState = true };

        db.BankStatementExpenses.Remove(entity);
        db.SaveChanges();

        return new BankStatementExpenseDeleteResponse() { State = state, Success = true };
    }

    [TsServiceMethod("BankStatementExpense", "List")]
    public BankStatementExpenseListResponse List(BankStatementExpenseListRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new BankStatementExpenseListResponse() { State = state, ErrorGettingState = true };

        var handler = new BankStatementExpenseServiceHander(state);
        if (!handler.CanList(db))
            return new BankStatementExpenseListResponse() { State = state, ErrorNotAuthorized = true };

        var entities = handler.ListAll(db);
        var dtos = entities
            .Select(a => a.ToDto()!)
            .ToArray();

        return new BankStatementExpenseListResponse()
        {
            Success = true,
            State = state,
            BankStatementExpenses = dtos
        };
    }
}