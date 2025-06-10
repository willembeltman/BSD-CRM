using BSD.Business.Models;
using BSD.Data;
using BSD.Data.Entities;

namespace BSD.Business.ServiceHandlers;

public class TechnologyServiceHander
{
    private readonly AuthenticationState State;

    public TechnologyServiceHander(AuthenticationState authenticationState)
    {
        State = authenticationState;
    }

    public bool CanCreate(ApplicationDbContext db, Technology entity) => State.DbUser != null;
    public bool CanRead(ApplicationDbContext db, Technology entity) => true;
    public bool CanUpdate(ApplicationDbContext db, Technology entity) => State.DbUser != null;
    public bool CanDelete(ApplicationDbContext db, Technology entity) => State.DbUser != null;
    public bool CanList(ApplicationDbContext db) => true;

    public Technology? FindByMatch(ApplicationDbContext db, BSD.Shared.Dtos.Technology dto) => db.Technologies.FirstOrDefault(a => a.Id == dto.Id);
    public Technology? FindById(ApplicationDbContext db, long id) => db.Technologies.FirstOrDefault(a => a.Id == id);
    public IQueryable<Technology> ListAll(ApplicationDbContext db) => db.Technologies;

    public bool AttachToState(ApplicationDbContext db, Technology entity) => true;
    public bool UpdateToState(ApplicationDbContext db, Technology entity, BSD.Shared.Dtos.Technology dto) => true;
    public bool DeleteFromState(ApplicationDbContext db, Technology entity) => true;
}
