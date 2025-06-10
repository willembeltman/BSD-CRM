using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class UpdateTransactionResponse : BaseResponse
{
    public Transaction? Transaction { get; set; }
}