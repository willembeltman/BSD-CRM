using Microsoft.AspNetCore.Mvc;
using BSD.Business.Interfaces;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class TransactionLogParameterController(ITransactionLogParameterService transactionlogparameter) : ControllerBase
{
    [HttpPost]
    public TransactionLogParameterCreateResponse Create(TransactionLogParameterCreateRequest request) 
        => transactionlogparameter.Create(request);

    [HttpPost]
    public TransactionLogParameterReadResponse Read(TransactionLogParameterReadRequest request) 
        => transactionlogparameter.Read(request);

    [HttpPost]
    public TransactionLogParameterUpdateResponse Update(TransactionLogParameterUpdateRequest request) 
        => transactionlogparameter.Update(request);

    [HttpPost]
    public TransactionLogParameterDeleteResponse Delete(TransactionLogParameterDeleteRequest request) 
        => transactionlogparameter.Delete(request);

    [HttpPost]
    public TransactionLogParameterListResponse List(TransactionLogParameterListRequest request) 
        => transactionlogparameter.List(request);
}
