using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class UpdateExpensePriceResponse : BaseResponse
{
    public ExpensePrice? ExpensePrice { get; set; }
}