using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class ClientIpAddressUpdateResponse : BaseResponse
{
    public ClientIpAddress? ClientIpAddress { get; set; }
}