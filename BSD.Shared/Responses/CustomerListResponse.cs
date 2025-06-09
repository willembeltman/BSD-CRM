using BSD.Shared.Dtos;

namespace BSD.Shared.Responses
{
    public class CustomerListResponse : Response
    {
        public Customer[] Customers { get; set; } = [];
    }
}
