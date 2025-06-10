using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos
{
    public class RateReadResponse : BaseResponse
    {
        public Rate? Rate { get; set; }
    }
}
