using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class TechnologyUpdateResponse : BaseResponse
{
    public Technology? Technology { get; set; }
}