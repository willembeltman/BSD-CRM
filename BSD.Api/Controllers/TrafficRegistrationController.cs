using BSD.Business.CrudInterfaces;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using Microsoft.AspNetCore.Mvc;

namespace BSD.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class TrafficRegistrationController(ITrafficRegistrationService trafficregistration) : ControllerBase
{
    [HttpPost]
    public TrafficRegistrationCreateResponse Create(TrafficRegistrationCreateRequest request)
        => trafficregistration.Create(request);

    [HttpPost]
    public TrafficRegistrationReadResponse Read(TrafficRegistrationReadRequest request)
        => trafficregistration.Read(request);

    [HttpPost]
    public TrafficRegistrationUpdateResponse Update(TrafficRegistrationUpdateRequest request)
        => trafficregistration.Update(request);

    [HttpPost]
    public TrafficRegistrationDeleteResponse Delete(TrafficRegistrationDeleteRequest request)
        => trafficregistration.Delete(request);

    [HttpPost]
    public TrafficRegistrationListResponse List(TrafficRegistrationListRequest request)
        => trafficregistration.List(request);
}
