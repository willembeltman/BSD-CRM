using BSD.Business.Interfaces;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using Microsoft.AspNetCore.Mvc;

namespace BSD.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class BankStatementInvoiceController(IBankStatementInvoiceService bankstatementinvoice) : ControllerBase
{
    [HttpPost]
    public BankStatementInvoiceCreateResponse Create(BankStatementInvoiceCreateRequest request)
        => bankstatementinvoice.Create(request);

    [HttpPost]
    public BankStatementInvoiceReadResponse Read(BankStatementInvoiceReadRequest request)
        => bankstatementinvoice.Read(request);

    [HttpPost]
    public BankStatementInvoiceUpdateResponse Update(BankStatementInvoiceUpdateRequest request)
        => bankstatementinvoice.Update(request);

    [HttpPost]
    public BankStatementInvoiceDeleteResponse Delete(BankStatementInvoiceDeleteRequest request)
        => bankstatementinvoice.Delete(request);

    [HttpPost]
    public BankStatementInvoiceListResponse List(BankStatementInvoiceListRequest request)
        => bankstatementinvoice.List(request);
}
