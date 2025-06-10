using BSD.Business.Models;
using BSD.Data;
using BSD.Data.Entities;

namespace BSD.Business.ServiceHandlers;

public class CountryServiceHander
{
    private readonly AuthenticationState State;

    public CountryServiceHander(AuthenticationState authenticationState)
    {
        State = authenticationState;
    }

    public bool CanCreate(ApplicationDbContext db, Country entity) => State.DbUser != null;
    public bool CanRead(ApplicationDbContext db, Country entity) => true;
    public bool CanUpdate(ApplicationDbContext db, Country entity) => State.DbUser != null;
    public bool CanDelete(ApplicationDbContext db, Country entity) => State.DbUser != null;
    public bool CanList(ApplicationDbContext db) => true;

    public Country? FindByMatch(ApplicationDbContext db, BSD.Shared.Dtos.Country dto) => db.Countries.FirstOrDefault(a => a.Id == dto.Id);
    public Country? FindById(ApplicationDbContext db, long id) => db.Countries.FirstOrDefault(a => a.Id == id);
    public IQueryable<Country> ListAll(ApplicationDbContext db) => db.Countries;

    public bool AttachToState(ApplicationDbContext db, Country entity) => true;
    public bool UpdateToState(ApplicationDbContext db, Country entity, BSD.Shared.Dtos.Country dto) => true;
    public bool DeleteFromState(ApplicationDbContext db, Country entity) => true;
}
