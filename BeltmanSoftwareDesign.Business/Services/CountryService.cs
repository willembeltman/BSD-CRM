using BeltmanSoftwareDesign.Business.Interfaces;
using BeltmanSoftwareDesign.Data;
using BeltmanSoftwareDesign.Data.Converters;
using BeltmanSoftwareDesign.Shared.RequestJsons;
using BeltmanSoftwareDesign.Shared.ResponseJsons;
using CodeGenerator.Attributes;
using Microsoft.AspNetCore.Authorization;

namespace BeltmanSoftwareDesign.Business.Services;

[Authorize, TsService]
public class CountryService(
    ApplicationDbContext db,
    IAuthenticationService authenticationService) : ICountryService
{
    CountryConverter CountryConverter = new CountryConverter();

    [TsServiceMethod("Country", "List")]
    public CountryListResponse List(CountryListRequest request, string? ipAddress, KeyValuePair<string, string?>[]? headers)
    {
        if (ipAddress == null)
            return new CountryListResponse()
            {
                ErrorAuthentication = true
            };

        var authentication = authenticationService.GetState(
            request, ipAddress, headers);
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
