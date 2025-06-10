using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class CustomerCreateRequest : BaseRequest
{
    public Customer Customer { get; set; } = new Customer();
}