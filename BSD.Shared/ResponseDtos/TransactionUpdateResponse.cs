using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class TransactionUpdateResponse : BaseResponse
{
    public Transaction? Transaction { get; set; }
}