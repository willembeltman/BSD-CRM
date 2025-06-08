using Microsoft.AspNetCore.Mvc;
using BeltmanSoftwareDesign.Business.Interfaces;
using BeltmanSoftwareDesign.Shared.RequestJsons;
using BeltmanSoftwareDesign.Shared.ResponseJsons;
namespace BeltmanSoftwareDesign.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CompanyController : BaseControllerBase
    {
        public CompanyController(ICompanyService companyService) 
        {
            CompanyService = companyService;
        }

        public ICompanyService CompanyService { get; }

        [HttpPost]
        public CompanyCreateResponse Create(CompanyCreateRequest request) 
            => CompanyService.Create(request);

        [HttpPost]
        public CompanyReadResponse Read(CompanyReadRequest request) 
            => CompanyService.Read(request);

        [HttpPost]
        public CompanyUpdateResponse Update(CompanyUpdateRequest request) 
            => CompanyService.Update(request);

        [HttpPost]
        public CompanyDeleteResponse Delete(CompanyDeleteRequest request) 
            => CompanyService.Delete(request);

        [HttpPost]
        public CompanyListResponse List(CompanyListRequest request) 
            => CompanyService.List(request);
    }
}
