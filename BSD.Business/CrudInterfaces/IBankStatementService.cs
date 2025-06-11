using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Business.CrudInterfaces;

public interface IBankStatementService
{
    BankStatementCreateResponse Create(BankStatementCreateRequest request);
    BankStatementDeleteResponse Delete(BankStatementDeleteRequest request);
    BankStatementListResponse List(BankStatementListRequest request);
    BankStatementReadResponse Read(BankStatementReadRequest request);
    BankStatementUpdateResponse Update(BankStatementUpdateRequest request);
}