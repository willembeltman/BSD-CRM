using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class ExpensePriceReadResponse : BaseResponse
{
    public ExpensePrice? ExpensePrice { get; set; }
}