using BSD.Business.Models;
using BSD.Data;
using BSD.Data.Entities;

namespace BSD.Business.ServiceHandlers;

public class ExperienceServiceHander
{
    private readonly AuthenticationState State;

    public ExperienceServiceHander(AuthenticationState authenticationState)
    {
        State = authenticationState;
    }

    public bool CanCreate(ApplicationDbContext db, Experience entity) => State.DbUser != null;
    public bool CanRead(ApplicationDbContext db, Experience entity) => true;
    public bool CanUpdate(ApplicationDbContext db, Experience entity) => State.DbUser != null;
    public bool CanDelete(ApplicationDbContext db, Experience entity) => State.DbUser != null;
    public bool CanList(ApplicationDbContext db) => true;

    public Experience? FindByMatch(ApplicationDbContext db, BSD.Shared.Dtos.Experience dto) => db.Experiences.FirstOrDefault(a => a.Id == dto.Id);
    public Experience? FindById(ApplicationDbContext db, long id) => db.Experiences.FirstOrDefault(a => a.Id == id);
    public IQueryable<Experience> ListAll(ApplicationDbContext db) => db.Experiences;

    public bool AttachToState(ApplicationDbContext db, Experience entity) => true;
    public bool UpdateToState(ApplicationDbContext db, Experience entity, BSD.Shared.Dtos.Experience dto) => true;
    public bool DeleteFromState(ApplicationDbContext db, Experience entity) => true;
}
