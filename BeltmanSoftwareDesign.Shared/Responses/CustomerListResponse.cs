using BeltmanSoftwareDesign.Shared.Dtos;

namespace BeltmanSoftwareDesign.Shared.Responses
{
    public class CustomerListResponse : Response
    {
        public Customer[] Customers { get; set; } = [];
    }
}
