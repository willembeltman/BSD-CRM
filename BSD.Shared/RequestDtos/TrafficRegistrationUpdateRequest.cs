using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class TrafficRegistrationUpdateRequest : BaseRequest
{
    public TrafficRegistration TrafficRegistration { get; set; } = new TrafficRegistration();
}