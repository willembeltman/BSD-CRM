using BSD.Business.Converters;
using BSD.Business.ServiceHandlers;
using BSD.Business.Interfaces;
using BSD.Data;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using CodeGenerator.Shared.Attributes;

namespace BSD.Business.CrudServices;

public class EmailService(
    ApplicationDbContext db,
    IAuthenticationStateService authenticationService)
    : IEmailService
{
    [TsServiceMethod("Email", "Create")]
    public EmailCreateResponse Create(EmailCreateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new EmailCreateResponse() { State = state, ErrorGettingState = true };

        var handler = new EmailServiceHandler(state);
        var entity = handler.FindByMatch(db, request.Email);
        if (entity != null)
            return new EmailCreateResponse() { State = state, ErrorAlreadyUsed = true };

        entity = request.Email.ToEntity();
        if (!handler.AttachToState(db, entity))
            return new EmailCreateResponse() { State = state, ErrorAttachingState = true };

        if (!handler.CanCreate(db, entity))
            return new EmailCreateResponse() { State = state, ErrorNotAuthorized = true };

        db.Emails.Add(entity);
        db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new EmailCreateResponse() { State = state, ErrorUpdatingState = true };

        return new EmailCreateResponse() { State = state, Email = dto, Success = true };
    }

    [TsServiceMethod("Email", "Read")]
    public EmailReadResponse Read(EmailReadRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new EmailReadResponse() { State = state, ErrorGettingState = true };

        var handler = new EmailServiceHandler(state);
        var entity = handler.FindById(db, request.EmailId);
        if (entity == null)
            return new EmailReadResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanRead(db, entity))
            return new EmailReadResponse() { State = state, ErrorNotAuthorized = true };

        var dto = entity.ToDto();
        return new EmailReadResponse() { State = state, Email = dto, Success = true, };
    }

    [TsServiceMethod("Email", "Update")]
    public EmailUpdateResponse Update(EmailUpdateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new EmailUpdateResponse() { State = state, ErrorGettingState = true };

        var handler = new EmailServiceHandler(state);
        var entity = handler.FindById(db, request.Email.Id);
        if (entity == null)
            return new EmailUpdateResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanUpdate(db, entity))
            return new EmailUpdateResponse() { State = state, ErrorNotAuthorized = true };

        if (request.Email.CopyTo(entity))
            db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new EmailUpdateResponse() { State = state, ErrorUpdatingState = true };

        return new EmailUpdateResponse() { State = state, Email = dto, Success = true };
    }

    [TsServiceMethod("Email", "Delete")]
    public EmailDeleteResponse Delete(EmailDeleteRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new EmailDeleteResponse() { State = state, ErrorGettingState = true };

        var handler = new EmailServiceHandler(state);
        var entity = handler.FindById(db, request.EmailId);
        if (entity == null)
            return new EmailDeleteResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanDelete(db, entity))
            return new EmailDeleteResponse() { State = state, ErrorNotAuthorized = true };

        if (!handler.DeleteFromState(db, entity))
            return new EmailDeleteResponse() { State = state, ErrorUpdatingState = true };

        db.Emails.Remove(entity);
        db.SaveChanges();

        return new EmailDeleteResponse() { State = state, Success = true };
    }

    [TsServiceMethod("Email", "List")]
    public EmailListResponse List(EmailListRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new EmailListResponse() { State = state, ErrorGettingState = true };

        var handler = new EmailServiceHandler(state);
        if (!handler.CanList(db))
            return new EmailListResponse() { State = state, ErrorNotAuthorized = true };

        var entities = handler.ListAll(db);
        var dtos = entities
            .Select(a => a.ToDto()!)
            .ToArray();

        return new EmailListResponse()
        {
            Success = true,
            State = state,
            Emails = dtos
        };
    }
}