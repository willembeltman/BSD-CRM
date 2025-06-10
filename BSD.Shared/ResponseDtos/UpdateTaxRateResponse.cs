using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class UpdateTaxRateResponse : BaseResponse
{
    public TaxRate? TaxRate { get; set; }
}