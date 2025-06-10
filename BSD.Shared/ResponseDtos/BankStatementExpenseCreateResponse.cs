using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class BankStatementExpenseCreateResponse : BaseResponse
{
    public BankStatementExpense? BankStatementExpense { get; set; }
}