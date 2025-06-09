using Microsoft.AspNetCore.Mvc;
using BeltmanSoftwareDesign.Shared.Interfaces;
using BeltmanSoftwareDesign.Business.Interfaces;
using BeltmanSoftwareDesign.Shared.Requests;
using BeltmanSoftwareDesign.Shared.Responses;

namespace BeltmanSoftwareDesign.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class RateController(IRate Rate) : BaseControllerBase
{
    [HttpPost]
    public RateCreateResponse Create(RateCreateRequest request) 
        => Rate.Create(request);

    [HttpPost]
    public RateReadResponse Read(RateReadRequest request) 
        => Rate.Read(request);

    [HttpPost]
    public RateUpdateResponse Update(RateUpdateRequest request) 
        => Rate.Update(request);

    [HttpPost]
    public RateDeleteResponse Delete(RateDeleteRequest request) 
        => Rate.Delete(request);

    [HttpPost]
    public RateListResponse List(RateListRequest request) 
        => Rate.List(request);
}
