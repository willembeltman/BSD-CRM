using BSD.Shared.Dtos;

namespace BSD.Shared.Requests;

public class CustomerCreateRequest : Request
{
    public Customer Customer { get; set; } = new Customer();
}
