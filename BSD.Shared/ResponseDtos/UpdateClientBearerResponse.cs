using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class UpdateClientBearerResponse : BaseResponse
{
    public ClientBearer? ClientBearer { get; set; }
}