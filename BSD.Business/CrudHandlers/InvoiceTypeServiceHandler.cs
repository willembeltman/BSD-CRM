using BSD.Business.Models;
using BSD.Data;
using BSD.Data.Entities;

namespace BSD.Business.CrudHandlers;

public class InvoiceTypeServiceHandler
{
    private readonly AuthenticationState State;

    public InvoiceTypeServiceHandler(AuthenticationState authenticationState)
    {
        State = authenticationState;
    }

    public bool CanCreate(ApplicationDbContext db, InvoiceType entity) => State.DbUser != null;
    public bool CanRead(ApplicationDbContext db, InvoiceType entity) => true;
    public bool CanUpdate(ApplicationDbContext db, InvoiceType entity) => State.DbUser != null;
    public bool CanDelete(ApplicationDbContext db, InvoiceType entity) => State.DbUser != null;
    public bool CanList(ApplicationDbContext db) => true;

    public InvoiceType? FindByMatch(ApplicationDbContext db, BSD.Shared.Dtos.InvoiceType dto) => null;
    public InvoiceType? FindById(ApplicationDbContext db, long id) => db.InvoiceTypes.FirstOrDefault(a => a.Id == id);
    public IQueryable<InvoiceType> ListAll(ApplicationDbContext db) => db.InvoiceTypes;

    public bool AttachToState(ApplicationDbContext db, InvoiceType entity) => true;
    public bool UpdateToState(ApplicationDbContext db, InvoiceType entity, BSD.Shared.Dtos.InvoiceType dto) => true;
    public bool DeleteFromState(ApplicationDbContext db, InvoiceType entity) => true;
}
