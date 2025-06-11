using BSD.Business.Models;
using BSD.Data;
using BSD.Data.Entities;

namespace BSD.Business.CrudHandlers;

public class ExpenseTypeServiceHandler
{
    private readonly AuthenticationState State;

    public ExpenseTypeServiceHandler(AuthenticationState authenticationState)
    {
        State = authenticationState;
    }

    public bool CanCreate(ApplicationDbContext db, ExpenseType entity) => State.DbUser != null;
    public bool CanRead(ApplicationDbContext db, ExpenseType entity) => true;
    public bool CanUpdate(ApplicationDbContext db, ExpenseType entity) => State.DbUser != null;
    public bool CanDelete(ApplicationDbContext db, ExpenseType entity) => State.DbUser != null;
    public bool CanList(ApplicationDbContext db) => true;

    public ExpenseType? FindByMatch(ApplicationDbContext db, BSD.Shared.Dtos.ExpenseType dto) => null;
    public ExpenseType? FindById(ApplicationDbContext db, long id) => db.ExpenseTypes.FirstOrDefault(a => a.Id == id);
    public IQueryable<ExpenseType> ListAll(ApplicationDbContext db) => db.ExpenseTypes;

    public bool AttachToState(ApplicationDbContext db, ExpenseType entity) => true;
    public bool UpdateToState(ApplicationDbContext db, ExpenseType entity, BSD.Shared.Dtos.ExpenseType dto) => true;
    public bool DeleteFromState(ApplicationDbContext db, ExpenseType entity) => true;
}
