using BeltmanSoftwareDesign.Shared.Dtos;

namespace BeltmanSoftwareDesign.Shared.Responses
{
    public class WorkorderListResponse : Response
    {
        public Workorder[] Workorders { get; set; } = [];
    }
}
