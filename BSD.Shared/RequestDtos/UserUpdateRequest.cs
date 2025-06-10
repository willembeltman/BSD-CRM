using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class UserUpdateRequest : BaseRequest
{
    public User User { get; set; } = new User();
}