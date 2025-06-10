using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class ProductPriceReadResponse : BaseResponse
{
    public ProductPrice? ProductPrice { get; set; }
}