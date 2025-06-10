using BSD.Business.Models;
using BSD.Data;
using BSD.Data.Entities;

namespace BSD.Business.ServiceHandlers;

public class InvoiceRowServiceHander
{
    private readonly AuthenticationState State;

    public InvoiceRowServiceHander(AuthenticationState authenticationState)
    {
        State = authenticationState;
    }

    public bool CanCreate(ApplicationDbContext db, InvoiceRow entity) => State.DbUser != null;
    public bool CanRead(ApplicationDbContext db, InvoiceRow entity) => true;
    public bool CanUpdate(ApplicationDbContext db, InvoiceRow entity) => State.DbUser != null;
    public bool CanDelete(ApplicationDbContext db, InvoiceRow entity) => State.DbUser != null;
    public bool CanList(ApplicationDbContext db) => true;

    public InvoiceRow? FindByMatch(ApplicationDbContext db, BSD.Shared.Dtos.InvoiceRow dto) => db.InvoiceRows.FirstOrDefault(a => a.Id == dto.Id);
    public InvoiceRow? FindById(ApplicationDbContext db, long id) => db.InvoiceRows.FirstOrDefault(a => a.Id == id);
    public IQueryable<InvoiceRow> ListAll(ApplicationDbContext db) => db.InvoiceRows;

    public bool AttachToState(ApplicationDbContext db, InvoiceRow entity) => true;
    public bool UpdateToState(ApplicationDbContext db, InvoiceRow entity, BSD.Shared.Dtos.InvoiceRow dto) => true;
    public bool DeleteFromState(ApplicationDbContext db, InvoiceRow entity) => true;
}
