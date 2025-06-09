using BeltmanSoftwareDesign.Shared.Dtos;

namespace BeltmanSoftwareDesign.Shared.Responses
{
    public class WorkorderReadResponse : Response
    {
        public Workorder? Workorder { get; set; }
    }
}
