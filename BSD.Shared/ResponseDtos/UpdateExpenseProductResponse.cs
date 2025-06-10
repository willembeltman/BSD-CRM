using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class UpdateExpenseProductResponse : BaseResponse
{
    public ExpenseProduct? ExpenseProduct { get; set; }
}