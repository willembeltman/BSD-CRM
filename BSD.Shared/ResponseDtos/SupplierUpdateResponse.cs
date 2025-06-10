using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class SupplierUpdateResponse : BaseResponse
{
    public Supplier? Supplier { get; set; }
}