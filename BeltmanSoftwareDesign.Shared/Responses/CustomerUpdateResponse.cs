using BeltmanSoftwareDesign.Shared.Dtos;

namespace BeltmanSoftwareDesign.Shared.Responses
{
    public class CustomerUpdateResponse : Response
    {
        public Customer? Customer { get; set; }
    }
}
