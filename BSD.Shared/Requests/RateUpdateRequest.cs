using BSD.Shared.Dtos;

namespace BSD.Shared.Requests;

public class RateUpdateRequest : Request
{
    public Rate Rate { get; set; } = new Rate();
}
