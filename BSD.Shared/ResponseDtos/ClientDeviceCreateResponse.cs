using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class ClientDeviceCreateResponse : BaseResponse
{
    public ClientDevice? ClientDevice { get; set; }
}