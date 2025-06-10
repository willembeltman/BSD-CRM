using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class UpdateInvoiceProductResponse : BaseResponse
{
    public InvoiceProduct? InvoiceProduct { get; set; }
}