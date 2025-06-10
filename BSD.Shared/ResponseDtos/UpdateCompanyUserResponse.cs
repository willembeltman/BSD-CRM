using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class UpdateCompanyUserResponse : BaseResponse
{
    public CompanyUser? CompanyUser { get; set; }
}