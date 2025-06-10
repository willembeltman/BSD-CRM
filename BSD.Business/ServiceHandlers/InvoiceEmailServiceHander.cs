using BSD.Business.Models;
using BSD.Data;
using BSD.Data.Entities;

namespace BSD.Business.ServiceHandlers;

public class InvoiceEmailServiceHander
{
    private readonly AuthenticationState State;

    public InvoiceEmailServiceHander(AuthenticationState authenticationState)
    {
        State = authenticationState;
    }

    public bool CanCreate(ApplicationDbContext db, InvoiceEmail entity) => State.DbUser != null;
    public bool CanRead(ApplicationDbContext db, InvoiceEmail entity) => true;
    public bool CanUpdate(ApplicationDbContext db, InvoiceEmail entity) => State.DbUser != null;
    public bool CanDelete(ApplicationDbContext db, InvoiceEmail entity) => State.DbUser != null;
    public bool CanList(ApplicationDbContext db) => true;

    public InvoiceEmail? FindByMatch(ApplicationDbContext db, BSD.Shared.Dtos.InvoiceEmail dto) => db.InvoiceEmails.FirstOrDefault(a => a.Id == dto.Id);
    public InvoiceEmail? FindById(ApplicationDbContext db, long id) => db.InvoiceEmails.FirstOrDefault(a => a.Id == id);
    public IQueryable<InvoiceEmail> ListAll(ApplicationDbContext db) => db.InvoiceEmails;

    public bool AttachToState(ApplicationDbContext db, InvoiceEmail entity) => true;
    public bool UpdateToState(ApplicationDbContext db, InvoiceEmail entity, BSD.Shared.Dtos.InvoiceEmail dto) => true;
    public bool DeleteFromState(ApplicationDbContext db, InvoiceEmail entity) => true;
}
