using Microsoft.AspNetCore.Mvc;
using BeltmanSoftwareDesign.Business.Interfaces;
using BeltmanSoftwareDesign.Shared.RequestJsons;
using BeltmanSoftwareDesign.Shared.ResponseJsons;

namespace BeltmanSoftwareDesign.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ProjectController(IProjectService ProjectService) : BaseControllerBase
{
    [HttpPost]
    public ProjectCreateResponse Create(ProjectCreateRequest request) 
        => ProjectService.Create(request);

    [HttpPost]
    public ProjectReadResponse Read(ProjectReadRequest request) 
        => ProjectService.Read(request);

    [HttpPost]
    public ProjectUpdateResponse Update(ProjectUpdateRequest request) 
        => ProjectService.Update(request);

    [HttpPost]
    public ProjectDeleteResponse Delete(ProjectDeleteRequest request) 
        => ProjectService.Delete(request);

    [HttpPost]
    public ProjectListResponse List(ProjectListRequest request) 
        => ProjectService.List(request);
}
