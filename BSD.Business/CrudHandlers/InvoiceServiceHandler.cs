using BSD.Business.Models;
using BSD.Data;
using BSD.Data.Entities;

namespace BSD.Business.ServiceHandlers;

public class InvoiceServiceHandler
{
    private readonly AuthenticationState State;

    public InvoiceServiceHandler(AuthenticationState authenticationState)
    {
        State = authenticationState;
    }

    public bool CanCreate(ApplicationDbContext db, Invoice entity) => State.DbUser != null;
    public bool CanRead(ApplicationDbContext db, Invoice entity) => true;
    public bool CanUpdate(ApplicationDbContext db, Invoice entity) => State.DbUser != null;
    public bool CanDelete(ApplicationDbContext db, Invoice entity) => State.DbUser != null;
    public bool CanList(ApplicationDbContext db) => true;

    public Invoice? FindByMatch(ApplicationDbContext db, BSD.Shared.Dtos.Invoice dto) => null;
    public Invoice? FindById(ApplicationDbContext db, long id) => db.Invoices.FirstOrDefault(a => a.Id == id);
    public IQueryable<Invoice> ListAll(ApplicationDbContext db) => db.Invoices;

    public bool AttachToState(ApplicationDbContext db, Invoice entity) => true;
    public bool UpdateToState(ApplicationDbContext db, Invoice entity, BSD.Shared.Dtos.Invoice dto) => true;
    public bool DeleteFromState(ApplicationDbContext db, Invoice entity) => true;
}
