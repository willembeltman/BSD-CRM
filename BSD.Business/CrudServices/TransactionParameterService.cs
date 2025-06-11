using BSD.Business.Converters;
using BSD.Business.CrudHandlers;
using BSD.Business.Interfaces;
using BSD.Data;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using CodeGenerator.Shared.Attributes;

namespace BSD.Business.CrudServices;

public class TransactionParameterService(
    ApplicationDbContext db,
    IAuthenticationStateService authenticationService)
    : ITransactionParameterService
{
    [TsServiceMethod("TransactionParameter", "Create")]
    public TransactionParameterCreateResponse Create(TransactionParameterCreateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new TransactionParameterCreateResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new TransactionParameterCreateResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new TransactionParameterServiceHandler(state);
        var entity = handler.FindByMatch(db, request.TransactionParameter);
        if (entity != null)
            return new TransactionParameterCreateResponse() { State = state, ErrorAlreadyUsed = true };

        entity = request.TransactionParameter.ToEntity();
        if (!handler.AttachToState(db, entity))
            return new TransactionParameterCreateResponse() { State = state, ErrorAttachingState = true };

        if (!handler.CanCreate(db, entity))
            return new TransactionParameterCreateResponse() { State = state, ErrorNotAuthorized = true };

        db.TransactionParameters.Add(entity);
        db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new TransactionParameterCreateResponse() { State = state, ErrorUpdatingState = true };

        return new TransactionParameterCreateResponse() { State = state, TransactionParameter = dto, Success = true };
    }

    [TsServiceMethod("TransactionParameter", "Read")]
    public TransactionParameterReadResponse Read(TransactionParameterReadRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new TransactionParameterReadResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new TransactionParameterReadResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new TransactionParameterServiceHandler(state);
        var entity = handler.FindById(db, request.TransactionParameterId);
        if (entity == null)
            return new TransactionParameterReadResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanRead(db, entity))
            return new TransactionParameterReadResponse() { State = state, ErrorNotAuthorized = true };

        var dto = entity.ToDto();
        return new TransactionParameterReadResponse() { State = state, TransactionParameter = dto, Success = true, };
    }

    [TsServiceMethod("TransactionParameter", "Update")]
    public TransactionParameterUpdateResponse Update(TransactionParameterUpdateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new TransactionParameterUpdateResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new TransactionParameterUpdateResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new TransactionParameterServiceHandler(state);
        var entity = handler.FindById(db, request.TransactionParameter.Id);
        if (entity == null)
            return new TransactionParameterUpdateResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanUpdate(db, entity))
            return new TransactionParameterUpdateResponse() { State = state, ErrorNotAuthorized = true };

        if (request.TransactionParameter.CopyTo(entity))
            db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new TransactionParameterUpdateResponse() { State = state, ErrorUpdatingState = true };

        return new TransactionParameterUpdateResponse() { State = state, TransactionParameter = dto, Success = true };
    }

    [TsServiceMethod("TransactionParameter", "Delete")]
    public TransactionParameterDeleteResponse Delete(TransactionParameterDeleteRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new TransactionParameterDeleteResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new TransactionParameterDeleteResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new TransactionParameterServiceHandler(state);
        var entity = handler.FindById(db, request.TransactionParameterId);
        if (entity == null)
            return new TransactionParameterDeleteResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanDelete(db, entity))
            return new TransactionParameterDeleteResponse() { State = state, ErrorNotAuthorized = true };

        if (!handler.DeleteFromState(db, entity))
            return new TransactionParameterDeleteResponse() { State = state, ErrorUpdatingState = true };

        db.TransactionParameters.Remove(entity);
        db.SaveChanges();

        return new TransactionParameterDeleteResponse() { State = state, Success = true };
    }

    [TsServiceMethod("TransactionParameter", "List")]
    public TransactionParameterListResponse List(TransactionParameterListRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new TransactionParameterListResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new TransactionParameterListResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new TransactionParameterServiceHandler(state);
        if (!handler.CanList(db))
            return new TransactionParameterListResponse() { State = state, ErrorNotAuthorized = true };

        var entities = handler.ListAll(db);
        var dtos = entities
            .Select(a => a.ToDto()!)
            .ToArray();

        return new TransactionParameterListResponse()
        {
            Success = true,
            State = state,
            TransactionParameters = dtos
        };
    }
}