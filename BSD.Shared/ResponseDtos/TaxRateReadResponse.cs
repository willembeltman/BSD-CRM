using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class TaxRateReadResponse : BaseResponse
{
    public TaxRate? TaxRate { get; set; }
}