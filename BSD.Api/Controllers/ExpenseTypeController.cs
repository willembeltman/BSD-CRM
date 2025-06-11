using BSD.Business.Interfaces;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using Microsoft.AspNetCore.Mvc;

namespace BSD.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ExpenseTypeController(IExpenseTypeService expensetype) : ControllerBase
{
    [HttpPost]
    public ExpenseTypeCreateResponse Create(ExpenseTypeCreateRequest request)
        => expensetype.Create(request);

    [HttpPost]
    public ExpenseTypeReadResponse Read(ExpenseTypeReadRequest request)
        => expensetype.Read(request);

    [HttpPost]
    public ExpenseTypeUpdateResponse Update(ExpenseTypeUpdateRequest request)
        => expensetype.Update(request);

    [HttpPost]
    public ExpenseTypeDeleteResponse Delete(ExpenseTypeDeleteRequest request)
        => expensetype.Delete(request);

    [HttpPost]
    public ExpenseTypeListResponse List(ExpenseTypeListRequest request)
        => expensetype.List(request);
}
