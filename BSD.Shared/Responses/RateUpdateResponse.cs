using BSD.Shared.Dtos;

namespace BSD.Shared.Responses
{
    public class RateUpdateResponse : Response
    {
        public Rate? Rate { get; set; }
    }
}
