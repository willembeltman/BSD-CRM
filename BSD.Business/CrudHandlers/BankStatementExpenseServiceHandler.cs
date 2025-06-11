using BSD.Business.Models;
using BSD.Data;
using BSD.Data.Entities;

namespace BSD.Business.CrudHandlers;

public class BankStatementExpenseServiceHandler 
{
    private readonly AuthenticationState State;

    public BankStatementExpenseServiceHandler(AuthenticationState authenticationState)
    {
        State = authenticationState;
    }

    public bool CanCreate(ApplicationDbContext db, BankStatementExpense entity) => State.DbUser != null;
    public bool CanRead(ApplicationDbContext db, BankStatementExpense entity) => true;
    public bool CanUpdate(ApplicationDbContext db, BankStatementExpense entity) => State.DbUser != null;
    public bool CanDelete(ApplicationDbContext db, BankStatementExpense entity) => State.DbUser != null;
    public bool CanList(ApplicationDbContext db) => true;

    public BankStatementExpense? FindByMatch(ApplicationDbContext db, BSD.Shared.Dtos.BankStatementExpense dto) => null;
    public BankStatementExpense? FindById(ApplicationDbContext db, long id) => db.BankStatementExpenses.FirstOrDefault(a => a.Id == id);
    public IQueryable<BankStatementExpense> ListAll(ApplicationDbContext db) => db.BankStatementExpenses;

    public bool AttachToState(ApplicationDbContext db, BankStatementExpense entity) => true;
    public bool UpdateToState(ApplicationDbContext db, BankStatementExpense entity, BSD.Shared.Dtos.BankStatementExpense dto) => true;
    public bool DeleteFromState(ApplicationDbContext db, BankStatementExpense entity) => true;
}
