using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class ExpenseCreateResponse : BaseResponse
{
    public Expense? Expense { get; set; }
}