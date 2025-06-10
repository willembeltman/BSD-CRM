using BSD.Shared.Dtos;
using CodeGenerator.Shared.Attributes;

namespace BSD.Shared.ResponseDtos;

[TsHidden]
public class BaseResponse
{
    public bool Success { get; set; }
    public bool ErrorGettingState { get; set; }
    public bool ErrorNotAuthorized { get; set; }
    public bool ErrorItemNotFound { get; set; }
    public bool ErrorAlreadyUsed { get; set; }
    public bool ErrorAttachingState { get; set; }
    public bool ErrorUpdatingState { get; set; }

    public State State { get; set; } = new State();
}