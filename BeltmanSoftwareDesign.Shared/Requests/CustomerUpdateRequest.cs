using BeltmanSoftwareDesign.Shared.Dtos;

namespace BeltmanSoftwareDesign.Shared.Requests;

public class CustomerUpdateRequest : Request
{
    public Customer Customer { get; set; } = new Customer();
}
