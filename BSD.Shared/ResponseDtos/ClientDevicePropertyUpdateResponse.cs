using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class ClientDevicePropertyUpdateResponse : BaseResponse
{
    public ClientDeviceProperty? ClientDeviceProperty { get; set; }
}