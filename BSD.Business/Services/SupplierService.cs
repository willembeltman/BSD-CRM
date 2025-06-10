using BSD.Business.Converters;
using BSD.Business.ServiceHandlers;
using BSD.Business.Interfaces;
using BSD.Data;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using CodeGenerator.Shared.Attributes;

namespace BSD.Business.Services;

public class SupplierService(
    ApplicationDbContext db,
    IAuthenticationStateService authenticationService)
    : ISupplierService
{
    [TsServiceMethod("Supplier", "Create")]
    public SupplierCreateResponse Create(SupplierCreateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new SupplierCreateResponse() { State = state, ErrorGettingState = true };

        var handler = new SupplierServiceHander(state);
        var entity = handler.FindByMatch(db, request.Supplier);
        if (entity != null)
            return new SupplierCreateResponse() { State = state, ErrorAlreadyUsed = true };

        entity = request.Supplier.ToEntity();
        if (!handler.AttachToState(db, entity))
            return new SupplierCreateResponse() { State = state, ErrorAttachingState = true };

        if (!handler.CanCreate(db, entity))
            return new SupplierCreateResponse() { State = state, ErrorNotAuthorized = true };

        db.Suppliers.Add(entity);
        db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new SupplierCreateResponse() { State = state, ErrorUpdatingState = true };

        return new SupplierCreateResponse() { State = state, Supplier = dto, Success = true };
    }

    [TsServiceMethod("Supplier", "Read")]
    public SupplierReadResponse Read(SupplierReadRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new SupplierReadResponse() { State = state, ErrorGettingState = true };

        var handler = new SupplierServiceHander(state);
        var entity = handler.FindById(db, request.SupplierId);
        if (entity == null)
            return new SupplierReadResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanRead(db, entity))
            return new SupplierReadResponse() { State = state, ErrorNotAuthorized = true };

        var dto = entity.ToDto();
        return new SupplierReadResponse() { State = state, Supplier = dto, Success = true, };
    }

    [TsServiceMethod("Supplier", "Update")]
    public SupplierUpdateResponse Update(SupplierUpdateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new SupplierUpdateResponse() { State = state, ErrorGettingState = true };

        var handler = new SupplierServiceHander(state);
        var entity = handler.FindById(db, request.Supplier.Id);
        if (entity == null)
            return new SupplierUpdateResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanUpdate(db, entity))
            return new SupplierUpdateResponse() { State = state, ErrorNotAuthorized = true };

        if (request.Supplier.CopyTo(entity))
            db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new SupplierUpdateResponse() { State = state, ErrorUpdatingState = true };

        return new SupplierUpdateResponse() { State = state, Supplier = dto, Success = true };
    }

    [TsServiceMethod("Supplier", "Delete")]
    public SupplierDeleteResponse Delete(SupplierDeleteRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new SupplierDeleteResponse() { State = state, ErrorGettingState = true };

        var handler = new SupplierServiceHander(state);
        var entity = handler.FindById(db, request.SupplierId);
        if (entity == null)
            return new SupplierDeleteResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanDelete(db, entity))
            return new SupplierDeleteResponse() { State = state, ErrorNotAuthorized = true };

        if (!handler.DeleteFromState(db, entity))
            return new SupplierDeleteResponse() { State = state, ErrorUpdatingState = true };

        db.Suppliers.Remove(entity);
        db.SaveChanges();

        return new SupplierDeleteResponse() { State = state, Success = true };
    }

    [TsServiceMethod("Supplier", "List")]
    public SupplierListResponse List(SupplierListRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new SupplierListResponse() { State = state, ErrorGettingState = true };

        var handler = new SupplierServiceHander(state);
        if (!handler.CanList(db))
            return new SupplierListResponse() { State = state, ErrorNotAuthorized = true };

        var entities = handler.ListAll(db);
        var dtos = entities
            .Select(a => a.ToDto()!)
            .ToArray();

        return new SupplierListResponse()
        {
            Success = true,
            State = state,
            Suppliers = dtos
        };
    }
}