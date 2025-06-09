using BeltmanSoftwareDesign.Shared.Interfaces;
using BeltmanSoftwareDesign.Shared.RequestJsons;
using BeltmanSoftwareDesign.Shared.ResponseJsons;
using Microsoft.AspNetCore.Mvc;

namespace BeltmanSoftwareDesign.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class InvoiceController(IInvoiceService InvoiceService) : BaseControllerBase
{
    [HttpPost]
    public InvoiceCreateResponse Create(InvoiceCreateRequest request)
        => InvoiceService.Create(request);

    [HttpPost]
    public InvoiceReadResponse Read(InvoiceReadRequest request)
        => InvoiceService.Read(request);

    [HttpPost]
    public InvoiceUpdateResponse Update(InvoiceUpdateRequest request)
        => InvoiceService.Update(request);

    [HttpPost]
    public InvoiceDeleteResponse Delete(InvoiceDeleteRequest request)
        => InvoiceService.Delete(request);

    [HttpPost]
    public InvoiceListResponse List(InvoiceListRequest request)
        => InvoiceService.List(request);
}
