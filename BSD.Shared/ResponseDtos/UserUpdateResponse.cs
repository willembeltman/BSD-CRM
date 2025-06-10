using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class UserUpdateResponse : BaseResponse
{
    public User? User { get; set; }
}