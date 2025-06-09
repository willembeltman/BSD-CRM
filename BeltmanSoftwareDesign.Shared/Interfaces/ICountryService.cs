using BeltmanSoftwareDesign.Shared.Requests;
using BeltmanSoftwareDesign.Shared.Responses;

namespace BeltmanSoftwareDesign.Shared.Interfaces;

public interface ICountryService
{
    CountryListResponse List(CountryListRequest request);
}
