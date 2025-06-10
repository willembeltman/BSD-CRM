using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class UpdateInvoiceResponse : BaseResponse
{
    public Invoice? Invoice { get; set; }
}