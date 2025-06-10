using BSD.Business.Converters;
using BSD.Business.ServiceHandlers;
using BSD.Business.Interfaces;
using BSD.Data;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using CodeGenerator.Shared.Attributes;

namespace BSD.Business.Services;

public class ExpenseTypeService(
    ApplicationDbContext db,
    IAuthenticationStateService authenticationService)
    : IExpenseTypeService
{
    [TsServiceMethod("ExpenseType", "Create")]
    public ExpenseTypeCreateResponse Create(ExpenseTypeCreateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ExpenseTypeCreateResponse() { State = state, ErrorGettingState = true };

        var handler = new ExpenseTypeServiceHander(state);
        var entity = handler.FindByMatch(db, request.ExpenseType);
        if (entity != null)
            return new ExpenseTypeCreateResponse() { State = state, ErrorAlreadyUsed = true };

        entity = request.ExpenseType.ToEntity();
        if (!handler.AttachToState(db, entity))
            return new ExpenseTypeCreateResponse() { State = state, ErrorAttachingState = true };

        if (!handler.CanCreate(db, entity))
            return new ExpenseTypeCreateResponse() { State = state, ErrorNotAuthorized = true };

        db.ExpenseTypes.Add(entity);
        db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new ExpenseTypeCreateResponse() { State = state, ErrorUpdatingState = true };

        return new ExpenseTypeCreateResponse() { State = state, ExpenseType = dto, Success = true };
    }

    [TsServiceMethod("ExpenseType", "Read")]
    public ExpenseTypeReadResponse Read(ExpenseTypeReadRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ExpenseTypeReadResponse() { State = state, ErrorGettingState = true };

        var handler = new ExpenseTypeServiceHander(state);
        var entity = handler.FindById(db, request.ExpenseTypeId);
        if (entity == null)
            return new ExpenseTypeReadResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanRead(db, entity))
            return new ExpenseTypeReadResponse() { State = state, ErrorNotAuthorized = true };

        var dto = entity.ToDto();
        return new ExpenseTypeReadResponse() { State = state, ExpenseType = dto, Success = true, };
    }

    [TsServiceMethod("ExpenseType", "Update")]
    public ExpenseTypeUpdateResponse Update(ExpenseTypeUpdateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ExpenseTypeUpdateResponse() { State = state, ErrorGettingState = true };

        var handler = new ExpenseTypeServiceHander(state);
        var entity = handler.FindById(db, request.ExpenseType.Id);
        if (entity == null)
            return new ExpenseTypeUpdateResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanUpdate(db, entity))
            return new ExpenseTypeUpdateResponse() { State = state, ErrorNotAuthorized = true };

        if (request.ExpenseType.CopyTo(entity))
            db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new ExpenseTypeUpdateResponse() { State = state, ErrorUpdatingState = true };

        return new ExpenseTypeUpdateResponse() { State = state, ExpenseType = dto, Success = true };
    }

    [TsServiceMethod("ExpenseType", "Delete")]
    public ExpenseTypeDeleteResponse Delete(ExpenseTypeDeleteRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ExpenseTypeDeleteResponse() { State = state, ErrorGettingState = true };

        var handler = new ExpenseTypeServiceHander(state);
        var entity = handler.FindById(db, request.ExpenseTypeId);
        if (entity == null)
            return new ExpenseTypeDeleteResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanDelete(db, entity))
            return new ExpenseTypeDeleteResponse() { State = state, ErrorNotAuthorized = true };

        if (!handler.DeleteFromState(db, entity))
            return new ExpenseTypeDeleteResponse() { State = state, ErrorUpdatingState = true };

        db.ExpenseTypes.Remove(entity);
        db.SaveChanges();

        return new ExpenseTypeDeleteResponse() { State = state, Success = true };
    }

    [TsServiceMethod("ExpenseType", "List")]
    public ExpenseTypeListResponse List(ExpenseTypeListRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ExpenseTypeListResponse() { State = state, ErrorGettingState = true };

        var handler = new ExpenseTypeServiceHander(state);
        if (!handler.CanList(db))
            return new ExpenseTypeListResponse() { State = state, ErrorNotAuthorized = true };

        var entities = handler.ListAll(db);
        var dtos = entities
            .Select(a => a.ToDto()!)
            .ToArray();

        return new ExpenseTypeListResponse()
        {
            Success = true,
            State = state,
            ExpenseTypes = dtos
        };
    }
}