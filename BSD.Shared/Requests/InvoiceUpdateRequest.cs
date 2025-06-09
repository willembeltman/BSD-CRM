using BSD.Shared.Dtos;

namespace BSD.Shared.Requests;

public class InvoiceUpdateRequest : Request
{
    public Invoice Invoice { get; set; } = new Invoice();
}
