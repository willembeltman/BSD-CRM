using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class CompanyUserReadResponse : BaseResponse
{
    public CompanyUser? CompanyUser { get; set; }
}