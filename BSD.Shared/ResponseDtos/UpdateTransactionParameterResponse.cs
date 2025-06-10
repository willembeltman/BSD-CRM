using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class UpdateTransactionParameterResponse : BaseResponse
{
    public TransactionParameter? TransactionParameter { get; set; }
}