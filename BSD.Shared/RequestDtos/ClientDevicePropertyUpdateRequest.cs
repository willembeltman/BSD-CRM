using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class ClientDevicePropertyUpdateRequest : BaseRequest
{
    public ClientDeviceProperty ClientDeviceProperty { get; set; } = new ClientDeviceProperty();
}