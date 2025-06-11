using BSD.Business.Converters;
using BSD.Business.CrudHandlers;
using BSD.Business.Interfaces;
using BSD.Data;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using CodeGenerator.Shared.Attributes;

namespace BSD.Business.CrudServices;

public class ExpensePriceService(
    ApplicationDbContext db,
    IAuthenticationStateService authenticationService)
    : IExpensePriceService
{
    [TsServiceMethod("ExpensePrice", "Create")]
    public ExpensePriceCreateResponse Create(ExpensePriceCreateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ExpensePriceCreateResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new ExpensePriceCreateResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new ExpensePriceServiceHandler(state);
        var entity = handler.FindByMatch(db, request.ExpensePrice);
        if (entity != null)
            return new ExpensePriceCreateResponse() { State = state, ErrorAlreadyUsed = true };

        entity = request.ExpensePrice.ToEntity();
        if (!handler.AttachToState(db, entity))
            return new ExpensePriceCreateResponse() { State = state, ErrorAttachingState = true };

        if (!handler.CanCreate(db, entity))
            return new ExpensePriceCreateResponse() { State = state, ErrorNotAuthorized = true };

        db.ExpensePrices.Add(entity);
        db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new ExpensePriceCreateResponse() { State = state, ErrorUpdatingState = true };

        return new ExpensePriceCreateResponse() { State = state, ExpensePrice = dto, Success = true };
    }

    [TsServiceMethod("ExpensePrice", "Read")]
    public ExpensePriceReadResponse Read(ExpensePriceReadRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ExpensePriceReadResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new ExpensePriceReadResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new ExpensePriceServiceHandler(state);
        var entity = handler.FindById(db, request.ExpensePriceId);
        if (entity == null)
            return new ExpensePriceReadResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanRead(db, entity))
            return new ExpensePriceReadResponse() { State = state, ErrorNotAuthorized = true };

        var dto = entity.ToDto();
        return new ExpensePriceReadResponse() { State = state, ExpensePrice = dto, Success = true, };
    }

    [TsServiceMethod("ExpensePrice", "Update")]
    public ExpensePriceUpdateResponse Update(ExpensePriceUpdateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ExpensePriceUpdateResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new ExpensePriceUpdateResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new ExpensePriceServiceHandler(state);
        var entity = handler.FindById(db, request.ExpensePrice.Id);
        if (entity == null)
            return new ExpensePriceUpdateResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanUpdate(db, entity))
            return new ExpensePriceUpdateResponse() { State = state, ErrorNotAuthorized = true };

        if (request.ExpensePrice.CopyTo(entity))
            db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new ExpensePriceUpdateResponse() { State = state, ErrorUpdatingState = true };

        return new ExpensePriceUpdateResponse() { State = state, ExpensePrice = dto, Success = true };
    }

    [TsServiceMethod("ExpensePrice", "Delete")]
    public ExpensePriceDeleteResponse Delete(ExpensePriceDeleteRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ExpensePriceDeleteResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new ExpensePriceDeleteResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new ExpensePriceServiceHandler(state);
        var entity = handler.FindById(db, request.ExpensePriceId);
        if (entity == null)
            return new ExpensePriceDeleteResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanDelete(db, entity))
            return new ExpensePriceDeleteResponse() { State = state, ErrorNotAuthorized = true };

        if (!handler.DeleteFromState(db, entity))
            return new ExpensePriceDeleteResponse() { State = state, ErrorUpdatingState = true };

        db.ExpensePrices.Remove(entity);
        db.SaveChanges();

        return new ExpensePriceDeleteResponse() { State = state, Success = true };
    }

    [TsServiceMethod("ExpensePrice", "List")]
    public ExpensePriceListResponse List(ExpensePriceListRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ExpensePriceListResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new ExpensePriceListResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new ExpensePriceServiceHandler(state);
        if (!handler.CanList(db))
            return new ExpensePriceListResponse() { State = state, ErrorNotAuthorized = true };

        var entities = handler.ListAll(db);
        var dtos = entities
            .Select(a => a.ToDto()!)
            .ToArray();

        return new ExpensePriceListResponse()
        {
            Success = true,
            State = state,
            ExpensePrices = dtos
        };
    }
}