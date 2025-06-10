using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class ClientDevicePropertyReadResponse : BaseResponse
{
    public ClientDeviceProperty? ClientDeviceProperty { get; set; }
}