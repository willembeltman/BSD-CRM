using BeltmanSoftwareDesign.Business.Interfaces;
using BeltmanSoftwareDesign.Data;
using BeltmanSoftwareDesign.Data.Converters;
using BeltmanSoftwareDesign.Shared.RequestJsons;
using BeltmanSoftwareDesign.Shared.ResponseJsons;
using CodeGenerator.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using StorageServer.Proxy;

namespace BeltmanSoftwareDesign.Business.Services;

[Authorize, TsService]
public class WorkorderService(
    ApplicationDbContext db, 
    IAuthenticationService authenticationService) : IWorkorderService
{
    WorkorderConverter WorkorderConverter = new WorkorderConverter();

    [TsServiceMethod("Workorder", "Create")]
    public async Task<WorkorderCreateResponse> CreateAsync(WorkorderCreateRequest request)
    {
        var authentication = authenticationService.GetState(
            request);
        if (!authentication.Success)
            return new WorkorderCreateResponse()
            {
                ErrorAuthentication = true
            };

        if (authentication.DbCurrentCompany == null)
            throw new Exception("Current company not chosen or doesn't exist, please create a company or select one.");

        var dbworkorder = WorkorderConverter.Create(request.Workorder, authentication.DbCurrentCompany, db);
        db.Workorders.Add(dbworkorder);
        db.SaveChanges();

        return new WorkorderCreateResponse()
        {
            Success = true,
            State = authentication,
            Workorder = await WorkorderConverter.CreateAsync(dbworkorder)
        };
    }

    [TsServiceMethod("Workorder", "Read")]
    public async Task< WorkorderReadResponse> ReadAsync(WorkorderReadRequest request)
    {
        var authentication = authenticationService.GetState(
            request);
        if (!authentication.Success)
            return new WorkorderReadResponse()
            {
                ErrorAuthentication = true
            };

        if (authentication.DbCurrentCompany == null)
            throw new Exception("Current company not chosen or doesn't exist, please create a company or select one.");

        var dbworkorder = db.Workorders
            .Include(a => a.Company)
            .Include(a => a.Customer)
            .Include(a => a.Project)
            .Include(a => a.InvoiceWorkorders)
            .Include(a => a.WorkorderAttachments)
            .FirstOrDefault(a =>
                a.CompanyId == authentication.DbCurrentCompany.id && 
                a.id == request.WorkorderId);
        if (dbworkorder == null)
            return new WorkorderReadResponse()
            {
                ErrorItemNotFound = true,
                State = authentication
            };

        return new WorkorderReadResponse()
        {
            Success = true,
            State = authentication,
            Workorder = await WorkorderConverter.CreateAsync(dbworkorder)
        };
    }

    [TsServiceMethod("Workorder", "Update")]
    public async Task<WorkorderUpdateResponse> UpdateAsync(WorkorderUpdateRequest request)
    {
        var authentication = authenticationService.GetState(
            request);
        if (!authentication.Success)
            return new WorkorderUpdateResponse()
            {
                ErrorAuthentication = true
            };

        if (authentication.DbCurrentCompany == null)
            throw new Exception("Current company not chosen or doesn't exist, please create a company or select one.");

        var dbworkorder = db.Workorders
            .Include(a => a.Company)
            .Include(a => a.Customer)
            .Include(a => a.Project)
            .Include(a => a.InvoiceWorkorders)
            .Include(a => a.WorkorderAttachments)
            .FirstOrDefault(a =>
                a.CompanyId == authentication.DbCurrentCompany.id &&
                a.id == request.Workorder.id);
        if (dbworkorder == null)
            return new WorkorderUpdateResponse()
            {
                ErrorItemNotFound = true,
                State = authentication
            };

        if (WorkorderConverter.Copy(request.Workorder, dbworkorder, authentication.DbCurrentCompany, db))
            db.SaveChanges();

        return new WorkorderUpdateResponse()
        {
            Success = true,
            State = authentication,
            Workorder = await WorkorderConverter.CreateAsync(dbworkorder)
        };
    }

    [TsServiceMethod("Workorder", "Delete")]
    public async Task<WorkorderDeleteResponse> DeleteAsync(WorkorderDeleteRequest request)
    {
        var authentication = authenticationService.GetState(
            request);
        if (!authentication.Success)
            return new WorkorderDeleteResponse()
            {
                ErrorAuthentication = true
            };

        if (authentication.DbCurrentCompany == null)
            throw new Exception("Current company not chosen or doesn't exist, please create a company or select one.");

        var dbworkorder = db.Workorders
            .Include(a => a.Company)
            .Include(a => a.Customer)
            .Include(a => a.Project)
            .Include(a => a.InvoiceWorkorders)
            .Include(a => a.WorkorderAttachments)
            .FirstOrDefault(a =>
                a.CompanyId == authentication.DbCurrentCompany.id && 
                a.id == request.WorkorderId);
        if (dbworkorder == null)
            return new WorkorderDeleteResponse()
            {
                ErrorItemNotFound = true,
                State = authentication
            };

        foreach (var att in dbworkorder.WorkorderAttachments)
        {
            await att.Delete();
        }

        db.Workorders.Remove(dbworkorder);
        db.SaveChanges();

        return new WorkorderDeleteResponse()
        {
            Success = true,
            State = authentication
        };
    }

    [TsServiceMethod("Workorder", "List")]
    public async Task<WorkorderListResponse> ListAsync(WorkorderListRequest request)
    {
        var authentication = authenticationService.GetState(
            request);
        if (!authentication.Success)
            return new WorkorderListResponse()
            {
                ErrorAuthentication = true
            };

        if (authentication.DbCurrentCompany == null)
            throw new Exception("Current company not chosen or doesn't exist, please create a company or select one.");

        var dbworkorders = await db.Workorders
            .Include(a => a.Company)
            .Include(a => a.Customer)
            .Include(a => a.Project)
            .Include(a => a.InvoiceWorkorders)
            .Include(a => a.WorkorderAttachments)
            .Where(a => a.CompanyId == authentication.DbCurrentCompany.id)
            .ToListAsync();

        var list = new List<Shared.Jsons.Workorder>();
        foreach (var dbworkorder in dbworkorders)
        {
            list.Add(await WorkorderConverter.CreateAsync(dbworkorder));
        }

        return new WorkorderListResponse()
        {
            Success = true,
            State = authentication,
            Workorders = list.ToArray()
        };
    }
}
