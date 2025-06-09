using BSD.Shared.Dtos;

namespace BSD.Shared.Responses
{
    public class CompanyReadResponse : Response
    {
        public Company? Company { get; set; }
        public bool CompanyNotFound { get; set; }
    }
}
