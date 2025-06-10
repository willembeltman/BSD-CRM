using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class SettingCreateResponse : BaseResponse
{
    public Setting? Setting { get; set; }
}