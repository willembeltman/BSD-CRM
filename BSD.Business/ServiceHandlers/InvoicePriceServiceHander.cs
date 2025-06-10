using BSD.Business.Models;
using BSD.Data;
using BSD.Data.Entities;

namespace BSD.Business.ServiceHandlers;

public class InvoicePriceServiceHander
{
    private readonly AuthenticationState State;

    public InvoicePriceServiceHander(AuthenticationState authenticationState)
    {
        State = authenticationState;
    }

    public bool CanCreate(ApplicationDbContext db, InvoicePrice entity) => State.DbUser != null;
    public bool CanRead(ApplicationDbContext db, InvoicePrice entity) => true;
    public bool CanUpdate(ApplicationDbContext db, InvoicePrice entity) => State.DbUser != null;
    public bool CanDelete(ApplicationDbContext db, InvoicePrice entity) => State.DbUser != null;
    public bool CanList(ApplicationDbContext db) => true;

    public InvoicePrice? FindByMatch(ApplicationDbContext db, BSD.Shared.Dtos.InvoicePrice dto) => db.InvoicePrices.FirstOrDefault(a => a.Id == dto.Id);
    public InvoicePrice? FindById(ApplicationDbContext db, long id) => db.InvoicePrices.FirstOrDefault(a => a.Id == id);
    public IQueryable<InvoicePrice> ListAll(ApplicationDbContext db) => db.InvoicePrices;

    public bool AttachToState(ApplicationDbContext db, InvoicePrice entity) => true;
    public bool UpdateToState(ApplicationDbContext db, InvoicePrice entity, BSD.Shared.Dtos.InvoicePrice dto) => true;
    public bool DeleteFromState(ApplicationDbContext db, InvoicePrice entity) => true;
}
