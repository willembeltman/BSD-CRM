using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class TransactionUpdateRequest : BaseRequest
{
    public Transaction Transaction { get; set; } = new Transaction();
}