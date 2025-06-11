using BSD.Business.Models;
using BSD.Data;
using BSD.Data.Entities;

namespace BSD.Business.CrudHandlers;

public class CustomerServiceHandler
{
    private readonly AuthenticationState State;

    public CustomerServiceHandler(AuthenticationState authenticationState)
    {
        State = authenticationState;
    }

    public bool CanCreate(ApplicationDbContext db, Customer entity) => State.DbUser != null;
    public bool CanRead(ApplicationDbContext db, Customer entity) => true;
    public bool CanUpdate(ApplicationDbContext db, Customer entity) => State.DbUser != null;
    public bool CanDelete(ApplicationDbContext db, Customer entity) => State.DbUser != null;
    public bool CanList(ApplicationDbContext db) => true;

    public Customer? FindByMatch(ApplicationDbContext db, BSD.Shared.Dtos.Customer dto) => null;
    public Customer? FindById(ApplicationDbContext db, long id) => db.Customers.FirstOrDefault(a => a.Id == id);
    public IQueryable<Customer> ListAll(ApplicationDbContext db) => db.Customers;

    public bool AttachToState(ApplicationDbContext db, Customer entity) => true;
    public bool UpdateToState(ApplicationDbContext db, Customer entity, BSD.Shared.Dtos.Customer dto) => true;
    public bool DeleteFromState(ApplicationDbContext db, Customer entity) => true;
}
