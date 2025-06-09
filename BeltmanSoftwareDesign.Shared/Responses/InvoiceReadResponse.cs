using BeltmanSoftwareDesign.Shared.Dtos;

namespace BeltmanSoftwareDesign.Shared.Responses
{
    public class InvoiceReadResponse : Response
    {
        public Invoice? Invoice { get; set; }
    }
}
