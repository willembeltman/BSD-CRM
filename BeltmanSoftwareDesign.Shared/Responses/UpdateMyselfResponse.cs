using BeltmanSoftwareDesign.Shared.Dtos;

namespace BeltmanSoftwareDesign.Shared.Responses
{
    public class UpdateMyselfResponse : Response
    {
        public User? User { get; set; }
        public bool ErrorOnlyUpdatesToYourselfAreAllowed { get; set; }
    }
}
