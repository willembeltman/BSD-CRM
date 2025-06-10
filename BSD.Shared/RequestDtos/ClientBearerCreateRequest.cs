using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class ClientBearerCreateRequest : BaseRequest
{
    public ClientBearer ClientBearer { get; set; } = new ClientBearer();
}