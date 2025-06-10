using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class ExpensePriceUpdateResponse : BaseResponse
{
    public ExpensePrice? ExpensePrice { get; set; }
}