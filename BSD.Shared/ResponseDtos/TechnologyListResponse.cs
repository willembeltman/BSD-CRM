using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class TechnologyListResponse : BaseResponse
{
    public Technology[] Technologys { get; set; } = [];
}