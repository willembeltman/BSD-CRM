using BeltmanSoftwareDesign.Business.Helpers;
using BeltmanSoftwareDesign.Data;
using BeltmanSoftwareDesign.Data.Entities;
using Microsoft.AspNetCore.Http;

namespace BeltmanSoftwareDesign.Business.Services;

public class AuthenticationBaseService(
    IHttpContextAccessor httpContextAccessor,
    ApplicationDbContext db)
{
    public string? IpAddress => httpContextAccessor.HttpContext?.Connection.RemoteIpAddress?.ToString();
    public KeyValuePair<string, string?>[]? Headers => httpContextAccessor.HttpContext!.Request.Headers
        .Select(a => new KeyValuePair<string, string?>(a.Key, a.Value))
        .ToArray();

    protected ClientBearer CreateBearer(User user, ClientDevice clientDevice, ClientIpAddress clientIpAddress)
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
    protected User CreateUser(string username, string email, string phoneNumber, string password)
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
    protected ClientIpAddress? GetIpAddress()
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
    protected ClientDevice? GetClientDevice()
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