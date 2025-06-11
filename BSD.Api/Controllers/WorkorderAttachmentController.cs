using Microsoft.AspNetCore.Mvc;
using BSD.Business.Interfaces;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class WorkorderAttachmentController(IWorkorderAttachmentService workorderattachment) : ControllerBase
{
    [HttpPost]
    public WorkorderAttachmentCreateResponse Create(WorkorderAttachmentCreateRequest request) 
        => workorderattachment.Create(request);

    [HttpPost]
    public WorkorderAttachmentReadResponse Read(WorkorderAttachmentReadRequest request) 
        => workorderattachment.Read(request);

    [HttpPost]
    public WorkorderAttachmentUpdateResponse Update(WorkorderAttachmentUpdateRequest request) 
        => workorderattachment.Update(request);

    [HttpPost]
    public WorkorderAttachmentDeleteResponse Delete(WorkorderAttachmentDeleteRequest request) 
        => workorderattachment.Delete(request);

    [HttpPost]
    public WorkorderAttachmentListResponse List(WorkorderAttachmentListRequest request) 
        => workorderattachment.List(request);
}
