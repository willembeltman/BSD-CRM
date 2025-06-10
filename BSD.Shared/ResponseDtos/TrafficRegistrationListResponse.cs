using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class TrafficRegistrationListResponse : BaseResponse
{
    public TrafficRegistration[] TrafficRegistrations { get; set; } = [];
}