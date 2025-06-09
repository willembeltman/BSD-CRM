using BeltmanSoftwareDesign.Shared.Dtos;

namespace BeltmanSoftwareDesign.Shared.Requests;

public class InvoiceUpdateRequest : Request
{
    public Invoice Invoice { get; set; } = new Invoice();
}
