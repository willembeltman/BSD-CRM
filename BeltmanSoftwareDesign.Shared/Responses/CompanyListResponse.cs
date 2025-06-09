using BeltmanSoftwareDesign.Shared.Dtos;

namespace BeltmanSoftwareDesign.Shared.Responses
{
    public class CompanyListResponse : Response
    {
        public Company[] Companies { get; set; } = [];
    }
}
