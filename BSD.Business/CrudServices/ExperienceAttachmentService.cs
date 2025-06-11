using BSD.Business.Converters;
using BSD.Business.CrudHandlers;
using BSD.Business.Interfaces;
using BSD.Data;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using CodeGenerator.Shared.Attributes;

namespace BSD.Business.CrudServices;

public class ExperienceAttachmentService(
    ApplicationDbContext db,
    IAuthenticationStateService authenticationService)
    : IExperienceAttachmentService
{
    [TsServiceMethod("ExperienceAttachment", "Create")]
    public ExperienceAttachmentCreateResponse Create(ExperienceAttachmentCreateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ExperienceAttachmentCreateResponse() { State = state, ErrorGettingState = true };

        var handler = new ExperienceAttachmentServiceHandler(state);
        var entity = handler.FindByMatch(db, request.ExperienceAttachment);
        if (entity != null)
            return new ExperienceAttachmentCreateResponse() { State = state, ErrorAlreadyUsed = true };

        entity = request.ExperienceAttachment.ToEntity();
        if (!handler.AttachToState(db, entity))
            return new ExperienceAttachmentCreateResponse() { State = state, ErrorAttachingState = true };

        if (!handler.CanCreate(db, entity))
            return new ExperienceAttachmentCreateResponse() { State = state, ErrorNotAuthorized = true };

        db.ExperienceAttachments.Add(entity);
        db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new ExperienceAttachmentCreateResponse() { State = state, ErrorUpdatingState = true };

        return new ExperienceAttachmentCreateResponse() { State = state, ExperienceAttachment = dto, Success = true };
    }

    [TsServiceMethod("ExperienceAttachment", "Read")]
    public ExperienceAttachmentReadResponse Read(ExperienceAttachmentReadRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ExperienceAttachmentReadResponse() { State = state, ErrorGettingState = true };

        var handler = new ExperienceAttachmentServiceHandler(state);
        var entity = handler.FindById(db, request.ExperienceAttachmentId);
        if (entity == null)
            return new ExperienceAttachmentReadResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanRead(db, entity))
            return new ExperienceAttachmentReadResponse() { State = state, ErrorNotAuthorized = true };

        var dto = entity.ToDto();
        return new ExperienceAttachmentReadResponse() { State = state, ExperienceAttachment = dto, Success = true, };
    }

    [TsServiceMethod("ExperienceAttachment", "Update")]
    public ExperienceAttachmentUpdateResponse Update(ExperienceAttachmentUpdateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ExperienceAttachmentUpdateResponse() { State = state, ErrorGettingState = true };

        var handler = new ExperienceAttachmentServiceHandler(state);
        var entity = handler.FindById(db, request.ExperienceAttachment.Id);
        if (entity == null)
            return new ExperienceAttachmentUpdateResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanUpdate(db, entity))
            return new ExperienceAttachmentUpdateResponse() { State = state, ErrorNotAuthorized = true };

        if (request.ExperienceAttachment.CopyTo(entity))
            db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new ExperienceAttachmentUpdateResponse() { State = state, ErrorUpdatingState = true };

        return new ExperienceAttachmentUpdateResponse() { State = state, ExperienceAttachment = dto, Success = true };
    }

    [TsServiceMethod("ExperienceAttachment", "Delete")]
    public ExperienceAttachmentDeleteResponse Delete(ExperienceAttachmentDeleteRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ExperienceAttachmentDeleteResponse() { State = state, ErrorGettingState = true };

        var handler = new ExperienceAttachmentServiceHandler(state);
        var entity = handler.FindById(db, request.ExperienceAttachmentId);
        if (entity == null)
            return new ExperienceAttachmentDeleteResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanDelete(db, entity))
            return new ExperienceAttachmentDeleteResponse() { State = state, ErrorNotAuthorized = true };

        if (!handler.DeleteFromState(db, entity))
            return new ExperienceAttachmentDeleteResponse() { State = state, ErrorUpdatingState = true };

        db.ExperienceAttachments.Remove(entity);
        db.SaveChanges();

        return new ExperienceAttachmentDeleteResponse() { State = state, Success = true };
    }

    [TsServiceMethod("ExperienceAttachment", "List")]
    public ExperienceAttachmentListResponse List(ExperienceAttachmentListRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ExperienceAttachmentListResponse() { State = state, ErrorGettingState = true };

        var handler = new ExperienceAttachmentServiceHandler(state);
        if (!handler.CanList(db))
            return new ExperienceAttachmentListResponse() { State = state, ErrorNotAuthorized = true };

        var entities = handler.ListAll(db);
        var dtos = entities
            .Select(a => a.ToDto()!)
            .ToArray();

        return new ExperienceAttachmentListResponse()
        {
            Success = true,
            State = state,
            ExperienceAttachments = dtos
        };
    }
}