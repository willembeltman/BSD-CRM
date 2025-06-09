using BSD.Shared.Dtos;

namespace BSD.Shared.Responses
{
    public class InvoiceListResponse : Response
    {
        public Invoice[] Invoices { get; set; } = [];
    }
}
