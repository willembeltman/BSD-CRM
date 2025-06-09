using BSD.Shared.Dtos;

namespace BSD.Shared.Requests;

public class RateCreateRequest : Request
{
    public Rate Rate { get; set; } = new Rate();
}
