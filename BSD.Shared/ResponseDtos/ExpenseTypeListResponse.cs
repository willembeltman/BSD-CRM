using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class ExpenseTypeListResponse : BaseResponse
{
    public ExpenseType[] ExpenseTypes { get; set; } = [];
}