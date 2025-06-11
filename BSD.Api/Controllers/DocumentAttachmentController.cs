using BSD.Business.Interfaces;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using Microsoft.AspNetCore.Mvc;

namespace BSD.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class DocumentAttachmentController(IDocumentAttachmentService documentattachment) : ControllerBase
{
    [HttpPost]
    public DocumentAttachmentCreateResponse Create(DocumentAttachmentCreateRequest request)
        => documentattachment.Create(request);

    [HttpPost]
    public DocumentAttachmentReadResponse Read(DocumentAttachmentReadRequest request)
        => documentattachment.Read(request);

    [HttpPost]
    public DocumentAttachmentUpdateResponse Update(DocumentAttachmentUpdateRequest request)
        => documentattachment.Update(request);

    [HttpPost]
    public DocumentAttachmentDeleteResponse Delete(DocumentAttachmentDeleteRequest request)
        => documentattachment.Delete(request);

    [HttpPost]
    public DocumentAttachmentListResponse List(DocumentAttachmentListRequest request)
        => documentattachment.List(request);
}
