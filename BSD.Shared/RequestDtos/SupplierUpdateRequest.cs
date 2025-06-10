using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class SupplierUpdateRequest : BaseRequest
{
    public Supplier Supplier { get; set; } = new Supplier();
}