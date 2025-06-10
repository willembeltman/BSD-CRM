using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class BankStatementExpenseUpdateResponse : BaseResponse
{
    public BankStatementExpense? BankStatementExpense { get; set; }
}