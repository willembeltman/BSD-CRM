using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class CompanyReadResponse : BaseResponse
{
    public Company? Company { get; set; }
}