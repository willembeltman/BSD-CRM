using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class ExpenseCreateRequest : BaseRequest
{
    public Expense Expense { get; set; } = new Expense();
}