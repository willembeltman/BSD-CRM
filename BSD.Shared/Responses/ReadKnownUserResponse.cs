using BSD.Shared.Dtos;

namespace BSD.Shared.Responses
{
    public class ReadKnownUserResponse : Response
    {
        public User? User { get; set; }
    }
}
