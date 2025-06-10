using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class TransactionCreateRequest : BaseRequest
{
    public Transaction Transaction { get; set; } = new Transaction();
}