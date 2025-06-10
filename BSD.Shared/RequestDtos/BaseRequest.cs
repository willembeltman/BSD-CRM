
using CodeGenerator.Shared.Attributes;

namespace BSD.Shared.RequestDtos;

[TsHidden]
public class BaseRequest
{
    public string? BearerId { get; set; }
}
