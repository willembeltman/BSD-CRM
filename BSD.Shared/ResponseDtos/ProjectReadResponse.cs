using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos
{
    public class ProjectReadResponse : BaseResponse
    {
        public Project? Project { get; set; }
    }
}
