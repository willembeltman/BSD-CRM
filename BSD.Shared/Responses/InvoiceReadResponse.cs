using BSD.Shared.Dtos;

namespace BSD.Shared.Responses
{
    public class InvoiceReadResponse : Response
    {
        public Invoice? Invoice { get; set; }
    }
}
