using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class ExpensePriceListResponse : BaseResponse
{
    public ExpensePrice[] ExpensePrices { get; set; } = [];
}