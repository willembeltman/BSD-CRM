using BeltmanSoftwareDesign.Shared.Dtos;

namespace BeltmanSoftwareDesign.Shared.Responses
{
    public class InvoiceCreateResponse : Response
    {
        public Invoice? Invoice { get; set; }
    }
}
