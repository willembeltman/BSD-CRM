using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class UpdateMyselfRequest : BaseRequest
{
    public User User { get; set; } = new User();
}
