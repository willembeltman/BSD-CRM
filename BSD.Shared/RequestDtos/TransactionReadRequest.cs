namespace BSD.Shared.RequestDtos;

public class TransactionReadRequest : BaseRequest
{
    public long TransactionId { get; set; }
}