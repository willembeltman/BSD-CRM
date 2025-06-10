using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos
{
    public class RateUpdateResponse : BaseResponse
    {
        public Rate? Rate { get; set; }
    }
}
