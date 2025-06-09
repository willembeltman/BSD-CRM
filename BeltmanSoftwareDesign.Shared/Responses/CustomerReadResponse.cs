using BeltmanSoftwareDesign.Shared.Dtos;

namespace BeltmanSoftwareDesign.Shared.Responses
{
    public class CustomerReadResponse : Response
    {
        public Customer? Customer { get; set; }
    }
}
