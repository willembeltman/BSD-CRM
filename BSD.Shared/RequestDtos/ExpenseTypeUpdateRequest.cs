using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class ExpenseTypeUpdateRequest : BaseRequest
{
    public ExpenseType ExpenseType { get; set; } = new ExpenseType();
}