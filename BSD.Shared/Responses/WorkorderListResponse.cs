using BSD.Shared.Dtos;

namespace BSD.Shared.Responses
{
    public class WorkorderListResponse : Response
    {
        public Workorder[] Workorders { get; set; } = [];
    }
}
