using BSD.Business.Models;
using BSD.Data;
using BSD.Data.Entities;

namespace BSD.Business.CrudHandlers;

public class TechnologyAttachmentServiceHandler
{
    private readonly AuthenticationState State;

    public TechnologyAttachmentServiceHandler(AuthenticationState authenticationState)
    {
        State = authenticationState;
    }

    public bool CanCreate(ApplicationDbContext db, TechnologyAttachment entity) => State.DbUser != null;
    public bool CanRead(ApplicationDbContext db, TechnologyAttachment entity) => true;
    public bool CanUpdate(ApplicationDbContext db, TechnologyAttachment entity) => State.DbUser != null;
    public bool CanDelete(ApplicationDbContext db, TechnologyAttachment entity) => State.DbUser != null;
    public bool CanList(ApplicationDbContext db) => true;

    public TechnologyAttachment? FindByMatch(ApplicationDbContext db, BSD.Shared.Dtos.TechnologyAttachment dto) => null;
    public TechnologyAttachment? FindById(ApplicationDbContext db, long id) => db.TechnologyAttachments.FirstOrDefault(a => a.Id == id);
    public IQueryable<TechnologyAttachment> ListAll(ApplicationDbContext db) => db.TechnologyAttachments;

    public bool AttachToState(ApplicationDbContext db, TechnologyAttachment entity) => true;
    public bool UpdateToState(ApplicationDbContext db, TechnologyAttachment entity, BSD.Shared.Dtos.TechnologyAttachment dto) => true;
    public bool DeleteFromState(ApplicationDbContext db, TechnologyAttachment entity) => true;
}
