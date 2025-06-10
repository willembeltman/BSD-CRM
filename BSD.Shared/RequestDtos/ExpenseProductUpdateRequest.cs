using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class ExpenseProductUpdateRequest : BaseRequest
{
    public ExpenseProduct ExpenseProduct { get; set; } = new ExpenseProduct();
}