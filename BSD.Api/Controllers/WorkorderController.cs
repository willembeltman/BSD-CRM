using BSD.Business.Interfaces;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using Microsoft.AspNetCore.Mvc;

namespace BSD.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class WorkorderController(IWorkorderService workorder) : ControllerBase
{
    [HttpPost]
    public WorkorderCreateResponse Create(WorkorderCreateRequest request)
        => workorder.Create(request);

    [HttpPost]
    public WorkorderReadResponse Read(WorkorderReadRequest request)
        => workorder.Read(request);

    [HttpPost]
    public WorkorderUpdateResponse Update(WorkorderUpdateRequest request)
        => workorder.Update(request);

    [HttpPost]
    public WorkorderDeleteResponse Delete(WorkorderDeleteRequest request)
        => workorder.Delete(request);

    [HttpPost]
    public WorkorderListResponse List(WorkorderListRequest request)
        => workorder.List(request);
}
