using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class UpdateCompanyResponse : BaseResponse
{
    public Company? Company { get; set; }
}