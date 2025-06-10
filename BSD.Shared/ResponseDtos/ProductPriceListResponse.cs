using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class ProductPriceListResponse : BaseResponse
{
    public ProductPrice[] ProductPrices { get; set; } = [];
}