using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class ExpenseTypeUpdateResponse : BaseResponse
{
    public ExpenseType? ExpenseType { get; set; }
}