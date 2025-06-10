using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class TransactionLogParameterCreateRequest : BaseRequest
{
    public TransactionLogParameter TransactionLogParameter { get; set; } = new TransactionLogParameter();
}