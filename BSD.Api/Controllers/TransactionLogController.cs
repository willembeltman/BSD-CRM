using BSD.Business.Interfaces;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using Microsoft.AspNetCore.Mvc;

namespace BSD.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class TransactionLogController(ITransactionLogService transactionlog) : ControllerBase
{
    [HttpPost]
    public TransactionLogCreateResponse Create(TransactionLogCreateRequest request)
        => transactionlog.Create(request);

    [HttpPost]
    public TransactionLogReadResponse Read(TransactionLogReadRequest request)
        => transactionlog.Read(request);

    [HttpPost]
    public TransactionLogUpdateResponse Update(TransactionLogUpdateRequest request)
        => transactionlog.Update(request);

    [HttpPost]
    public TransactionLogDeleteResponse Delete(TransactionLogDeleteRequest request)
        => transactionlog.Delete(request);

    [HttpPost]
    public TransactionLogListResponse List(TransactionLogListRequest request)
        => transactionlog.List(request);
}
