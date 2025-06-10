using BSD.Business.Interfaces;
using BSD.Data;
using BSD.Data.Converters;
using BSD.Shared.Requests;
using BSD.Shared.Responses;
using CodeGenerator.Shared.Attributes;

namespace BSD.Business.Services;

public class CountryService(
    ApplicationDbContext db,
    IAuthenticationStateService stateService)
    : ICountryService
{
    CountryConverter CountryConverter = new CountryConverter();

    [TsServiceMethod("Country", "List")]
    public CountryListResponse List(CountryListRequest request)
    {
        var authentication = stateService.GetState(request);
        if (!authentication.Success)
            return new CountryListResponse()
            {
                ErrorAuthentication = true
            };

        var list = db.Countries
            .Select(a => CountryConverter.Create(a))
            .ToArray();

        return new CountryListResponse()
        {
            Success = true,
            State = authentication,
            Countries = list
        };
    }
}
