namespace BSD.Shared.RequestDtos;

public class TransactionLogReadRequest : BaseRequest
{
    public long TransactionLogId { get; set; }
}