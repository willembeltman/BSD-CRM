using BSD.Business.Interfaces;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using Microsoft.AspNetCore.Mvc;

namespace BSD.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class InvoiceRowController(IInvoiceRowService invoicerow) : ControllerBase
{
    [HttpPost]
    public InvoiceRowCreateResponse Create(InvoiceRowCreateRequest request)
        => invoicerow.Create(request);

    [HttpPost]
    public InvoiceRowReadResponse Read(InvoiceRowReadRequest request)
        => invoicerow.Read(request);

    [HttpPost]
    public InvoiceRowUpdateResponse Update(InvoiceRowUpdateRequest request)
        => invoicerow.Update(request);

    [HttpPost]
    public InvoiceRowDeleteResponse Delete(InvoiceRowDeleteRequest request)
        => invoicerow.Delete(request);

    [HttpPost]
    public InvoiceRowListResponse List(InvoiceRowListRequest request)
        => invoicerow.List(request);
}
