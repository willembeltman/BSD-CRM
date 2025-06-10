using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class ClientIpAddressReadResponse : BaseResponse
{
    public ClientIpAddress? ClientIpAddress { get; set; }
}