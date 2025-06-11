using BSD.Business.CrudInterfaces;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using Microsoft.AspNetCore.Mvc;

namespace BSD.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class TechnologyAttachmentController(ITechnologyAttachmentService technologyattachment) : ControllerBase
{
    [HttpPost]
    public TechnologyAttachmentCreateResponse Create(TechnologyAttachmentCreateRequest request)
        => technologyattachment.Create(request);

    [HttpPost]
    public TechnologyAttachmentReadResponse Read(TechnologyAttachmentReadRequest request)
        => technologyattachment.Read(request);

    [HttpPost]
    public TechnologyAttachmentUpdateResponse Update(TechnologyAttachmentUpdateRequest request)
        => technologyattachment.Update(request);

    [HttpPost]
    public TechnologyAttachmentDeleteResponse Delete(TechnologyAttachmentDeleteRequest request)
        => technologyattachment.Delete(request);

    [HttpPost]
    public TechnologyAttachmentListResponse List(TechnologyAttachmentListRequest request)
        => technologyattachment.List(request);
}
