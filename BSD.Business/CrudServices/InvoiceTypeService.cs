using BSD.Business.Converters;
using BSD.Business.ServiceHandlers;
using BSD.Business.Interfaces;
using BSD.Data;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using CodeGenerator.Shared.Attributes;

namespace BSD.Business.CrudServices;

public class InvoiceTypeService(
    ApplicationDbContext db,
    IAuthenticationStateService authenticationService)
    : IInvoiceTypeService
{
    [TsServiceMethod("InvoiceType", "Create")]
    public InvoiceTypeCreateResponse Create(InvoiceTypeCreateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new InvoiceTypeCreateResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new InvoiceTypeCreateResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new InvoiceTypeServiceHandler(state);
        var entity = handler.FindByMatch(db, request.InvoiceType);
        if (entity != null)
            return new InvoiceTypeCreateResponse() { State = state, ErrorAlreadyUsed = true };

        entity = request.InvoiceType.ToEntity();
        if (!handler.AttachToState(db, entity))
            return new InvoiceTypeCreateResponse() { State = state, ErrorAttachingState = true };

        if (!handler.CanCreate(db, entity))
            return new InvoiceTypeCreateResponse() { State = state, ErrorNotAuthorized = true };

        db.InvoiceTypes.Add(entity);
        db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new InvoiceTypeCreateResponse() { State = state, ErrorUpdatingState = true };

        return new InvoiceTypeCreateResponse() { State = state, InvoiceType = dto, Success = true };
    }

    [TsServiceMethod("InvoiceType", "Read")]
    public InvoiceTypeReadResponse Read(InvoiceTypeReadRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new InvoiceTypeReadResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new InvoiceTypeReadResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new InvoiceTypeServiceHandler(state);
        var entity = handler.FindById(db, request.InvoiceTypeId);
        if (entity == null)
            return new InvoiceTypeReadResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanRead(db, entity))
            return new InvoiceTypeReadResponse() { State = state, ErrorNotAuthorized = true };

        var dto = entity.ToDto();
        return new InvoiceTypeReadResponse() { State = state, InvoiceType = dto, Success = true, };
    }

    [TsServiceMethod("InvoiceType", "Update")]
    public InvoiceTypeUpdateResponse Update(InvoiceTypeUpdateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new InvoiceTypeUpdateResponse() { State = state, ErrorGettingState = true };

            if (state.User == null || state.DbUser == null)
                return new InvoiceTypeUpdateResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new InvoiceTypeServiceHandler(state);
        var entity = handler.FindById(db, request.InvoiceType.Id);
        if (entity == null)
            return new InvoiceTypeUpdateResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanUpdate(db, entity))
            return new InvoiceTypeUpdateResponse() { State = state, ErrorNotAuthorized = true };

        if (request.InvoiceType.CopyTo(entity))
            db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new InvoiceTypeUpdateResponse() { State = state, ErrorUpdatingState = true };

        return new InvoiceTypeUpdateResponse() { State = state, InvoiceType = dto, Success = true };
    }

    [TsServiceMethod("InvoiceType", "Delete")]
    public InvoiceTypeDeleteResponse Delete(InvoiceTypeDeleteRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new InvoiceTypeDeleteResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new InvoiceTypeDeleteResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new InvoiceTypeServiceHandler(state);
        var entity = handler.FindById(db, request.InvoiceTypeId);
        if (entity == null)
            return new InvoiceTypeDeleteResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanDelete(db, entity))
            return new InvoiceTypeDeleteResponse() { State = state, ErrorNotAuthorized = true };

        if (!handler.DeleteFromState(db, entity))
            return new InvoiceTypeDeleteResponse() { State = state, ErrorUpdatingState = true };

        db.InvoiceTypes.Remove(entity);
        db.SaveChanges();

        return new InvoiceTypeDeleteResponse() { State = state, Success = true };
    }

    [TsServiceMethod("InvoiceType", "List")]
    public InvoiceTypeListResponse List(InvoiceTypeListRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new InvoiceTypeListResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new InvoiceTypeListResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new InvoiceTypeServiceHandler(state);
        if (!handler.CanList(db))
            return new InvoiceTypeListResponse() { State = state, ErrorNotAuthorized = true };

        var entities = handler.ListAll(db);
        var dtos = entities
            .Select(a => a.ToDto()!)
            .ToArray();

        return new InvoiceTypeListResponse()
        {
            Success = true,
            State = state,
            InvoiceTypes = dtos
        };
    }
}