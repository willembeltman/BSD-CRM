using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class InvoicePriceListResponse : BaseResponse
{
    public InvoicePrice[] InvoicePrices { get; set; } = [];
}