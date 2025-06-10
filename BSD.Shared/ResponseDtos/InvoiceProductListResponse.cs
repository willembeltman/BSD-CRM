using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class InvoiceProductListResponse : BaseResponse
{
    public InvoiceProduct[] InvoiceProducts { get; set; } = [];
}