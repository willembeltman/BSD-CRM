using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class TransactionParameterCreateRequest : BaseRequest
{
    public TransactionParameter TransactionParameter { get; set; } = new TransactionParameter();
}