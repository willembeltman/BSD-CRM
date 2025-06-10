using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class TrafficRegistrationReadResponse : BaseResponse
{
    public TrafficRegistration? TrafficRegistration { get; set; }
}