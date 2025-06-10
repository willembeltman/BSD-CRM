using BSD.Business.Converters;
using BSD.Business.ServiceHandlers;
using BSD.Business.Interfaces;
using BSD.Data;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using CodeGenerator.Shared.Attributes;

namespace BSD.Business.Services;

public class TaxRateService(
    ApplicationDbContext db,
    IAuthenticationStateService authenticationService)
    : ITaxRateService
{
    [TsServiceMethod("TaxRate", "Create")]
    public TaxRateCreateResponse Create(TaxRateCreateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new TaxRateCreateResponse() { State = state, ErrorGettingState = true };

        var handler = new TaxRateServiceHander(state);
        var entity = handler.FindByMatch(db, request.TaxRate);
        if (entity != null)
            return new TaxRateCreateResponse() { State = state, ErrorAlreadyUsed = true };

        entity = request.TaxRate.ToEntity();
        if (!handler.AttachToState(db, entity))
            return new TaxRateCreateResponse() { State = state, ErrorAttachingState = true };

        if (!handler.CanCreate(db, entity))
            return new TaxRateCreateResponse() { State = state, ErrorNotAuthorized = true };

        db.TaxRates.Add(entity);
        db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new TaxRateCreateResponse() { State = state, ErrorUpdatingState = true };

        return new TaxRateCreateResponse() { State = state, TaxRate = dto, Success = true };
    }

    [TsServiceMethod("TaxRate", "Read")]
    public TaxRateReadResponse Read(TaxRateReadRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new TaxRateReadResponse() { State = state, ErrorGettingState = true };

        var handler = new TaxRateServiceHander(state);
        var entity = handler.FindById(db, request.TaxRateId);
        if (entity == null)
            return new TaxRateReadResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanRead(db, entity))
            return new TaxRateReadResponse() { State = state, ErrorNotAuthorized = true };

        var dto = entity.ToDto();
        return new TaxRateReadResponse() { State = state, TaxRate = dto, Success = true, };
    }

    [TsServiceMethod("TaxRate", "Update")]
    public TaxRateUpdateResponse Update(TaxRateUpdateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new TaxRateUpdateResponse() { State = state, ErrorGettingState = true };

        var handler = new TaxRateServiceHander(state);
        var entity = handler.FindById(db, request.TaxRate.Id);
        if (entity == null)
            return new TaxRateUpdateResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanUpdate(db, entity))
            return new TaxRateUpdateResponse() { State = state, ErrorNotAuthorized = true };

        if (request.TaxRate.CopyTo(entity))
            db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new TaxRateUpdateResponse() { State = state, ErrorUpdatingState = true };

        return new TaxRateUpdateResponse() { State = state, TaxRate = dto, Success = true };
    }

    [TsServiceMethod("TaxRate", "Delete")]
    public TaxRateDeleteResponse Delete(TaxRateDeleteRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new TaxRateDeleteResponse() { State = state, ErrorGettingState = true };

        var handler = new TaxRateServiceHander(state);
        var entity = handler.FindById(db, request.TaxRateId);
        if (entity == null)
            return new TaxRateDeleteResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanDelete(db, entity))
            return new TaxRateDeleteResponse() { State = state, ErrorNotAuthorized = true };

        if (!handler.DeleteFromState(db, entity))
            return new TaxRateDeleteResponse() { State = state, ErrorUpdatingState = true };

        db.TaxRates.Remove(entity);
        db.SaveChanges();

        return new TaxRateDeleteResponse() { State = state, Success = true };
    }

    [TsServiceMethod("TaxRate", "List")]
    public TaxRateListResponse List(TaxRateListRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new TaxRateListResponse() { State = state, ErrorGettingState = true };

        var handler = new TaxRateServiceHander(state);
        if (!handler.CanList(db))
            return new TaxRateListResponse() { State = state, ErrorNotAuthorized = true };

        var entities = handler.ListAll(db);
        var dtos = entities
            .Select(a => a.ToDto()!)
            .ToArray();

        return new TaxRateListResponse()
        {
            Success = true,
            State = state,
            TaxRates = dtos
        };
    }
}