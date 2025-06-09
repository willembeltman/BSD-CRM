using Microsoft.AspNetCore.Mvc;
using BeltmanSoftwareDesign.Shared.Interfaces;
using BeltmanSoftwareDesign.Business.Interfaces;
using BeltmanSoftwareDesign.Shared.Requests;
using BeltmanSoftwareDesign.Shared.Responses;

namespace BeltmanSoftwareDesign.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ProjectController(IProject Project) : BaseControllerBase
{
    [HttpPost]
    public ProjectCreateResponse Create(ProjectCreateRequest request) 
        => Project.Create(request);

    [HttpPost]
    public ProjectReadResponse Read(ProjectReadRequest request) 
        => Project.Read(request);

    [HttpPost]
    public ProjectUpdateResponse Update(ProjectUpdateRequest request) 
        => Project.Update(request);

    [HttpPost]
    public ProjectDeleteResponse Delete(ProjectDeleteRequest request) 
        => Project.Delete(request);

    [HttpPost]
    public ProjectListResponse List(ProjectListRequest request) 
        => Project.List(request);
}
