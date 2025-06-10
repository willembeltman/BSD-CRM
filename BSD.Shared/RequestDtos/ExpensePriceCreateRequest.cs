using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class ExpensePriceCreateRequest : BaseRequest
{
    public ExpensePrice ExpensePrice { get; set; } = new ExpensePrice();
}