using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class TransactionLogParameterUpdateResponse : BaseResponse
{
    public TransactionLogParameter? TransactionLogParameter { get; set; }
}