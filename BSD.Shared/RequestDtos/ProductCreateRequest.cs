using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class ProductCreateRequest : BaseRequest
{
    public Product Product { get; set; } = new Product();
}