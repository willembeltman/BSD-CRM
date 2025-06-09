using Microsoft.AspNetCore.Mvc;
using BeltmanSoftwareDesign.Shared.Interfaces;
using BeltmanSoftwareDesign.Business.Interfaces;
using BeltmanSoftwareDesign.Shared.Requests;
using BeltmanSoftwareDesign.Shared.Responses;

namespace BeltmanSoftwareDesign.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class InvoiceController(IInvoiceService invoice) : ControllerBase
{
    [HttpPost]
    public InvoiceCreateResponse Create(InvoiceCreateRequest request) 
        => invoice.Create(request);

    [HttpPost]
    public InvoiceReadResponse Read(InvoiceReadRequest request) 
        => invoice.Read(request);

    [HttpPost]
    public InvoiceUpdateResponse Update(InvoiceUpdateRequest request) 
        => invoice.Update(request);

    [HttpPost]
    public InvoiceDeleteResponse Delete(InvoiceDeleteRequest request) 
        => invoice.Delete(request);

    [HttpPost]
    public InvoiceListResponse List(InvoiceListRequest request) 
        => invoice.List(request);
}
