using BSD.Business.Converters;
using BSD.Business.ServiceHandlers;
using BSD.Business.Interfaces;
using BSD.Data;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using CodeGenerator.Shared.Attributes;

namespace BSD.Business.Services;

public class BankStatementService(
    ApplicationDbContext db,
    IAuthenticationStateService authenticationService)
    : IBankStatementService
{
    [TsServiceMethod("BankStatement", "Create")]
    public BankStatementCreateResponse Create(BankStatementCreateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new BankStatementCreateResponse() { State = state, ErrorGettingState = true };

        var handler = new BankStatementServiceHandler(state);
        var entity = handler.FindByMatch(db, request.BankStatement);
        if (entity != null)
            return new BankStatementCreateResponse() { State = state, ErrorAlreadyUsed = true };

        entity = request.BankStatement.ToEntity();
        if (!handler.AttachToState(db, entity))
            return new BankStatementCreateResponse() { State = state, ErrorAttachingState = true };

        if (!handler.CanCreate(db, entity))
            return new BankStatementCreateResponse() { State = state, ErrorNotAuthorized = true };

        db.BankStatements.Add(entity);
        db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new BankStatementCreateResponse() { State = state, ErrorUpdatingState = true };

        return new BankStatementCreateResponse() { State = state, BankStatement = dto, Success = true };
    }

    [TsServiceMethod("BankStatement", "Read")]
    public BankStatementReadResponse Read(BankStatementReadRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new BankStatementReadResponse() { State = state, ErrorGettingState = true };

        var handler = new BankStatementServiceHandler(state);
        var entity = handler.FindById(db, request.BankStatementId);
        if (entity == null)
            return new BankStatementReadResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanRead(db, entity))
            return new BankStatementReadResponse() { State = state, ErrorNotAuthorized = true };

        var dto = entity.ToDto();
        return new BankStatementReadResponse() { State = state, BankStatement = dto, Success = true, };
    }

    [TsServiceMethod("BankStatement", "Update")]
    public BankStatementUpdateResponse Update(BankStatementUpdateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new BankStatementUpdateResponse() { State = state, ErrorGettingState = true };

        var handler = new BankStatementServiceHandler(state);
        var entity = handler.FindById(db, request.BankStatement.Id);
        if (entity == null)
            return new BankStatementUpdateResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanUpdate(db, entity))
            return new BankStatementUpdateResponse() { State = state, ErrorNotAuthorized = true };

        if (request.BankStatement.CopyTo(entity))
            db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new BankStatementUpdateResponse() { State = state, ErrorUpdatingState = true };

        return new BankStatementUpdateResponse() { State = state, BankStatement = dto, Success = true };
    }

    [TsServiceMethod("BankStatement", "Delete")]
    public BankStatementDeleteResponse Delete(BankStatementDeleteRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new BankStatementDeleteResponse() { State = state, ErrorGettingState = true };

        var handler = new BankStatementServiceHandler(state);
        var entity = handler.FindById(db, request.BankStatementId);
        if (entity == null)
            return new BankStatementDeleteResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanDelete(db, entity))
            return new BankStatementDeleteResponse() { State = state, ErrorNotAuthorized = true };

        if (!handler.DeleteFromState(db, entity))
            return new BankStatementDeleteResponse() { State = state, ErrorUpdatingState = true };

        db.BankStatements.Remove(entity);
        db.SaveChanges();

        return new BankStatementDeleteResponse() { State = state, Success = true };
    }

    [TsServiceMethod("BankStatement", "List")]
    public BankStatementListResponse List(BankStatementListRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new BankStatementListResponse() { State = state, ErrorGettingState = true };

        var handler = new BankStatementServiceHandler(state);
        if (!handler.CanList(db))
            return new BankStatementListResponse() { State = state, ErrorNotAuthorized = true };

        var entities = handler.ListAll(db);
        var dtos = entities
            .Select(a => a.ToDto()!)
            .ToArray();

        return new BankStatementListResponse()
        {
            Success = true,
            State = state,
            BankStatements = dtos
        };
    }
}