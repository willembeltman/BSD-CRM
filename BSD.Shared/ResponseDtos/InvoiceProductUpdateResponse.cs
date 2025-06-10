using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class InvoiceProductUpdateResponse : BaseResponse
{
    public InvoiceProduct? InvoiceProduct { get; set; }
}