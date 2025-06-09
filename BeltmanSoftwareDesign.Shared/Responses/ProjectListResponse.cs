using BeltmanSoftwareDesign.Shared.Dtos;

namespace BeltmanSoftwareDesign.Shared.Responses
{
    public class ProjectListResponse : Response
    {
        public Project[] Projects { get; set; } = [];
    }
}
