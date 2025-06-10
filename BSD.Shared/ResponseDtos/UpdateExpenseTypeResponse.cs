using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class UpdateExpenseTypeResponse : BaseResponse
{
    public ExpenseType? ExpenseType { get; set; }
}