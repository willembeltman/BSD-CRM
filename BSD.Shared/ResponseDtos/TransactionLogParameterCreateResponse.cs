using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class TransactionLogParameterCreateResponse : BaseResponse
{
    public TransactionLogParameter? TransactionLogParameter { get; set; }
}