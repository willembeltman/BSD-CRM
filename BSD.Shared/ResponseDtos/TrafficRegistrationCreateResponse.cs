using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class TrafficRegistrationCreateResponse : BaseResponse
{
    public TrafficRegistration? TrafficRegistration { get; set; }
}