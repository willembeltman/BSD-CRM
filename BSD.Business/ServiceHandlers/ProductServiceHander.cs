using BSD.Business.Models;
using BSD.Data;
using BSD.Data.Entities;

namespace BSD.Business.ServiceHandlers;

public class ProductServiceHander
{
    private readonly AuthenticationState State;

    public ProductServiceHander(AuthenticationState authenticationState)
    {
        State = authenticationState;
    }

    public bool CanCreate(ApplicationDbContext db, Product entity) => State.DbUser != null;
    public bool CanRead(ApplicationDbContext db, Product entity) => true;
    public bool CanUpdate(ApplicationDbContext db, Product entity) => State.DbUser != null;
    public bool CanDelete(ApplicationDbContext db, Product entity) => State.DbUser != null;
    public bool CanList(ApplicationDbContext db) => true;

    public Product? FindByMatch(ApplicationDbContext db, BSD.Shared.Dtos.Product dto) => db.Products.FirstOrDefault(a => a.Id == dto.Id);
    public Product? FindById(ApplicationDbContext db, long id) => db.Products.FirstOrDefault(a => a.Id == id);
    public IQueryable<Product> ListAll(ApplicationDbContext db) => db.Products;

    public bool AttachToState(ApplicationDbContext db, Product entity) => true;
    public bool UpdateToState(ApplicationDbContext db, Product entity, BSD.Shared.Dtos.Product dto) => true;
    public bool DeleteFromState(ApplicationDbContext db, Product entity) => true;
}
