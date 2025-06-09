using Microsoft.AspNetCore.Mvc;
using BSD.Business.Interfaces;
using BSD.Shared.Requests;
using BSD.Shared.Responses;

namespace BSD.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class CountryController(ICountryService country) : ControllerBase
{
    [HttpPost]
    public CountryListResponse List(CountryListRequest request) 
        => country.List(request);
}
