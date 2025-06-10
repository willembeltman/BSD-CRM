using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos
{
    public class InvoiceUpdateResponse : BaseResponse
    {
        public Invoice? Invoice { get; set; }
    }
}
