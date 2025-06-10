using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class UpdateClientDevicePropertyResponse : BaseResponse
{
    public ClientDeviceProperty? ClientDeviceProperty { get; set; }
}