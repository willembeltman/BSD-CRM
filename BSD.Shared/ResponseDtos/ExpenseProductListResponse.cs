using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class ExpenseProductListResponse : BaseResponse
{
    public ExpenseProduct[] ExpenseProducts { get; set; } = [];
}