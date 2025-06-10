using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class SupplierReadResponse : BaseResponse
{
    public Supplier? Supplier { get; set; }
}