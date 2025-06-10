using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Business.Interfaces;

public interface IExpensePriceService
{
    ExpensePriceCreateResponse Create(ExpensePriceCreateRequest request);
    ExpensePriceDeleteResponse Delete(ExpensePriceDeleteRequest request);
    ExpensePriceListResponse List(ExpensePriceListRequest request);
    ExpensePriceReadResponse Read(ExpensePriceReadRequest request);
    ExpensePriceUpdateResponse Update(ExpensePriceUpdateRequest request);
}