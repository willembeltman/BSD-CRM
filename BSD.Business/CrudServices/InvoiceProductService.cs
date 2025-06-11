using BSD.Business.Converters;
using BSD.Business.CrudHandlers;
using BSD.Business.Interfaces;
using BSD.Data;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using CodeGenerator.Shared.Attributes;

namespace BSD.Business.CrudServices;

public class InvoiceProductService(
    ApplicationDbContext db,
    IAuthenticationStateService authenticationService)
    : IInvoiceProductService
{
    [TsServiceMethod("InvoiceProduct", "Create")]
    public InvoiceProductCreateResponse Create(InvoiceProductCreateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new InvoiceProductCreateResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new InvoiceProductCreateResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new InvoiceProductServiceHandler(state);
        var entity = handler.FindByMatch(db, request.InvoiceProduct);
        if (entity != null)
            return new InvoiceProductCreateResponse() { State = state, ErrorAlreadyUsed = true };

        entity = request.InvoiceProduct.ToEntity();
        if (!handler.AttachToState(db, entity))
            return new InvoiceProductCreateResponse() { State = state, ErrorAttachingState = true };

        if (!handler.CanCreate(db, entity))
            return new InvoiceProductCreateResponse() { State = state, ErrorNotAuthorized = true };

        db.InvoiceProducts.Add(entity);
        db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new InvoiceProductCreateResponse() { State = state, ErrorUpdatingState = true };

        return new InvoiceProductCreateResponse() { State = state, InvoiceProduct = dto, Success = true };
    }

    [TsServiceMethod("InvoiceProduct", "Read")]
    public InvoiceProductReadResponse Read(InvoiceProductReadRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new InvoiceProductReadResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new InvoiceProductReadResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new InvoiceProductServiceHandler(state);
        var entity = handler.FindById(db, request.InvoiceProductId);
        if (entity == null)
            return new InvoiceProductReadResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanRead(db, entity))
            return new InvoiceProductReadResponse() { State = state, ErrorNotAuthorized = true };

        var dto = entity.ToDto();
        return new InvoiceProductReadResponse() { State = state, InvoiceProduct = dto, Success = true, };
    }

    [TsServiceMethod("InvoiceProduct", "Update")]
    public InvoiceProductUpdateResponse Update(InvoiceProductUpdateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new InvoiceProductUpdateResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new InvoiceProductUpdateResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new InvoiceProductServiceHandler(state);
        var entity = handler.FindById(db, request.InvoiceProduct.Id);
        if (entity == null)
            return new InvoiceProductUpdateResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanUpdate(db, entity))
            return new InvoiceProductUpdateResponse() { State = state, ErrorNotAuthorized = true };

        if (request.InvoiceProduct.CopyTo(entity))
            db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new InvoiceProductUpdateResponse() { State = state, ErrorUpdatingState = true };

        return new InvoiceProductUpdateResponse() { State = state, InvoiceProduct = dto, Success = true };
    }

    [TsServiceMethod("InvoiceProduct", "Delete")]
    public InvoiceProductDeleteResponse Delete(InvoiceProductDeleteRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new InvoiceProductDeleteResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new InvoiceProductDeleteResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new InvoiceProductServiceHandler(state);
        var entity = handler.FindById(db, request.InvoiceProductId);
        if (entity == null)
            return new InvoiceProductDeleteResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanDelete(db, entity))
            return new InvoiceProductDeleteResponse() { State = state, ErrorNotAuthorized = true };

        if (!handler.DeleteFromState(db, entity))
            return new InvoiceProductDeleteResponse() { State = state, ErrorUpdatingState = true };

        db.InvoiceProducts.Remove(entity);
        db.SaveChanges();

        return new InvoiceProductDeleteResponse() { State = state, Success = true };
    }

    [TsServiceMethod("InvoiceProduct", "List")]
    public InvoiceProductListResponse List(InvoiceProductListRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new InvoiceProductListResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new InvoiceProductListResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new InvoiceProductServiceHandler(state);
        if (!handler.CanList(db))
            return new InvoiceProductListResponse() { State = state, ErrorNotAuthorized = true };

        var entities = handler.ListAll(db);
        var dtos = entities
            .Select(a => a.ToDto()!)
            .ToArray();

        return new InvoiceProductListResponse()
        {
            Success = true,
            State = state,
            InvoiceProducts = dtos
        };
    }
}