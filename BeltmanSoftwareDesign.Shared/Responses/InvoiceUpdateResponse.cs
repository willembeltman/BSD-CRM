using BeltmanSoftwareDesign.Shared.Dtos;

namespace BeltmanSoftwareDesign.Shared.Responses
{
    public class InvoiceUpdateResponse : Response
    {
        public Invoice? Invoice { get; set; }
    }
}
