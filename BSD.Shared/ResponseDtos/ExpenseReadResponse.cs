using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class ExpenseReadResponse : BaseResponse
{
    public Expense? Expense { get; set; }
}