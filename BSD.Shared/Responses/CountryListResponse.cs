using BSD.Shared.Dtos;

namespace BSD.Shared.Responses
{
    public class CountryListResponse : Response
    {
        public Country[] Countries { get; set; } = [];
    }
}
