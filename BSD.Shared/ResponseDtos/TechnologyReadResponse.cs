using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class TechnologyReadResponse : BaseResponse
{
    public Technology? Technology { get; set; }
}