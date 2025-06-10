using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class InvoiceRowUpdateResponse : BaseResponse
{
    public InvoiceRow? InvoiceRow { get; set; }
}