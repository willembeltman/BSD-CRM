using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class TransactionLogCreateResponse : BaseResponse
{
    public TransactionLog? TransactionLog { get; set; }
}