using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class ClientDeviceReadResponse : BaseResponse
{
    public ClientDevice? ClientDevice { get; set; }
}