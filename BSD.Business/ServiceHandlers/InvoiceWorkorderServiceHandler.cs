using BSD.Business.Models;
using BSD.Data;
using BSD.Data.Entities;

namespace BSD.Business.ServiceHandlers;

public class InvoiceWorkorderServiceHandler
{
    private readonly AuthenticationState State;

    public InvoiceWorkorderServiceHandler(AuthenticationState authenticationState)
    {
        State = authenticationState;
    }

    public bool CanCreate(ApplicationDbContext db, InvoiceWorkorder entity) => State.DbUser != null;
    public bool CanRead(ApplicationDbContext db, InvoiceWorkorder entity) => true;
    public bool CanUpdate(ApplicationDbContext db, InvoiceWorkorder entity) => State.DbUser != null;
    public bool CanDelete(ApplicationDbContext db, InvoiceWorkorder entity) => State.DbUser != null;
    public bool CanList(ApplicationDbContext db) => true;

    public InvoiceWorkorder? FindByMatch(ApplicationDbContext db, BSD.Shared.Dtos.InvoiceWorkorder dto) => null;
    public InvoiceWorkorder? FindById(ApplicationDbContext db, long id) => db.InvoiceWorkorders.FirstOrDefault(a => a.Id == id);
    public IQueryable<InvoiceWorkorder> ListAll(ApplicationDbContext db) => db.InvoiceWorkorders;

    public bool AttachToState(ApplicationDbContext db, InvoiceWorkorder entity) => true;
    public bool UpdateToState(ApplicationDbContext db, InvoiceWorkorder entity, BSD.Shared.Dtos.InvoiceWorkorder dto) => true;
    public bool DeleteFromState(ApplicationDbContext db, InvoiceWorkorder entity) => true;
}
