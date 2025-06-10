using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Business.Interfaces;

public interface ICountryService
{
    CountryListResponse List(CountryListRequest request);
}
