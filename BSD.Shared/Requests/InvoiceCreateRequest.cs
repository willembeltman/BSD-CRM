using BSD.Shared.Dtos;

namespace BSD.Shared.Requests;

public class InvoiceCreateRequest : Request
{
    public Invoice Invoice { get; set; } = new Invoice();
}
