using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class TransactionLogReadResponse : BaseResponse
{
    public TransactionLog? TransactionLog { get; set; }
}