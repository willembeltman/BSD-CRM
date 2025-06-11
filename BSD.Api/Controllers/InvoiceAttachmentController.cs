using Microsoft.AspNetCore.Mvc;
using BSD.Business.Interfaces;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class InvoiceAttachmentController(IInvoiceAttachmentService invoiceattachment) : ControllerBase
{
    [HttpPost]
    public InvoiceAttachmentCreateResponse Create(InvoiceAttachmentCreateRequest request) 
        => invoiceattachment.Create(request);

    [HttpPost]
    public InvoiceAttachmentReadResponse Read(InvoiceAttachmentReadRequest request) 
        => invoiceattachment.Read(request);

    [HttpPost]
    public InvoiceAttachmentUpdateResponse Update(InvoiceAttachmentUpdateRequest request) 
        => invoiceattachment.Update(request);

    [HttpPost]
    public InvoiceAttachmentDeleteResponse Delete(InvoiceAttachmentDeleteRequest request) 
        => invoiceattachment.Delete(request);

    [HttpPost]
    public InvoiceAttachmentListResponse List(InvoiceAttachmentListRequest request) 
        => invoiceattachment.List(request);
}
