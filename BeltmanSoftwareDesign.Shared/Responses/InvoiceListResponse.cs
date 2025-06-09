using BeltmanSoftwareDesign.Shared.Dtos;

namespace BeltmanSoftwareDesign.Shared.Responses
{
    public class InvoiceListResponse : Response
    {
        public Invoice[] Invoices { get; set; } = [];
    }
}
