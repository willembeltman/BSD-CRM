using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos
{
    public class UpdateMyselfResponse : BaseResponse
    {
        public User? User { get; set; }
        public bool ErrorOnlyUpdatesToYourselfAreAllowed { get; set; }
    }
}
