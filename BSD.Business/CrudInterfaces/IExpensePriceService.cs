using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Business.CrudInterfaces;

public interface IExpensePriceService
{
    ExpensePriceCreateResponse Create(ExpensePriceCreateRequest request);
    ExpensePriceDeleteResponse Delete(ExpensePriceDeleteRequest request);
    ExpensePriceListResponse List(ExpensePriceListRequest request);
    ExpensePriceReadResponse Read(ExpensePriceReadRequest request);
    ExpensePriceUpdateResponse Update(ExpensePriceUpdateRequest request);
}