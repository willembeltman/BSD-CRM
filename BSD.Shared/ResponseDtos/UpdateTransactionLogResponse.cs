using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class UpdateTransactionLogResponse : BaseResponse
{
    public TransactionLog? TransactionLog { get; set; }
}