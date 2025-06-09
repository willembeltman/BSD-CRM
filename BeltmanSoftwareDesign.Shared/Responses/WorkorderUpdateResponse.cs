using BeltmanSoftwareDesign.Shared.Dtos;

namespace BeltmanSoftwareDesign.Shared.Responses
{
    public class WorkorderUpdateResponse : Response
    {
        public Workorder? Workorder { get; set; }
    }
}
