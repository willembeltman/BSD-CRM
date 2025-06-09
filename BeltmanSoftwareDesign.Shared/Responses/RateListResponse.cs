using BeltmanSoftwareDesign.Shared.Dtos;

namespace BeltmanSoftwareDesign.Shared.Responses
{
    public class RateListResponse : Response
    {
        public Rate[] Rates { get; set; } = [];
    }
}
