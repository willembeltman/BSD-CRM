using BSD.Business.Models;
using BSD.Data;
using BSD.Data.Entities;

namespace BSD.Business.ServiceHandlers;

public class RateServiceHandler
{
    private readonly AuthenticationState State;

    public RateServiceHandler(AuthenticationState authenticationState)
    {
        State = authenticationState;
    }

    public bool CanCreate(ApplicationDbContext db, Rate entity) => State.DbUser != null;
    public bool CanRead(ApplicationDbContext db, Rate entity) => true;
    public bool CanUpdate(ApplicationDbContext db, Rate entity) => State.DbUser != null;
    public bool CanDelete(ApplicationDbContext db, Rate entity) => State.DbUser != null;
    public bool CanList(ApplicationDbContext db) => true;

    public Rate? FindByMatch(ApplicationDbContext db, BSD.Shared.Dtos.Rate dto) => null;
    public Rate? FindById(ApplicationDbContext db, long id) => db.Rates.FirstOrDefault(a => a.Id == id);
    public IQueryable<Rate> ListAll(ApplicationDbContext db) => db.Rates;

    public bool AttachToState(ApplicationDbContext db, Rate entity) => true;
    public bool UpdateToState(ApplicationDbContext db, Rate entity, BSD.Shared.Dtos.Rate dto) => true;
    public bool DeleteFromState(ApplicationDbContext db, Rate entity) => true;
}
