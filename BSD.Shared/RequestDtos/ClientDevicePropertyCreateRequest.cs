using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class ClientDevicePropertyCreateRequest : BaseRequest
{
    public ClientDeviceProperty ClientDeviceProperty { get; set; } = new ClientDeviceProperty();
}