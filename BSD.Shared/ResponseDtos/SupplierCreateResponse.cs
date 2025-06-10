using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class SupplierCreateResponse : BaseResponse
{
    public Supplier? Supplier { get; set; }
}