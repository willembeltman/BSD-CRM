using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class TransactionCreateResponse : BaseResponse
{
    public Transaction? Transaction { get; set; }
}