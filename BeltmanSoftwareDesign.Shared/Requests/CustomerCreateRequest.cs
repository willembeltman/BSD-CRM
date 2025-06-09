using BeltmanSoftwareDesign.Shared.Dtos;

namespace BeltmanSoftwareDesign.Shared.Requests;

public class CustomerCreateRequest : Request
{
    public Customer Customer { get; set; } = new Customer();
}
