using BSD.Shared.Requests;
using BSD.Shared.Responses;

namespace BSD.Business.Interfaces;

public interface ICompanyService
{
    CompanyCreateResponse Create(CompanyCreateRequest request);
    CompanyDeleteResponse Delete(CompanyDeleteRequest request);
    CompanyListResponse List(CompanyListRequest request);
    CompanyReadResponse Read(CompanyReadRequest request);
    CompanyUpdateResponse Update(CompanyUpdateRequest request);
}