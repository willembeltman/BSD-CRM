using BeltmanSoftwareDesign.Business.Helpers;
using BeltmanSoftwareDesign.Business.Interfaces;
using BeltmanSoftwareDesign.Business.Models;
using BeltmanSoftwareDesign.Data;
using BeltmanSoftwareDesign.Data.Converters;
using BeltmanSoftwareDesign.Data.Entities;
using BeltmanSoftwareDesign.Shared.RequestJsons;
using BeltmanSoftwareDesign.Shared.ResponseJsons;
using CodeGenerator.Library.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BeltmanSoftwareDesign.Business.Services;

public class AuthenticationService(IHttpContextAccessor httpContextAccessor, ApplicationDbContext db,
    IDateTimeService dateTime) : IAuthenticationService
{
    static int shorthoursago = -1;
    static int longhoursago = -72;

    UserConverter UserConverter = new UserConverter();
    CompanyConverter CompanyConverter = new CompanyConverter();

    public string? IpAddress => httpContextAccessor.HttpContext?.Connection.RemoteIpAddress?.ToString();
    public KeyValuePair<string, string?>[]? Headers => httpContextAccessor.HttpContext!.Request.Headers
        .Select(a => new KeyValuePair<string, string?>(a.Key, a.Value))
        .ToArray();

    [TsServiceMethod("Auth", "Login")]
    public LoginResponse Login(LoginRequest request)
    {
        var shortago = dateTime.Now.AddHours(shorthoursago);
        var longago = dateTime.Now.AddHours(longhoursago);

        var email = request.Email;
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
            State = new Shared.Jsons.State()
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
            State = new Shared.Jsons.State()
            {
                User = user,
                BearerId = bearer.Id,
            }
        };
    }

    public AuthenticationState GetState(Request request)
    {
        if (IpAddress == null)
            return new AuthenticationState()
            {
            };

        if (Headers == null)
            return new AuthenticationState()
            {
            };

        var shortago = dateTime.Now.AddHours(shorthoursago);
        var longago = dateTime.Now.AddHours(longhoursago);

        var clientDevice = GetClientDevice();
        if (clientDevice == null)
            return new AuthenticationState()
            {
            };

        var clientIpAddress = GetIpAddress();
        if (clientIpAddress == null)
            return new AuthenticationState()
            {
            };

        var clientBearer = db.ClientBearers
            .OrderByDescending(a => a.Date)
            .FirstOrDefault(a =>
                a.Id == request.BearerId &&
                a.Date > longago);
        if (clientBearer == null || clientBearer.UserId == null)
            return new AuthenticationState()
            {
            };

        if (clientBearer.ClientDeviceId != clientDevice.Id)
            return new AuthenticationState()
            {
            };

        if (clientBearer.Date < longago)
            return new AuthenticationState()
            {
            };

        // Get user from database
        var user = db.Users
            .FirstOrDefault(a => a.Id == clientBearer.UserId);
        if (user == null)
            return new AuthenticationState()
            {
            };

        if (clientBearer.ClientIpAddressId != clientIpAddress.Id)
        {
            // Ip veranderd, toch automatisch vernieuwen
            clientBearer = CreateBearer(user, clientDevice, clientIpAddress);
        }

        if (clientBearer.Date < shortago && clientBearer.Date > longago)
        {
            // Automatisch vernieuwen
            clientBearer = CreateBearer(user, clientDevice, clientIpAddress);
        }

        // Get current company from database
        var currentcompany = db.Companies
            .Include(a => a.Country)
            .FirstOrDefault(a =>
                a.CompanyUsers.Any(a => a.UserId == user.Id) &&
                a.Id == request.CurrentCompanyId);
        if (currentcompany == null)
            return new AuthenticationState()
            {
            };

        var userJson = UserConverter.Create(user);
        var companyJson = CompanyConverter.Create(currentcompany);

        return new AuthenticationState()
        {
            Success = true,

            User = userJson,
            CurrentCompany = companyJson,
            BearerId = clientBearer.Id,

            DbUser = user,
            DbCurrentCompany = currentcompany,
            DbClientBearer = clientBearer,
            DbClientDevice = clientDevice,
            DbClientLocation = clientIpAddress,
        };
    }


    private ClientBearer CreateBearer(User user, ClientDevice clientDevice, ClientIpAddress clientIpAddress)
    {
        // Te oud, vernieuwen
        var bearerid = HashGeneratorHelper.GenerateCode(64);
        var bearer = new ClientBearer()
        {
            Id = bearerid,
            ClientDevice = clientDevice,
            ClientDeviceId = clientDevice?.Id,
            ClientIpAddress = clientIpAddress,
            ClientIpAddressId = clientIpAddress?.Id,
            User = user,
            UserId = user.Id,
        };
        db.ClientBearers.Add(bearer);
        db.SaveChanges();
        return bearer;
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
    private ClientIpAddress? GetIpAddress()
    {
        if (IpAddress == null)
            return null;

        var location = db.ClientLocations.FirstOrDefault(a => a.IpAddress == IpAddress);
        if (location == null)
        {
            location = new ClientIpAddress()
            {
                IpAddress = IpAddress,
            };
            db.ClientLocations.Add(location);
            db.SaveChanges();
        }

        return location;
    }
    private ClientDevice? GetClientDevice()
    {
        if (Headers == null)
            return null;

        if (!Headers.Any(a => a.Key.ToLower() == "useragent" || a.Key.ToLower() == "user-agent"))
            return null;

        var useragentheader = Headers.First(a => a.Key.ToLower() == "useragent" || a.Key.ToLower() == "user-agent");
        var useragent = (useragentheader.Value ?? string.Empty).ToLower();

        if (useragent == null)
            return null;

        var deviceHash = StringHelper.HashString(useragent);
        var device = db.ClientDevices.FirstOrDefault(a => a.DeviceHash == deviceHash);
        if (device == null)
        {
            device = new ClientDevice()
            {
                DeviceHash = deviceHash,
                ClientDeviceProperties = new List<ClientDeviceProperty>()
                {
                    new ClientDeviceProperty()
                    {
                        Name = "UserAgent",
                        Value = useragent
                    },
                }
            };
            db.ClientDevices.Add(device);
            db.SaveChanges();
        }

        return device;
    }
}
