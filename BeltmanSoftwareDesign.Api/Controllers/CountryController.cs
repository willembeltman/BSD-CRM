using Microsoft.AspNetCore.Mvc;
using BeltmanSoftwareDesign.Business.Interfaces;
using BeltmanSoftwareDesign.Shared.RequestJsons;
using BeltmanSoftwareDesign.Shared.ResponseJsons;

namespace BeltmanSoftwareDesign.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class CountryController(ICountryService CountryService) : BaseControllerBase
{
    [HttpPost]
    public CountryListResponse List(CountryListRequest request) 
        => CountryService.List(request);
}
