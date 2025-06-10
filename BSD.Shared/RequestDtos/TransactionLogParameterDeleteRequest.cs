namespace BSD.Shared.RequestDtos;

public class TransactionLogParameterDeleteRequest : BaseRequest
{
    public long TransactionLogParameterId { get; set; }
}