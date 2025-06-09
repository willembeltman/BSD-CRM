using BSD.Business.Helpers;
using BSD.Data;
using BSD.Data.Converters;
using BSD.Business.Interfaces;
using BSD.Shared.Requests;
using BSD.Shared.Responses;
using CodeGenerator.Shared.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BSD.Business.Services;

public class AuthenticationService(
    IHttpContextAccessor httpContextAccessor,
    ApplicationDbContext db,
    IDateTimeService dateTime)
    : AuthenticationBaseService(httpContextAccessor, db), 
    IAuthenticationService
{
    readonly ApplicationDbContext db = db;
    readonly int ShortHoursAgo = -1;
    readonly int LongHoursAgo = -72;
    readonly UserConverter UserConverter = new();
    readonly CompanyConverter CompanyConverter = new();

    [TsServiceMethod("Auth", "Login")]
    public LoginResponse Login(LoginRequest request)
    {
        var shortago = dateTime.Now.AddHours(ShortHoursAgo);
        var longago = dateTime.Now.AddHours(LongHoursAgo);

        var email = request.UserName;
        var password = request.Password;

        if (!EmailAddressHelper.IsEmailAddress(email))
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
        var passwordHash = StringHelper.HashString(password);
        if (dbuser.PasswordHash != passwordHash)
            return new LoginResponse()
            {
                AuthenticationError = true // Security?
            };

        var clientDevice = GetClientDevice();
        if (clientDevice == null)
            return new LoginResponse()
            {
                AuthenticationError = true
            };

        var clientIpAddress = GetIpAddress();
        if (clientIpAddress == null)
            return new LoginResponse()
            {
                AuthenticationError = true
            };

        var clientBearer = db.ClientBearers
            .OrderByDescending(a => a.Date)
            .FirstOrDefault(a =>
                a.UserId == dbuser.Id &&
                a.ClientIpAddressId == clientIpAddress.Id &&
                a.ClientDeviceId == clientDevice.Id &&
                a.Date > shortago);
        if (clientBearer == null)
        {
            // Automatisch vernieuwen
            clientBearer = CreateBearer(dbuser, clientDevice, clientIpAddress);
        }

        var user = UserConverter.Create(dbuser);
        if (user == null)
            return new LoginResponse()
            {
                AuthenticationError = true
            };

        var dbcurrentcompany = db.Companies
            .Include(a => a.Country)
            .FirstOrDefault(a =>
                a.Id == user.currentCompanyId &&
                a.CompanyUsers.Any(a => a.UserId == user.id));
        if (dbcurrentcompany == null)
            return new LoginResponse()
            {
                AuthenticationError = true
            };

        var currentcompany = CompanyConverter.Create(dbcurrentcompany);

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
        if (string.IsNullOrEmpty(this.IpAddress))
            return new RegisterResponse()
            {
                ErrorAuthentication = true
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
        if (!EmailAddressHelper.IsEmailAddress(email))
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

        var device = GetClientDevice();
        if (device == null)
            return new RegisterResponse()
            {
                ErrorCouldNotGetDevice = true
            };

        var ipAddress = GetIpAddress();
        if (ipAddress == null)
            return new RegisterResponse()
            {
                ErrorEmailInUse = true
            };

        var bearer = CreateBearer(dbuser, device, ipAddress);
        if (bearer == null)
            return new RegisterResponse()
            {
                ErrorCouldNotCreateBearer = true
            };

        var user = UserConverter.Create(dbuser);
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
}
