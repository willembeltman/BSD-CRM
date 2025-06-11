using BSD.Business.Interfaces;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using Microsoft.AspNetCore.Mvc;

namespace BSD.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ExpenseProductController(IExpenseProductService expenseproduct) : ControllerBase
{
    [HttpPost]
    public ExpenseProductCreateResponse Create(ExpenseProductCreateRequest request)
        => expenseproduct.Create(request);

    [HttpPost]
    public ExpenseProductReadResponse Read(ExpenseProductReadRequest request)
        => expenseproduct.Read(request);

    [HttpPost]
    public ExpenseProductUpdateResponse Update(ExpenseProductUpdateRequest request)
        => expenseproduct.Update(request);

    [HttpPost]
    public ExpenseProductDeleteResponse Delete(ExpenseProductDeleteRequest request)
        => expenseproduct.Delete(request);

    [HttpPost]
    public ExpenseProductListResponse List(ExpenseProductListRequest request)
        => expenseproduct.List(request);
}
