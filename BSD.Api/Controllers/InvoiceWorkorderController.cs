using Microsoft.AspNetCore.Mvc;
using BSD.Business.Interfaces;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class InvoiceWorkorderController(IInvoiceWorkorderService invoiceworkorder) : ControllerBase
{
    [HttpPost]
    public InvoiceWorkorderCreateResponse Create(InvoiceWorkorderCreateRequest request) 
        => invoiceworkorder.Create(request);

    [HttpPost]
    public InvoiceWorkorderReadResponse Read(InvoiceWorkorderReadRequest request) 
        => invoiceworkorder.Read(request);

    [HttpPost]
    public InvoiceWorkorderUpdateResponse Update(InvoiceWorkorderUpdateRequest request) 
        => invoiceworkorder.Update(request);

    [HttpPost]
    public InvoiceWorkorderDeleteResponse Delete(InvoiceWorkorderDeleteRequest request) 
        => invoiceworkorder.Delete(request);

    [HttpPost]
    public InvoiceWorkorderListResponse List(InvoiceWorkorderListRequest request) 
        => invoiceworkorder.List(request);
}
