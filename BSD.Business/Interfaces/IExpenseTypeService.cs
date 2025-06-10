using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Business.Interfaces;

public interface IExpenseTypeService
{
    ExpenseTypeCreateResponse Create(ExpenseTypeCreateRequest request);
    ExpenseTypeDeleteResponse Delete(ExpenseTypeDeleteRequest request);
    ExpenseTypeListResponse List(ExpenseTypeListRequest request);
    ExpenseTypeReadResponse Read(ExpenseTypeReadRequest request);
    ExpenseTypeUpdateResponse Update(ExpenseTypeUpdateRequest request);
}