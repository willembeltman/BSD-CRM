using BSD.Business.CrudInterfaces;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using Microsoft.AspNetCore.Mvc;

namespace BSD.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class InvoiceProductController(IInvoiceProductService invoiceproduct) : ControllerBase
{
    [HttpPost]
    public InvoiceProductCreateResponse Create(InvoiceProductCreateRequest request)
        => invoiceproduct.Create(request);

    [HttpPost]
    public InvoiceProductReadResponse Read(InvoiceProductReadRequest request)
        => invoiceproduct.Read(request);

    [HttpPost]
    public InvoiceProductUpdateResponse Update(InvoiceProductUpdateRequest request)
        => invoiceproduct.Update(request);

    [HttpPost]
    public InvoiceProductDeleteResponse Delete(InvoiceProductDeleteRequest request)
        => invoiceproduct.Delete(request);

    [HttpPost]
    public InvoiceProductListResponse List(InvoiceProductListRequest request)
        => invoiceproduct.List(request);
}
