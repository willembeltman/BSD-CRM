using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class ClientBearerUpdateResponse : BaseResponse
{
    public ClientBearer? ClientBearer { get; set; }
}