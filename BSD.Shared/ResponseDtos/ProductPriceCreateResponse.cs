using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class ProductPriceCreateResponse : BaseResponse
{
    public ProductPrice? ProductPrice { get; set; }
}