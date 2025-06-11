using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Business.CrudInterfaces;

public interface IExpenseProductService
{
    ExpenseProductCreateResponse Create(ExpenseProductCreateRequest request);
    ExpenseProductDeleteResponse Delete(ExpenseProductDeleteRequest request);
    ExpenseProductListResponse List(ExpenseProductListRequest request);
    ExpenseProductReadResponse Read(ExpenseProductReadRequest request);
    ExpenseProductUpdateResponse Update(ExpenseProductUpdateRequest request);
}