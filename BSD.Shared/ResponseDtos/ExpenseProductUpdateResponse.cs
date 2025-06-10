using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class ExpenseProductUpdateResponse : BaseResponse
{
    public ExpenseProduct? ExpenseProduct { get; set; }
}