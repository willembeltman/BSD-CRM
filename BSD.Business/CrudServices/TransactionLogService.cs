using BSD.Business.Converters;
using BSD.Business.CrudHandlers;
using BSD.Business.CrudInterfaces;
using BSD.Business.Interfaces;
using BSD.Data;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using CodeGenerator.Shared.Attributes;

namespace BSD.Business.CrudServices;

public class TransactionLogService(
    ApplicationDbContext db,
    IAuthenticationStateService authenticationService)
    : ITransactionLogService
{
    [TsServiceMethod("TransactionLog", "Create")]
    public TransactionLogCreateResponse Create(TransactionLogCreateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new TransactionLogCreateResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new TransactionLogCreateResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new TransactionLogServiceHandler(state);
        var entity = handler.FindByMatch(db, request.TransactionLog);
        if (entity != null)
            return new TransactionLogCreateResponse() { State = state, ErrorAlreadyUsed = true };

        entity = request.TransactionLog.ToEntity();
        if (!handler.AttachToState(db, entity))
            return new TransactionLogCreateResponse() { State = state, ErrorAttachingState = true };

        if (!handler.CanCreate(db, entity))
            return new TransactionLogCreateResponse() { State = state, ErrorNotAuthorized = true };

        db.TransactionLogs.Add(entity);
        db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new TransactionLogCreateResponse() { State = state, ErrorUpdatingState = true };

        return new TransactionLogCreateResponse() { State = state, TransactionLog = dto, Success = true };
    }

    [TsServiceMethod("TransactionLog", "Read")]
    public TransactionLogReadResponse Read(TransactionLogReadRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new TransactionLogReadResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new TransactionLogReadResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new TransactionLogServiceHandler(state);
        var entity = handler.FindById(db, request.TransactionLogId);
        if (entity == null)
            return new TransactionLogReadResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanRead(db, entity))
            return new TransactionLogReadResponse() { State = state, ErrorNotAuthorized = true };

        var dto = entity.ToDto();
        return new TransactionLogReadResponse() { State = state, TransactionLog = dto, Success = true, };
    }

    [TsServiceMethod("TransactionLog", "Update")]
    public TransactionLogUpdateResponse Update(TransactionLogUpdateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new TransactionLogUpdateResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new TransactionLogUpdateResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new TransactionLogServiceHandler(state);
        var entity = handler.FindById(db, request.TransactionLog.Id);
        if (entity == null)
            return new TransactionLogUpdateResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanUpdate(db, entity))
            return new TransactionLogUpdateResponse() { State = state, ErrorNotAuthorized = true };

        if (request.TransactionLog.CopyTo(entity))
            db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new TransactionLogUpdateResponse() { State = state, ErrorUpdatingState = true };

        return new TransactionLogUpdateResponse() { State = state, TransactionLog = dto, Success = true };
    }

    [TsServiceMethod("TransactionLog", "Delete")]
    public TransactionLogDeleteResponse Delete(TransactionLogDeleteRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new TransactionLogDeleteResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new TransactionLogDeleteResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new TransactionLogServiceHandler(state);
        var entity = handler.FindById(db, request.TransactionLogId);
        if (entity == null)
            return new TransactionLogDeleteResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanDelete(db, entity))
            return new TransactionLogDeleteResponse() { State = state, ErrorNotAuthorized = true };

        if (!handler.DeleteFromState(db, entity))
            return new TransactionLogDeleteResponse() { State = state, ErrorUpdatingState = true };

        db.TransactionLogs.Remove(entity);
        db.SaveChanges();

        return new TransactionLogDeleteResponse() { State = state, Success = true };
    }

    [TsServiceMethod("TransactionLog", "List")]
    public TransactionLogListResponse List(TransactionLogListRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new TransactionLogListResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new TransactionLogListResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new TransactionLogServiceHandler(state);
        if (!handler.CanList(db))
            return new TransactionLogListResponse() { State = state, ErrorNotAuthorized = true };

        var entities = handler.ListAll(db);
        var dtos = entities
            .Select(a => a.ToDto()!)
            .ToArray();

        return new TransactionLogListResponse()
        {
            Success = true,
            State = state,
            TransactionLogs = dtos
        };
    }
}