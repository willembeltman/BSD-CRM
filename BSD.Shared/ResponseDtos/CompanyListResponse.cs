using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class CompanyListResponse : BaseResponse
{
    public Company[] Companys { get; set; } = [];
}