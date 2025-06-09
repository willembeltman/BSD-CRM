using BeltmanSoftwareDesign.Shared.Dtos;

namespace BeltmanSoftwareDesign.Shared.Responses
{
    public class CompanyReadResponse : Response
    {
        public Company? Company { get; set; }
        public bool CompanyNotFound { get; set; }
    }
}
