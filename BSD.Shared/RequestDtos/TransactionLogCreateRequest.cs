using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class TransactionLogCreateRequest : BaseRequest
{
    public TransactionLog TransactionLog { get; set; } = new TransactionLog();
}