using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class ExpenseProductCreateRequest : BaseRequest
{
    public ExpenseProduct ExpenseProduct { get; set; } = new ExpenseProduct();
}