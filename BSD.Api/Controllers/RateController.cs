using Microsoft.AspNetCore.Mvc;
using BSD.Business.Interfaces;
using BSD.Shared.Requests;
using BSD.Shared.Responses;

namespace BSD.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class RateController(IRateService rate) : ControllerBase
{
    [HttpPost]
    public RateCreateResponse Create(RateCreateRequest request) 
        => rate.Create(request);

    [HttpPost]
    public RateReadResponse Read(RateReadRequest request) 
        => rate.Read(request);

    [HttpPost]
    public RateUpdateResponse Update(RateUpdateRequest request) 
        => rate.Update(request);

    [HttpPost]
    public RateDeleteResponse Delete(RateDeleteRequest request) 
        => rate.Delete(request);

    [HttpPost]
    public RateListResponse List(RateListRequest request) 
        => rate.List(request);
}
