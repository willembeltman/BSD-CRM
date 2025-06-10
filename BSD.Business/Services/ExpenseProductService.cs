using BSD.Business.Converters;
using BSD.Business.ServiceHandlers;
using BSD.Business.Interfaces;
using BSD.Data;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using CodeGenerator.Shared.Attributes;

namespace BSD.Business.Services;

public class ExpenseProductService(
    ApplicationDbContext db,
    IAuthenticationStateService authenticationService)
    : IExpenseProductService
{
    [TsServiceMethod("ExpenseProduct", "Create")]
    public ExpenseProductCreateResponse Create(ExpenseProductCreateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ExpenseProductCreateResponse() { State = state, ErrorGettingState = true };

        var handler = new ExpenseProductServiceHander(state);
        var entity = handler.FindByMatch(db, request.ExpenseProduct);
        if (entity != null)
            return new ExpenseProductCreateResponse() { State = state, ErrorAlreadyUsed = true };

        entity = request.ExpenseProduct.ToEntity();
        if (!handler.AttachToState(db, entity))
            return new ExpenseProductCreateResponse() { State = state, ErrorAttachingState = true };

        if (!handler.CanCreate(db, entity))
            return new ExpenseProductCreateResponse() { State = state, ErrorNotAuthorized = true };

        db.ExpenseProducts.Add(entity);
        db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new ExpenseProductCreateResponse() { State = state, ErrorUpdatingState = true };

        return new ExpenseProductCreateResponse() { State = state, ExpenseProduct = dto, Success = true };
    }

    [TsServiceMethod("ExpenseProduct", "Read")]
    public ExpenseProductReadResponse Read(ExpenseProductReadRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ExpenseProductReadResponse() { State = state, ErrorGettingState = true };

        var handler = new ExpenseProductServiceHander(state);
        var entity = handler.FindById(db, request.ExpenseProductId);
        if (entity == null)
            return new ExpenseProductReadResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanRead(db, entity))
            return new ExpenseProductReadResponse() { State = state, ErrorNotAuthorized = true };

        var dto = entity.ToDto();
        return new ExpenseProductReadResponse() { State = state, ExpenseProduct = dto, Success = true, };
    }

    [TsServiceMethod("ExpenseProduct", "Update")]
    public ExpenseProductUpdateResponse Update(ExpenseProductUpdateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ExpenseProductUpdateResponse() { State = state, ErrorGettingState = true };

        var handler = new ExpenseProductServiceHander(state);
        var entity = handler.FindById(db, request.ExpenseProduct.Id);
        if (entity == null)
            return new ExpenseProductUpdateResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanUpdate(db, entity))
            return new ExpenseProductUpdateResponse() { State = state, ErrorNotAuthorized = true };

        if (request.ExpenseProduct.CopyTo(entity))
            db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new ExpenseProductUpdateResponse() { State = state, ErrorUpdatingState = true };

        return new ExpenseProductUpdateResponse() { State = state, ExpenseProduct = dto, Success = true };
    }

    [TsServiceMethod("ExpenseProduct", "Delete")]
    public ExpenseProductDeleteResponse Delete(ExpenseProductDeleteRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ExpenseProductDeleteResponse() { State = state, ErrorGettingState = true };

        var handler = new ExpenseProductServiceHander(state);
        var entity = handler.FindById(db, request.ExpenseProductId);
        if (entity == null)
            return new ExpenseProductDeleteResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanDelete(db, entity))
            return new ExpenseProductDeleteResponse() { State = state, ErrorNotAuthorized = true };

        if (!handler.DeleteFromState(db, entity))
            return new ExpenseProductDeleteResponse() { State = state, ErrorUpdatingState = true };

        db.ExpenseProducts.Remove(entity);
        db.SaveChanges();

        return new ExpenseProductDeleteResponse() { State = state, Success = true };
    }

    [TsServiceMethod("ExpenseProduct", "List")]
    public ExpenseProductListResponse List(ExpenseProductListRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ExpenseProductListResponse() { State = state, ErrorGettingState = true };

        var handler = new ExpenseProductServiceHander(state);
        if (!handler.CanList(db))
            return new ExpenseProductListResponse() { State = state, ErrorNotAuthorized = true };

        var entities = handler.ListAll(db);
        var dtos = entities
            .Select(a => a.ToDto()!)
            .ToArray();

        return new ExpenseProductListResponse()
        {
            Success = true,
            State = state,
            ExpenseProducts = dtos
        };
    }
}