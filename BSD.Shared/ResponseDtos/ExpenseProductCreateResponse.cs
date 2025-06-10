using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class ExpenseProductCreateResponse : BaseResponse
{
    public ExpenseProduct? ExpenseProduct { get; set; }
}