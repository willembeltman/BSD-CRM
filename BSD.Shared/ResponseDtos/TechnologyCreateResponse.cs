using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class TechnologyCreateResponse : BaseResponse
{
    public Technology? Technology { get; set; }
}