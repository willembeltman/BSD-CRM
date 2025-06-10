using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class UpdateClientIpAddressResponse : BaseResponse
{
    public ClientIpAddress? ClientIpAddress { get; set; }
}