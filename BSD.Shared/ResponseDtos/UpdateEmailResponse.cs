using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class UpdateEmailResponse : BaseResponse
{
    public Email? Email { get; set; }
}