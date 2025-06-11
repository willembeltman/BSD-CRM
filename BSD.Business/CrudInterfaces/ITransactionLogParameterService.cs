using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Business.CrudInterfaces;

public interface ITransactionLogParameterService
{
    TransactionLogParameterCreateResponse Create(TransactionLogParameterCreateRequest request);
    TransactionLogParameterDeleteResponse Delete(TransactionLogParameterDeleteRequest request);
    TransactionLogParameterListResponse List(TransactionLogParameterListRequest request);
    TransactionLogParameterReadResponse Read(TransactionLogParameterReadRequest request);
    TransactionLogParameterUpdateResponse Update(TransactionLogParameterUpdateRequest request);
}