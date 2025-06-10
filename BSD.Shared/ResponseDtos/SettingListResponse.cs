using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class SettingListResponse : BaseResponse
{
    public Setting[] Settings { get; set; } = [];
}