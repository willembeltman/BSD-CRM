using BSD.Business.CrudInterfaces;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using Microsoft.AspNetCore.Mvc;

namespace BSD.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class TransactionController(ITransactionService transaction) : ControllerBase
{
    [HttpPost]
    public TransactionCreateResponse Create(TransactionCreateRequest request)
        => transaction.Create(request);

    [HttpPost]
    public TransactionReadResponse Read(TransactionReadRequest request)
        => transaction.Read(request);

    [HttpPost]
    public TransactionUpdateResponse Update(TransactionUpdateRequest request)
        => transaction.Update(request);

    [HttpPost]
    public TransactionDeleteResponse Delete(TransactionDeleteRequest request)
        => transaction.Delete(request);

    [HttpPost]
    public TransactionListResponse List(TransactionListRequest request)
        => transaction.List(request);
}
