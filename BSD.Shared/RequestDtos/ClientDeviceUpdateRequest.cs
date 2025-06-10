using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class ClientDeviceUpdateRequest : BaseRequest
{
    public ClientDevice ClientDevice { get; set; } = new ClientDevice();
}