using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class ProjectListResponse : BaseResponse
{
    public Project[] Projects { get; set; } = [];
}