using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class ClientBearerUpdateRequest : BaseRequest
{
    public ClientBearer ClientBearer { get; set; } = new ClientBearer();
}