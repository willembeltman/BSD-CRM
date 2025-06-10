using BSD.Shared.Dtos;
using CodeGenerator.Shared.Attributes;

namespace BSD.Shared.ResponseDtos;

[TsHidden]
public class BaseResponse
{
    public bool Success { get; set; }
    public bool ErrorAuthentication { get; set; }
    public bool ErrorItemNotFound { get; set; }

    public State State { get; set; } = new State();
}