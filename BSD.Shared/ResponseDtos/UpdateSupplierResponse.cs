using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class UpdateSupplierResponse : BaseResponse
{
    public Supplier? Supplier { get; set; }
}