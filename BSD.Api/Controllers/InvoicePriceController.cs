using BSD.Business.CrudInterfaces;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using Microsoft.AspNetCore.Mvc;

namespace BSD.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class InvoicePriceController(IInvoicePriceService invoiceprice) : ControllerBase
{
    [HttpPost]
    public InvoicePriceCreateResponse Create(InvoicePriceCreateRequest request)
        => invoiceprice.Create(request);

    [HttpPost]
    public InvoicePriceReadResponse Read(InvoicePriceReadRequest request)
        => invoiceprice.Read(request);

    [HttpPost]
    public InvoicePriceUpdateResponse Update(InvoicePriceUpdateRequest request)
        => invoiceprice.Update(request);

    [HttpPost]
    public InvoicePriceDeleteResponse Delete(InvoicePriceDeleteRequest request)
        => invoiceprice.Delete(request);

    [HttpPost]
    public InvoicePriceListResponse List(InvoicePriceListRequest request)
        => invoiceprice.List(request);
}
