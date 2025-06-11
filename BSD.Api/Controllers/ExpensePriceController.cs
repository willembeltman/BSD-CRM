using BSD.Business.Interfaces;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using Microsoft.AspNetCore.Mvc;

namespace BSD.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ExpensePriceController(IExpensePriceService expenseprice) : ControllerBase
{
    [HttpPost]
    public ExpensePriceCreateResponse Create(ExpensePriceCreateRequest request)
        => expenseprice.Create(request);

    [HttpPost]
    public ExpensePriceReadResponse Read(ExpensePriceReadRequest request)
        => expenseprice.Read(request);

    [HttpPost]
    public ExpensePriceUpdateResponse Update(ExpensePriceUpdateRequest request)
        => expenseprice.Update(request);

    [HttpPost]
    public ExpensePriceDeleteResponse Delete(ExpensePriceDeleteRequest request)
        => expenseprice.Delete(request);

    [HttpPost]
    public ExpensePriceListResponse List(ExpensePriceListRequest request)
        => expenseprice.List(request);
}
