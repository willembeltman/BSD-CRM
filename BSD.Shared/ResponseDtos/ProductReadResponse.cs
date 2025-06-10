using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class ProductReadResponse : BaseResponse
{
    public Product? Product { get; set; }
}