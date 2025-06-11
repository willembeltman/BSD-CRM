using BSD.Business.Interfaces;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using Microsoft.AspNetCore.Mvc;

namespace BSD.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ProductController(IProductService product) : ControllerBase
{
    [HttpPost]
    public ProductCreateResponse Create(ProductCreateRequest request)
        => product.Create(request);

    [HttpPost]
    public ProductReadResponse Read(ProductReadRequest request)
        => product.Read(request);

    [HttpPost]
    public ProductUpdateResponse Update(ProductUpdateRequest request)
        => product.Update(request);

    [HttpPost]
    public ProductDeleteResponse Delete(ProductDeleteRequest request)
        => product.Delete(request);

    [HttpPost]
    public ProductListResponse List(ProductListRequest request)
        => product.List(request);
}
