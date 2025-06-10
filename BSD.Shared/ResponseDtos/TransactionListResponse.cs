using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class TransactionListResponse : BaseResponse
{
    public Transaction[] Transactions { get; set; } = [];
}