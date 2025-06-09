using BSD.Shared.Dtos;

namespace BSD.Shared.Responses
{
    public class CompanyListResponse : Response
    {
        public Company[] Companies { get; set; } = [];
    }
}
