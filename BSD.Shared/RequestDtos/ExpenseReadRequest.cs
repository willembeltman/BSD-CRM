namespace BSD.Shared.RequestDtos;

public class ExpenseReadRequest : BaseRequest
{
    public long ExpenseId { get; set; }
}