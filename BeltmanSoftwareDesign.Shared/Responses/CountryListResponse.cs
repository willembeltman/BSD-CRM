using BeltmanSoftwareDesign.Shared.Dtos;

namespace BeltmanSoftwareDesign.Shared.Responses
{
    public class CountryListResponse : Response
    {
        public Country[] Countries { get; set; } = [];
    }
}
