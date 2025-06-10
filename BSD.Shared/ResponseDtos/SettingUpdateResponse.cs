using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class SettingUpdateResponse : BaseResponse
{
    public Setting? Setting { get; set; }
}