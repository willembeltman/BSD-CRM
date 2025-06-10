using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class TaxRateCreateRequest : BaseRequest
{
    public TaxRate TaxRate { get; set; } = new TaxRate();
}