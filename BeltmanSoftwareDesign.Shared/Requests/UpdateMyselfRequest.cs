using BeltmanSoftwareDesign.Shared.Dtos;

namespace BeltmanSoftwareDesign.Shared.Requests;

public class UpdateMyselfRequest : Request
{
    public User User { get; set; } = new User();
}
