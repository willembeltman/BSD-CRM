using Microsoft.AspNetCore.Mvc;
using BSD.Business.Interfaces;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class CountryController(ICountryService country) : ControllerBase
{
    [HttpPost]
    public CountryListResponse List(CountryListRequest request) 
        => country.List(request);
}
