using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class TransactionLogUpdateResponse : BaseResponse
{
    public TransactionLog? TransactionLog { get; set; }
}