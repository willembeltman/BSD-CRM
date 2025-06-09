using BSD.Shared.Dtos;

namespace BSD.Shared.Responses
{
    public class ProjectListResponse : Response
    {
        public Project[] Projects { get; set; } = [];
    }
}
