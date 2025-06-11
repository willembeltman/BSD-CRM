using BSD.Business.Converters;
using BSD.Business.ServiceHandlers;
using BSD.Business.Interfaces;
using BSD.Data;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using CodeGenerator.Shared.Attributes;

namespace BSD.Business.Services;

public class TransactionLogParameterService(
    ApplicationDbContext db,
    IAuthenticationStateService authenticationService)
    : ITransactionLogParameterService
{
    [TsServiceMethod("TransactionLogParameter", "Create")]
    public TransactionLogParameterCreateResponse Create(TransactionLogParameterCreateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new TransactionLogParameterCreateResponse() { State = state, ErrorGettingState = true };

        var handler = new TransactionLogParameterServiceHandler(state);
        var entity = handler.FindByMatch(db, request.TransactionLogParameter);
        if (entity != null)
            return new TransactionLogParameterCreateResponse() { State = state, ErrorAlreadyUsed = true };

        entity = request.TransactionLogParameter.ToEntity();
        if (!handler.AttachToState(db, entity))
            return new TransactionLogParameterCreateResponse() { State = state, ErrorAttachingState = true };

        if (!handler.CanCreate(db, entity))
            return new TransactionLogParameterCreateResponse() { State = state, ErrorNotAuthorized = true };

        db.TransactionLogParameters.Add(entity);
        db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new TransactionLogParameterCreateResponse() { State = state, ErrorUpdatingState = true };

        return new TransactionLogParameterCreateResponse() { State = state, TransactionLogParameter = dto, Success = true };
    }

    [TsServiceMethod("TransactionLogParameter", "Read")]
    public TransactionLogParameterReadResponse Read(TransactionLogParameterReadRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new TransactionLogParameterReadResponse() { State = state, ErrorGettingState = true };

        var handler = new TransactionLogParameterServiceHandler(state);
        var entity = handler.FindById(db, request.TransactionLogParameterId);
        if (entity == null)
            return new TransactionLogParameterReadResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanRead(db, entity))
            return new TransactionLogParameterReadResponse() { State = state, ErrorNotAuthorized = true };

        var dto = entity.ToDto();
        return new TransactionLogParameterReadResponse() { State = state, TransactionLogParameter = dto, Success = true, };
    }

    [TsServiceMethod("TransactionLogParameter", "Update")]
    public TransactionLogParameterUpdateResponse Update(TransactionLogParameterUpdateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new TransactionLogParameterUpdateResponse() { State = state, ErrorGettingState = true };

        var handler = new TransactionLogParameterServiceHandler(state);
        var entity = handler.FindById(db, request.TransactionLogParameter.Id);
        if (entity == null)
            return new TransactionLogParameterUpdateResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanUpdate(db, entity))
            return new TransactionLogParameterUpdateResponse() { State = state, ErrorNotAuthorized = true };

        if (request.TransactionLogParameter.CopyTo(entity))
            db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new TransactionLogParameterUpdateResponse() { State = state, ErrorUpdatingState = true };

        return new TransactionLogParameterUpdateResponse() { State = state, TransactionLogParameter = dto, Success = true };
    }

    [TsServiceMethod("TransactionLogParameter", "Delete")]
    public TransactionLogParameterDeleteResponse Delete(TransactionLogParameterDeleteRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new TransactionLogParameterDeleteResponse() { State = state, ErrorGettingState = true };

        var handler = new TransactionLogParameterServiceHandler(state);
        var entity = handler.FindById(db, request.TransactionLogParameterId);
        if (entity == null)
            return new TransactionLogParameterDeleteResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanDelete(db, entity))
            return new TransactionLogParameterDeleteResponse() { State = state, ErrorNotAuthorized = true };

        if (!handler.DeleteFromState(db, entity))
            return new TransactionLogParameterDeleteResponse() { State = state, ErrorUpdatingState = true };

        db.TransactionLogParameters.Remove(entity);
        db.SaveChanges();

        return new TransactionLogParameterDeleteResponse() { State = state, Success = true };
    }

    [TsServiceMethod("TransactionLogParameter", "List")]
    public TransactionLogParameterListResponse List(TransactionLogParameterListRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new TransactionLogParameterListResponse() { State = state, ErrorGettingState = true };

        var handler = new TransactionLogParameterServiceHandler(state);
        if (!handler.CanList(db))
            return new TransactionLogParameterListResponse() { State = state, ErrorNotAuthorized = true };

        var entities = handler.ListAll(db);
        var dtos = entities
            .Select(a => a.ToDto()!)
            .ToArray();

        return new TransactionLogParameterListResponse()
        {
            Success = true,
            State = state,
            TransactionLogParameters = dtos
        };
    }
}