using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class UpdateCustomerResponse : BaseResponse
{
    public Customer? Customer { get; set; }
}