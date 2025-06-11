using BSD.Business.Converters;
using BSD.Business.ServiceHandlers;
using BSD.Business.Interfaces;
using BSD.Data;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using CodeGenerator.Shared.Attributes;

namespace BSD.Business.Services;

public class RateService(
    ApplicationDbContext db,
    IAuthenticationStateService authenticationService)
    : IRateService
{
    [TsServiceMethod("Rate", "Create")]
    public RateCreateResponse Create(RateCreateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new RateCreateResponse() { State = state, ErrorGettingState = true };

        var handler = new RateServiceHandler(state);
        var entity = handler.FindByMatch(db, request.Rate);
        if (entity != null)
            return new RateCreateResponse() { State = state, ErrorAlreadyUsed = true };

        entity = request.Rate.ToEntity();
        if (!handler.AttachToState(db, entity))
            return new RateCreateResponse() { State = state, ErrorAttachingState = true };

        if (!handler.CanCreate(db, entity))
            return new RateCreateResponse() { State = state, ErrorNotAuthorized = true };

        db.Rates.Add(entity);
        db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new RateCreateResponse() { State = state, ErrorUpdatingState = true };

        return new RateCreateResponse() { State = state, Rate = dto, Success = true };
    }

    [TsServiceMethod("Rate", "Read")]
    public RateReadResponse Read(RateReadRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new RateReadResponse() { State = state, ErrorGettingState = true };

        var handler = new RateServiceHandler(state);
        var entity = handler.FindById(db, request.RateId);
        if (entity == null)
            return new RateReadResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanRead(db, entity))
            return new RateReadResponse() { State = state, ErrorNotAuthorized = true };

        var dto = entity.ToDto();
        return new RateReadResponse() { State = state, Rate = dto, Success = true, };
    }

    [TsServiceMethod("Rate", "Update")]
    public RateUpdateResponse Update(RateUpdateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new RateUpdateResponse() { State = state, ErrorGettingState = true };

        var handler = new RateServiceHandler(state);
        var entity = handler.FindById(db, request.Rate.Id);
        if (entity == null)
            return new RateUpdateResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanUpdate(db, entity))
            return new RateUpdateResponse() { State = state, ErrorNotAuthorized = true };

        if (request.Rate.CopyTo(entity))
            db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new RateUpdateResponse() { State = state, ErrorUpdatingState = true };

        return new RateUpdateResponse() { State = state, Rate = dto, Success = true };
    }

    [TsServiceMethod("Rate", "Delete")]
    public RateDeleteResponse Delete(RateDeleteRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new RateDeleteResponse() { State = state, ErrorGettingState = true };

        var handler = new RateServiceHandler(state);
        var entity = handler.FindById(db, request.RateId);
        if (entity == null)
            return new RateDeleteResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanDelete(db, entity))
            return new RateDeleteResponse() { State = state, ErrorNotAuthorized = true };

        if (!handler.DeleteFromState(db, entity))
            return new RateDeleteResponse() { State = state, ErrorUpdatingState = true };

        db.Rates.Remove(entity);
        db.SaveChanges();

        return new RateDeleteResponse() { State = state, Success = true };
    }

    [TsServiceMethod("Rate", "List")]
    public RateListResponse List(RateListRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new RateListResponse() { State = state, ErrorGettingState = true };

        var handler = new RateServiceHandler(state);
        if (!handler.CanList(db))
            return new RateListResponse() { State = state, ErrorNotAuthorized = true };

        var entities = handler.ListAll(db);
        var dtos = entities
            .Select(a => a.ToDto()!)
            .ToArray();

        return new RateListResponse()
        {
            Success = true,
            State = state,
            Rates = dtos
        };
    }
}