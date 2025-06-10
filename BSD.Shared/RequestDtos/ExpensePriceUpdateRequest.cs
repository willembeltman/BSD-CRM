using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class ExpensePriceUpdateRequest : BaseRequest
{
    public ExpensePrice ExpensePrice { get; set; } = new ExpensePrice();
}