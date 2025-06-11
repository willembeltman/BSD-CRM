using BSD.Business.Interfaces;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using Microsoft.AspNetCore.Mvc;

namespace BSD.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ExpenseController(IExpenseService expense) : ControllerBase
{
    [HttpPost]
    public ExpenseCreateResponse Create(ExpenseCreateRequest request)
        => expense.Create(request);

    [HttpPost]
    public ExpenseReadResponse Read(ExpenseReadRequest request)
        => expense.Read(request);

    [HttpPost]
    public ExpenseUpdateResponse Update(ExpenseUpdateRequest request)
        => expense.Update(request);

    [HttpPost]
    public ExpenseDeleteResponse Delete(ExpenseDeleteRequest request)
        => expense.Delete(request);

    [HttpPost]
    public ExpenseListResponse List(ExpenseListRequest request)
        => expense.List(request);
}
