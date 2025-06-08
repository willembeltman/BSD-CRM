using Microsoft.AspNetCore.Mvc;
using BeltmanSoftwareDesign.Business.Interfaces;
using BeltmanSoftwareDesign.Shared.RequestJsons;
using BeltmanSoftwareDesign.Shared.ResponseJsons;
namespace BeltmanSoftwareDesign.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : BaseControllerBase
    {
        public UserController(IUserService userService) 
        {
            UserService = userService;
        }

        public IUserService UserService { get; }

        [HttpPost]
        public SetCurrentCompanyResponse SetCurrentCompany(SetCurrentCompanyRequest request) 
            => UserService.SetCurrentCompany(request);

        [HttpPost]
        public ReadKnownUserResponse ReadKnownUser(ReadKnownUserRequest request) 
            => UserService.ReadKnownUser(request);

        [HttpPost]
        public UpdateMyselfResponse UpdateMyself(UpdateMyselfRequest request) 
            => UserService.UpdateMyself(request);

        [HttpPost]
        public DeleteMyselfResponse DeleteMyself(DeleteMyselfRequest request) 
            => UserService.DeleteMyself(request);

        [HttpPost]
        public ListKnownUsersResponse ListKnownUsers(ListKnownUsersRequest request) 
            => UserService.ListKnownUsers(request);
    }
}
