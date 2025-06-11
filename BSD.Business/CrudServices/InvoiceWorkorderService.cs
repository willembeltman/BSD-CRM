using BSD.Business.Converters;
using BSD.Business.CrudHandlers;
using BSD.Business.Interfaces;
using BSD.Data;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using CodeGenerator.Shared.Attributes;

namespace BSD.Business.CrudServices;

public class InvoiceWorkorderService(
    ApplicationDbContext db,
    IAuthenticationStateService authenticationService)
    : IInvoiceWorkorderService
{
    [TsServiceMethod("InvoiceWorkorder", "Create")]
    public InvoiceWorkorderCreateResponse Create(InvoiceWorkorderCreateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new InvoiceWorkorderCreateResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new InvoiceWorkorderCreateResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new InvoiceWorkorderServiceHandler(state);
        var entity = handler.FindByMatch(db, request.InvoiceWorkorder);
        if (entity != null)
            return new InvoiceWorkorderCreateResponse() { State = state, ErrorAlreadyUsed = true };

        entity = request.InvoiceWorkorder.ToEntity();
        if (!handler.AttachToState(db, entity))
            return new InvoiceWorkorderCreateResponse() { State = state, ErrorAttachingState = true };

        if (!handler.CanCreate(db, entity))
            return new InvoiceWorkorderCreateResponse() { State = state, ErrorNotAuthorized = true };

        db.InvoiceWorkorders.Add(entity);
        db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new InvoiceWorkorderCreateResponse() { State = state, ErrorUpdatingState = true };

        return new InvoiceWorkorderCreateResponse() { State = state, InvoiceWorkorder = dto, Success = true };
    }

    [TsServiceMethod("InvoiceWorkorder", "Read")]
    public InvoiceWorkorderReadResponse Read(InvoiceWorkorderReadRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new InvoiceWorkorderReadResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new InvoiceWorkorderReadResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new InvoiceWorkorderServiceHandler(state);
        var entity = handler.FindById(db, request.InvoiceWorkorderId);
        if (entity == null)
            return new InvoiceWorkorderReadResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanRead(db, entity))
            return new InvoiceWorkorderReadResponse() { State = state, ErrorNotAuthorized = true };

        var dto = entity.ToDto();
        return new InvoiceWorkorderReadResponse() { State = state, InvoiceWorkorder = dto, Success = true, };
    }

    [TsServiceMethod("InvoiceWorkorder", "Update")]
    public InvoiceWorkorderUpdateResponse Update(InvoiceWorkorderUpdateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new InvoiceWorkorderUpdateResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new InvoiceWorkorderUpdateResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new InvoiceWorkorderServiceHandler(state);
        var entity = handler.FindById(db, request.InvoiceWorkorder.Id);
        if (entity == null)
            return new InvoiceWorkorderUpdateResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanUpdate(db, entity))
            return new InvoiceWorkorderUpdateResponse() { State = state, ErrorNotAuthorized = true };

        if (request.InvoiceWorkorder.CopyTo(entity))
            db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new InvoiceWorkorderUpdateResponse() { State = state, ErrorUpdatingState = true };

        return new InvoiceWorkorderUpdateResponse() { State = state, InvoiceWorkorder = dto, Success = true };
    }

    [TsServiceMethod("InvoiceWorkorder", "Delete")]
    public InvoiceWorkorderDeleteResponse Delete(InvoiceWorkorderDeleteRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new InvoiceWorkorderDeleteResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new InvoiceWorkorderDeleteResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new InvoiceWorkorderServiceHandler(state);
        var entity = handler.FindById(db, request.InvoiceWorkorderId);
        if (entity == null)
            return new InvoiceWorkorderDeleteResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanDelete(db, entity))
            return new InvoiceWorkorderDeleteResponse() { State = state, ErrorNotAuthorized = true };

        if (!handler.DeleteFromState(db, entity))
            return new InvoiceWorkorderDeleteResponse() { State = state, ErrorUpdatingState = true };

        db.InvoiceWorkorders.Remove(entity);
        db.SaveChanges();

        return new InvoiceWorkorderDeleteResponse() { State = state, Success = true };
    }

    [TsServiceMethod("InvoiceWorkorder", "List")]
    public InvoiceWorkorderListResponse List(InvoiceWorkorderListRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new InvoiceWorkorderListResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new InvoiceWorkorderListResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new InvoiceWorkorderServiceHandler(state);
        if (!handler.CanList(db))
            return new InvoiceWorkorderListResponse() { State = state, ErrorNotAuthorized = true };

        var entities = handler.ListAll(db);
        var dtos = entities
            .Select(a => a.ToDto()!)
            .ToArray();

        return new InvoiceWorkorderListResponse()
        {
            Success = true,
            State = state,
            InvoiceWorkorders = dtos
        };
    }
}