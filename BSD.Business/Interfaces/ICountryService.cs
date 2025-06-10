using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Business.Interfaces;

public interface ICountryService
{
    CountryCreateResponse Create(CountryCreateRequest request);
    CountryDeleteResponse Delete(CountryDeleteRequest request);
    CountryListResponse List(CountryListRequest request);
    CountryReadResponse Read(CountryReadRequest request);
    CountryUpdateResponse Update(CountryUpdateRequest request);
}