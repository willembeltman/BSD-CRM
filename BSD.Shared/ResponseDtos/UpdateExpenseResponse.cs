using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class UpdateExpenseResponse : BaseResponse
{
    public Expense? Expense { get; set; }
}