using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class UpdateProductResponse : BaseResponse
{
    public Product? Product { get; set; }
}