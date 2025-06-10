using BSD.Business.Converters;
using BSD.Business.ServiceHandlers;
using BSD.Business.Interfaces;
using BSD.Data;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using CodeGenerator.Shared.Attributes;

namespace BSD.Business.Services;

public class ExperienceTechnologyService(
    ApplicationDbContext db,
    IAuthenticationStateService authenticationService)
    : IExperienceTechnologyService
{
    [TsServiceMethod("ExperienceTechnology", "Create")]
    public ExperienceTechnologyCreateResponse Create(ExperienceTechnologyCreateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ExperienceTechnologyCreateResponse() { State = state, ErrorGettingState = true };

        var handler = new ExperienceTechnologyServiceHander(state);
        var entity = handler.FindByMatch(db, request.ExperienceTechnology);
        if (entity != null)
            return new ExperienceTechnologyCreateResponse() { State = state, ErrorAlreadyUsed = true };

        entity = request.ExperienceTechnology.ToEntity();
        if (!handler.AttachToState(db, entity))
            return new ExperienceTechnologyCreateResponse() { State = state, ErrorAttachingState = true };

        if (!handler.CanCreate(db, entity))
            return new ExperienceTechnologyCreateResponse() { State = state, ErrorNotAuthorized = true };

        db.ExperienceTechnologies.Add(entity);
        db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new ExperienceTechnologyCreateResponse() { State = state, ErrorUpdatingState = true };

        return new ExperienceTechnologyCreateResponse() { State = state, ExperienceTechnology = dto, Success = true };
    }

    [TsServiceMethod("ExperienceTechnology", "Read")]
    public ExperienceTechnologyReadResponse Read(ExperienceTechnologyReadRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ExperienceTechnologyReadResponse() { State = state, ErrorGettingState = true };

        var handler = new ExperienceTechnologyServiceHander(state);
        var entity = handler.FindById(db, request.ExperienceTechnologyId);
        if (entity == null)
            return new ExperienceTechnologyReadResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanRead(db, entity))
            return new ExperienceTechnologyReadResponse() { State = state, ErrorNotAuthorized = true };

        var dto = entity.ToDto();
        return new ExperienceTechnologyReadResponse() { State = state, ExperienceTechnology = dto, Success = true, };
    }

    [TsServiceMethod("ExperienceTechnology", "Update")]
    public ExperienceTechnologyUpdateResponse Update(ExperienceTechnologyUpdateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ExperienceTechnologyUpdateResponse() { State = state, ErrorGettingState = true };

        var handler = new ExperienceTechnologyServiceHander(state);
        var entity = handler.FindById(db, request.ExperienceTechnology.Id);
        if (entity == null)
            return new ExperienceTechnologyUpdateResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanUpdate(db, entity))
            return new ExperienceTechnologyUpdateResponse() { State = state, ErrorNotAuthorized = true };

        if (request.ExperienceTechnology.CopyTo(entity))
            db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new ExperienceTechnologyUpdateResponse() { State = state, ErrorUpdatingState = true };

        return new ExperienceTechnologyUpdateResponse() { State = state, ExperienceTechnology = dto, Success = true };
    }

    [TsServiceMethod("ExperienceTechnology", "Delete")]
    public ExperienceTechnologyDeleteResponse Delete(ExperienceTechnologyDeleteRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ExperienceTechnologyDeleteResponse() { State = state, ErrorGettingState = true };

        var handler = new ExperienceTechnologyServiceHander(state);
        var entity = handler.FindById(db, request.ExperienceTechnologyId);
        if (entity == null)
            return new ExperienceTechnologyDeleteResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanDelete(db, entity))
            return new ExperienceTechnologyDeleteResponse() { State = state, ErrorNotAuthorized = true };

        if (!handler.DeleteFromState(db, entity))
            return new ExperienceTechnologyDeleteResponse() { State = state, ErrorUpdatingState = true };

        db.ExperienceTechnologies.Remove(entity);
        db.SaveChanges();

        return new ExperienceTechnologyDeleteResponse() { State = state, Success = true };
    }

    [TsServiceMethod("ExperienceTechnology", "List")]
    public ExperienceTechnologyListResponse List(ExperienceTechnologyListRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ExperienceTechnologyListResponse() { State = state, ErrorGettingState = true };

        var handler = new ExperienceTechnologyServiceHander(state);
        if (!handler.CanList(db))
            return new ExperienceTechnologyListResponse() { State = state, ErrorNotAuthorized = true };

        var entities = handler.ListAll(db);
        var dtos = entities
            .Select(a => a.ToDto()!)
            .ToArray();

        return new ExperienceTechnologyListResponse()
        {
            Success = true,
            State = state,
            ExperienceTechnologys = dtos
        };
    }
}