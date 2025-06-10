using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class ExpenseProductReadResponse : BaseResponse
{
    public ExpenseProduct? ExpenseProduct { get; set; }
}