using BSD.Business.CrudInterfaces;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using Microsoft.AspNetCore.Mvc;

namespace BSD.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class InvoiceEmailController(IInvoiceEmailService invoiceemail) : ControllerBase
{
    [HttpPost]
    public InvoiceEmailCreateResponse Create(InvoiceEmailCreateRequest request)
        => invoiceemail.Create(request);

    [HttpPost]
    public InvoiceEmailReadResponse Read(InvoiceEmailReadRequest request)
        => invoiceemail.Read(request);

    [HttpPost]
    public InvoiceEmailUpdateResponse Update(InvoiceEmailUpdateRequest request)
        => invoiceemail.Update(request);

    [HttpPost]
    public InvoiceEmailDeleteResponse Delete(InvoiceEmailDeleteRequest request)
        => invoiceemail.Delete(request);

    [HttpPost]
    public InvoiceEmailListResponse List(InvoiceEmailListRequest request)
        => invoiceemail.List(request);
}
