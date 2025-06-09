using BSD.Shared.Dtos;

namespace BSD.Shared.Requests;

public class UpdateMyselfRequest : Request
{
    public User User { get; set; } = new User();
}
