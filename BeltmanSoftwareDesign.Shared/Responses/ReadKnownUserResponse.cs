using BeltmanSoftwareDesign.Shared.Dtos;

namespace BeltmanSoftwareDesign.Shared.Responses
{
    public class ReadKnownUserResponse : Response
    {
        public User? User { get; set; }
    }
}
