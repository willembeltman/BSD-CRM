using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class UserCreateResponse : BaseResponse
{
    public User? User { get; set; }
}