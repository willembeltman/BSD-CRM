using BSD.Business.CrudInterfaces;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using Microsoft.AspNetCore.Mvc;

namespace BSD.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class InvoiceTypeController(IInvoiceTypeService invoicetype) : ControllerBase
{
    [HttpPost]
    public InvoiceTypeCreateResponse Create(InvoiceTypeCreateRequest request)
        => invoicetype.Create(request);

    [HttpPost]
    public InvoiceTypeReadResponse Read(InvoiceTypeReadRequest request)
        => invoicetype.Read(request);

    [HttpPost]
    public InvoiceTypeUpdateResponse Update(InvoiceTypeUpdateRequest request)
        => invoicetype.Update(request);

    [HttpPost]
    public InvoiceTypeDeleteResponse Delete(InvoiceTypeDeleteRequest request)
        => invoicetype.Delete(request);

    [HttpPost]
    public InvoiceTypeListResponse List(InvoiceTypeListRequest request)
        => invoicetype.List(request);
}
