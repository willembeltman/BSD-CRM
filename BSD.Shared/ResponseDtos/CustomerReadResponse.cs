using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos
{
    public class CustomerReadResponse : BaseResponse
    {
        public Customer? Customer { get; set; }
    }
}
