using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class ExpenseTypeReadResponse : BaseResponse
{
    public ExpenseType? ExpenseType { get; set; }
}