using BSD.Business.Converters;
using BSD.Business.CrudHandlers;
using BSD.Business.CrudInterfaces;
using BSD.Business.Interfaces;
using BSD.Data;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using CodeGenerator.Shared.Attributes;

namespace BSD.Business.CrudServices;

public class CountryService(
    ApplicationDbContext db,
    IAuthenticationStateService authenticationService)
    : ICountryService
{
    [TsServiceMethod("Country", "Create")]
    public CountryCreateResponse Create(CountryCreateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new CountryCreateResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new CountryCreateResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new CountryServiceHandler(state);
        var entity = handler.FindByMatch(db, request.Country);
        if (entity != null)
            return new CountryCreateResponse() { State = state, ErrorAlreadyUsed = true };

        entity = request.Country.ToEntity();
        if (!handler.AttachToState(db, entity))
            return new CountryCreateResponse() { State = state, ErrorAttachingState = true };

        if (!handler.CanCreate(db, entity))
            return new CountryCreateResponse() { State = state, ErrorNotAuthorized = true };

        db.Countries.Add(entity);
        db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new CountryCreateResponse() { State = state, ErrorUpdatingState = true };

        return new CountryCreateResponse() { State = state, Country = dto, Success = true };
    }

    [TsServiceMethod("Country", "Read")]
    public CountryReadResponse Read(CountryReadRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new CountryReadResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new CountryReadResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new CountryServiceHandler(state);
        var entity = handler.FindById(db, request.CountryId);
        if (entity == null)
            return new CountryReadResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanRead(db, entity))
            return new CountryReadResponse() { State = state, ErrorNotAuthorized = true };

        var dto = entity.ToDto();
        return new CountryReadResponse() { State = state, Country = dto, Success = true, };
    }

    [TsServiceMethod("Country", "Update")]
    public CountryUpdateResponse Update(CountryUpdateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new CountryUpdateResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new CountryUpdateResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new CountryServiceHandler(state);
        var entity = handler.FindById(db, request.Country.Id);
        if (entity == null)
            return new CountryUpdateResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanUpdate(db, entity))
            return new CountryUpdateResponse() { State = state, ErrorNotAuthorized = true };

        if (request.Country.CopyTo(entity))
            db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new CountryUpdateResponse() { State = state, ErrorUpdatingState = true };

        return new CountryUpdateResponse() { State = state, Country = dto, Success = true };
    }

    [TsServiceMethod("Country", "Delete")]
    public CountryDeleteResponse Delete(CountryDeleteRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new CountryDeleteResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new CountryDeleteResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new CountryServiceHandler(state);
        var entity = handler.FindById(db, request.CountryId);
        if (entity == null)
            return new CountryDeleteResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanDelete(db, entity))
            return new CountryDeleteResponse() { State = state, ErrorNotAuthorized = true };

        if (!handler.DeleteFromState(db, entity))
            return new CountryDeleteResponse() { State = state, ErrorUpdatingState = true };

        db.Countries.Remove(entity);
        db.SaveChanges();

        return new CountryDeleteResponse() { State = state, Success = true };
    }

    [TsServiceMethod("Country", "List")]
    public CountryListResponse List(CountryListRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new CountryListResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new CountryListResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new CountryServiceHandler(state);
        if (!handler.CanList(db))
            return new CountryListResponse() { State = state, ErrorNotAuthorized = true };

        var entities = handler.ListAll(db);
        var dtos = entities
            .Select(a => a.ToDto()!)
            .ToArray();

        return new CountryListResponse()
        {
            Success = true,
            State = state,
            Countrys = dtos
        };
    }
}