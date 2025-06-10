using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class BankStatementExpenseUpdateRequest : BaseRequest
{
    public BankStatementExpense BankStatementExpense { get; set; } = new BankStatementExpense();
}