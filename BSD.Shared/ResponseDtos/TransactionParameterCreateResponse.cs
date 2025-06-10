using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class TransactionParameterCreateResponse : BaseResponse
{
    public TransactionParameter? TransactionParameter { get; set; }
}