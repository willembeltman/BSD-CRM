using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Business.CrudInterfaces;

public interface IUserService
{
    UserCreateResponse Create(UserCreateRequest request);
    UserDeleteResponse Delete(UserDeleteRequest request);
    UserListResponse List(UserListRequest request);
    UserReadResponse Read(UserReadRequest request);
    UserUpdateResponse Update(UserUpdateRequest request);
}