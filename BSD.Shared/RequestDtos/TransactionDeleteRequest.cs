namespace BSD.Shared.RequestDtos;

public class TransactionDeleteRequest : BaseRequest
{
    public long TransactionId { get; set; }
}