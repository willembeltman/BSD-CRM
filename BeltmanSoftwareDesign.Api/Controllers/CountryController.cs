using BeltmanSoftwareDesign.Business.Interfaces;
using BeltmanSoftwareDesign.Shared.RequestJsons;
using BeltmanSoftwareDesign.Shared.ResponseJsons;
using Microsoft.AspNetCore.Mvc;

namespace BeltmanSoftwareDesign.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class CountryController(ICountryService CountryService) : BaseControllerBase
{
    [HttpPost]
    public CountryListResponse List(CountryListRequest request)
        => CountryService.List(request);
}
