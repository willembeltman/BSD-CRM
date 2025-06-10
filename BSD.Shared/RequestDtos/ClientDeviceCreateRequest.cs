using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class ClientDeviceCreateRequest : BaseRequest
{
    public ClientDevice ClientDevice { get; set; } = new ClientDevice();
}