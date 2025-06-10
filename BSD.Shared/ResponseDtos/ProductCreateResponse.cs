using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class ProductCreateResponse : BaseResponse
{
    public Product? Product { get; set; }
}