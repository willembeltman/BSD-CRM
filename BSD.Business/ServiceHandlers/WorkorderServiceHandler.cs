using BSD.Business.Models;
using BSD.Data;
using BSD.Data.Entities;

namespace BSD.Business.ServiceHandlers;

public class WorkorderServiceHandler
{
    private readonly AuthenticationState State;

    public WorkorderServiceHandler(AuthenticationState authenticationState)
    {
        State = authenticationState;
    }

    public bool CanCreate(ApplicationDbContext db, Workorder entity) => State.DbUser != null;
    public bool CanRead(ApplicationDbContext db, Workorder entity) => true;
    public bool CanUpdate(ApplicationDbContext db, Workorder entity) => State.DbUser != null;
    public bool CanDelete(ApplicationDbContext db, Workorder entity) => State.DbUser != null;
    public bool CanList(ApplicationDbContext db) => true;

    public Workorder? FindByMatch(ApplicationDbContext db, BSD.Shared.Dtos.Workorder dto) => null;
    public Workorder? FindById(ApplicationDbContext db, long id) => db.Workorders.FirstOrDefault(a => a.Id == id);
    public IQueryable<Workorder> ListAll(ApplicationDbContext db) => db.Workorders;

    public bool AttachToState(ApplicationDbContext db, Workorder entity) => true;
    public bool UpdateToState(ApplicationDbContext db, Workorder entity, BSD.Shared.Dtos.Workorder dto) => true;
    public bool DeleteFromState(ApplicationDbContext db, Workorder entity) => true;
}
