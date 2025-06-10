using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class TaxRateListResponse : BaseResponse
{
    public TaxRate[] TaxRates { get; set; } = [];
}