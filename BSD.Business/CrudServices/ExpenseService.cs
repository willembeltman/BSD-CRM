using BSD.Business.Converters;
using BSD.Business.CrudHandlers;
using BSD.Business.Interfaces;
using BSD.Data;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using CodeGenerator.Shared.Attributes;

namespace BSD.Business.CrudServices;

public class ExpenseService(
    ApplicationDbContext db,
    IAuthenticationStateService authenticationService)
    : IExpenseService
{
    [TsServiceMethod("Expense", "Create")]
    public ExpenseCreateResponse Create(ExpenseCreateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ExpenseCreateResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new ExpenseCreateResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new ExpenseServiceHandler(state);
        var entity = handler.FindByMatch(db, request.Expense);
        if (entity != null)
            return new ExpenseCreateResponse() { State = state, ErrorAlreadyUsed = true };

        entity = request.Expense.ToEntity();
        if (!handler.AttachToState(db, entity))
            return new ExpenseCreateResponse() { State = state, ErrorAttachingState = true };

        if (!handler.CanCreate(db, entity))
            return new ExpenseCreateResponse() { State = state, ErrorNotAuthorized = true };

        db.Expenses.Add(entity);
        db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new ExpenseCreateResponse() { State = state, ErrorUpdatingState = true };

        return new ExpenseCreateResponse() { State = state, Expense = dto, Success = true };
    }

    [TsServiceMethod("Expense", "Read")]
    public ExpenseReadResponse Read(ExpenseReadRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ExpenseReadResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new ExpenseReadResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new ExpenseServiceHandler(state);
        var entity = handler.FindById(db, request.ExpenseId);
        if (entity == null)
            return new ExpenseReadResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanRead(db, entity))
            return new ExpenseReadResponse() { State = state, ErrorNotAuthorized = true };

        var dto = entity.ToDto();
        return new ExpenseReadResponse() { State = state, Expense = dto, Success = true, };
    }

    [TsServiceMethod("Expense", "Update")]
    public ExpenseUpdateResponse Update(ExpenseUpdateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ExpenseUpdateResponse() { State = state, ErrorGettingState = true };

            if (state.User == null || state.DbUser == null)
                return new ExpenseUpdateResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new ExpenseServiceHandler(state);
        var entity = handler.FindById(db, request.Expense.Id);
        if (entity == null)
            return new ExpenseUpdateResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanUpdate(db, entity))
            return new ExpenseUpdateResponse() { State = state, ErrorNotAuthorized = true };

        if (request.Expense.CopyTo(entity))
            db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new ExpenseUpdateResponse() { State = state, ErrorUpdatingState = true };

        return new ExpenseUpdateResponse() { State = state, Expense = dto, Success = true };
    }

    [TsServiceMethod("Expense", "Delete")]
    public ExpenseDeleteResponse Delete(ExpenseDeleteRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ExpenseDeleteResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new ExpenseDeleteResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new ExpenseServiceHandler(state);
        var entity = handler.FindById(db, request.ExpenseId);
        if (entity == null)
            return new ExpenseDeleteResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanDelete(db, entity))
            return new ExpenseDeleteResponse() { State = state, ErrorNotAuthorized = true };

        if (!handler.DeleteFromState(db, entity))
            return new ExpenseDeleteResponse() { State = state, ErrorUpdatingState = true };

        db.Expenses.Remove(entity);
        db.SaveChanges();

        return new ExpenseDeleteResponse() { State = state, Success = true };
    }

    [TsServiceMethod("Expense", "List")]
    public ExpenseListResponse List(ExpenseListRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ExpenseListResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new ExpenseListResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new ExpenseServiceHandler(state);
        if (!handler.CanList(db))
            return new ExpenseListResponse() { State = state, ErrorNotAuthorized = true };

        var entities = handler.ListAll(db);
        var dtos = entities
            .Select(a => a.ToDto()!)
            .ToArray();

        return new ExpenseListResponse()
        {
            Success = true,
            State = state,
            Expenses = dtos
        };
    }
}