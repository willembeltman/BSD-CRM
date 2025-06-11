using BSD.Business.Models;
using BSD.Data;
using BSD.Data.Entities;

namespace BSD.Business.CrudHandlers;

public class ExperienceAttachmentServiceHandler
{
    private readonly AuthenticationState State;

    public ExperienceAttachmentServiceHandler(AuthenticationState authenticationState)
    {
        State = authenticationState;
    }

    public bool CanCreate(ApplicationDbContext db, ExperienceAttachment entity) => State.DbUser != null;
    public bool CanRead(ApplicationDbContext db, ExperienceAttachment entity) => true;
    public bool CanUpdate(ApplicationDbContext db, ExperienceAttachment entity) => State.DbUser != null;
    public bool CanDelete(ApplicationDbContext db, ExperienceAttachment entity) => State.DbUser != null;
    public bool CanList(ApplicationDbContext db) => true;

    public ExperienceAttachment? FindByMatch(ApplicationDbContext db, BSD.Shared.Dtos.ExperienceAttachment dto) => null;
    public ExperienceAttachment? FindById(ApplicationDbContext db, long id) => db.ExperienceAttachments.FirstOrDefault(a => a.Id == id);
    public IQueryable<ExperienceAttachment> ListAll(ApplicationDbContext db) => db.ExperienceAttachments;

    public bool AttachToState(ApplicationDbContext db, ExperienceAttachment entity) => true;
    public bool UpdateToState(ApplicationDbContext db, ExperienceAttachment entity, BSD.Shared.Dtos.ExperienceAttachment dto) => true;
    public bool DeleteFromState(ApplicationDbContext db, ExperienceAttachment entity) => true;
}
