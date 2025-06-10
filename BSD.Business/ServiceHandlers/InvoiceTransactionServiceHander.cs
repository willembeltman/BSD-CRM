using BSD.Business.Models;
using BSD.Data;
using BSD.Data.Entities;

namespace BSD.Business.ServiceHandlers;

public class InvoiceTransactionServiceHander
{
    private readonly AuthenticationState State;

    public InvoiceTransactionServiceHander(AuthenticationState authenticationState)
    {
        State = authenticationState;
    }

    public bool CanCreate(ApplicationDbContext db, InvoiceTransaction entity) => State.DbUser != null;
    public bool CanRead(ApplicationDbContext db, InvoiceTransaction entity) => true;
    public bool CanUpdate(ApplicationDbContext db, InvoiceTransaction entity) => State.DbUser != null;
    public bool CanDelete(ApplicationDbContext db, InvoiceTransaction entity) => State.DbUser != null;
    public bool CanList(ApplicationDbContext db) => true;

    public InvoiceTransaction? FindByMatch(ApplicationDbContext db, BSD.Shared.Dtos.InvoiceTransaction dto) => db.InvoiceTransactions.FirstOrDefault(a => a.Id == dto.Id);
    public InvoiceTransaction? FindById(ApplicationDbContext db, long id) => db.InvoiceTransactions.FirstOrDefault(a => a.Id == id);
    public IQueryable<InvoiceTransaction> ListAll(ApplicationDbContext db) => db.InvoiceTransactions;

    public bool AttachToState(ApplicationDbContext db, InvoiceTransaction entity) => true;
    public bool UpdateToState(ApplicationDbContext db, InvoiceTransaction entity, BSD.Shared.Dtos.InvoiceTransaction dto) => true;
    public bool DeleteFromState(ApplicationDbContext db, InvoiceTransaction entity) => true;
}
