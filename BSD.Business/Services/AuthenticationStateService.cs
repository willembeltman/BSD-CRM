using BSD.Business.Converters;
using BSD.Business.Interfaces;
using BSD.Business.Models;
using BSD.Data;
using BSD.Data.Entities;
using BSD.Shared.RequestDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace BSD.Business.Services;

public class AuthenticationStateService(
    IHttpContextAccessor httpContextAccessor,
    ApplicationDbContext db,
    IDateTimeService dateTime)
    : IAuthenticationStateService
{
    static int shorthoursago = -1;
    static int longhoursago = -72;
    ApplicationDbContext db = db;

    public AuthenticationState GetState(BaseRequest request)
    {
        if (IpAddress == null)
            return new AuthenticationState()
            {
            };

        if (Headers == null)
            return new AuthenticationState()
            {
            };

        var now = dateTime.GetNow();
        var shortago = now.AddHours(shorthoursago);
        var longago = now.AddHours(longhoursago);

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

        var userJson = user.ToDto();
        var companyJson = currentcompany.ToDto();

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

    internal string? IpAddress => httpContextAccessor.HttpContext?.Connection.RemoteIpAddress?.ToString();
    internal KeyValuePair<string, string?>[]? Headers => httpContextAccessor.HttpContext!.Request.Headers
        .Select(a => new KeyValuePair<string, string?>(a.Key, a.Value))
        .ToArray();

    internal ClientBearer CreateBearer(User user, ClientDevice clientDevice, ClientIpAddress clientIpAddress)
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
    internal User CreateUser(string username, string email, string phoneNumber, string password)
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
    internal ClientIpAddress? GetIpAddress()
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
    internal ClientDevice? GetClientDevice()
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

    internal static class HashGeneratorHelper
    {
        static Random random = new Random();
        static string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        internal static string GenerateCode(int length)
        {
            char[] code = new char[length];
            for (int i = 0; i < length; i++)
            {
                code[i] = chars[random.Next(chars.Length)];
            }
            return new string(code);
        }
    }
    internal static class StringHelper
    {
        internal static string HashString(string input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Convert the input string to a byte array and compute the hash.
                byte[] data = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Convert the byte array to a hexadecimal string.
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    builder.Append(data[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
    internal static class EmailAddressHelper
    {
        static readonly Regex emailRegex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
        internal static bool IsEmailAddress(string email)
        {
            return emailRegex.IsMatch(email);
        }
    }
}
