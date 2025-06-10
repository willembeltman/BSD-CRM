using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Business.Interfaces;

public interface ITransactionParameterService
{
    TransactionParameterCreateResponse Create(TransactionParameterCreateRequest request);
    TransactionParameterDeleteResponse Delete(TransactionParameterDeleteRequest request);
    TransactionParameterListResponse List(TransactionParameterListRequest request);
    TransactionParameterReadResponse Read(TransactionParameterReadRequest request);
    TransactionParameterUpdateResponse Update(TransactionParameterUpdateRequest request);
}