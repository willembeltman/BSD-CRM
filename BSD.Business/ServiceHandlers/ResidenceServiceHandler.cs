using BSD.Business.Models;
using BSD.Data;
using BSD.Data.Entities;

namespace BSD.Business.ServiceHandlers;

public class ResidenceServiceHandler
{
    private readonly AuthenticationState State;

    public ResidenceServiceHandler(AuthenticationState authenticationState)
    {
        State = authenticationState;
    }

    public bool CanCreate(ApplicationDbContext db, Residence entity) => State.DbUser != null;
    public bool CanRead(ApplicationDbContext db, Residence entity) => true;
    public bool CanUpdate(ApplicationDbContext db, Residence entity) => State.DbUser != null;
    public bool CanDelete(ApplicationDbContext db, Residence entity) => State.DbUser != null;
    public bool CanList(ApplicationDbContext db) => true;

    public Residence? FindByMatch(ApplicationDbContext db, BSD.Shared.Dtos.Residence dto) => null;
    public Residence? FindById(ApplicationDbContext db, long id) => db.Residences.FirstOrDefault(a => a.Id == id);
    public IQueryable<Residence> ListAll(ApplicationDbContext db) => db.Residences;

    public bool AttachToState(ApplicationDbContext db, Residence entity) => true;
    public bool UpdateToState(ApplicationDbContext db, Residence entity, BSD.Shared.Dtos.Residence dto) => true;
    public bool DeleteFromState(ApplicationDbContext db, Residence entity) => true;
}
