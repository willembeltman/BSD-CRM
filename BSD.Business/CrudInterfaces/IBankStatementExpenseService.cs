using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Business.CrudInterfaces;

public interface IBankStatementExpenseService
{
    BankStatementExpenseCreateResponse Create(BankStatementExpenseCreateRequest request);
    BankStatementExpenseDeleteResponse Delete(BankStatementExpenseDeleteRequest request);
    BankStatementExpenseListResponse List(BankStatementExpenseListRequest request);
    BankStatementExpenseReadResponse Read(BankStatementExpenseReadRequest request);
    BankStatementExpenseUpdateResponse Update(BankStatementExpenseUpdateRequest request);
}