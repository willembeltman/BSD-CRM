using BSD.Business.Converters;
using BSD.Business.ServiceHandlers;
using BSD.Business.Interfaces;
using BSD.Data;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using CodeGenerator.Shared.Attributes;

namespace BSD.Business.Services;

public class TrafficRegistrationService(
    ApplicationDbContext db,
    IAuthenticationStateService authenticationService)
    : ITrafficRegistrationService
{
    [TsServiceMethod("TrafficRegistration", "Create")]
    public TrafficRegistrationCreateResponse Create(TrafficRegistrationCreateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new TrafficRegistrationCreateResponse() { State = state, ErrorGettingState = true };

        var handler = new TrafficRegistrationServiceHander(state);
        var entity = handler.FindByMatch(db, request.TrafficRegistration);
        if (entity != null)
            return new TrafficRegistrationCreateResponse() { State = state, ErrorAlreadyUsed = true };

        entity = request.TrafficRegistration.ToEntity();
        if (!handler.AttachToState(db, entity))
            return new TrafficRegistrationCreateResponse() { State = state, ErrorAttachingState = true };

        if (!handler.CanCreate(db, entity))
            return new TrafficRegistrationCreateResponse() { State = state, ErrorNotAuthorized = true };

        db.TrafficRegistrations.Add(entity);
        db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new TrafficRegistrationCreateResponse() { State = state, ErrorUpdatingState = true };

        return new TrafficRegistrationCreateResponse() { State = state, TrafficRegistration = dto, Success = true };
    }

    [TsServiceMethod("TrafficRegistration", "Read")]
    public TrafficRegistrationReadResponse Read(TrafficRegistrationReadRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new TrafficRegistrationReadResponse() { State = state, ErrorGettingState = true };

        var handler = new TrafficRegistrationServiceHander(state);
        var entity = handler.FindById(db, request.TrafficRegistrationId);
        if (entity == null)
            return new TrafficRegistrationReadResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanRead(db, entity))
            return new TrafficRegistrationReadResponse() { State = state, ErrorNotAuthorized = true };

        var dto = entity.ToDto();
        return new TrafficRegistrationReadResponse() { State = state, TrafficRegistration = dto, Success = true, };
    }

    [TsServiceMethod("TrafficRegistration", "Update")]
    public TrafficRegistrationUpdateResponse Update(TrafficRegistrationUpdateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new TrafficRegistrationUpdateResponse() { State = state, ErrorGettingState = true };

        var handler = new TrafficRegistrationServiceHander(state);
        var entity = handler.FindById(db, request.TrafficRegistration.Id);
        if (entity == null)
            return new TrafficRegistrationUpdateResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanUpdate(db, entity))
            return new TrafficRegistrationUpdateResponse() { State = state, ErrorNotAuthorized = true };

        if (request.TrafficRegistration.CopyTo(entity))
            db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new TrafficRegistrationUpdateResponse() { State = state, ErrorUpdatingState = true };

        return new TrafficRegistrationUpdateResponse() { State = state, TrafficRegistration = dto, Success = true };
    }

    [TsServiceMethod("TrafficRegistration", "Delete")]
    public TrafficRegistrationDeleteResponse Delete(TrafficRegistrationDeleteRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new TrafficRegistrationDeleteResponse() { State = state, ErrorGettingState = true };

        var handler = new TrafficRegistrationServiceHander(state);
        var entity = handler.FindById(db, request.TrafficRegistrationId);
        if (entity == null)
            return new TrafficRegistrationDeleteResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanDelete(db, entity))
            return new TrafficRegistrationDeleteResponse() { State = state, ErrorNotAuthorized = true };

        if (!handler.DeleteFromState(db, entity))
            return new TrafficRegistrationDeleteResponse() { State = state, ErrorUpdatingState = true };

        db.TrafficRegistrations.Remove(entity);
        db.SaveChanges();

        return new TrafficRegistrationDeleteResponse() { State = state, Success = true };
    }

    [TsServiceMethod("TrafficRegistration", "List")]
    public TrafficRegistrationListResponse List(TrafficRegistrationListRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new TrafficRegistrationListResponse() { State = state, ErrorGettingState = true };

        var handler = new TrafficRegistrationServiceHander(state);
        if (!handler.CanList(db))
            return new TrafficRegistrationListResponse() { State = state, ErrorNotAuthorized = true };

        var entities = handler.ListAll(db);
        var dtos = entities
            .Select(a => a.ToDto()!)
            .ToArray();

        return new TrafficRegistrationListResponse()
        {
            Success = true,
            State = state,
            TrafficRegistrations = dtos
        };
    }
}