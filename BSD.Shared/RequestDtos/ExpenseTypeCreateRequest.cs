using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class ExpenseTypeCreateRequest : BaseRequest
{
    public ExpenseType ExpenseType { get; set; } = new ExpenseType();
}