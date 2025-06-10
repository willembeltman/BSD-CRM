using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Business.Interfaces;

public interface IProductPriceService
{
    ProductPriceCreateResponse Create(ProductPriceCreateRequest request);
    ProductPriceDeleteResponse Delete(ProductPriceDeleteRequest request);
    ProductPriceListResponse List(ProductPriceListRequest request);
    ProductPriceReadResponse Read(ProductPriceReadRequest request);
    ProductPriceUpdateResponse Update(ProductPriceUpdateRequest request);
}