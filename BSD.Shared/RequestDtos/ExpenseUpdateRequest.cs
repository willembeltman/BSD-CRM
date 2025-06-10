using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class ExpenseUpdateRequest : BaseRequest
{
    public Expense Expense { get; set; } = new Expense();
}