using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class CustomerCreateResponse : BaseResponse
{
    public Customer? Customer { get; set; }
}