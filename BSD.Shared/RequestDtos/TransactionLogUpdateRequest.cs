using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class TransactionLogUpdateRequest : BaseRequest
{
    public TransactionLog TransactionLog { get; set; } = new TransactionLog();
}