using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class SettingUpdateRequest : BaseRequest
{
    public Setting Setting { get; set; } = new Setting();
}