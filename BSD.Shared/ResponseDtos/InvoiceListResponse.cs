using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos
{
    public class InvoiceListResponse : BaseResponse
    {
        public Invoice[] Invoices { get; set; } = [];
    }
}
