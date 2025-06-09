using BSD.Shared.Requests;
using BSD.Shared.Responses;

namespace BSD.Business.Interfaces;

public interface ICountryService
{
    CountryListResponse List(CountryListRequest request);
}
