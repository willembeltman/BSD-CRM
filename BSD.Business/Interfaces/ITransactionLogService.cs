using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Business.Interfaces;

public interface ITransactionLogService
{
    TransactionLogCreateResponse Create(TransactionLogCreateRequest request);
    TransactionLogDeleteResponse Delete(TransactionLogDeleteRequest request);
    TransactionLogListResponse List(TransactionLogListRequest request);
    TransactionLogReadResponse Read(TransactionLogReadRequest request);
    TransactionLogUpdateResponse Update(TransactionLogUpdateRequest request);
}