using BSD.Shared.Dtos;

namespace BSD.Shared.Responses
{
    public class WorkorderUpdateResponse : Response
    {
        public Workorder? Workorder { get; set; }
    }
}
