using BSD.Business.Models;
using BSD.Data;
using BSD.Data.Entities;

namespace BSD.Business.CrudHandlers;

public class ExpenseProductServiceHandler
{
    private readonly AuthenticationState State;

    public ExpenseProductServiceHandler(AuthenticationState authenticationState)
    {
        State = authenticationState;
    }

    public bool CanCreate(ApplicationDbContext db, ExpenseProduct entity) => State.DbUser != null;
    public bool CanRead(ApplicationDbContext db, ExpenseProduct entity) => true;
    public bool CanUpdate(ApplicationDbContext db, ExpenseProduct entity) => State.DbUser != null;
    public bool CanDelete(ApplicationDbContext db, ExpenseProduct entity) => State.DbUser != null;
    public bool CanList(ApplicationDbContext db) => true;

    public ExpenseProduct? FindByMatch(ApplicationDbContext db, BSD.Shared.Dtos.ExpenseProduct dto) => null;
    public ExpenseProduct? FindById(ApplicationDbContext db, long id) => db.ExpenseProducts.FirstOrDefault(a => a.Id == id);
    public IQueryable<ExpenseProduct> ListAll(ApplicationDbContext db) => db.ExpenseProducts;

    public bool AttachToState(ApplicationDbContext db, ExpenseProduct entity) => true;
    public bool UpdateToState(ApplicationDbContext db, ExpenseProduct entity, BSD.Shared.Dtos.ExpenseProduct dto) => true;
    public bool DeleteFromState(ApplicationDbContext db, ExpenseProduct entity) => true;
}
