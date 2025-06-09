using Microsoft.AspNetCore.Mvc;
using BeltmanSoftwareDesign.Shared.Interfaces;
using BeltmanSoftwareDesign.Business.Interfaces;
using BeltmanSoftwareDesign.Shared.Requests;
using BeltmanSoftwareDesign.Shared.Responses;

namespace BeltmanSoftwareDesign.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class InvoiceController(IInvoice Invoice) : BaseControllerBase
{
    [HttpPost]
    public InvoiceCreateResponse Create(InvoiceCreateRequest request) 
        => Invoice.Create(request);

    [HttpPost]
    public InvoiceReadResponse Read(InvoiceReadRequest request) 
        => Invoice.Read(request);

    [HttpPost]
    public InvoiceUpdateResponse Update(InvoiceUpdateRequest request) 
        => Invoice.Update(request);

    [HttpPost]
    public InvoiceDeleteResponse Delete(InvoiceDeleteRequest request) 
        => Invoice.Delete(request);

    [HttpPost]
    public InvoiceListResponse List(InvoiceListRequest request) 
        => Invoice.List(request);
}
