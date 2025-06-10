using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class CompanyUpdateResponse : BaseResponse
{
    public Company? Company { get; set; }
}