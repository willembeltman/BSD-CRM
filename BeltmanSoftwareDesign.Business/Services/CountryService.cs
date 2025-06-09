using BeltmanSoftwareDesign.Business.Interfaces;
using BeltmanSoftwareDesign.Data;
using BeltmanSoftwareDesign.Data.Converters;
using BeltmanSoftwareDesign.Shared.RequestJsons;
using BeltmanSoftwareDesign.Shared.ResponseJsons;
using CodeGenerator.Library.Attributes;

namespace BeltmanSoftwareDesign.Business.Services;

public class CountryService(ApplicationDbContext db, IAuthenticationService authenticationService) : ICountryService
{
    CountryConverter CountryConverter = new CountryConverter();

    [TsServiceMethod("Country", "List")]
    public CountryListResponse List(CountryListRequest request)
    {
        var authentication = authenticationService.GetState(request);
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
