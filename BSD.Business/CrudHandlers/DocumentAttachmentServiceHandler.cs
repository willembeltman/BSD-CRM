using BSD.Business.Models;
using BSD.Data;
using BSD.Data.Entities;

namespace BSD.Business.CrudHandlers;

public class DocumentAttachmentServiceHandler
{
    private readonly AuthenticationState State;

    public DocumentAttachmentServiceHandler(AuthenticationState authenticationState)
    {
        State = authenticationState;
    }

    public bool CanCreate(ApplicationDbContext db, DocumentAttachment entity) => State.DbUser != null;
    public bool CanRead(ApplicationDbContext db, DocumentAttachment entity) => true;
    public bool CanUpdate(ApplicationDbContext db, DocumentAttachment entity) => State.DbUser != null;
    public bool CanDelete(ApplicationDbContext db, DocumentAttachment entity) => State.DbUser != null;
    public bool CanList(ApplicationDbContext db) => true;

    public DocumentAttachment? FindByMatch(ApplicationDbContext db, BSD.Shared.Dtos.DocumentAttachment dto) => null;
    public DocumentAttachment? FindById(ApplicationDbContext db, long id) => db.DocumentAttachments.FirstOrDefault(a => a.Id == id);
    public IQueryable<DocumentAttachment> ListAll(ApplicationDbContext db) => db.DocumentAttachments;

    public bool AttachToState(ApplicationDbContext db, DocumentAttachment entity) => true;
    public bool UpdateToState(ApplicationDbContext db, DocumentAttachment entity, BSD.Shared.Dtos.DocumentAttachment dto) => true;
    public bool DeleteFromState(ApplicationDbContext db, DocumentAttachment entity) => true;
}
