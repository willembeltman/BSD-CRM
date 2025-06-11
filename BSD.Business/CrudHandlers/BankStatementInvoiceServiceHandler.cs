using BSD.Business.Models;
using BSD.Data;
using BSD.Data.Entities;

namespace BSD.Business.ServiceHandlers;

public class BankStatementInvoiceServiceHandler
{
    private readonly AuthenticationState State;

    public BankStatementInvoiceServiceHandler(AuthenticationState authenticationState)
    {
        State = authenticationState;
    }

    public bool CanCreate(ApplicationDbContext db, BankStatementInvoice entity) => State.DbUser != null;
    public bool CanRead(ApplicationDbContext db, BankStatementInvoice entity) => true;
    public bool CanUpdate(ApplicationDbContext db, BankStatementInvoice entity) => State.DbUser != null;
    public bool CanDelete(ApplicationDbContext db, BankStatementInvoice entity) => State.DbUser != null;
    public bool CanList(ApplicationDbContext db) => true;

    public BankStatementInvoice? FindByMatch(ApplicationDbContext db, BSD.Shared.Dtos.BankStatementInvoice dto) => null;
    public BankStatementInvoice? FindById(ApplicationDbContext db, long id) => db.BankStatementInvoices.FirstOrDefault(a => a.Id == id);
    public IQueryable<BankStatementInvoice> ListAll(ApplicationDbContext db) => db.BankStatementInvoices;

    public bool AttachToState(ApplicationDbContext db, BankStatementInvoice entity) => true;
    public bool UpdateToState(ApplicationDbContext db, BankStatementInvoice entity, BSD.Shared.Dtos.BankStatementInvoice dto) => true;
    public bool DeleteFromState(ApplicationDbContext db, BankStatementInvoice entity) => true;
}
