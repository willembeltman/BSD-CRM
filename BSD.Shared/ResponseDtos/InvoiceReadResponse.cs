using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos
{
    public class InvoiceReadResponse : BaseResponse
    {
        public Invoice? Invoice { get; set; }
    }
}
