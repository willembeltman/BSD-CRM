using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class SupplierListResponse : BaseResponse
{
    public Supplier[] Suppliers { get; set; } = [];
}