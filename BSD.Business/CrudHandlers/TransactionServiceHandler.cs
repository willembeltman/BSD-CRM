using BSD.Business.Models;
using BSD.Data;
using BSD.Data.Entities;

namespace BSD.Business.ServiceHandlers;

public class TransactionServiceHandler
{
    private readonly AuthenticationState State;

    public TransactionServiceHandler(AuthenticationState authenticationState)
    {
        State = authenticationState;
    }

    public bool CanCreate(ApplicationDbContext db, Transaction entity) => State.DbUser != null;
    public bool CanRead(ApplicationDbContext db, Transaction entity) => true;
    public bool CanUpdate(ApplicationDbContext db, Transaction entity) => State.DbUser != null;
    public bool CanDelete(ApplicationDbContext db, Transaction entity) => State.DbUser != null;
    public bool CanList(ApplicationDbContext db) => true;

    public Transaction? FindByMatch(ApplicationDbContext db, BSD.Shared.Dtos.Transaction dto) => null;
    public Transaction? FindById(ApplicationDbContext db, long id) => db.Transactions.FirstOrDefault(a => a.Id == id);
    public IQueryable<Transaction> ListAll(ApplicationDbContext db) => db.Transactions;

    public bool AttachToState(ApplicationDbContext db, Transaction entity) => true;
    public bool UpdateToState(ApplicationDbContext db, Transaction entity, BSD.Shared.Dtos.Transaction dto) => true;
    public bool DeleteFromState(ApplicationDbContext db, Transaction entity) => true;
}
