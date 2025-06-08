using BeltmanSoftwareDesign.Shared.RequestJsons;
using BeltmanSoftwareDesign.Shared.ResponseJsons;

namespace BeltmanSoftwareDesign.Business.Interfaces
{
    public interface ICompanyService
    {
        CompanyCreateResponse Create(CompanyCreateRequest request);
        CompanyDeleteResponse Delete(CompanyDeleteRequest request);
        CompanyListResponse List(CompanyListRequest request);
        CompanyReadResponse Read(CompanyReadRequest request);
        CompanyUpdateResponse Update(CompanyUpdateRequest request);
    }
}