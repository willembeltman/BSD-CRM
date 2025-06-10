using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class UserListResponse : BaseResponse
{
    public User[] Users { get; set; } = [];
}