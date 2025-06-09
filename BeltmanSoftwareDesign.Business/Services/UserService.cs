using BeltmanSoftwareDesign.Business.Interfaces;
using BeltmanSoftwareDesign.Business.Models;
using BeltmanSoftwareDesign.Data;
using BeltmanSoftwareDesign.Data.Converters;
using BeltmanSoftwareDesign.Shared.Interfaces;
using BeltmanSoftwareDesign.Shared.Dtos;
using BeltmanSoftwareDesign.Shared.Requests;
using BeltmanSoftwareDesign.Shared.Responses;
using CodeGenerator.Library.Attributes;

namespace BeltmanSoftwareDesign.Business.Services;

public class UserService(
    ApplicationDbContext db,
    IAuthenticationStateService authenticationService)
    : IUserService
{
    UserConverter UserConverter = new UserConverter();
    CompanyConverter CompanyConverter = new CompanyConverter();

    [TsServiceMethod("User", "SetCurrentCompany")]
    public SetCurrentCompanyResponse SetCurrentCompany(SetCurrentCompanyRequest request)
    {
        if (request == null)
            return new SetCurrentCompanyResponse()
            {
                ErrorAuthentication = true
            };
        var state = authenticationService.GetState(request);
        if (!state.Success || state.User == null || state.DbUser == null)
            return new SetCurrentCompanyResponse()
            {
                ErrorAuthentication = true
            };

        // ===========================

        var dbcompany = db.Companies
            .FirstOrDefault(a =>
                a.Id == request.CurrentCompanyId &&
                a.CompanyUsers.Any(a => a.UserId == state.User.id));
        if (dbcompany == null)
            return new SetCurrentCompanyResponse()
            {
                CompanyNotFound = true
            };


        // Convert it back
        var company = CompanyConverter.Create(dbcompany);

        // Set current company to 
        state.User.currentCompanyId = company.Id;
        state.DbUser.CurrentCompanyId = dbcompany.Id;
        state.DbUser.CurrentCompany = dbcompany;
        state.CurrentCompany = company;
        state.DbCurrentCompany = dbcompany;
        db.SaveChanges();

        return new SetCurrentCompanyResponse()
        {
            Success = true,
            State = state
        };
    }

    [TsServiceMethod("User", "ReadKnownUser")]
    public ReadKnownUserResponse ReadKnownUser(ReadKnownUserRequest request)
    {
        if (request == null)
            return new ReadKnownUserResponse()
            {
                ErrorAuthentication = true
            };
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ReadKnownUserResponse()
            {
                ErrorAuthentication = true
            };

        // ===========================

        var knownusers = GetKnownUsers(state);

        var dbuser = knownusers.FirstOrDefault(a => a.Id == request.UserId);
        if (dbuser == null)
            return new ReadKnownUserResponse()
            {
                ErrorItemNotFound = true
            };

        var user = UserConverter.Create(dbuser);

        return new ReadKnownUserResponse()
        {
            Success = true,
            User = user,
            State = state
        };
    }

    [TsServiceMethod("User", "UpdateMyself")]
    public UpdateMyselfResponse UpdateMyself(UpdateMyselfRequest request)
    {
        if (request == null)
            return new UpdateMyselfResponse()
            {
                ErrorAuthentication = true
            };
        var state = authenticationService.GetState(request);
        if (!state.Success || state.User == null || state.DbUser == null)
            return new UpdateMyselfResponse()
            {
                ErrorAuthentication = true
            };

        // ===========================

        if (request.User.id != state.User.id)
            return new UpdateMyselfResponse()
            {
                ErrorOnlyUpdatesToYourselfAreAllowed = true
            };

        // Convert it to db item
        if (UserConverter.Copy(request.User, state.DbUser) == true)
            db.SaveChanges();

        // Convert it back
        var user = UserConverter.Create(state.DbUser);

        // Zichzelf ook update in de json
        state.User = user;
        return new UpdateMyselfResponse()
        {
            Success = true,
            User = user,
            State = state
        };
    }

    [TsServiceMethod("User", "DeleteMyself")]
    public DeleteMyselfResponse DeleteMyself(DeleteMyselfRequest request)
    {
        if (request == null)
            return new DeleteMyselfResponse()
            {
                ErrorAuthentication = true
            };
        var state = authenticationService.GetState(request);
        if (!state.Success || state.User == null || state.DbUser == null)
            return new DeleteMyselfResponse()
            {
                ErrorAuthentication = true
            };

        // ===========================

        if (request.UserId != state.User.id)
            return new DeleteMyselfResponse()
            {
                ErrorOnlyDeletesToYourselfAreAllowed = true
            };

        db.Users.Remove(state.DbUser);
        db.SaveChanges();

        return new DeleteMyselfResponse()
        {
            Success = true,
            State = new State()
            {

            }
        };
    }

    [TsServiceMethod("User", "ListKnownUsers")]
    public ListKnownUsersResponse ListKnownUsers(ListKnownUsersRequest request)
    {
        if (request == null)
            return new ListKnownUsersResponse()
            {
                ErrorAuthentication = true
            };

        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ListKnownUsersResponse()
            {
                ErrorAuthentication = true
            };

        var knownusers = GetKnownUsers(state);

        var list =
            knownusers
                .Select(u => UserConverter.Create(u))
                .ToArray();

        return new ListKnownUsersResponse()
        {
            Success = true,
            State = state,
            Users = list
        };
    }

    private List<Data.Entities.User> GetKnownUsers(AuthenticationState state)
    {
        if (state.DbUser == null) return [];
        var loggedinuser = state.DbUser;
        var knownusers =
            db.CompanyUsers
                .Where(a => a.UserId == loggedinuser.Id)
                .Select(a => a.Company!)
                .SelectMany(c => c.CompanyUsers)
                .Select(cu => cu.User!)
                .ToList();
        knownusers.Add(loggedinuser);
        knownusers = knownusers
            .GroupBy(a => a.Id)
            .Select(a => a.First())
            .ToList();
        return knownusers;
    }
}
