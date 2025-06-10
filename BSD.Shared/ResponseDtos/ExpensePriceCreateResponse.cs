using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class ExpensePriceCreateResponse : BaseResponse
{
    public ExpensePrice? ExpensePrice { get; set; }
}