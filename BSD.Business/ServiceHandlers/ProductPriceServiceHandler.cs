using BSD.Business.Models;
using BSD.Data;
using BSD.Data.Entities;

namespace BSD.Business.ServiceHandlers;

public class ProductPriceServiceHandler
{
    private readonly AuthenticationState State;

    public ProductPriceServiceHandler(AuthenticationState authenticationState)
    {
        State = authenticationState;
    }

    public bool CanCreate(ApplicationDbContext db, ProductPrice entity) => State.DbUser != null;
    public bool CanRead(ApplicationDbContext db, ProductPrice entity) => true;
    public bool CanUpdate(ApplicationDbContext db, ProductPrice entity) => State.DbUser != null;
    public bool CanDelete(ApplicationDbContext db, ProductPrice entity) => State.DbUser != null;
    public bool CanList(ApplicationDbContext db) => true;

    public ProductPrice? FindByMatch(ApplicationDbContext db, BSD.Shared.Dtos.ProductPrice dto) => null;
    public ProductPrice? FindById(ApplicationDbContext db, long id) => db.ProductPrices.FirstOrDefault(a => a.Id == id);
    public IQueryable<ProductPrice> ListAll(ApplicationDbContext db) => db.ProductPrices;

    public bool AttachToState(ApplicationDbContext db, ProductPrice entity) => true;
    public bool UpdateToState(ApplicationDbContext db, ProductPrice entity, BSD.Shared.Dtos.ProductPrice dto) => true;
    public bool DeleteFromState(ApplicationDbContext db, ProductPrice entity) => true;
}
