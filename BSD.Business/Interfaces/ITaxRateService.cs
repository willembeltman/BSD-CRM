using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Business.Interfaces;

public interface ITaxRateService
{
    TaxRateCreateResponse Create(TaxRateCreateRequest request);
    TaxRateDeleteResponse Delete(TaxRateDeleteRequest request);
    TaxRateListResponse List(TaxRateListRequest request);
    TaxRateReadResponse Read(TaxRateReadRequest request);
    TaxRateUpdateResponse Update(TaxRateUpdateRequest request);
}