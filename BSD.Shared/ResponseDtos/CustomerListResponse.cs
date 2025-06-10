using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class CustomerListResponse : BaseResponse
{
    public Customer[] Customers { get; set; } = [];
}