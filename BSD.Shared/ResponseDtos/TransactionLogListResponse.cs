using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class TransactionLogListResponse : BaseResponse
{
    public TransactionLog[] TransactionLogs { get; set; } = [];
}