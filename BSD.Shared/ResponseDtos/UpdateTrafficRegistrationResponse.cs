using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class UpdateTrafficRegistrationResponse : BaseResponse
{
    public TrafficRegistration? TrafficRegistration { get; set; }
}