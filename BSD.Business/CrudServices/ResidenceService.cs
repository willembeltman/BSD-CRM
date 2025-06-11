using BSD.Business.Converters;
using BSD.Business.CrudHandlers;
using BSD.Business.CrudInterfaces;
using BSD.Business.Interfaces;
using BSD.Data;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using CodeGenerator.Shared.Attributes;

namespace BSD.Business.CrudServices;

public class ResidenceService(
    ApplicationDbContext db,
    IAuthenticationStateService authenticationService)
    : IResidenceService
{
    [TsServiceMethod("Residence", "Create")]
    public ResidenceCreateResponse Create(ResidenceCreateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ResidenceCreateResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new ResidenceCreateResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new ResidenceServiceHandler(state);
        var entity = handler.FindByMatch(db, request.Residence);
        if (entity != null)
            return new ResidenceCreateResponse() { State = state, ErrorAlreadyUsed = true };

        entity = request.Residence.ToEntity();
        if (!handler.AttachToState(db, entity))
            return new ResidenceCreateResponse() { State = state, ErrorAttachingState = true };

        if (!handler.CanCreate(db, entity))
            return new ResidenceCreateResponse() { State = state, ErrorNotAuthorized = true };

        db.Residences.Add(entity);
        db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new ResidenceCreateResponse() { State = state, ErrorUpdatingState = true };

        return new ResidenceCreateResponse() { State = state, Residence = dto, Success = true };
    }

    [TsServiceMethod("Residence", "Read")]
    public ResidenceReadResponse Read(ResidenceReadRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ResidenceReadResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new ResidenceReadResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new ResidenceServiceHandler(state);
        var entity = handler.FindById(db, request.ResidenceId);
        if (entity == null)
            return new ResidenceReadResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanRead(db, entity))
            return new ResidenceReadResponse() { State = state, ErrorNotAuthorized = true };

        var dto = entity.ToDto();
        return new ResidenceReadResponse() { State = state, Residence = dto, Success = true, };
    }

    [TsServiceMethod("Residence", "Update")]
    public ResidenceUpdateResponse Update(ResidenceUpdateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ResidenceUpdateResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new ResidenceUpdateResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new ResidenceServiceHandler(state);
        var entity = handler.FindById(db, request.Residence.Id);
        if (entity == null)
            return new ResidenceUpdateResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanUpdate(db, entity))
            return new ResidenceUpdateResponse() { State = state, ErrorNotAuthorized = true };

        if (request.Residence.CopyTo(entity))
            db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new ResidenceUpdateResponse() { State = state, ErrorUpdatingState = true };

        return new ResidenceUpdateResponse() { State = state, Residence = dto, Success = true };
    }

    [TsServiceMethod("Residence", "Delete")]
    public ResidenceDeleteResponse Delete(ResidenceDeleteRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ResidenceDeleteResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new ResidenceDeleteResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new ResidenceServiceHandler(state);
        var entity = handler.FindById(db, request.ResidenceId);
        if (entity == null)
            return new ResidenceDeleteResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanDelete(db, entity))
            return new ResidenceDeleteResponse() { State = state, ErrorNotAuthorized = true };

        if (!handler.DeleteFromState(db, entity))
            return new ResidenceDeleteResponse() { State = state, ErrorUpdatingState = true };

        db.Residences.Remove(entity);
        db.SaveChanges();

        return new ResidenceDeleteResponse() { State = state, Success = true };
    }

    [TsServiceMethod("Residence", "List")]
    public ResidenceListResponse List(ResidenceListRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ResidenceListResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new ResidenceListResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new ResidenceServiceHandler(state);
        if (!handler.CanList(db))
            return new ResidenceListResponse() { State = state, ErrorNotAuthorized = true };

        var entities = handler.ListAll(db);
        var dtos = entities
            .Select(a => a.ToDto()!)
            .ToArray();

        return new ResidenceListResponse()
        {
            Success = true,
            State = state,
            Residences = dtos
        };
    }
}