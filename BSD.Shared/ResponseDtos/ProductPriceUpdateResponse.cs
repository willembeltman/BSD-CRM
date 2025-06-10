using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class ProductPriceUpdateResponse : BaseResponse
{
    public ProductPrice? ProductPrice { get; set; }
}