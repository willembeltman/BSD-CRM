using BeltmanSoftwareDesign.Shared.Interfaces;
using BeltmanSoftwareDesign.Shared.RequestJsons;
using BeltmanSoftwareDesign.Shared.ResponseJsons;
using Microsoft.AspNetCore.Mvc;

namespace BeltmanSoftwareDesign.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class RateController(IRateService RateService) : BaseControllerBase
{
    [HttpPost]
    public RateCreateResponse Create(RateCreateRequest request)
        => RateService.Create(request);

    [HttpPost]
    public RateReadResponse Read(RateReadRequest request)
        => RateService.Read(request);

    [HttpPost]
    public RateUpdateResponse Update(RateUpdateRequest request)
        => RateService.Update(request);

    [HttpPost]
    public RateDeleteResponse Delete(RateDeleteRequest request)
        => RateService.Delete(request);

    [HttpPost]
    public RateListResponse List(RateListRequest request)
        => RateService.List(request);
}
