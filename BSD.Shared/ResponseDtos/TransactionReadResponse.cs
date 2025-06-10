using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class TransactionReadResponse : BaseResponse
{
    public Transaction? Transaction { get; set; }
}