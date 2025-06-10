using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class TaxRateUpdateResponse : BaseResponse
{
    public TaxRate? TaxRate { get; set; }
}