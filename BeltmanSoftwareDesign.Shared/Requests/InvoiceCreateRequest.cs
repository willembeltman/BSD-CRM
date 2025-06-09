using BeltmanSoftwareDesign.Shared.Dtos;

namespace BeltmanSoftwareDesign.Shared.Requests;

public class InvoiceCreateRequest : Request
{
    public Invoice Invoice { get; set; } = new Invoice();
}
