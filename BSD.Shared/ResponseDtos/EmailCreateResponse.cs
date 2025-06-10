using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class EmailCreateResponse : BaseResponse
{
    public Email? Email { get; set; }
}