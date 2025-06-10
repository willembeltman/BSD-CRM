using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class ProductPriceUpdateRequest : BaseRequest
{
    public ProductPrice ProductPrice { get; set; } = new ProductPrice();
}