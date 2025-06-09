using BSD.Shared.Dtos;

namespace BSD.Shared.Responses
{
    public class CompanyCreateResponse : Response
    {
        public Company? Company { get; set; }
        public bool ErrorCompanyNameAlreadyUsed { get; set; }
    }
}
