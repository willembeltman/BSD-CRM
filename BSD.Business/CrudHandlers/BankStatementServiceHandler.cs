using BSD.Business.Models;
using BSD.Data;
using BSD.Data.Entities;

namespace BSD.Business.CrudHandlers;

public class BankStatementServiceHandler
{
    private readonly AuthenticationState State;

    public BankStatementServiceHandler(AuthenticationState authenticationState)
    {
        State = authenticationState;
    }

    public bool CanCreate(ApplicationDbContext db, BankStatement entity) => State.DbUser != null;
    public bool CanRead(ApplicationDbContext db, BankStatement entity) => true;
    public bool CanUpdate(ApplicationDbContext db, BankStatement entity) => State.DbUser != null;
    public bool CanDelete(ApplicationDbContext db, BankStatement entity) => State.DbUser != null;
    public bool CanList(ApplicationDbContext db) => true;

    public BankStatement? FindByMatch(ApplicationDbContext db, BSD.Shared.Dtos.BankStatement dto) => null;
    public BankStatement? FindById(ApplicationDbContext db, long id) => db.BankStatements.FirstOrDefault(a => a.Id == id);
    public IQueryable<BankStatement> ListAll(ApplicationDbContext db) => db.BankStatements;

    public bool AttachToState(ApplicationDbContext db, BankStatement entity) => true;
    public bool UpdateToState(ApplicationDbContext db, BankStatement entity, BSD.Shared.Dtos.BankStatement dto) => true;
    public bool DeleteFromState(ApplicationDbContext db, BankStatement entity) => true;
}
