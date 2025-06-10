using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class UpdateProductPriceResponse : BaseResponse
{
    public ProductPrice? ProductPrice { get; set; }
}