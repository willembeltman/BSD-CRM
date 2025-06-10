using Microsoft.AspNetCore.Mvc;
using BSD.Business.Interfaces;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ProjectController(IProjectService project) : ControllerBase
{
    [HttpPost]
    public ProjectCreateResponse Create(ProjectCreateRequest request) 
        => project.Create(request);

    [HttpPost]
    public ProjectReadResponse Read(ProjectReadRequest request) 
        => project.Read(request);

    [HttpPost]
    public ProjectUpdateResponse Update(ProjectUpdateRequest request) 
        => project.Update(request);

    [HttpPost]
    public ProjectDeleteResponse Delete(ProjectDeleteRequest request) 
        => project.Delete(request);

    [HttpPost]
    public ProjectListResponse List(ProjectListRequest request) 
        => project.List(request);
}
