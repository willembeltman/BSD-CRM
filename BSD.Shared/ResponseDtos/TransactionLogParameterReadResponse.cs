using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class TransactionLogParameterReadResponse : BaseResponse
{
    public TransactionLogParameter? TransactionLogParameter { get; set; }
}