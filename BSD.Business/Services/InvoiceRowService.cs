using BSD.Business.Converters;
using BSD.Business.ServiceHandlers;
using BSD.Business.Interfaces;
using BSD.Data;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using CodeGenerator.Shared.Attributes;

namespace BSD.Business.Services;

public class InvoiceRowService(
    ApplicationDbContext db,
    IAuthenticationStateService authenticationService)
    : IInvoiceRowService
{
    [TsServiceMethod("InvoiceRow", "Create")]
    public InvoiceRowCreateResponse Create(InvoiceRowCreateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new InvoiceRowCreateResponse() { State = state, ErrorGettingState = true };

        var handler = new InvoiceRowServiceHander(state);
        var entity = handler.FindByMatch(db, request.InvoiceRow);
        if (entity != null)
            return new InvoiceRowCreateResponse() { State = state, ErrorAlreadyUsed = true };

        entity = request.InvoiceRow.ToEntity();
        if (!handler.AttachToState(db, entity))
            return new InvoiceRowCreateResponse() { State = state, ErrorAttachingState = true };

        if (!handler.CanCreate(db, entity))
            return new InvoiceRowCreateResponse() { State = state, ErrorNotAuthorized = true };

        db.InvoiceRows.Add(entity);
        db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new InvoiceRowCreateResponse() { State = state, ErrorUpdatingState = true };

        return new InvoiceRowCreateResponse() { State = state, InvoiceRow = dto, Success = true };
    }

    [TsServiceMethod("InvoiceRow", "Read")]
    public InvoiceRowReadResponse Read(InvoiceRowReadRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new InvoiceRowReadResponse() { State = state, ErrorGettingState = true };

        var handler = new InvoiceRowServiceHander(state);
        var entity = handler.FindById(db, request.InvoiceRowId);
        if (entity == null)
            return new InvoiceRowReadResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanRead(db, entity))
            return new InvoiceRowReadResponse() { State = state, ErrorNotAuthorized = true };

        var dto = entity.ToDto();
        return new InvoiceRowReadResponse() { State = state, InvoiceRow = dto, Success = true, };
    }

    [TsServiceMethod("InvoiceRow", "Update")]
    public InvoiceRowUpdateResponse Update(InvoiceRowUpdateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new InvoiceRowUpdateResponse() { State = state, ErrorGettingState = true };

        var handler = new InvoiceRowServiceHander(state);
        var entity = handler.FindById(db, request.InvoiceRow.Id);
        if (entity == null)
            return new InvoiceRowUpdateResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanUpdate(db, entity))
            return new InvoiceRowUpdateResponse() { State = state, ErrorNotAuthorized = true };

        if (request.InvoiceRow.CopyTo(entity))
            db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new InvoiceRowUpdateResponse() { State = state, ErrorUpdatingState = true };

        return new InvoiceRowUpdateResponse() { State = state, InvoiceRow = dto, Success = true };
    }

    [TsServiceMethod("InvoiceRow", "Delete")]
    public InvoiceRowDeleteResponse Delete(InvoiceRowDeleteRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new InvoiceRowDeleteResponse() { State = state, ErrorGettingState = true };

        var handler = new InvoiceRowServiceHander(state);
        var entity = handler.FindById(db, request.InvoiceRowId);
        if (entity == null)
            return new InvoiceRowDeleteResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanDelete(db, entity))
            return new InvoiceRowDeleteResponse() { State = state, ErrorNotAuthorized = true };

        if (!handler.DeleteFromState(db, entity))
            return new InvoiceRowDeleteResponse() { State = state, ErrorUpdatingState = true };

        db.InvoiceRows.Remove(entity);
        db.SaveChanges();

        return new InvoiceRowDeleteResponse() { State = state, Success = true };
    }

    [TsServiceMethod("InvoiceRow", "List")]
    public InvoiceRowListResponse List(InvoiceRowListRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new InvoiceRowListResponse() { State = state, ErrorGettingState = true };

        var handler = new InvoiceRowServiceHander(state);
        if (!handler.CanList(db))
            return new InvoiceRowListResponse() { State = state, ErrorNotAuthorized = true };

        var entities = handler.ListAll(db);
        var dtos = entities
            .Select(a => a.ToDto()!)
            .ToArray();

        return new InvoiceRowListResponse()
        {
            Success = true,
            State = state,
            InvoiceRows = dtos
        };
    }
}