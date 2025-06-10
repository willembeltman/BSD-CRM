using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class TaxRateCreateResponse : BaseResponse
{
    public TaxRate? TaxRate { get; set; }
}