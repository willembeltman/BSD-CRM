using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class RateUpdateRequest : BaseRequest
{
    public Rate Rate { get; set; } = new Rate();
}