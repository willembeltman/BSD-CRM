using BSD.Business.Interfaces;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using Microsoft.AspNetCore.Mvc;

namespace BSD.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ExperienceAttachmentController(IExperienceAttachmentService experienceattachment) : ControllerBase
{
    [HttpPost]
    public ExperienceAttachmentCreateResponse Create(ExperienceAttachmentCreateRequest request)
        => experienceattachment.Create(request);

    [HttpPost]
    public ExperienceAttachmentReadResponse Read(ExperienceAttachmentReadRequest request)
        => experienceattachment.Read(request);

    [HttpPost]
    public ExperienceAttachmentUpdateResponse Update(ExperienceAttachmentUpdateRequest request)
        => experienceattachment.Update(request);

    [HttpPost]
    public ExperienceAttachmentDeleteResponse Delete(ExperienceAttachmentDeleteRequest request)
        => experienceattachment.Delete(request);

    [HttpPost]
    public ExperienceAttachmentListResponse List(ExperienceAttachmentListRequest request)
        => experienceattachment.List(request);
}
