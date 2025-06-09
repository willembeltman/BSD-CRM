using BSD.Shared.Dtos;

namespace BSD.Shared.Responses
{
    public class UpdateMyselfResponse : Response
    {
        public User? User { get; set; }
        public bool ErrorOnlyUpdatesToYourselfAreAllowed { get; set; }
    }
}
