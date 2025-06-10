using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos
{
    public class WorkorderUpdateResponse : BaseResponse
    {
        public Workorder? Workorder { get; set; }
    }
}
