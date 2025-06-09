using BSD.Shared.Dtos;

namespace BSD.Shared.Requests;

public class CustomerUpdateRequest : Request
{
    public Customer Customer { get; set; } = new Customer();
}
