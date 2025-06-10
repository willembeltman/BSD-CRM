using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class ExpenseListResponse : BaseResponse
{
    public Expense[] Expenses { get; set; } = [];
}