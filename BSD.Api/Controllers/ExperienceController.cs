using BSD.Business.Interfaces;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using Microsoft.AspNetCore.Mvc;

namespace BSD.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ExperienceController(IExperienceService experience) : ControllerBase
{
    [HttpPost]
    public ExperienceCreateResponse Create(ExperienceCreateRequest request)
        => experience.Create(request);

    [HttpPost]
    public ExperienceReadResponse Read(ExperienceReadRequest request)
        => experience.Read(request);

    [HttpPost]
    public ExperienceUpdateResponse Update(ExperienceUpdateRequest request)
        => experience.Update(request);

    [HttpPost]
    public ExperienceDeleteResponse Delete(ExperienceDeleteRequest request)
        => experience.Delete(request);

    [HttpPost]
    public ExperienceListResponse List(ExperienceListRequest request)
        => experience.List(request);
}
