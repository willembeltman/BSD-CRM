using Microsoft.AspNetCore.Mvc;
using BSD.Business.Interfaces;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ResidenceController(IResidenceService residence) : ControllerBase
{
    [HttpPost]
    public ResidenceCreateResponse Create(ResidenceCreateRequest request) 
        => residence.Create(request);

    [HttpPost]
    public ResidenceReadResponse Read(ResidenceReadRequest request) 
        => residence.Read(request);

    [HttpPost]
    public ResidenceUpdateResponse Update(ResidenceUpdateRequest request) 
        => residence.Update(request);

    [HttpPost]
    public ResidenceDeleteResponse Delete(ResidenceDeleteRequest request) 
        => residence.Delete(request);

    [HttpPost]
    public ResidenceListResponse List(ResidenceListRequest request) 
        => residence.List(request);
}
