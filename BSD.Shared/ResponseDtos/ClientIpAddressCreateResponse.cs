using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class ClientIpAddressCreateResponse : BaseResponse
{
    public ClientIpAddress? ClientIpAddress { get; set; }
}