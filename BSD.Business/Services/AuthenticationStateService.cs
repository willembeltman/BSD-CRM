using BSD.Business.Interfaces;
using BSD.Business.Models;
using BSD.Data;
using BSD.Business.Converters;
using BSD.Shared.RequestDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BSD.Business.Services;

public class AuthenticationStateService(
    IHttpContextAccessor httpContextAccessor,
    ApplicationDbContext db,
    IDateTimeService dateTime)
    : AuthenticationBaseService(httpContextAccessor, db),
    IAuthenticationStateService
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


}
