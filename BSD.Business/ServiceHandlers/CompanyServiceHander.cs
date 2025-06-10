using BSD.Business.Models;
using BSD.Data;
using BSD.Data.Entities;

namespace BSD.Business.ServiceHandlers;

public class CompanyServiceHander
{
    private readonly AuthenticationState State;

    public CompanyServiceHander(AuthenticationState authenticationState)
    {
        State = authenticationState;
    }

    public bool CanCreate(ApplicationDbContext db, Company entity) => State.DbUser != null;
    public bool CanRead(ApplicationDbContext db, Company entity) => true;
    public bool CanUpdate(ApplicationDbContext db, Company entity) => State.DbUser != null;
    public bool CanDelete(ApplicationDbContext db, Company entity) => State.DbUser != null;
    public bool CanList(ApplicationDbContext db) => true;

    public Company? FindByMatch(ApplicationDbContext db, BSD.Shared.Dtos.Company dto) => db.Companies.FirstOrDefault(a => a.Id == dto.Id);
    public Company? FindById(ApplicationDbContext db, long id) => db.Companies.FirstOrDefault(a => a.Id == id);
    public IQueryable<Company> ListAll(ApplicationDbContext db) => db.Companies;

    public bool AttachToState(ApplicationDbContext db, Company entity) => true;
    public bool UpdateToState(ApplicationDbContext db, Company entity, BSD.Shared.Dtos.Company dto) => true;
    public bool DeleteFromState(ApplicationDbContext db, Company entity) => true;
}
