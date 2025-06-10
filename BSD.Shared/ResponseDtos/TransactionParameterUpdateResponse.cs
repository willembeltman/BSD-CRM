using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class TransactionParameterUpdateResponse : BaseResponse
{
    public TransactionParameter? TransactionParameter { get; set; }
}