using BSD.Business.Interfaces;
using BSD.Data;
using BSD.Data.Converters;
using BSD.Business.Interfaces;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using CodeGenerator.Shared.Attributes;
using Microsoft.EntityFrameworkCore;

namespace BSD.Business.Services;

public class CompanyService(
    ApplicationDbContext db,
    IAuthenticationStateService authenticationService)
    : ICompanyService
{
    CompanyConverter CompanyConverter = new CompanyConverter();

    [TsServiceMethod("Company", "Create")]
    public CompanyCreateResponse Create(CompanyCreateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new CompanyCreateResponse()
            {
                ErrorAuthentication = true
            };

        if (state.User == null)
            return new CompanyCreateResponse();
        if (state.DbUser == null)
            return new CompanyCreateResponse();

        var dbcompany = db.Companies.FirstOrDefault(a =>
            a.Name == request.Company.Name &&
            a.CompanyUsers.Any(a => a.UserId == state.User.id));
        if (dbcompany != null)
            return new CompanyCreateResponse()
            {
                ErrorCompanyNameAlreadyUsed = true
            };

        // Convert it to db item
        dbcompany = CompanyConverter.Create(request.Company);
        if (dbcompany == null)
            return new CompanyCreateResponse();
        db.Companies.Add(dbcompany);
        db.SaveChanges();

        var dbcompanyuser = new Data.Entities.CompanyUser()
        {
            Company = dbcompany,
            CompanyId = dbcompany.Id,
            User = state.DbUser,
            UserId = state.DbUser.Id,
            Eigenaar = true,
            Admin = true,
            Actief = true,
        };
        db.CompanyUsers.Add(dbcompanyuser);
        db.SaveChanges();

        // Convert it back
        var company = CompanyConverter.Create(dbcompany);

        state.DbUser.CurrentCompany = dbcompany;
        state.DbUser.CurrentCompanyId = dbcompany.Id;
        state.User.currentCompanyId = dbcompany.Id;
        state.DbCurrentCompany = dbcompany;
        state.CurrentCompany = company;
        db.SaveChanges();

        return new CompanyCreateResponse()
        {
            Success = true,
            Company = company,
            State = state
        };
    }

    [TsServiceMethod("Company", "Read")]
    public CompanyReadResponse Read(CompanyReadRequest request)
    {
        if (request == null)
            return new CompanyReadResponse()
            {
                ErrorAuthentication = true
            };

        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new CompanyReadResponse()
            {
                ErrorAuthentication = true
            };

        // ===========================

        if (state.User == null)
            return new CompanyReadResponse();

        var dbcompany = db.Companies
            .Include(a => a.Country)
            .FirstOrDefault(a =>
                a.Id == request.CompanyId &&
                a.CompanyUsers.Any(a => a.UserId == state.User.id));
        if (dbcompany == null)
            return new CompanyReadResponse()
            {
                CompanyNotFound = true
            };

        // Convert it back
        var company = CompanyConverter.Create(dbcompany);

        return new CompanyReadResponse()
        {
            Success = true,
            Company = company,
            State = state
        };
    }

    [TsServiceMethod("Company", "Update")]
    public CompanyUpdateResponse Update(CompanyUpdateRequest request)
    {
        if (request == null)
            return new CompanyUpdateResponse()
            {
                ErrorAuthentication = true
            };
        var state = authenticationService.GetState(request);
        if (!state.Success || state.User == null || state.DbUser == null)
            return new CompanyUpdateResponse()
            {
                ErrorAuthentication = true
            };

        // ===========================

        var dbcompany = db.Companies.FirstOrDefault(a =>
            a.Id == request.Company.Id &&
            a.CompanyUsers.Any(a => a.UserId == state.User.id));
        if (dbcompany == null)
            return new CompanyUpdateResponse()
            {
                ErrorItemNotFound = true
            };

        // Convert it to db item
        if (CompanyConverter.Copy(request.Company, dbcompany) == true)
            db.SaveChanges();

        // Convert it back
        var company = CompanyConverter.Create(dbcompany);
        if (company == null)
            return new CompanyUpdateResponse()
            {
                ErrorItemNotFound = true
            };

        // Set current company to 
        state.User.currentCompanyId = company.Id;
        state.DbUser.CurrentCompanyId = dbcompany.Id;
        state.DbUser.CurrentCompany = dbcompany;
        state.CurrentCompany = company;
        state.DbCurrentCompany = dbcompany;
        db.SaveChanges();

        return new CompanyUpdateResponse()
        {
            Success = true,
            Company = company,
            State = state
        };
    }

    [TsServiceMethod("Company", "Delete")]
    public CompanyDeleteResponse Delete(CompanyDeleteRequest request)
    {
        if (request == null)
            return new CompanyDeleteResponse()
            {
                ErrorAuthentication = true
            };
        var state = authenticationService.GetState(request);
        if (!state.Success || state.User == null || state.DbUser == null)
            return new CompanyDeleteResponse()
            {
                ErrorAuthentication = true
            };

        // ===========================

        var dbcompany = db.Companies
            .Include(a => a.CompanyUsers)
            .FirstOrDefault(a =>
                a.Id == request.CompanyId &&
                a.CompanyUsers.Any(b => b.UserId == state.User.id && (b.Admin || b.Eigenaar)));
        if (dbcompany == null)
            return new CompanyDeleteResponse()
            {
                ErrorItemNotFound = true
            };


        var userscurrentcompanywillbedeleted =
            state.DbUser.CurrentCompanyId == dbcompany.Id;

        if (userscurrentcompanywillbedeleted)
        {
            state.DbUser.CurrentCompany = null;
            state.DbCurrentCompany = null;
            state.CurrentCompany = null;
            state.User.currentCompanyId = null;
            state.DbUser.CurrentCompanyId = null;
        }

        db.CompanyUsers.RemoveRange(dbcompany.CompanyUsers);
        db.Companies.Remove(dbcompany);
        db.SaveChanges();

        return new CompanyDeleteResponse()
        {
            Success = true,
            State = state
        };
    }

    [TsServiceMethod("Company", "List")]
    public CompanyListResponse List(CompanyListRequest request)
    {
        if (request == null)
            return new CompanyListResponse()
            {
                ErrorAuthentication = true
            };

        var state = authenticationService.GetState(request);
        if (!state.Success || state.User == null || state.DbUser == null)
            return new CompanyListResponse()
            {
                ErrorAuthentication = true
            };

        var list = db.Companies
            .Where(a => a.CompanyUsers.Any(a => a.UserId == state.User.id))
            .Select(a => CompanyConverter.Create(a)!)
            .ToArray();

        return new CompanyListResponse()
        {
            Success = true,
            State = state,
            Companies = list
        };
    }
}
