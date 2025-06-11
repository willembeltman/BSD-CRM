using BSD.Business.Models;
using BSD.Data;
using BSD.Data.Entities;

namespace BSD.Business.ServiceHandlers;

public class TransactionLogServiceHandler
{
    private readonly AuthenticationState State;

    public TransactionLogServiceHandler(AuthenticationState authenticationState)
    {
        State = authenticationState;
    }

    public bool CanCreate(ApplicationDbContext db, TransactionLog entity) => State.DbUser != null;
    public bool CanRead(ApplicationDbContext db, TransactionLog entity) => true;
    public bool CanUpdate(ApplicationDbContext db, TransactionLog entity) => State.DbUser != null;
    public bool CanDelete(ApplicationDbContext db, TransactionLog entity) => State.DbUser != null;
    public bool CanList(ApplicationDbContext db) => true;

    public TransactionLog? FindByMatch(ApplicationDbContext db, BSD.Shared.Dtos.TransactionLog dto) => null;
    public TransactionLog? FindById(ApplicationDbContext db, long id) => db.TransactionLogs.FirstOrDefault(a => a.Id == id);
    public IQueryable<TransactionLog> ListAll(ApplicationDbContext db) => db.TransactionLogs;

    public bool AttachToState(ApplicationDbContext db, TransactionLog entity) => true;
    public bool UpdateToState(ApplicationDbContext db, TransactionLog entity, BSD.Shared.Dtos.TransactionLog dto) => true;
    public bool DeleteFromState(ApplicationDbContext db, TransactionLog entity) => true;
}
