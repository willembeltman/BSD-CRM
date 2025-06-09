using Microsoft.AspNetCore.Mvc;
using BeltmanSoftwareDesign.Shared.Interfaces;
using BeltmanSoftwareDesign.Business.Interfaces;
using BeltmanSoftwareDesign.Shared.Requests;
using BeltmanSoftwareDesign.Shared.Responses;

namespace BeltmanSoftwareDesign.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class CountryController(ICountryService country) : ControllerBase
{
    [HttpPost]
    public CountryListResponse List(CountryListRequest request) 
        => country.List(request);
}
