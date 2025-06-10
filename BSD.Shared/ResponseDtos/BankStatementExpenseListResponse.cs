using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class BankStatementExpenseListResponse : BaseResponse
{
    public BankStatementExpense[] BankStatementExpenses { get; set; } = [];
}