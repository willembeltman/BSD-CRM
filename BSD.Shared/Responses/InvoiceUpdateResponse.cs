using BSD.Shared.Dtos;

namespace BSD.Shared.Responses
{
    public class InvoiceUpdateResponse : Response
    {
        public Invoice? Invoice { get; set; }
    }
}
