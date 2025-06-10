using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class CustomerUpdateRequest : BaseRequest
{
    public Customer Customer { get; set; } = new Customer();
}
