using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class EmailReadResponse : BaseResponse
{
    public Email? Email { get; set; }
}