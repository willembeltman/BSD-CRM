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
    public CountryCreateResponse Create(CountryCreateRequest request) 
        => country.Create(request);

    [HttpPost]
    public CountryReadResponse Read(CountryReadRequest request) 
        => country.Read(request);

    [HttpPost]
    public CountryUpdateResponse Update(CountryUpdateRequest request) 
        => country.Update(request);

    [HttpPost]
    public CountryDeleteResponse Delete(CountryDeleteRequest request) 
        => country.Delete(request);

    [HttpPost]
    public CountryListResponse List(CountryListRequest request) 
        => country.List(request);
}
