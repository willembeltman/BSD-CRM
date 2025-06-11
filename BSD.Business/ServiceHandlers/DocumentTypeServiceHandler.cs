using BSD.Business.Models;
using BSD.Data;
using BSD.Data.Entities;

namespace BSD.Business.ServiceHandlers;

public class DocumentTypeServiceHandler
{
    private readonly AuthenticationState State;

    public DocumentTypeServiceHandler(AuthenticationState authenticationState)
    {
        State = authenticationState;
    }

    public bool CanCreate(ApplicationDbContext db, DocumentType entity) => State.DbUser != null;
    public bool CanRead(ApplicationDbContext db, DocumentType entity) => true;
    public bool CanUpdate(ApplicationDbContext db, DocumentType entity) => State.DbUser != null;
    public bool CanDelete(ApplicationDbContext db, DocumentType entity) => State.DbUser != null;
    public bool CanList(ApplicationDbContext db) => true;

    public DocumentType? FindByMatch(ApplicationDbContext db, BSD.Shared.Dtos.DocumentType dto) => null;
    public DocumentType? FindById(ApplicationDbContext db, long id) => db.DocumentTypes.FirstOrDefault(a => a.Id == id);
    public IQueryable<DocumentType> ListAll(ApplicationDbContext db) => db.DocumentTypes;

    public bool AttachToState(ApplicationDbContext db, DocumentType entity) => true;
    public bool UpdateToState(ApplicationDbContext db, DocumentType entity, BSD.Shared.Dtos.DocumentType dto) => true;
    public bool DeleteFromState(ApplicationDbContext db, DocumentType entity) => true;
}
