using BeltmanSoftwareDesign.Shared.Dtos;

namespace BeltmanSoftwareDesign.Shared.Responses
{
    public class CompanyCreateResponse : Response
    {
        public Company? Company { get; set; }
        public bool ErrorCompanyNameAlreadyUsed { get; set; }
    }
}
