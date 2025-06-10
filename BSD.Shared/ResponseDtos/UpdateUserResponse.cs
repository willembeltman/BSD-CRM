using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class UpdateUserResponse : BaseResponse
{
    public User? User { get; set; }
}