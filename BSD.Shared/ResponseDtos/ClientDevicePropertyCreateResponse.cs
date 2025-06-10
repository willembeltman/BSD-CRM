using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class ClientDevicePropertyCreateResponse : BaseResponse
{
    public ClientDeviceProperty? ClientDeviceProperty { get; set; }
}