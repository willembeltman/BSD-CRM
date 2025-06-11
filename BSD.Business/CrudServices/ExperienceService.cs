using BSD.Business.Converters;
using BSD.Business.CrudHandlers;
using BSD.Business.Interfaces;
using BSD.Data;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using CodeGenerator.Shared.Attributes;

namespace BSD.Business.CrudServices;

public class ExperienceService(
    ApplicationDbContext db,
    IAuthenticationStateService authenticationService)
    : IExperienceService
{
    [TsServiceMethod("Experience", "Create")]
    public ExperienceCreateResponse Create(ExperienceCreateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ExperienceCreateResponse() { State = state, ErrorGettingState = true };

        var handler = new ExperienceServiceHandler(state);
        var entity = handler.FindByMatch(db, request.Experience);
        if (entity != null)
            return new ExperienceCreateResponse() { State = state, ErrorAlreadyUsed = true };

        entity = request.Experience.ToEntity();
        if (!handler.AttachToState(db, entity))
            return new ExperienceCreateResponse() { State = state, ErrorAttachingState = true };

        if (!handler.CanCreate(db, entity))
            return new ExperienceCreateResponse() { State = state, ErrorNotAuthorized = true };

        db.Experiences.Add(entity);
        db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new ExperienceCreateResponse() { State = state, ErrorUpdatingState = true };

        return new ExperienceCreateResponse() { State = state, Experience = dto, Success = true };
    }

    [TsServiceMethod("Experience", "Read")]
    public ExperienceReadResponse Read(ExperienceReadRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ExperienceReadResponse() { State = state, ErrorGettingState = true };

        var handler = new ExperienceServiceHandler(state);
        var entity = handler.FindById(db, request.ExperienceId);
        if (entity == null)
            return new ExperienceReadResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanRead(db, entity))
            return new ExperienceReadResponse() { State = state, ErrorNotAuthorized = true };

        var dto = entity.ToDto();
        return new ExperienceReadResponse() { State = state, Experience = dto, Success = true, };
    }

    [TsServiceMethod("Experience", "Update")]
    public ExperienceUpdateResponse Update(ExperienceUpdateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ExperienceUpdateResponse() { State = state, ErrorGettingState = true };

        var handler = new ExperienceServiceHandler(state);
        var entity = handler.FindById(db, request.Experience.Id);
        if (entity == null)
            return new ExperienceUpdateResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanUpdate(db, entity))
            return new ExperienceUpdateResponse() { State = state, ErrorNotAuthorized = true };

        if (request.Experience.CopyTo(entity))
            db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new ExperienceUpdateResponse() { State = state, ErrorUpdatingState = true };

        return new ExperienceUpdateResponse() { State = state, Experience = dto, Success = true };
    }

    [TsServiceMethod("Experience", "Delete")]
    public ExperienceDeleteResponse Delete(ExperienceDeleteRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ExperienceDeleteResponse() { State = state, ErrorGettingState = true };

        var handler = new ExperienceServiceHandler(state);
        var entity = handler.FindById(db, request.ExperienceId);
        if (entity == null)
            return new ExperienceDeleteResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanDelete(db, entity))
            return new ExperienceDeleteResponse() { State = state, ErrorNotAuthorized = true };

        if (!handler.DeleteFromState(db, entity))
            return new ExperienceDeleteResponse() { State = state, ErrorUpdatingState = true };

        db.Experiences.Remove(entity);
        db.SaveChanges();

        return new ExperienceDeleteResponse() { State = state, Success = true };
    }

    [TsServiceMethod("Experience", "List")]
    public ExperienceListResponse List(ExperienceListRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ExperienceListResponse() { State = state, ErrorGettingState = true };

        var handler = new ExperienceServiceHandler(state);
        if (!handler.CanList(db))
            return new ExperienceListResponse() { State = state, ErrorNotAuthorized = true };

        var entities = handler.ListAll(db);
        var dtos = entities
            .Select(a => a.ToDto()!)
            .ToArray();

        return new ExperienceListResponse()
        {
            Success = true,
            State = state,
            Experiences = dtos
        };
    }
}