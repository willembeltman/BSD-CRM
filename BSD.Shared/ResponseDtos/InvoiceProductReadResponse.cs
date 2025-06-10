using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class InvoiceProductReadResponse : BaseResponse
{
    public InvoiceProduct? InvoiceProduct { get; set; }
}