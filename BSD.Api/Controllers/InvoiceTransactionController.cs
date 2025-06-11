using BSD.Business.CrudInterfaces;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using Microsoft.AspNetCore.Mvc;

namespace BSD.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class InvoiceTransactionController(IInvoiceTransactionService invoicetransaction) : ControllerBase
{
    [HttpPost]
    public InvoiceTransactionCreateResponse Create(InvoiceTransactionCreateRequest request)
        => invoicetransaction.Create(request);

    [HttpPost]
    public InvoiceTransactionReadResponse Read(InvoiceTransactionReadRequest request)
        => invoicetransaction.Read(request);

    [HttpPost]
    public InvoiceTransactionUpdateResponse Update(InvoiceTransactionUpdateRequest request)
        => invoicetransaction.Update(request);

    [HttpPost]
    public InvoiceTransactionDeleteResponse Delete(InvoiceTransactionDeleteRequest request)
        => invoicetransaction.Delete(request);

    [HttpPost]
    public InvoiceTransactionListResponse List(InvoiceTransactionListRequest request)
        => invoicetransaction.List(request);
}
