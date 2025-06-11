using BSD.Business.Converters;
using BSD.Business.CrudHandlers;
using BSD.Business.Interfaces;
using BSD.Data;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using CodeGenerator.Shared.Attributes;

namespace BSD.Business.CrudServices;

public class CustomerService(
    ApplicationDbContext db,
    IAuthenticationStateService authenticationService)
    : ICustomerService
{
    [TsServiceMethod("Customer", "Create")]
    public CustomerCreateResponse Create(CustomerCreateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new CustomerCreateResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new CustomerCreateResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new CustomerServiceHandler(state);
        var entity = handler.FindByMatch(db, request.Customer);
        if (entity != null)
            return new CustomerCreateResponse() { State = state, ErrorAlreadyUsed = true };

        entity = request.Customer.ToEntity();
        if (!handler.AttachToState(db, entity))
            return new CustomerCreateResponse() { State = state, ErrorAttachingState = true };

        if (!handler.CanCreate(db, entity))
            return new CustomerCreateResponse() { State = state, ErrorNotAuthorized = true };

        db.Customers.Add(entity);
        db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new CustomerCreateResponse() { State = state, ErrorUpdatingState = true };

        return new CustomerCreateResponse() { State = state, Customer = dto, Success = true };
    }

    [TsServiceMethod("Customer", "Read")]
    public CustomerReadResponse Read(CustomerReadRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new CustomerReadResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new CustomerReadResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new CustomerServiceHandler(state);
        var entity = handler.FindById(db, request.CustomerId);
        if (entity == null)
            return new CustomerReadResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanRead(db, entity))
            return new CustomerReadResponse() { State = state, ErrorNotAuthorized = true };

        var dto = entity.ToDto();
        return new CustomerReadResponse() { State = state, Customer = dto, Success = true, };
    }

    [TsServiceMethod("Customer", "Update")]
    public CustomerUpdateResponse Update(CustomerUpdateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new CustomerUpdateResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new CustomerUpdateResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new CustomerServiceHandler(state);
        var entity = handler.FindById(db, request.Customer.Id);
        if (entity == null)
            return new CustomerUpdateResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanUpdate(db, entity))
            return new CustomerUpdateResponse() { State = state, ErrorNotAuthorized = true };

        if (request.Customer.CopyTo(entity))
            db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new CustomerUpdateResponse() { State = state, ErrorUpdatingState = true };

        return new CustomerUpdateResponse() { State = state, Customer = dto, Success = true };
    }

    [TsServiceMethod("Customer", "Delete")]
    public CustomerDeleteResponse Delete(CustomerDeleteRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new CustomerDeleteResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new CustomerDeleteResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new CustomerServiceHandler(state);
        var entity = handler.FindById(db, request.CustomerId);
        if (entity == null)
            return new CustomerDeleteResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanDelete(db, entity))
            return new CustomerDeleteResponse() { State = state, ErrorNotAuthorized = true };

        if (!handler.DeleteFromState(db, entity))
            return new CustomerDeleteResponse() { State = state, ErrorUpdatingState = true };

        db.Customers.Remove(entity);
        db.SaveChanges();

        return new CustomerDeleteResponse() { State = state, Success = true };
    }

    [TsServiceMethod("Customer", "List")]
    public CustomerListResponse List(CustomerListRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new CustomerListResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new CustomerListResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new CustomerServiceHandler(state);
        if (!handler.CanList(db))
            return new CustomerListResponse() { State = state, ErrorNotAuthorized = true };

        var entities = handler.ListAll(db);
        var dtos = entities
            .Select(a => a.ToDto()!)
            .ToArray();

        return new CustomerListResponse()
        {
            Success = true,
            State = state,
            Customers = dtos
        };
    }
}