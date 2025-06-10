using BSD.Business.Models;
using BSD.Data;
using BSD.Data.Entities;

namespace BSD.Business.ServiceHandlers;

public class CompanyUserServiceHander
{
    private readonly AuthenticationState State;

    public CompanyUserServiceHander(AuthenticationState authenticationState)
    {
        State = authenticationState;
    }

    public bool CanCreate(ApplicationDbContext db, CompanyUser entity) => State.DbUser != null;
    public bool CanRead(ApplicationDbContext db, CompanyUser entity) => true;
    public bool CanUpdate(ApplicationDbContext db, CompanyUser entity) => State.DbUser != null;
    public bool CanDelete(ApplicationDbContext db, CompanyUser entity) => State.DbUser != null;
    public bool CanList(ApplicationDbContext db) => true;

    public CompanyUser? FindByMatch(ApplicationDbContext db, BSD.Shared.Dtos.CompanyUser dto) => db.CompanyUsers.FirstOrDefault(a => a.Id == dto.Id);
    public CompanyUser? FindById(ApplicationDbContext db, long id) => db.CompanyUsers.FirstOrDefault(a => a.Id == id);
    public IQueryable<CompanyUser> ListAll(ApplicationDbContext db) => db.CompanyUsers;

    public bool AttachToState(ApplicationDbContext db, CompanyUser entity) => true;
    public bool UpdateToState(ApplicationDbContext db, CompanyUser entity, BSD.Shared.Dtos.CompanyUser dto) => true;
    public bool DeleteFromState(ApplicationDbContext db, CompanyUser entity) => true;
}
