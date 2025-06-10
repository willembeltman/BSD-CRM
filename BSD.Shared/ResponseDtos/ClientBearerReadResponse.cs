using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class ClientBearerReadResponse : BaseResponse
{
    public ClientBearer? ClientBearer { get; set; }
}