using BSD.Business.Models;
using BSD.Data;
using BSD.Data.Entities;

namespace BSD.Business.ServiceHandlers;

public class TransactionLogParameterServiceHander
{
    private readonly AuthenticationState State;

    public TransactionLogParameterServiceHander(AuthenticationState authenticationState)
    {
        State = authenticationState;
    }

    public bool CanCreate(ApplicationDbContext db, TransactionLogParameter entity) => State.DbUser != null;
    public bool CanRead(ApplicationDbContext db, TransactionLogParameter entity) => true;
    public bool CanUpdate(ApplicationDbContext db, TransactionLogParameter entity) => State.DbUser != null;
    public bool CanDelete(ApplicationDbContext db, TransactionLogParameter entity) => State.DbUser != null;
    public bool CanList(ApplicationDbContext db) => true;

    public TransactionLogParameter? FindByMatch(ApplicationDbContext db, BSD.Shared.Dtos.TransactionLogParameter dto) => db.TransactionLogParameters.FirstOrDefault(a => a.Id == dto.Id);
    public TransactionLogParameter? FindById(ApplicationDbContext db, long id) => db.TransactionLogParameters.FirstOrDefault(a => a.Id == id);
    public IQueryable<TransactionLogParameter> ListAll(ApplicationDbContext db) => db.TransactionLogParameters;

    public bool AttachToState(ApplicationDbContext db, TransactionLogParameter entity) => true;
    public bool UpdateToState(ApplicationDbContext db, TransactionLogParameter entity, BSD.Shared.Dtos.TransactionLogParameter dto) => true;
    public bool DeleteFromState(ApplicationDbContext db, TransactionLogParameter entity) => true;
}
