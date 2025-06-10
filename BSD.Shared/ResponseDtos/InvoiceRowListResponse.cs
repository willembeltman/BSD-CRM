using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class InvoiceRowListResponse : BaseResponse
{
    public InvoiceRow[] InvoiceRows { get; set; } = [];
}