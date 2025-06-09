using BeltmanSoftwareDesign.Shared.Dtos;

namespace BeltmanSoftwareDesign.Shared.Responses
{
    public class WorkorderCreateResponse : Response
    {
        public Workorder? Workorder { get; set; }
    }
}
