using Microsoft.AspNetCore.Mvc;
using BSD.Business.Interfaces;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class TaxRateController(ITaxRateService taxrate) : ControllerBase
{
    [HttpPost]
    public TaxRateCreateResponse Create(TaxRateCreateRequest request) 
        => taxrate.Create(request);

    [HttpPost]
    public TaxRateReadResponse Read(TaxRateReadRequest request) 
        => taxrate.Read(request);

    [HttpPost]
    public TaxRateUpdateResponse Update(TaxRateUpdateRequest request) 
        => taxrate.Update(request);

    [HttpPost]
    public TaxRateDeleteResponse Delete(TaxRateDeleteRequest request) 
        => taxrate.Delete(request);

    [HttpPost]
    public TaxRateListResponse List(TaxRateListRequest request) 
        => taxrate.List(request);
}
