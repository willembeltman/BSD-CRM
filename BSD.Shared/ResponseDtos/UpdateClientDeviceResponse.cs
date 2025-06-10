using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class UpdateClientDeviceResponse : BaseResponse
{
    public ClientDevice? ClientDevice { get; set; }
}