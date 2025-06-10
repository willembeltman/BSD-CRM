using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class SettingCreateRequest : BaseRequest
{
    public Setting Setting { get; set; } = new Setting();
}