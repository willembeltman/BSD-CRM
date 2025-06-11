using BSD.Business.Models;
using BSD.Data;
using BSD.Data.Entities;

namespace BSD.Business.ServiceHandlers;

public class ExpenseServiceHandler
{
    private readonly AuthenticationState State;

    public ExpenseServiceHandler(AuthenticationState authenticationState)
    {
        State = authenticationState;
    }

    public bool CanCreate(ApplicationDbContext db, Expense entity) => State.DbUser != null;
    public bool CanRead(ApplicationDbContext db, Expense entity) => true;
    public bool CanUpdate(ApplicationDbContext db, Expense entity) => State.DbUser != null;
    public bool CanDelete(ApplicationDbContext db, Expense entity) => State.DbUser != null;
    public bool CanList(ApplicationDbContext db) => true;

    public Expense? FindByMatch(ApplicationDbContext db, BSD.Shared.Dtos.Expense dto) => null;
    public Expense? FindById(ApplicationDbContext db, long id) => db.Expenses.FirstOrDefault(a => a.Id == id);
    public IQueryable<Expense> ListAll(ApplicationDbContext db) => db.Expenses;

    public bool AttachToState(ApplicationDbContext db, Expense entity) => true;
    public bool UpdateToState(ApplicationDbContext db, Expense entity, BSD.Shared.Dtos.Expense dto) => true;
    public bool DeleteFromState(ApplicationDbContext db, Expense entity) => true;
}
