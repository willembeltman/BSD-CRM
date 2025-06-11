using Microsoft.AspNetCore.Mvc;
using BSD.Business.Interfaces;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ExperienceTechnologyController(IExperienceTechnologyService experiencetechnology) : ControllerBase
{
    [HttpPost]
    public ExperienceTechnologyCreateResponse Create(ExperienceTechnologyCreateRequest request) 
        => experiencetechnology.Create(request);

    [HttpPost]
    public ExperienceTechnologyReadResponse Read(ExperienceTechnologyReadRequest request) 
        => experiencetechnology.Read(request);

    [HttpPost]
    public ExperienceTechnologyUpdateResponse Update(ExperienceTechnologyUpdateRequest request) 
        => experiencetechnology.Update(request);

    [HttpPost]
    public ExperienceTechnologyDeleteResponse Delete(ExperienceTechnologyDeleteRequest request) 
        => experiencetechnology.Delete(request);

    [HttpPost]
    public ExperienceTechnologyListResponse List(ExperienceTechnologyListRequest request) 
        => experiencetechnology.List(request);
}
