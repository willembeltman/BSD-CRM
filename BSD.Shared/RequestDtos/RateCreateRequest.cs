using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class RateCreateRequest : BaseRequest
{
    public Rate Rate { get; set; } = new Rate();
}