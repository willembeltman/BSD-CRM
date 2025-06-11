using Microsoft.AspNetCore.Mvc;
using BSD.Business.Interfaces;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class BankStatementExpenseController(IBankStatementExpenseService bankstatementexpense) : ControllerBase
{
    [HttpPost]
    public BankStatementExpenseCreateResponse Create(BankStatementExpenseCreateRequest request) 
        => bankstatementexpense.Create(request);

    [HttpPost]
    public BankStatementExpenseReadResponse Read(BankStatementExpenseReadRequest request) 
        => bankstatementexpense.Read(request);

    [HttpPost]
    public BankStatementExpenseUpdateResponse Update(BankStatementExpenseUpdateRequest request) 
        => bankstatementexpense.Update(request);

    [HttpPost]
    public BankStatementExpenseDeleteResponse Delete(BankStatementExpenseDeleteRequest request) 
        => bankstatementexpense.Delete(request);

    [HttpPost]
    public BankStatementExpenseListResponse List(BankStatementExpenseListRequest request) 
        => bankstatementexpense.List(request);
}
