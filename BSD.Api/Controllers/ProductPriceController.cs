using BSD.Business.Interfaces;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using Microsoft.AspNetCore.Mvc;

namespace BSD.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ProductPriceController(IProductPriceService productprice) : ControllerBase
{
    [HttpPost]
    public ProductPriceCreateResponse Create(ProductPriceCreateRequest request)
        => productprice.Create(request);

    [HttpPost]
    public ProductPriceReadResponse Read(ProductPriceReadRequest request)
        => productprice.Read(request);

    [HttpPost]
    public ProductPriceUpdateResponse Update(ProductPriceUpdateRequest request)
        => productprice.Update(request);

    [HttpPost]
    public ProductPriceDeleteResponse Delete(ProductPriceDeleteRequest request)
        => productprice.Delete(request);

    [HttpPost]
    public ProductPriceListResponse List(ProductPriceListRequest request)
        => productprice.List(request);
}
