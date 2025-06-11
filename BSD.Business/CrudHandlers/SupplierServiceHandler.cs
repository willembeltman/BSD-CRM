using BSD.Business.Models;
using BSD.Data;
using BSD.Data.Entities;

namespace BSD.Business.ServiceHandlers;

public class SupplierServiceHandler
{
    private readonly AuthenticationState State;

    public SupplierServiceHandler(AuthenticationState authenticationState)
    {
        State = authenticationState;
    }

    public bool CanCreate(ApplicationDbContext db, Supplier entity) => State.DbUser != null;
    public bool CanRead(ApplicationDbContext db, Supplier entity) => true;
    public bool CanUpdate(ApplicationDbContext db, Supplier entity) => State.DbUser != null;
    public bool CanDelete(ApplicationDbContext db, Supplier entity) => State.DbUser != null;
    public bool CanList(ApplicationDbContext db) => true;

    public Supplier? FindByMatch(ApplicationDbContext db, BSD.Shared.Dtos.Supplier dto) => null;
    public Supplier? FindById(ApplicationDbContext db, long id) => db.Suppliers.FirstOrDefault(a => a.Id == id);
    public IQueryable<Supplier> ListAll(ApplicationDbContext db) => db.Suppliers;

    public bool AttachToState(ApplicationDbContext db, Supplier entity) => true;
    public bool UpdateToState(ApplicationDbContext db, Supplier entity, BSD.Shared.Dtos.Supplier dto) => true;
    public bool DeleteFromState(ApplicationDbContext db, Supplier entity) => true;
}
