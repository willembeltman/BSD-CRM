using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class UserReadResponse : BaseResponse
{
    public User? User { get; set; }
}