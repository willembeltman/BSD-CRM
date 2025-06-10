using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class TrafficRegistrationUpdateResponse : BaseResponse
{
    public TrafficRegistration? TrafficRegistration { get; set; }
}