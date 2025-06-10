using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class TaxRateUpdateRequest : BaseRequest
{
    public TaxRate TaxRate { get; set; } = new TaxRate();
}