using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class UpdateSettingResponse : BaseResponse
{
    public Setting? Setting { get; set; }
}