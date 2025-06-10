namespace BSD.Shared.RequestDtos;

public class BankStatementExpenseDeleteRequest : BaseRequest
{
    public long BankStatementExpenseId { get; set; }
}