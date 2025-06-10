using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class ClientIpAddressCreateRequest : BaseRequest
{
    public ClientIpAddress ClientIpAddress { get; set; } = new ClientIpAddress();
}