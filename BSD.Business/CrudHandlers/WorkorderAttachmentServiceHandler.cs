using BSD.Business.Models;
using BSD.Data;
using BSD.Data.Entities;

namespace BSD.Business.CrudHandlers;

public class WorkorderAttachmentServiceHandler
{
    private readonly AuthenticationState State;

    public WorkorderAttachmentServiceHandler(AuthenticationState authenticationState)
    {
        State = authenticationState;
    }

    public bool CanCreate(ApplicationDbContext db, WorkorderAttachment entity) => State.DbUser != null;
    public bool CanRead(ApplicationDbContext db, WorkorderAttachment entity) => true;
    public bool CanUpdate(ApplicationDbContext db, WorkorderAttachment entity) => State.DbUser != null;
    public bool CanDelete(ApplicationDbContext db, WorkorderAttachment entity) => State.DbUser != null;
    public bool CanList(ApplicationDbContext db) => true;

    public WorkorderAttachment? FindByMatch(ApplicationDbContext db, BSD.Shared.Dtos.WorkorderAttachment dto) => null;
    public WorkorderAttachment? FindById(ApplicationDbContext db, long id) => db.WorkorderAttachments.FirstOrDefault(a => a.Id == id);
    public IQueryable<WorkorderAttachment> ListAll(ApplicationDbContext db) => db.WorkorderAttachments;

    public bool AttachToState(ApplicationDbContext db, WorkorderAttachment entity) => true;
    public bool UpdateToState(ApplicationDbContext db, WorkorderAttachment entity, BSD.Shared.Dtos.WorkorderAttachment dto) => true;
    public bool DeleteFromState(ApplicationDbContext db, WorkorderAttachment entity) => true;
}
