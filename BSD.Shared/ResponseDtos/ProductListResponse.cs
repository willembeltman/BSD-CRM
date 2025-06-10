using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class ProductListResponse : BaseResponse
{
    public Product[] Products { get; set; } = [];
}