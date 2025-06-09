using BeltmanSoftwareDesign.Shared.Requests;
using BeltmanSoftwareDesign.Shared.Responses;

namespace BeltmanSoftwareDesign.Shared.Interfaces;

public interface IUserService
{
    //UserCreateResponse Create(UserCreateRequest request);
    DeleteMyselfResponse DeleteMyself(DeleteMyselfRequest request);
    ListKnownUsersResponse ListKnownUsers(ListKnownUsersRequest request);
    ReadKnownUserResponse ReadKnownUser(ReadKnownUserRequest request);
    SetCurrentCompanyResponse SetCurrentCompany(SetCurrentCompanyRequest request);
    UpdateMyselfResponse UpdateMyself(UpdateMyselfRequest request);
}