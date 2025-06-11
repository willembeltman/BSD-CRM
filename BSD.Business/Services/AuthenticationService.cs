using BSD.Business.Converters;
using BSD.Business.Interfaces;
using BSD.Data;
using BSD.Data.Entities;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using CodeGenerator.Shared.Attributes;
using Microsoft.EntityFrameworkCore;
using static BSD.Business.Services.AuthenticationStateService;

namespace BSD.Business.Services;

public class AuthenticationService(
    IForgotPasswordService forgotPasswordService,
    IAuthenticationStateService authenticationStateService,
    ApplicationDbContext db)
    : IAuthenticationService
{
    readonly ApplicationDbContext db = db;

    [TsServiceMethod("Auth", "Login")]
    public LoginResponse Login(LoginRequest request)
    {

        var email = request.UserName;
        var password = request.Password;

        if (!AuthenticationStateService.EmailAddressHelper.IsEmailAddress(email))
            return new LoginResponse()
            {
                ErrorEmailNotValid = true
            };
        if (string.IsNullOrEmpty(password))
            return new LoginResponse()
            {
                AuthenticationError = true
            };

        var dbuser = db.Users.FirstOrDefault(a => a.Email == email);
        if (dbuser == null)
            return new LoginResponse()
            {
                AuthenticationError = true // Security?
            };

        // Password correct?
        var passwordHash = AuthenticationStateService.StringHelper.HashString(password);
        if (dbuser.PasswordHash != passwordHash)
            return new LoginResponse()
            {
                AuthenticationError = true // Security?
            };

        var clientBearer = authenticationStateService.GetClientBearer(dbuser);
        if (clientBearer == null)
            return new LoginResponse()
            {
                AuthenticationError = true
            };

        var user = dbuser.ToDto();
        if (user == null)
            return new LoginResponse()
            {
                AuthenticationError = true
            };

        var dbcurrentcompany = db.Companies
            .Include(a => a.Country)
            .FirstOrDefault(a =>
                a.Id == user.CurrentCompanyId &&
                a.CompanyUsers.Any(a => a.UserId == user.Id));
        if (dbcurrentcompany == null)
            return new LoginResponse()
            {
                AuthenticationError = true
            };

        var currentcompany = dbcurrentcompany.ToDto();

        return new LoginResponse()
        {
            Success = true,
            State = new Shared.Dtos.State()
            {
                User = user,
                CurrentCompany = currentcompany,
                BearerId = clientBearer.Id,
            }
        };
    }

    [TsServiceMethod("Auth", "Register")]
    public RegisterResponse Register(RegisterRequest request)
    {
        if (string.IsNullOrEmpty(authenticationStateService.IpAddress))
            return new RegisterResponse()
            {
                ErrorGettingState = true
            };

        var username = request.Username;
        var email = request.Email;
        var phoneNumber = request.PhoneNumber;
        var password = request.Password;

        // Add validation
        if (email == null)
            return new RegisterResponse()
            {
                ErrorEmailNotValid = true
            };
        if (!AuthenticationStateService.EmailAddressHelper.IsEmailAddress(email))
            return new RegisterResponse()
            {
                ErrorEmailNotValid = true
            };
        if (string.IsNullOrEmpty(username))
            return new RegisterResponse()
            {
                ErrorUsernameEmpty = true
            };
        if (string.IsNullOrEmpty(password))
            return new RegisterResponse()
            {
                ErrorPasswordEmpty = true
            };
        if (string.IsNullOrEmpty(phoneNumber))
            return new RegisterResponse()
            {
                ErrorPhoneNumberEmpty = true
            };

        var usernameUser = db.Users.FirstOrDefault(a => a.UserName.ToLower() == username.ToLower());
        if (usernameUser != null)
            return new RegisterResponse()
            {
                ErrorUsernameInUse = true
            };

        var emailUser = db.Users.FirstOrDefault(a => a.Email.ToLower() == email.ToLower());
        if (emailUser != null)
            return new RegisterResponse()
            {
                ErrorEmailInUse = true
            };

        var dbuser = CreateUser(username, email, phoneNumber, password);
        if (dbuser == null)
            return new RegisterResponse()
            {
                ErrorCouldNotCreateUser = true
            };

        var bearer = authenticationStateService.GetClientBearer(dbuser);
        if (bearer == null)
            return new RegisterResponse()
            {
                ErrorCouldNotCreateBearer = true
            };

        var user = dbuser.ToDto();
        return new RegisterResponse()
        {
            Success = true,
            State = new Shared.Dtos.State()
            {
                User = user,
                BearerId = bearer.Id,
            }
        };
    }

    [TsServiceMethod("Auth", "ForgotPassword")]
    public ForgotPasswordResponse ForgotPassword(ForgotPasswordRequest request)
    {
        if (string.IsNullOrEmpty(authenticationStateService.IpAddress))
            return new ForgotPasswordResponse()
            {
                ErrorGettingState = true
            };

        var email = request.Email;

        // Add validation
        if (email == null)
            return new ForgotPasswordResponse()
            {
                ErrorEmailNotValid = true
            };
        if (!AuthenticationStateService.EmailAddressHelper.IsEmailAddress(email))
            return new ForgotPasswordResponse()
            {
                ErrorEmailNotValid = true
            };

        var dbuser = db.Users.FirstOrDefault(a => a.Email.ToLower() == email.ToLower());
        if (dbuser == null)
            return new ForgotPasswordResponse()
            {
                Success = true, // Security? Don't tell if email exists
            };

        forgotPasswordService.Handle(dbuser);
        return new ForgotPasswordResponse()
        {
            Success = true
        };
    }
    private User CreateUser(string username, string email, string phoneNumber, string password)
    {
        // Create user
        var passwordHash = StringHelper.HashString(password);
        var userid = HashGeneratorHelper.GenerateCode(64);
        var dbuser = new User()
        {
            Id = userid,
            UserName = username,
            Email = email,
            PhoneNumber = phoneNumber,
            PasswordHash = passwordHash,
        };
        db.Users.Add(dbuser);
        db.SaveChanges();
        return dbuser;
    }

}
