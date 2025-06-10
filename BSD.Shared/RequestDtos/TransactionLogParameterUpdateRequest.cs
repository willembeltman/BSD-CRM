using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class TransactionLogParameterUpdateRequest : BaseRequest
{
    public TransactionLogParameter TransactionLogParameter { get; set; } = new TransactionLogParameter();
}