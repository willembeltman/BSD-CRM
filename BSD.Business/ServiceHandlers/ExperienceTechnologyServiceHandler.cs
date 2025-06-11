using BSD.Business.Models;
using BSD.Data;
using BSD.Data.Entities;

namespace BSD.Business.ServiceHandlers;

public class ExperienceTechnologyServiceHandler
{
    private readonly AuthenticationState State;

    public ExperienceTechnologyServiceHandler(AuthenticationState authenticationState)
    {
        State = authenticationState;
    }

    public bool CanCreate(ApplicationDbContext db, ExperienceTechnology entity) => State.DbUser != null;
    public bool CanRead(ApplicationDbContext db, ExperienceTechnology entity) => true;
    public bool CanUpdate(ApplicationDbContext db, ExperienceTechnology entity) => State.DbUser != null;
    public bool CanDelete(ApplicationDbContext db, ExperienceTechnology entity) => State.DbUser != null;
    public bool CanList(ApplicationDbContext db) => true;

    public ExperienceTechnology? FindByMatch(ApplicationDbContext db, BSD.Shared.Dtos.ExperienceTechnology dto) => null;
    public ExperienceTechnology? FindById(ApplicationDbContext db, long id) => db.ExperienceTechnologies.FirstOrDefault(a => a.Id == id);
    public IQueryable<ExperienceTechnology> ListAll(ApplicationDbContext db) => db.ExperienceTechnologies;

    public bool AttachToState(ApplicationDbContext db, ExperienceTechnology entity) => true;
    public bool UpdateToState(ApplicationDbContext db, ExperienceTechnology entity, BSD.Shared.Dtos.ExperienceTechnology dto) => true;
    public bool DeleteFromState(ApplicationDbContext db, ExperienceTechnology entity) => true;
}
