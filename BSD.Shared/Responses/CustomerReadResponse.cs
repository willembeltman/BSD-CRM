using BSD.Shared.Dtos;

namespace BSD.Shared.Responses
{
    public class CustomerReadResponse : Response
    {
        public Customer? Customer { get; set; }
    }
}
