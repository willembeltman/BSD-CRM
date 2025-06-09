using BSD.Shared.Dtos;

namespace BSD.Shared.Responses
{
    public class CustomerUpdateResponse : Response
    {
        public Customer? Customer { get; set; }
    }
}
