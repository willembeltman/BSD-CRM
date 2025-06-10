using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos
{
    public class WorkorderListResponse : BaseResponse
    {
        public Workorder[] Workorders { get; set; } = [];
    }
}
