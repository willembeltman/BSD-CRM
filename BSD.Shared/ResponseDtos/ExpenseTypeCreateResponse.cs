using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class ExpenseTypeCreateResponse : BaseResponse
{
    public ExpenseType? ExpenseType { get; set; }
}