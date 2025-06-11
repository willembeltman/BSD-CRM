using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Business.CrudInterfaces;

public interface IExpenseService
{
    ExpenseCreateResponse Create(ExpenseCreateRequest request);
    ExpenseDeleteResponse Delete(ExpenseDeleteRequest request);
    ExpenseListResponse List(ExpenseListRequest request);
    ExpenseReadResponse Read(ExpenseReadRequest request);
    ExpenseUpdateResponse Update(ExpenseUpdateRequest request);
}