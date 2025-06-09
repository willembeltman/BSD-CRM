using BeltmanSoftwareDesign.Shared.Dtos;

namespace BeltmanSoftwareDesign.Shared.Responses
{
    public class ListKnownUsersResponse : Response
    {
        public User[] Users { get; set; } = [];
    }
}
