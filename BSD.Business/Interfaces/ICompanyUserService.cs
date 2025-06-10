using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Business.Interfaces;

public interface ICompanyUserService
{
    CompanyUserCreateResponse Create(CompanyUserCreateRequest request);
    CompanyUserDeleteResponse Delete(CompanyUserDeleteRequest request);
    CompanyUserListResponse List(CompanyUserListRequest request);
    CompanyUserReadResponse Read(CompanyUserReadRequest request);
    CompanyUserUpdateResponse Update(CompanyUserUpdateRequest request);
}