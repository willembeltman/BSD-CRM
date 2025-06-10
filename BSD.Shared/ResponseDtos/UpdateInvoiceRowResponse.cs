using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class UpdateInvoiceRowResponse : BaseResponse
{
    public InvoiceRow? InvoiceRow { get; set; }
}