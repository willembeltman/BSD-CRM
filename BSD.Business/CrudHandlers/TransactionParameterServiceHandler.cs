using BSD.Business.Models;
using BSD.Data;
using BSD.Data.Entities;

namespace BSD.Business.ServiceHandlers;

public class TransactionParameterServiceHandler
{
    private readonly AuthenticationState State;

    public TransactionParameterServiceHandler(AuthenticationState authenticationState)
    {
        State = authenticationState;
    }

    public bool CanCreate(ApplicationDbContext db, TransactionParameter entity) => State.DbUser != null;
    public bool CanRead(ApplicationDbContext db, TransactionParameter entity) => true;
    public bool CanUpdate(ApplicationDbContext db, TransactionParameter entity) => State.DbUser != null;
    public bool CanDelete(ApplicationDbContext db, TransactionParameter entity) => State.DbUser != null;
    public bool CanList(ApplicationDbContext db) => true;

    public TransactionParameter? FindByMatch(ApplicationDbContext db, BSD.Shared.Dtos.TransactionParameter dto) => null;
    public TransactionParameter? FindById(ApplicationDbContext db, long id) => db.TransactionParameters.FirstOrDefault(a => a.Id == id);
    public IQueryable<TransactionParameter> ListAll(ApplicationDbContext db) => db.TransactionParameters;

    public bool AttachToState(ApplicationDbContext db, TransactionParameter entity) => true;
    public bool UpdateToState(ApplicationDbContext db, TransactionParameter entity, BSD.Shared.Dtos.TransactionParameter dto) => true;
    public bool DeleteFromState(ApplicationDbContext db, TransactionParameter entity) => true;
}
