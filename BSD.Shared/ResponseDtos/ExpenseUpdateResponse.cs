using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class ExpenseUpdateResponse : BaseResponse
{
    public Expense? Expense { get; set; }
}