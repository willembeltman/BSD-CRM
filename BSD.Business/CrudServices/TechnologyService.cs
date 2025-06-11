using BSD.Business.Converters;
using BSD.Business.ServiceHandlers;
using BSD.Business.Interfaces;
using BSD.Data;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using CodeGenerator.Shared.Attributes;

namespace BSD.Business.CrudServices;

public class TechnologyService(
    ApplicationDbContext db,
    IAuthenticationStateService authenticationService)
    : ITechnologyService
{
    [TsServiceMethod("Technology", "Create")]
    public TechnologyCreateResponse Create(TechnologyCreateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new TechnologyCreateResponse() { State = state, ErrorGettingState = true };

        var handler = new TechnologyServiceHandler(state);
        var entity = handler.FindByMatch(db, request.Technology);
        if (entity != null)
            return new TechnologyCreateResponse() { State = state, ErrorAlreadyUsed = true };

        entity = request.Technology.ToEntity();
        if (!handler.AttachToState(db, entity))
            return new TechnologyCreateResponse() { State = state, ErrorAttachingState = true };

        if (!handler.CanCreate(db, entity))
            return new TechnologyCreateResponse() { State = state, ErrorNotAuthorized = true };

        db.Technologies.Add(entity);
        db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new TechnologyCreateResponse() { State = state, ErrorUpdatingState = true };

        return new TechnologyCreateResponse() { State = state, Technology = dto, Success = true };
    }

    [TsServiceMethod("Technology", "Read")]
    public TechnologyReadResponse Read(TechnologyReadRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new TechnologyReadResponse() { State = state, ErrorGettingState = true };

        var handler = new TechnologyServiceHandler(state);
        var entity = handler.FindById(db, request.TechnologyId);
        if (entity == null)
            return new TechnologyReadResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanRead(db, entity))
            return new TechnologyReadResponse() { State = state, ErrorNotAuthorized = true };

        var dto = entity.ToDto();
        return new TechnologyReadResponse() { State = state, Technology = dto, Success = true, };
    }

    [TsServiceMethod("Technology", "Update")]
    public TechnologyUpdateResponse Update(TechnologyUpdateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new TechnologyUpdateResponse() { State = state, ErrorGettingState = true };

        var handler = new TechnologyServiceHandler(state);
        var entity = handler.FindById(db, request.Technology.Id);
        if (entity == null)
            return new TechnologyUpdateResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanUpdate(db, entity))
            return new TechnologyUpdateResponse() { State = state, ErrorNotAuthorized = true };

        if (request.Technology.CopyTo(entity))
            db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new TechnologyUpdateResponse() { State = state, ErrorUpdatingState = true };

        return new TechnologyUpdateResponse() { State = state, Technology = dto, Success = true };
    }

    [TsServiceMethod("Technology", "Delete")]
    public TechnologyDeleteResponse Delete(TechnologyDeleteRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new TechnologyDeleteResponse() { State = state, ErrorGettingState = true };

        var handler = new TechnologyServiceHandler(state);
        var entity = handler.FindById(db, request.TechnologyId);
        if (entity == null)
            return new TechnologyDeleteResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanDelete(db, entity))
            return new TechnologyDeleteResponse() { State = state, ErrorNotAuthorized = true };

        if (!handler.DeleteFromState(db, entity))
            return new TechnologyDeleteResponse() { State = state, ErrorUpdatingState = true };

        db.Technologies.Remove(entity);
        db.SaveChanges();

        return new TechnologyDeleteResponse() { State = state, Success = true };
    }

    [TsServiceMethod("Technology", "List")]
    public TechnologyListResponse List(TechnologyListRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new TechnologyListResponse() { State = state, ErrorGettingState = true };

        var handler = new TechnologyServiceHandler(state);
        if (!handler.CanList(db))
            return new TechnologyListResponse() { State = state, ErrorNotAuthorized = true };

        var entities = handler.ListAll(db);
        var dtos = entities
            .Select(a => a.ToDto()!)
            .ToArray();

        return new TechnologyListResponse()
        {
            Success = true,
            State = state,
            Technologys = dtos
        };
    }
}