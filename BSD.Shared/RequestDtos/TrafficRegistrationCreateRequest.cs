using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class TrafficRegistrationCreateRequest : BaseRequest
{
    public TrafficRegistration TrafficRegistration { get; set; } = new TrafficRegistration();
}