using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class UserCreateRequest : BaseRequest
{
    public User User { get; set; } = new User();
}