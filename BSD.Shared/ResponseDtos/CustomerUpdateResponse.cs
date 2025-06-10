using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class CustomerUpdateResponse : BaseResponse
{
    public Customer? Customer { get; set; }
}