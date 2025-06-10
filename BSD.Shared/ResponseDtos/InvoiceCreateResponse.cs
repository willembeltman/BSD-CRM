using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos
{
    public class InvoiceCreateResponse : BaseResponse
    {
        public Invoice? Invoice { get; set; }
    }
}
