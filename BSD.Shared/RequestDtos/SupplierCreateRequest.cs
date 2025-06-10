using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class SupplierCreateRequest : BaseRequest
{
    public Supplier Supplier { get; set; } = new Supplier();
}