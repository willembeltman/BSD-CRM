using BSD.Shared.Dtos;

namespace BSD.Shared.Responses
{
    public class WorkorderReadResponse : Response
    {
        public Workorder? Workorder { get; set; }
    }
}
