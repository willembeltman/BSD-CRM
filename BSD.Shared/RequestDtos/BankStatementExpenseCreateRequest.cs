using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class BankStatementExpenseCreateRequest : BaseRequest
{
    public BankStatementExpense BankStatementExpense { get; set; } = new BankStatementExpense();
}