using BSD.Shared.Dtos;

namespace BSD.Shared.Responses
{
    public class InvoiceCreateResponse : Response
    {
        public Invoice? Invoice { get; set; }
    }
}
