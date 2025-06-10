using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class CompanyCreateResponse : BaseResponse
{
    public Company? Company { get; set; }
    public bool ErrorCompanyNameAlreadyUsed { get; set; }
}
