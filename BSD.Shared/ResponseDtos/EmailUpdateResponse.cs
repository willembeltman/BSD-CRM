using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class EmailUpdateResponse : BaseResponse
{
    public Email? Email { get; set; }
}