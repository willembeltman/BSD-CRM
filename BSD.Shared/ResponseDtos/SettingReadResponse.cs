using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class SettingReadResponse : BaseResponse
{
    public Setting? Setting { get; set; }
}