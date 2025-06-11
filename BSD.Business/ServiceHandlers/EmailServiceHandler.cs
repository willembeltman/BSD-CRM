using BSD.Business.Models;
using BSD.Data;
using BSD.Data.Entities;

namespace BSD.Business.ServiceHandlers;

public class EmailServiceHandler
{
    private readonly AuthenticationState State;

    public EmailServiceHandler(AuthenticationState authenticationState)
    {
        State = authenticationState;
    }

    public bool CanCreate(ApplicationDbContext db, Email entity) => State.DbUser != null;
    public bool CanRead(ApplicationDbContext db, Email entity) => true;
    public bool CanUpdate(ApplicationDbContext db, Email entity) => State.DbUser != null;
    public bool CanDelete(ApplicationDbContext db, Email entity) => State.DbUser != null;
    public bool CanList(ApplicationDbContext db) => true;

    public Email? FindByMatch(ApplicationDbContext db, BSD.Shared.Dtos.Email dto) => null;
    public Email? FindById(ApplicationDbContext db, long id) => db.Emails.FirstOrDefault(a => a.Id == id);
    public IQueryable<Email> ListAll(ApplicationDbContext db) => db.Emails;

    public bool AttachToState(ApplicationDbContext db, Email entity) => true;
    public bool UpdateToState(ApplicationDbContext db, Email entity, BSD.Shared.Dtos.Email dto) => true;
    public bool DeleteFromState(ApplicationDbContext db, Email entity) => true;
}
