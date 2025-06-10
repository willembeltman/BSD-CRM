using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class TransactionParameterUpdateRequest : BaseRequest
{
    public TransactionParameter TransactionParameter { get; set; } = new TransactionParameter();
}