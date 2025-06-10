using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class ClientBearerCreateResponse : BaseResponse
{
    public ClientBearer? ClientBearer { get; set; }
}