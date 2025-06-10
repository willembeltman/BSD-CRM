using BSD.Business.Models;
using BSD.Data;
using BSD.Data.Entities;

namespace BSD.Business.ServiceHandlers;

public class TaxRateServiceHander
{
    private readonly AuthenticationState State;

    public TaxRateServiceHander(AuthenticationState authenticationState)
    {
        State = authenticationState;
    }

    public bool CanCreate(ApplicationDbContext db, TaxRate entity) => State.DbUser != null;
    public bool CanRead(ApplicationDbContext db, TaxRate entity) => true;
    public bool CanUpdate(ApplicationDbContext db, TaxRate entity) => State.DbUser != null;
    public bool CanDelete(ApplicationDbContext db, TaxRate entity) => State.DbUser != null;
    public bool CanList(ApplicationDbContext db) => true;

    public TaxRate? FindByMatch(ApplicationDbContext db, BSD.Shared.Dtos.TaxRate dto) => db.TaxRates.FirstOrDefault(a => a.Id == dto.Id);
    public TaxRate? FindById(ApplicationDbContext db, long id) => db.TaxRates.FirstOrDefault(a => a.Id == id);
    public IQueryable<TaxRate> ListAll(ApplicationDbContext db) => db.TaxRates;

    public bool AttachToState(ApplicationDbContext db, TaxRate entity) => true;
    public bool UpdateToState(ApplicationDbContext db, TaxRate entity, BSD.Shared.Dtos.TaxRate dto) => true;
    public bool DeleteFromState(ApplicationDbContext db, TaxRate entity) => true;
}
