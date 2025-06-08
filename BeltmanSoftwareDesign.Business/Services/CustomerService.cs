using BeltmanSoftwareDesign.Business.Interfaces;
using BeltmanSoftwareDesign.Data;
using BeltmanSoftwareDesign.Data.Converters;
using BeltmanSoftwareDesign.Shared.RequestJsons;
using BeltmanSoftwareDesign.Shared.ResponseJsons;
using CodeGenerator.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace BeltmanSoftwareDesign.Business.Services;

[Authorize, TsService]
public class CustomerService(
    ApplicationDbContext db,
    IAuthenticationService authenticationService) : ICustomerService
{
    CustomerConverter CustomerConverter = new CustomerConverter();

    [TsServiceMethod("Customer", "Create")]
    public CustomerCreateResponse Create(CustomerCreateRequest request)
    {
        var authentication = authenticationService.GetState(
            request);
        if (!authentication.Success)
            return new CustomerCreateResponse()
            {
                ErrorAuthentication = true
            };

        if (authentication.DbCurrentCompany == null)
            throw new Exception("Current company not chosen or doesn't exist, please create a company or select one.");

        var dbcustomer = CustomerConverter.Create(request.Customer);

        dbcustomer.Company = authentication.DbCurrentCompany;
        dbcustomer.CompanyId = authentication.DbCurrentCompany.id;

        db.Customers.Add(dbcustomer);
        db.SaveChanges();

        return new CustomerCreateResponse()
        {
            Success = true,
            State = authentication,
            Customer = CustomerConverter.Create(dbcustomer)
        };
    }

    [TsServiceMethod("Customer", "Read")]
    public CustomerReadResponse Read(CustomerReadRequest request)
    {
        var authentication = authenticationService.GetState(
            request);
        if (!authentication.Success)
            return new CustomerReadResponse()
            {
                ErrorAuthentication = true
            };

        if (authentication.DbCurrentCompany == null)
            throw new Exception("Current company not chosen or doesn't exist, please create a company or select one.");

        var dbcustomer = db.Customers
            .Include(a => a.Country)
            .Include(a => a.Workorders)
            .Include(a => a.Projects)
            .Include(a => a.Invoices)
            .Include(a => a.Expenses)
            .Include(a => a.Documents)
            .FirstOrDefault(a => 
                a.CompanyId == authentication.DbCurrentCompany.id &&
                a.id == request.CustomerId);

        if (dbcustomer == null)
            return new CustomerReadResponse()
            {
                ErrorItemNotFound = true
            };

        return new CustomerReadResponse()
        {
            Success = true,
            State = authentication,
            Customer = CustomerConverter.Create(dbcustomer)
        };
    }

    [TsServiceMethod("Customer", "Update")]
    public CustomerUpdateResponse Update(CustomerUpdateRequest request)
    {
        var authentication = authenticationService.GetState(
            request);
        if (!authentication.Success)
            return new CustomerUpdateResponse()
            {
                ErrorAuthentication = true
            };

        if (authentication.DbCurrentCompany == null)
            throw new Exception("Current company not chosen or doesn't exist, please create a company or select one.");

        var dbcustomer = db.Customers
            .Include(a => a.Country)
            .Include(a => a.Workorders)
            .Include(a => a.Projects)
            .Include(a => a.Invoices)
            .Include(a => a.Expenses)
            .Include(a => a.Documents)
            .FirstOrDefault(a =>
                a.CompanyId == authentication.DbCurrentCompany.id &&
                a.id == request.Customer.id);
        if (dbcustomer == null)
            return new CustomerUpdateResponse()
            {
                ErrorItemNotFound = true,
            };

        if (CustomerConverter.Copy(request.Customer, dbcustomer))
            db.SaveChanges();

        return new CustomerUpdateResponse()
        {
            Success = true,
            State = authentication,
            Customer = CustomerConverter.Create(dbcustomer)
        };
    }

    [TsServiceMethod("Customer", "Delete")]
    public CustomerDeleteResponse Delete(CustomerDeleteRequest request)
    {
        var authentication = authenticationService.GetState(
            request);
        if (!authentication.Success)
            return new CustomerDeleteResponse()
            {
                ErrorAuthentication = true
            };

        if (authentication.DbCurrentCompany == null)
            throw new Exception("Current company not chosen or doesn't exist, please create a company or select one.");

        var dbcustomer = db.Customers
            .Include(a => a.Country)
            .Include(a => a.Workorders)
            .Include(a => a.Projects)
            .Include(a => a.Invoices)
            .Include(a => a.Expenses)
            .Include(a => a.Documents)
            .FirstOrDefault(a =>
                a.CompanyId == authentication.DbCurrentCompany.id &&
                a.id == request.CustomerId);

        if (dbcustomer == null)
            return new CustomerDeleteResponse()
            {
                ErrorItemNotFound = true,
                State = authentication
            };

        db.Customers.Remove(dbcustomer);
        db.SaveChanges();

        return new CustomerDeleteResponse()
        {
            Success = true,
            State = authentication
        };
    }

    [TsServiceMethod("Customer", "List")]
    public CustomerListResponse List(CustomerListRequest request)
    {
        var authentication = authenticationService.GetState(
            request);
        if (!authentication.Success)
            return new CustomerListResponse()
            {
                ErrorAuthentication = true
            };

        if (authentication.DbCurrentCompany == null)
            throw new Exception("Current company not chosen or doesn't exist, please create a company or select one.");

        var list = db.Customers
            .Include(a => a.Country)
            .Include(a => a.Workorders)
            .Include(a => a.Projects)
            .Include(a => a.Invoices)
            .Include(a => a.Expenses)
            .Include(a => a.Documents)
            .Where(a => 
                a.CompanyId == authentication.DbCurrentCompany.id)
            .Select(a => CustomerConverter.Create(a))
            .ToArray();

        return new CustomerListResponse()
        {
            Success = true,
            State = authentication,
            Customers = list
        };
    }
}
