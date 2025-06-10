using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class ProductUpdateResponse : BaseResponse
{
    public Product? Product { get; set; }
}