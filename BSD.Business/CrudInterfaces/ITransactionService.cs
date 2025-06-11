using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Business.CrudInterfaces;

public interface ITransactionService
{
    TransactionCreateResponse Create(TransactionCreateRequest request);
    TransactionDeleteResponse Delete(TransactionDeleteRequest request);
    TransactionListResponse List(TransactionListRequest request);
    TransactionReadResponse Read(TransactionReadRequest request);
    TransactionUpdateResponse Update(TransactionUpdateRequest request);
}