namespace BSD.Shared.RequestDtos;

public class ExpenseDeleteRequest : BaseRequest
{
    public long ExpenseId { get; set; }
}