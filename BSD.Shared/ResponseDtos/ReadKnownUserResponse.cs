using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos
{
    public class ReadKnownUserResponse : BaseResponse
    {
        public User? User { get; set; }
    }
}
