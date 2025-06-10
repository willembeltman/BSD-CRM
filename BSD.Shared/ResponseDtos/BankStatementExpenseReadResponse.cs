using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class BankStatementExpenseReadResponse : BaseResponse
{
    public BankStatementExpense? BankStatementExpense { get; set; }
}