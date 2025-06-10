using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class ClientDeviceUpdateResponse : BaseResponse
{
    public ClientDevice? ClientDevice { get; set; }
}