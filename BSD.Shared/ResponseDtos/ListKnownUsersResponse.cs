using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos
{
    public class ListKnownUsersResponse : BaseResponse
    {
        public User[] Users { get; set; } = [];
    }
}
