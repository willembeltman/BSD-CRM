using BSD.Shared.Dtos;

namespace BSD.Shared.Responses
{
    public class RateListResponse : Response
    {
        public Rate[] Rates { get; set; } = [];
    }
}
