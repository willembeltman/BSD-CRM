using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class ProductUpdateRequest : BaseRequest
{
    public Product Product { get; set; } = new Product();
}