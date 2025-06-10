using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class InvoiceProductCreateResponse : BaseResponse
{
    public InvoiceProduct? InvoiceProduct { get; set; }
}