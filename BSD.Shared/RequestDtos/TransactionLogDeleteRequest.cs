namespace BSD.Shared.RequestDtos;

public class TransactionLogDeleteRequest : BaseRequest
{
    public long TransactionLogId { get; set; }
}