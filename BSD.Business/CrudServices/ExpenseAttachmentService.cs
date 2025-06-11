using BSD.Business.Converters;
using BSD.Business.CrudHandlers;
using BSD.Business.Interfaces;
using BSD.Data;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using CodeGenerator.Shared.Attributes;

namespace BSD.Business.CrudServices;

public class ExpenseAttachmentService(
    ApplicationDbContext db,
    IAuthenticationStateService authenticationService)
    : IExpenseAttachmentService
{
    [TsServiceMethod("ExpenseAttachment", "Create")]
    public ExpenseAttachmentCreateResponse Create(ExpenseAttachmentCreateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ExpenseAttachmentCreateResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new ExpenseAttachmentCreateResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new ExpenseAttachmentServiceHandler(state);
        var entity = handler.FindByMatch(db, request.ExpenseAttachment);
        if (entity != null)
            return new ExpenseAttachmentCreateResponse() { State = state, ErrorAlreadyUsed = true };

        entity = request.ExpenseAttachment.ToEntity();
        if (!handler.AttachToState(db, entity))
            return new ExpenseAttachmentCreateResponse() { State = state, ErrorAttachingState = true };

        if (!handler.CanCreate(db, entity))
            return new ExpenseAttachmentCreateResponse() { State = state, ErrorNotAuthorized = true };

        db.ExpenseAttachments.Add(entity);
        db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new ExpenseAttachmentCreateResponse() { State = state, ErrorUpdatingState = true };

        return new ExpenseAttachmentCreateResponse() { State = state, ExpenseAttachment = dto, Success = true };
    }

    [TsServiceMethod("ExpenseAttachment", "Read")]
    public ExpenseAttachmentReadResponse Read(ExpenseAttachmentReadRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ExpenseAttachmentReadResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new ExpenseAttachmentReadResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new ExpenseAttachmentServiceHandler(state);
        var entity = handler.FindById(db, request.ExpenseAttachmentId);
        if (entity == null)
            return new ExpenseAttachmentReadResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanRead(db, entity))
            return new ExpenseAttachmentReadResponse() { State = state, ErrorNotAuthorized = true };

        var dto = entity.ToDto();
        return new ExpenseAttachmentReadResponse() { State = state, ExpenseAttachment = dto, Success = true, };
    }

    [TsServiceMethod("ExpenseAttachment", "Update")]
    public ExpenseAttachmentUpdateResponse Update(ExpenseAttachmentUpdateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ExpenseAttachmentUpdateResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new ExpenseAttachmentUpdateResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new ExpenseAttachmentServiceHandler(state);
        var entity = handler.FindById(db, request.ExpenseAttachment.Id);
        if (entity == null)
            return new ExpenseAttachmentUpdateResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanUpdate(db, entity))
            return new ExpenseAttachmentUpdateResponse() { State = state, ErrorNotAuthorized = true };

        if (request.ExpenseAttachment.CopyTo(entity))
            db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new ExpenseAttachmentUpdateResponse() { State = state, ErrorUpdatingState = true };

        return new ExpenseAttachmentUpdateResponse() { State = state, ExpenseAttachment = dto, Success = true };
    }

    [TsServiceMethod("ExpenseAttachment", "Delete")]
    public ExpenseAttachmentDeleteResponse Delete(ExpenseAttachmentDeleteRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ExpenseAttachmentDeleteResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new ExpenseAttachmentDeleteResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new ExpenseAttachmentServiceHandler(state);
        var entity = handler.FindById(db, request.ExpenseAttachmentId);
        if (entity == null)
            return new ExpenseAttachmentDeleteResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanDelete(db, entity))
            return new ExpenseAttachmentDeleteResponse() { State = state, ErrorNotAuthorized = true };

        if (!handler.DeleteFromState(db, entity))
            return new ExpenseAttachmentDeleteResponse() { State = state, ErrorUpdatingState = true };

        db.ExpenseAttachments.Remove(entity);
        db.SaveChanges();

        return new ExpenseAttachmentDeleteResponse() { State = state, Success = true };
    }

    [TsServiceMethod("ExpenseAttachment", "List")]
    public ExpenseAttachmentListResponse List(ExpenseAttachmentListRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ExpenseAttachmentListResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new ExpenseAttachmentListResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new ExpenseAttachmentServiceHandler(state);
        if (!handler.CanList(db))
            return new ExpenseAttachmentListResponse() { State = state, ErrorNotAuthorized = true };

        var entities = handler.ListAll(db);
        var dtos = entities
            .Select(a => a.ToDto()!)
            .ToArray();

        return new ExpenseAttachmentListResponse()
        {
            Success = true,
            State = state,
            ExpenseAttachments = dtos
        };
    }
}