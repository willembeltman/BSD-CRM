using CodeGenerator.DtoConvertersAndServices;

namespace CodeGenerator.Dtos_Converters_Services.Generators;

public class ServiceGenerator : BaseGenerator
{
    public ServiceGenerator(
        ServiceInterfaceGenerator serviceInterface,
        DirectoryInfo dtoConvertersDirectory,
        string dtoConvertersNamespace)
    {
    }

    public void GenerateCode()
    {
        //using BSD.Business.Interfaces;
        //using BSD.Data;
        //using BSD.Data.Converters;
        //using BSD.Business.Interfaces;
        //using BSD.Shared.RequestDtos;
        //using BSD.Shared.ResponseDtos;
        //using CodeGenerator.Shared.Attributes;
        //using Microsoft.EntityFrameworkCore;

        //namespace BSD.Business.Services;

        //public class CompanyService(
        //    ApplicationDbContext db,
        //    IAuthenticationStateService authenticationService)
        //    : ICompanyService
        //{
        //    CompanyConverter CompanyConverter = new CompanyConverter();

        //    [TsServiceMethod("Company", "Create")]
        //    public CompanyCreateResponse Create(CompanyCreateRequest request)
        //    {
        //        var state = authenticationService.GetState(request);
        //        if (!state.Success)
        //            return new CompanyCreateResponse()
        //            {
        //                ErrorAuthentication = true
        //            };

        //        if (state.User == null)
        //            return new CompanyCreateResponse();
        //        if (state.DbUser == null)
        //            return new CompanyCreateResponse();

        //        var dbCompany = db.Companies.FirstOrDefault(a =>
        //            a.Name == request.Company.Name &&
        //            a.CompanyUsers.Any(a => a.UserId == state.User.id));
        //        if (dbCompany != null)
        //            return new CompanyCreateResponse()
        //            {
        //                ErrorCompanyNameAlreadyUsed = true
        //            };

        //        // Convert it to db item
        //        dbCompany = CompanyConverter.Create(request.Company);
        //        if (dbCompany == null)
        //            return new CompanyCreateResponse();
        //        db.Companies.Add(dbCompany);
        //        db.SaveChanges();

        //        var dbCompanyuser = new Data.Entities.CompanyUser()
        //        {
        //            Company = dbCompany,
        //            CompanyId = dbCompany.Id,
        //            User = state.DbUser,
        //            UserId = state.DbUser.Id,
        //            Eigenaar = true,
        //            Admin = true,
        //            Actief = true,
        //        };
        //        db.CompanyUsers.Add(dbCompanyuser);
        //        db.SaveChanges();

        //        // Convert it back
        //        var company = CompanyConverter.Create(dbCompany);

        //        state.DbUser.CurrentCompany = dbCompany;
        //        state.DbUser.CurrentCompanyId = dbCompany.Id;
        //        state.User.currentCompanyId = dbCompany.Id;
        //        state.DbCurrentCompany = dbCompany;
        //        state.CurrentCompany = company;
        //        db.SaveChanges();

        //        return new CompanyCreateResponse()
        //        {
        //            Success = true,
        //            Company = company,
        //            State = state
        //        };
        //    }

        //    [TsServiceMethod("Company", "Read")]
        //    public CompanyReadResponse Read(CompanyReadRequest request)
        //    {
        //        if (request == null)
        //            return new CompanyReadResponse()
        //            {
        //                ErrorAuthentication = true
        //            };

        //        var state = authenticationService.GetState(request);
        //        if (!state.Success)
        //            return new CompanyReadResponse()
        //            {
        //                ErrorAuthentication = true
        //            };

        //        // ===========================

        //        if (state.User == null)
        //            return new CompanyReadResponse();

        //        var dbCompany = db.Companies
        //            .Include(a => a.Country)
        //            .FirstOrDefault(a =>
        //                a.Id == request.CompanyId &&
        //                a.CompanyUsers.Any(a => a.UserId == state.User.id));
        //        if (dbCompany == null)
        //            return new CompanyReadResponse()
        //            {
        //                CompanyNotFound = true
        //            };

        //        // Convert it back
        //        var company = CompanyConverter.Create(dbCompany);

        //        return new CompanyReadResponse()
        //        {
        //            Success = true,
        //            Company = company,
        //            State = state
        //        };
        //    }

        //    [TsServiceMethod("Company", "Update")]
        //    public CompanyUpdateResponse Update(CompanyUpdateRequest request)
        //    {
        //        if (request == null)
        //            return new CompanyUpdateResponse()
        //            {
        //                ErrorAuthentication = true
        //            };
        //        var state = authenticationService.GetState(request);
        //        if (!state.Success || state.User == null || state.DbUser == null)
        //            return new CompanyUpdateResponse()
        //            {
        //                ErrorAuthentication = true
        //            };

        //        var dbCompany = db.Companies.FirstOrDefault(a =>
        //            a.Id == request.Company.Id &&
        //            a.CompanyUsers.Any(a => a.UserId == state.User.id));
        //        if (dbCompany == null)
        //            return new CompanyUpdateResponse()
        //            {
        //                ErrorItemNotFound = true
        //            };

        //        // Convert it to db item
        //        if (CompanyConverter.Copy(request.Company, dbCompany) == true)
        //            db.SaveChanges();

        //        // Convert it back
        //        var company = CompanyConverter.Create(dbCompany);
        //        if (company == null)
        //            return new CompanyUpdateResponse()
        //            {
        //                ErrorItemNotFound = true
        //            };

        //        // Set current company to 
        //        state.User.currentCompanyId = company.Id;
        //        state.DbUser.CurrentCompanyId = dbCompany.Id;
        //        state.DbUser.CurrentCompany = dbCompany;
        //        state.CurrentCompany = company;
        //        state.DbCurrentCompany = dbCompany;
        //        db.SaveChanges();

        //        return new CompanyUpdateResponse()
        //        {
        //            Success = true,
        //            Company = company,
        //            State = state
        //        };
        //    }

        //    [TsServiceMethod("Company", "Delete")]
        //    public CompanyDeleteResponse Delete(CompanyDeleteRequest request)
        //    {
        //        if (request == null)
        //            return new CompanyDeleteResponse()
        //            {
        //                ErrorAuthentication = true
        //            };
        //        var state = authenticationService.GetState(request);
        //        if (!state.Success || state.User == null || state.DbUser == null)
        //            return new CompanyDeleteResponse()
        //            {
        //                ErrorAuthentication = true
        //            };

        //        var dbCompany = db.Companies
        //            .Include(a => a.CompanyUsers)
        //            .FirstOrDefault(a =>
        //                a.Id == request.CompanyId &&
        //                a.CompanyUsers.Any(b => b.UserId == state.User.id && (b.Admin || b.Eigenaar)));
        //        if (dbCompany == null)
        //            return new CompanyDeleteResponse()
        //            {
        //                ErrorItemNotFound = true
        //            };


        //        var userscurrentcompanywillbedeleted =
        //            state.DbUser.CurrentCompanyId == dbCompany.Id;

        //        if (userscurrentcompanywillbedeleted)
        //        {
        //            state.DbUser.CurrentCompany = null;
        //            state.DbCurrentCompany = null;
        //            state.CurrentCompany = null;
        //            state.User.currentCompanyId = null;
        //            state.DbUser.CurrentCompanyId = null;
        //        }

        //        db.CompanyUsers.RemoveRange(dbCompany.CompanyUsers);
        //        db.Companies.Remove(dbCompany);
        //        db.SaveChanges();

        //        return new CompanyDeleteResponse()
        //        {
        //            Success = true,
        //            State = state
        //        };
        //    }

        //    [TsServiceMethod("Company", "List")]
        //    public CompanyListResponse List(CompanyListRequest request)
        //    {
        //        if (request == null)
        //            return new CompanyListResponse()
        //            {
        //                ErrorAuthentication = true
        //            };

        //        var state = authenticationService.GetState(request);
        //        if (!state.Success || state.User == null || state.DbUser == null)
        //            return new CompanyListResponse()
        //            {
        //                ErrorAuthentication = true
        //            };

        //        var list = db.Companies
        //            .Where(a => a.CompanyUsers.Any(a => a.UserId == state.User.id))
        //            .Select(a => CompanyConverter.Create(a)!)
        //            .ToArray();

        //        return new CompanyListResponse()
        //        {
        //            Success = true,
        //            State = state,
        //            Companies = list
        //        };
        //    }
        //}
    }
}