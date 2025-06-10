using BSD.Business.Models;
using BSD.Data;
using BSD.Data.Entities;

namespace BSD.Business.ServiceHandlers;

public class ExpensePriceServiceHander
{
    private readonly AuthenticationState State;

    public ExpensePriceServiceHander(AuthenticationState authenticationState)
    {
        State = authenticationState;
    }

    public bool CanCreate(ApplicationDbContext db, ExpensePrice entity) => State.DbUser != null;
    public bool CanRead(ApplicationDbContext db, ExpensePrice entity) => true;
    public bool CanUpdate(ApplicationDbContext db, ExpensePrice entity) => State.DbUser != null;
    public bool CanDelete(ApplicationDbContext db, ExpensePrice entity) => State.DbUser != null;
    public bool CanList(ApplicationDbContext db) => true;

    public ExpensePrice? FindByMatch(ApplicationDbContext db, BSD.Shared.Dtos.ExpensePrice dto) => db.ExpensePrices.FirstOrDefault(a => a.Id == dto.Id);
    public ExpensePrice? FindById(ApplicationDbContext db, long id) => db.ExpensePrices.FirstOrDefault(a => a.Id == id);
    public IQueryable<ExpensePrice> ListAll(ApplicationDbContext db) => db.ExpensePrices;

    public bool AttachToState(ApplicationDbContext db, ExpensePrice entity) => true;
    public bool UpdateToState(ApplicationDbContext db, ExpensePrice entity, BSD.Shared.Dtos.ExpensePrice dto) => true;
    public bool DeleteFromState(ApplicationDbContext db, ExpensePrice entity) => true;
}
