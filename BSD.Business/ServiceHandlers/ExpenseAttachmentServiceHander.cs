using BSD.Business.Models;
using BSD.Data;
using BSD.Data.Entities;

namespace BSD.Business.ServiceHandlers;

public class ExpenseAttachmentServiceHander
{
    private readonly AuthenticationState State;

    public ExpenseAttachmentServiceHander(AuthenticationState authenticationState)
    {
        State = authenticationState;
    }

    public bool CanCreate(ApplicationDbContext db, ExpenseAttachment entity) => State.DbUser != null;
    public bool CanRead(ApplicationDbContext db, ExpenseAttachment entity) => true;
    public bool CanUpdate(ApplicationDbContext db, ExpenseAttachment entity) => State.DbUser != null;
    public bool CanDelete(ApplicationDbContext db, ExpenseAttachment entity) => State.DbUser != null;
    public bool CanList(ApplicationDbContext db) => true;

    public ExpenseAttachment? FindByMatch(ApplicationDbContext db, BSD.Shared.Dtos.ExpenseAttachment dto) => db.ExpenseAttachments.FirstOrDefault(a => a.Id == dto.Id);
    public ExpenseAttachment? FindById(ApplicationDbContext db, long id) => db.ExpenseAttachments.FirstOrDefault(a => a.Id == id);
    public IQueryable<ExpenseAttachment> ListAll(ApplicationDbContext db) => db.ExpenseAttachments;

    public bool AttachToState(ApplicationDbContext db, ExpenseAttachment entity) => true;
    public bool UpdateToState(ApplicationDbContext db, ExpenseAttachment entity, BSD.Shared.Dtos.ExpenseAttachment dto) => true;
    public bool DeleteFromState(ApplicationDbContext db, ExpenseAttachment entity) => true;
}
