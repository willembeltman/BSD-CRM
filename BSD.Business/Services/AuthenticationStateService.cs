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
    static int ShortHoursAgo = -1;
    static int LongHoursAgo = -72;
    ApplicationDbContext db = db;

    public async Task<AuthenticationState> GetState(BaseRequest request)
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
        var shortago = now.AddHours(ShortHoursAgo);
        var longago = now.AddHours(LongHoursAgo);

        var clientDevice = await GetClientDevice();
        if (clientDevice == null)
            return new AuthenticationState()
            {
            };

        var clientIpAddress = await GetIpAddress();
        if (clientIpAddress == null)
            return new AuthenticationState()
            {
            };

        var clientBearer = await db.ClientBearers
            .OrderByDescending(a => a.Date)
            .FirstOrDefaultAsync(a =>
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
        var user = await db.Users
            .Include(a => a.CurrentCompany)
            .FirstOrDefaultAsync(a => a.Id == clientBearer.UserId);
        if (user == null)
            return new AuthenticationState()
            {
            };

        if (clientBearer.ClientIpAddressId != clientIpAddress.Id)
        {
            // Ip veranderd, toch automatisch vernieuwen
            clientBearer = await CreateBearer(user, clientDevice, clientIpAddress);
        }

        if (clientBearer.Date < shortago && clientBearer.Date > longago)
        {
            // Automatisch vernieuwen
            clientBearer = await CreateBearer(user, clientDevice, clientIpAddress);
        }

        // Get current company from database
        var currentcompany = user.CurrentCompany;

        var userJson = user.ToDto();
        var companyJson = currentcompany?.ToDto();

        return new AuthenticationState()
        {
            Success = true,

            User = userJson,
            CurrentCompany = companyJson,
            BearerId = clientBearer.Id,

            DbUser = user,
            DbCurrentCompany = currentcompany,
        };
    }
    public async Task<ClientBearer?> GetClientBearer(User dbuser)
    {
        var now = dateTime.GetNow();
        var shortago = now.AddHours(ShortHoursAgo);
        var longago = now.AddHours(LongHoursAgo);

        var clientDevice = await GetClientDevice();
        if (clientDevice == null) return null;

        var clientIpAddress = await GetIpAddress();
        if (clientIpAddress == null) return null;

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
            clientBearer = await CreateBearer(dbuser, clientDevice, clientIpAddress);
        }
        return clientBearer;
    }
    public async Task<User> CreateUser(string username, string email, string phoneNumber, string password)
    {
        // Create user
        var passwordHash = await StringHelper.HashString(password);
        var userid = await HashGeneratorHelper.GenerateCode(64);
        var dbuser = new User()
        {
            Id = userid,
            UserName = username,
            Email = email,
            PhoneNumber = phoneNumber,
            PasswordHash = passwordHash,
        };
        await db.Users.AddAsync(dbuser);
        await db.SaveChangesAsync();
        return dbuser;
    }

    public string? IpAddress => httpContextAccessor.HttpContext?.Connection.RemoteIpAddress?.ToString();
    public KeyValuePair<string, string?>[]? Headers => httpContextAccessor.HttpContext!.Request.Headers
        .Select(a => new KeyValuePair<string, string?>(a.Key, a.Value))
        .ToArray();

    internal async Task<ClientBearer> CreateBearer(User user, ClientDevice clientDevice, ClientIpAddress clientIpAddress)
    {
        // Te oud, vernieuwen
        var bearerid = await HashGeneratorHelper.GenerateCode(64);
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
        await db.ClientBearers.AddAsync(bearer);
        await db.SaveChangesAsync();
        return bearer;
    }
    internal async Task<ClientIpAddress?> GetIpAddress()
    {
        if (IpAddress == null)
            return null;

        var location = await db.ClientLocations.FirstOrDefaultAsync(a => a.IpAddress == IpAddress);
        if (location == null)
        {
            location = new ClientIpAddress()
            {
                IpAddress = IpAddress,
            };
            await db.ClientLocations.AddAsync(location);
            await db.SaveChangesAsync();
        }

        return location;
    }
    internal async Task<ClientDevice?> GetClientDevice()
    {
        if (Headers == null)
            return null;

        if (!Headers.Any(a => a.Key.ToLower() == "useragent" || a.Key.ToLower() == "user-agent"))
            return null;

        var useragentheader = Headers.First(a => a.Key.ToLower() == "useragent" || a.Key.ToLower() == "user-agent");
        var useragent = (useragentheader.Value ?? string.Empty).ToLower();

        if (useragent == null)
            return null;

        var deviceHash = await StringHelper.HashString(useragent);
        var device = await db.ClientDevices.FirstOrDefaultAsync(a => a.DeviceHash == deviceHash);
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
            await db.ClientDevices.AddAsync(device);
            await db.SaveChangesAsync();
        }

        return device;
    }

    internal static class HashGeneratorHelper
    {
        static Random random = new Random();
        static string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        internal static async Task<string> GenerateCode(int length)
        {
            return await Task.Run(() =>
            {
                char[] code = new char[length];
                for (int i = 0; i < length; i++)
                {
                    code[i] = chars[random.Next(chars.Length)];
                }
                return new string(code);
            });
        }
    }
    internal static class StringHelper
    {
        internal static async Task<string> HashString(string input)
        {
            using var sha256Hash = SHA256.Create();

            // Convert the input string to a byte array and compute the hash.
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(input));
            var data = await sha256Hash.ComputeHashAsync(stream);

            // Convert the byte array to a hexadecimal string.
            var builder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }
            return builder.ToString();

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
