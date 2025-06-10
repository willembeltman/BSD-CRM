using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class TransactionParameterReadResponse : BaseResponse
{
    public TransactionParameter? TransactionParameter { get; set; }
}