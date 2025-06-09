using BSD.Shared.Dtos;

namespace BSD.Shared.Responses
{
    public class ListKnownUsersResponse : Response
    {
        public User[] Users { get; set; } = [];
    }
}
