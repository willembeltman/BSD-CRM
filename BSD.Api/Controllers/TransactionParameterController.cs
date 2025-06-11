using Microsoft.AspNetCore.Mvc;
using BSD.Business.Interfaces;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class TransactionParameterController(ITransactionParameterService transactionparameter) : ControllerBase
{
    [HttpPost]
    public TransactionParameterCreateResponse Create(TransactionParameterCreateRequest request) 
        => transactionparameter.Create(request);

    [HttpPost]
    public TransactionParameterReadResponse Read(TransactionParameterReadRequest request) 
        => transactionparameter.Read(request);

    [HttpPost]
    public TransactionParameterUpdateResponse Update(TransactionParameterUpdateRequest request) 
        => transactionparameter.Update(request);

    [HttpPost]
    public TransactionParameterDeleteResponse Delete(TransactionParameterDeleteRequest request) 
        => transactionparameter.Delete(request);

    [HttpPost]
    public TransactionParameterListResponse List(TransactionParameterListRequest request) 
        => transactionparameter.List(request);
}
