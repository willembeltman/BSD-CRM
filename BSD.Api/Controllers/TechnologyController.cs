using BSD.Business.CrudInterfaces;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using Microsoft.AspNetCore.Mvc;

namespace BSD.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class TechnologyController(ITechnologyService technology) : ControllerBase
{
    [HttpPost]
    public TechnologyCreateResponse Create(TechnologyCreateRequest request)
        => technology.Create(request);

    [HttpPost]
    public TechnologyReadResponse Read(TechnologyReadRequest request)
        => technology.Read(request);

    [HttpPost]
    public TechnologyUpdateResponse Update(TechnologyUpdateRequest request)
        => technology.Update(request);

    [HttpPost]
    public TechnologyDeleteResponse Delete(TechnologyDeleteRequest request)
        => technology.Delete(request);

    [HttpPost]
    public TechnologyListResponse List(TechnologyListRequest request)
        => technology.List(request);
}
