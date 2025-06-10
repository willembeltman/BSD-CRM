using BSD.Business.Converters;
using BSD.Business.ServiceHandlers;
using BSD.Business.Interfaces;
using BSD.Data;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using CodeGenerator.Shared.Attributes;

namespace BSD.Business.Services;

public class ProductPriceService(
    ApplicationDbContext db,
    IAuthenticationStateService authenticationService)
    : IProductPriceService
{
    [TsServiceMethod("ProductPrice", "Create")]
    public ProductPriceCreateResponse Create(ProductPriceCreateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ProductPriceCreateResponse() { State = state, ErrorGettingState = true };

        var handler = new ProductPriceServiceHander(state);
        var entity = handler.FindByMatch(db, request.ProductPrice);
        if (entity != null)
            return new ProductPriceCreateResponse() { State = state, ErrorAlreadyUsed = true };

        entity = request.ProductPrice.ToEntity();
        if (!handler.AttachToState(db, entity))
            return new ProductPriceCreateResponse() { State = state, ErrorAttachingState = true };

        if (!handler.CanCreate(db, entity))
            return new ProductPriceCreateResponse() { State = state, ErrorNotAuthorized = true };

        db.ProductPrices.Add(entity);
        db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new ProductPriceCreateResponse() { State = state, ErrorUpdatingState = true };

        return new ProductPriceCreateResponse() { State = state, ProductPrice = dto, Success = true };
    }

    [TsServiceMethod("ProductPrice", "Read")]
    public ProductPriceReadResponse Read(ProductPriceReadRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ProductPriceReadResponse() { State = state, ErrorGettingState = true };

        var handler = new ProductPriceServiceHander(state);
        var entity = handler.FindById(db, request.ProductPriceId);
        if (entity == null)
            return new ProductPriceReadResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanRead(db, entity))
            return new ProductPriceReadResponse() { State = state, ErrorNotAuthorized = true };

        var dto = entity.ToDto();
        return new ProductPriceReadResponse() { State = state, ProductPrice = dto, Success = true, };
    }

    [TsServiceMethod("ProductPrice", "Update")]
    public ProductPriceUpdateResponse Update(ProductPriceUpdateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ProductPriceUpdateResponse() { State = state, ErrorGettingState = true };

        var handler = new ProductPriceServiceHander(state);
        var entity = handler.FindById(db, request.ProductPrice.Id);
        if (entity == null)
            return new ProductPriceUpdateResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanUpdate(db, entity))
            return new ProductPriceUpdateResponse() { State = state, ErrorNotAuthorized = true };

        if (request.ProductPrice.CopyTo(entity))
            db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new ProductPriceUpdateResponse() { State = state, ErrorUpdatingState = true };

        return new ProductPriceUpdateResponse() { State = state, ProductPrice = dto, Success = true };
    }

    [TsServiceMethod("ProductPrice", "Delete")]
    public ProductPriceDeleteResponse Delete(ProductPriceDeleteRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ProductPriceDeleteResponse() { State = state, ErrorGettingState = true };

        var handler = new ProductPriceServiceHander(state);
        var entity = handler.FindById(db, request.ProductPriceId);
        if (entity == null)
            return new ProductPriceDeleteResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanDelete(db, entity))
            return new ProductPriceDeleteResponse() { State = state, ErrorNotAuthorized = true };

        if (!handler.DeleteFromState(db, entity))
            return new ProductPriceDeleteResponse() { State = state, ErrorUpdatingState = true };

        db.ProductPrices.Remove(entity);
        db.SaveChanges();

        return new ProductPriceDeleteResponse() { State = state, Success = true };
    }

    [TsServiceMethod("ProductPrice", "List")]
    public ProductPriceListResponse List(ProductPriceListRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ProductPriceListResponse() { State = state, ErrorGettingState = true };

        var handler = new ProductPriceServiceHander(state);
        if (!handler.CanList(db))
            return new ProductPriceListResponse() { State = state, ErrorNotAuthorized = true };

        var entities = handler.ListAll(db);
        var dtos = entities
            .Select(a => a.ToDto()!)
            .ToArray();

        return new ProductPriceListResponse()
        {
            Success = true,
            State = state,
            ProductPrices = dtos
        };
    }
}