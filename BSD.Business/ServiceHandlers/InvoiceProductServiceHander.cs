using BSD.Business.Models;
using BSD.Data;
using BSD.Data.Entities;

namespace BSD.Business.ServiceHandlers;

public class InvoiceProductServiceHander
{
    private readonly AuthenticationState State;

    public InvoiceProductServiceHander(AuthenticationState authenticationState)
    {
        State = authenticationState;
    }

    public bool CanCreate(ApplicationDbContext db, InvoiceProduct entity) => State.DbUser != null;
    public bool CanRead(ApplicationDbContext db, InvoiceProduct entity) => true;
    public bool CanUpdate(ApplicationDbContext db, InvoiceProduct entity) => State.DbUser != null;
    public bool CanDelete(ApplicationDbContext db, InvoiceProduct entity) => State.DbUser != null;
    public bool CanList(ApplicationDbContext db) => true;

    public InvoiceProduct? FindByMatch(ApplicationDbContext db, BSD.Shared.Dtos.InvoiceProduct dto) => db.InvoiceProducts.FirstOrDefault(a => a.Id == dto.Id);
    public InvoiceProduct? FindById(ApplicationDbContext db, long id) => db.InvoiceProducts.FirstOrDefault(a => a.Id == id);
    public IQueryable<InvoiceProduct> ListAll(ApplicationDbContext db) => db.InvoiceProducts;

    public bool AttachToState(ApplicationDbContext db, InvoiceProduct entity) => true;
    public bool UpdateToState(ApplicationDbContext db, InvoiceProduct entity, BSD.Shared.Dtos.InvoiceProduct dto) => true;
    public bool DeleteFromState(ApplicationDbContext db, InvoiceProduct entity) => true;
}
