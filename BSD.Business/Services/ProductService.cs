using BSD.Business.Converters;
using BSD.Business.ServiceHandlers;
using BSD.Business.Interfaces;
using BSD.Data;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using CodeGenerator.Shared.Attributes;

namespace BSD.Business.Services;

public class ProductService(
    ApplicationDbContext db,
    IAuthenticationStateService authenticationService)
    : IProductService
{
    [TsServiceMethod("Product", "Create")]
    public ProductCreateResponse Create(ProductCreateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ProductCreateResponse() { State = state, ErrorGettingState = true };

        var handler = new ProductServiceHandler(state);
        var entity = handler.FindByMatch(db, request.Product);
        if (entity != null)
            return new ProductCreateResponse() { State = state, ErrorAlreadyUsed = true };

        entity = request.Product.ToEntity();
        if (!handler.AttachToState(db, entity))
            return new ProductCreateResponse() { State = state, ErrorAttachingState = true };

        if (!handler.CanCreate(db, entity))
            return new ProductCreateResponse() { State = state, ErrorNotAuthorized = true };

        db.Products.Add(entity);
        db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new ProductCreateResponse() { State = state, ErrorUpdatingState = true };

        return new ProductCreateResponse() { State = state, Product = dto, Success = true };
    }

    [TsServiceMethod("Product", "Read")]
    public ProductReadResponse Read(ProductReadRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ProductReadResponse() { State = state, ErrorGettingState = true };

        var handler = new ProductServiceHandler(state);
        var entity = handler.FindById(db, request.ProductId);
        if (entity == null)
            return new ProductReadResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanRead(db, entity))
            return new ProductReadResponse() { State = state, ErrorNotAuthorized = true };

        var dto = entity.ToDto();
        return new ProductReadResponse() { State = state, Product = dto, Success = true, };
    }

    [TsServiceMethod("Product", "Update")]
    public ProductUpdateResponse Update(ProductUpdateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ProductUpdateResponse() { State = state, ErrorGettingState = true };

        var handler = new ProductServiceHandler(state);
        var entity = handler.FindById(db, request.Product.Id);
        if (entity == null)
            return new ProductUpdateResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanUpdate(db, entity))
            return new ProductUpdateResponse() { State = state, ErrorNotAuthorized = true };

        if (request.Product.CopyTo(entity))
            db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new ProductUpdateResponse() { State = state, ErrorUpdatingState = true };

        return new ProductUpdateResponse() { State = state, Product = dto, Success = true };
    }

    [TsServiceMethod("Product", "Delete")]
    public ProductDeleteResponse Delete(ProductDeleteRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ProductDeleteResponse() { State = state, ErrorGettingState = true };

        var handler = new ProductServiceHandler(state);
        var entity = handler.FindById(db, request.ProductId);
        if (entity == null)
            return new ProductDeleteResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanDelete(db, entity))
            return new ProductDeleteResponse() { State = state, ErrorNotAuthorized = true };

        if (!handler.DeleteFromState(db, entity))
            return new ProductDeleteResponse() { State = state, ErrorUpdatingState = true };

        db.Products.Remove(entity);
        db.SaveChanges();

        return new ProductDeleteResponse() { State = state, Success = true };
    }

    [TsServiceMethod("Product", "List")]
    public ProductListResponse List(ProductListRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ProductListResponse() { State = state, ErrorGettingState = true };

        var handler = new ProductServiceHandler(state);
        if (!handler.CanList(db))
            return new ProductListResponse() { State = state, ErrorNotAuthorized = true };

        var entities = handler.ListAll(db);
        var dtos = entities
            .Select(a => a.ToDto()!)
            .ToArray();

        return new ProductListResponse()
        {
            Success = true,
            State = state,
            Products = dtos
        };
    }
}