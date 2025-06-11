using BSD.Business.Models;
using BSD.Data;
using BSD.Data.Entities;

namespace BSD.Business.CrudHandlers;

public class DocumentServiceHandler
{
    private readonly AuthenticationState State;

    public DocumentServiceHandler(AuthenticationState authenticationState)
    {
        State = authenticationState;
    }

    public bool CanCreate(ApplicationDbContext db, Document entity) => State.DbUser != null;
    public bool CanRead(ApplicationDbContext db, Document entity) => true;
    public bool CanUpdate(ApplicationDbContext db, Document entity) => State.DbUser != null;
    public bool CanDelete(ApplicationDbContext db, Document entity) => State.DbUser != null;
    public bool CanList(ApplicationDbContext db) => true;

    public Document? FindByMatch(ApplicationDbContext db, BSD.Shared.Dtos.Document dto) => null;
    public Document? FindById(ApplicationDbContext db, long id) => db.Documents.FirstOrDefault(a => a.Id == id);
    public IQueryable<Document> ListAll(ApplicationDbContext db) => db.Documents;

    public bool AttachToState(ApplicationDbContext db, Document entity) => true;
    public bool UpdateToState(ApplicationDbContext db, Document entity, BSD.Shared.Dtos.Document dto) => true;
    public bool DeleteFromState(ApplicationDbContext db, Document entity) => true;
}
