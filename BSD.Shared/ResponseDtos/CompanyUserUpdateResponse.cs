using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class CompanyUserUpdateResponse : BaseResponse
{
    public CompanyUser? CompanyUser { get; set; }
}