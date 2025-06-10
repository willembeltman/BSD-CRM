using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class ClientIpAddressUpdateRequest : BaseRequest
{
    public ClientIpAddress ClientIpAddress { get; set; } = new ClientIpAddress();
}