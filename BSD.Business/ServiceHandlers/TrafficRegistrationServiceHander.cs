using BSD.Business.Models;
using BSD.Data;
using BSD.Data.Entities;

namespace BSD.Business.ServiceHandlers;

public class TrafficRegistrationServiceHander
{
    private readonly AuthenticationState State;

    public TrafficRegistrationServiceHander(AuthenticationState authenticationState)
    {
        State = authenticationState;
    }

    public bool CanCreate(ApplicationDbContext db, TrafficRegistration entity) => State.DbUser != null;
    public bool CanRead(ApplicationDbContext db, TrafficRegistration entity) => true;
    public bool CanUpdate(ApplicationDbContext db, TrafficRegistration entity) => State.DbUser != null;
    public bool CanDelete(ApplicationDbContext db, TrafficRegistration entity) => State.DbUser != null;
    public bool CanList(ApplicationDbContext db) => true;

    public TrafficRegistration? FindByMatch(ApplicationDbContext db, BSD.Shared.Dtos.TrafficRegistration dto) => db.TrafficRegistrations.FirstOrDefault(a => a.Id == dto.Id);
    public TrafficRegistration? FindById(ApplicationDbContext db, long id) => db.TrafficRegistrations.FirstOrDefault(a => a.Id == id);
    public IQueryable<TrafficRegistration> ListAll(ApplicationDbContext db) => db.TrafficRegistrations;

    public bool AttachToState(ApplicationDbContext db, TrafficRegistration entity) => true;
    public bool UpdateToState(ApplicationDbContext db, TrafficRegistration entity, BSD.Shared.Dtos.TrafficRegistration dto) => true;
    public bool DeleteFromState(ApplicationDbContext db, TrafficRegistration entity) => true;
}
